﻿




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private AudioSource _SwordAudio;
    
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private LayerMask _groundLayer;

    private bool _resetJumped = false;

    [SerializeField]
    private float _speed = 5.0f;

    private SpriteRenderer _PlayerSprite;
    private SpriteRenderer _SwordArcSprite;
    private PlayerAnimation _PlayerAnim;
    private bool _grounded = false;
    public GameObject _fireBullet;


    [SerializeField]
    private int _power = 0;
    [SerializeField]
    private bool _CanTakePower = true;

    //Awake is used to initialize any variables or game state before the game starts
    void Awake()
    {
        _SwordAudio = GameObject.Find("Sword_Arc").GetComponent<AudioSource>();
       

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

        // if the user pressed on O then will be attack by sword
        if (Input.GetKeyDown(KeyCode.O) && isGrounded() == true)
        {
            _PlayerAnim.Attack();
            _SwordAudio.Play();
        }
    }

    void Movement()
    {

        // player move horizontal (left and right )
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = isGrounded();
        GameObject _bullet;

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
               

            }
            else if (move < 0 || _PlayerSprite.flipX == true)
            {
                // when the player in a right side then will be used gun in the right side
                _bullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x;
                
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
            _SwordArcSprite.flipX = false;
            _SwordArcSprite.flipY = false;
            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _SwordArcSprite.transform.localPosition = newPos;


        }
        // when the player flip (faceleft)
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
        //activate && Deactivate jump  and wait few seconds between them
        _resetJumped = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumped = false;

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerIcon")
        {
            collision.gameObject.SetActive(false);

            if (_CanTakePower)
            {
                _power += 1;

                if (_power >= 3)
                {

                    _power += 0;

                    _speed = 8.0f;
                    _jumpForce = 8.0f;

                    _CanTakePower = false;

                    Debug.Log("POWERED!!!" + _power);


                }
                else
                {
                    Debug.Log("NOT POWERED!!!" + _power);
                }
            }

        }
    }



    IEnumerator Buff()
    {

        yield return new WaitForSeconds(10f);
        _speed = 5.0f;
        _jumpForce = 5.0f;
        _CanTakePower = true;

    }

}