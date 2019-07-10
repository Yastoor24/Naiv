using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private AudioSource _SwordAudio;
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJumped = false;
    [SerializeField]
    private float _speed = 5.0f;
    private SpriteRenderer _PlayerSprite;
    //private SpriteRenderer _SwordArcSprite;
    private SpriteRenderer _BulletSprite;
    public static PlayerAnimation _PlayerAnim;
    private bool _grounded = false;
    public GameObject _fireBullet;
    public bool _canMove = true;
    private int _powerPoint = 0;
    private bool _canPower = true;
    private Animator _anim;
    public GameObject _bullet;
    [SerializeField]
    public Transform HitBox1;
    [SerializeField]
    public Transform HitBox2;


    //Awake is used to initialize any variables or game state before the game starts
    void Awake()
    {
       // _SwordAudio = GameObject.Find("Sword_Arc").GetComponent<AudioSource>();

    }

    //use his for init
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
       // _SwordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
        _BulletSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();



    }

    // Update is called once per frame
    void Update()
    {

        if (_canMove)
        {
            //ShootBullet();
            Movement();

            // if the user pressed on O then will be attack by sword
            if (Input.GetKeyDown(KeyCode.H) && isGrounded() == true)
            {
                _PlayerAnim.Attack();
                //_SwordAudio.Play();

            }
        }


    }


   
   public void Movement()
    {

        // player move horizontal (left and right )
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = isGrounded();
       

        // if the user pressed on O then will be attack by bullet
        if (Input.GetKeyDown(KeyCode.J))
        {
            // An existing object that you want to make a copy of, take three thing
            //(original *An existing object that you want to make a copy of*, position *Position for the new object* ,rotation *Orientation of the new object* )
          
            _bullet = Instantiate(_fireBullet, transform.position, Quaternion.identity);

           
            if (move > 0 || _PlayerSprite.flipX == false)
            {
                // when the player in a left side then will be used gun in the left side
               


                _bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
                _bullet.GetComponent<FireBullet>().transform.position = HitBox1.position;
               



                _anim.Play("Shoot");

               

            }
            else if (move < 0 || _PlayerSprite.flipX == true)
            {
               
                 _bullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x ;
            
                _bullet.GetComponent<FireBullet>().transform.position = HitBox2.position ;
                
                _anim.Play("Shoot");
               
              
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

        // if the user pressed on space then will be jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {

            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpedRoutine());
            _PlayerAnim.Jump(true);

        }
        // speed for the player jump
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _PlayerAnim.Move(move);


    }

    bool isGrounded()
    {

        // LayerMask mask = (1 <<8 );
        // collider grounded and jump
         RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down , 3.5f, 1<<8);

       // RaycastHit2D hitInfo = Physics2D.CircleCast(transform.position, 1f, Vector2.down * 0.35f);

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
        if(collision.gameObject.tag == "PowerIcon")
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
                    _jumpForce = 8;
                    StartCoroutine(WaitBuff());
                }
            }
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
