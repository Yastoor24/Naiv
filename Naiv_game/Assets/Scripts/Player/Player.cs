using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private AudioSource _SwordAudio;
    private AudioSource _GunAudio;
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool resetJumped = false;
    [SerializeField]
    private float _speed = 5.0f;
    private SpriteRenderer _PlayerSprite;
    private SpriteRenderer _SwordArcSprite;
    private PlayerAnimation _PlayerAnim;
   
    private bool _grounded = false;



    public GameObject fireBullet;



    // Update is called once per frame



        void Awake()
    {
        _SwordAudio = GameObject.Find("Sword_Arc").GetComponent<AudioSource>();
        _GunAudio = GameObject.Find("Bullet").GetComponent<AudioSource>();

    }


    //use his for init
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _SwordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //ShootBullet();
        Movement();


        if (Input.GetKeyDown(KeyCode.K) && isGrounded() == true)
        {
            _PlayerAnim.Attack();
            _SwordAudio.Play();
        }
    }
    
    void Movement()
    {


        float move = Input.GetAxisRaw("Horizontal");
      

        if (Input.GetKeyDown(KeyCode.O))
        {

         GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);

            if (move > 0 || _PlayerSprite.flipX == false)
            {
                // _PlayerSprite.flipX = false;
                bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
                _GunAudio.Play();

            }
            else if (move < 0 || _PlayerSprite.flipX == true)
            {
                // _PlayerSprite.flipX = true;
                bullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x;
                _GunAudio.Play();
            }


        }
        _grounded = isGrounded();
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }



        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            Debug.Log("Jump!");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);

            StartCoroutine(ResetJumpedRoutine());
            _PlayerAnim.Jump(true);

        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _PlayerAnim.Move(move);


    }



    bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (resetJumped == false)
            {
                Debug.Log("Grounded");
                _PlayerAnim.Jump(false);
                return true;
            }
        }
        Debug.Log("jummmmmmmmmmmmmmmp");
        return false;

    }
    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _PlayerSprite.flipX = false;
            _SwordArcSprite.flipX = false;
            _SwordArcSprite.flipY = false;
            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _SwordArcSprite.transform.localPosition = newPos;
          

        }
        if (faceRight == false)
        {
            _PlayerSprite.flipX = true;
            _SwordArcSprite.flipX = true;
            _SwordArcSprite.flipY = true;
            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _SwordArcSprite.transform.localPosition = newPos;
            
        }

    }
    IEnumerator ResetJumpedRoutine()
    {
        resetJumped = true;
        yield return new WaitForSeconds(0.1f);
        resetJumped = false;

    }



}