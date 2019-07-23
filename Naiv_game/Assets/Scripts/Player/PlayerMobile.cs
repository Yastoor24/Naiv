using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMobile : MonoBehaviour
{
    private AudioSource _GunAudio;
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 3f;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJumped = false;
    [SerializeField]
    private float _speed = 5.0f;
    private SpriteRenderer _PlayerSprite;
    private SpriteRenderer _BulletSprite;
    public static PlayerAnimation _PlayerAnim;
    private bool _grounded = false;
    public GameObject _fireBullet;
    public bool _canMove = true;
    private int _powerPoint = 0;
    private bool _canPower = true;
    private Animator _anim;
    private GameObject _bullet;
    [SerializeField]
    public Transform HitBox1;
    public Joystick joystick;
    public float move;
    public GameObject toStar;
    public bool jumpped = false;

    //use his for init
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _GunAudio = GetComponent<AudioSource>();
        _anim = GetComponentInChildren<Animator>();
        _BulletSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HitBox1.gameObject.SetActive(false);

        if (_canMove)
        {
            Movement();
        }
    }

    public void Movement()
    {
        float verticalMove = joystick.Vertical;
        move = joystick.Horizontal;
        _grounded = isGrounded();

        // if the user pressed on O then will be attack by bullet
        if (CrossPlatformInputManager.GetButtonDown("shoot"))
        {

            // An existing object that you want to make a copy of, take three thing
            //(original *An existing object that you want to make a copy of*, position *Position for the new object* ,rotation *Orientation of the new object* )

            _bullet = Instantiate(_fireBullet, transform.position, Quaternion.identity);
            HitBox1.gameObject.SetActive(true);
            // _GunAudio.Play();

            if (move > 0 || _PlayerSprite.flipX == false)
            {
                // when the player in a left side then will be used gun in the left side

                _bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
                _bullet.GetComponent<FireBullet>().transform.position = HitBox1.position;
                _anim.Play("Shoot");

            }
            else if (move < 0 || _PlayerSprite.flipX == true)
            {
                _bullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x;
                Vector3 pos = HitBox1.position;
                pos.x = -2.7f;
                pos.y = 0f;
                HitBox1.position = pos + HitBox1.position;
                _bullet.GetComponent<FireBullet>().transform.position = HitBox1.position;
                _bullet.transform.rotation = Quaternion.Euler(0f, 0f, -180);
                _anim.Play("Shoot");
            }
        }

        if ((verticalMove <= -0.5f) && isGrounded() == true)
        {
            // An existing object that you want to make a copy of, take three thing
            //(original *An existing object that you want to make a copy of*, position *Position for the new object* ,rotation *Orientation of the new object* )

            _bullet = Instantiate(_fireBullet, transform.position, Quaternion.identity);
            HitBox1.gameObject.SetActive(true);


            if (move > 0 || _PlayerSprite.flipX == false)
            {
                // when the player in a left side then will be used gun in the left side and down

                _bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
                _bullet.GetComponent<FireBullet>().transform.position = HitBox1.position;
                _anim.Play("ShootDown");

            }
            else if (move < 0 || _PlayerSprite.flipX == true)
            {

                _bullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x;
                Vector3 pos = HitBox1.position;
                pos.x = -2.3f;
                pos.y = 0f;
                HitBox1.position = pos + HitBox1.position;
                _bullet.GetComponent<FireBullet>().transform.position = HitBox1.position;
                _bullet.transform.rotation = Quaternion.Euler(0f, 0f, -180);
                _anim.Play("ShootDown");
            }
        }
        // when player just move without any anthor action
        if (move > 0)
        {
            // the player move in right side
            Flip(true);
        }
        else if (move < 0)
        {
            //the player move in left side
            Flip(false);
        }


        if (move == 0 && isGrounded() == true)
        {
            _PlayerAnim.Fall(false);

        }

        else if (move == 0 && isGrounded() == false)
        {
            _PlayerAnim.Fall(true);
        }

        // if the user pressed on space then will be jump
        if ((verticalMove >= 0.5f) && isGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpedRoutine());
            _PlayerAnim.Jump(true);
        }

        if (jumpped)
        {

            _rigid.velocity = new Vector2(_rigid.velocity.x, 11);
            StartCoroutine(ResetJumpedRoutine());
            _PlayerAnim.Jump(true);
            jumpped = false;


        }
        // speed for the player jump
        _rigid.velocity = new Vector2((move) * _speed, _rigid.velocity.y);
        _PlayerAnim.Move(move);
    }

    bool isGrounded()
    {
        // collider grounded and jump
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        if (hitInfo.collider != null)
        {
            // if the palyer jump false then collider for grounded true
            if (_resetJumped == false)
            {
                _PlayerAnim.Jump(false);
                return true;
            }
        }
        // if the palyer jump true then collider for grounded false
        return false;

    }

    void Flip(bool faceRight)
    {
        // when the player flip (faceRight)
        if (faceRight == true)
        {
            _PlayerSprite.flipX = false;
            Vector3 pos = _PlayerSprite.transform.localPosition;
            _PlayerSprite.transform.localPosition = pos;
        }

        // when the player flip (faceleft)
        if (faceRight == false)
        {
            _PlayerSprite.flipX = true;
            Vector3 pos = _PlayerSprite.transform.localPosition;

        }
    }

    IEnumerator ResetJumpedRoutine()
    {
        //activate && Deactivate jump  and wait few seconds between them
        _resetJumped = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumped = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerIcon")
        {
            if (_canPower)
            {
                collision.gameObject.SetActive(false);
                Debug.Log("POwer Icon !!");
                if (_powerPoint < 3)
                {
                    _powerPoint += 1;
                }
                else
                {
                    _canPower = false;
                    _powerPoint = 0;
                    _speed = 8;
                    _jumpForce = 3;
                    StartCoroutine(WaitBuff());
                }
            }
        }
        if (collision.tag == "startPoint")
        {
            toStar.SetActive(true);

        }

        if (collision.gameObject.tag == "Jump")
        {
            jumpped = true;

        }
    }

    IEnumerator WaitBuff()
    {
        yield return new WaitForSeconds(5f);
        _canPower = true;
        _speed = 5f;
        _jumpForce = 5f;
    }
}


