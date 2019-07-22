using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbkarBoss : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private Animator _anim;
    private GameObject _player;
   
    private string _bulletMood;
 
    private Vector3 _moveDirection = Vector3.right;
    private float _bossX;
    [SerializeField]
    private GameObject _up;
    [SerializeField]
    private GameObject _down;
   
    [SerializeField]
    private GameObject _canvas;
    private float _bossUp;
    private float _bossDown;
    private float _playerPostionY;
    private float _playerPostionX;
    private string nameAnim ="Idle";
    private bool _dead = false;
    private bool _flip = true;
    private bool _bulletState = false;
    public HealthBarFadeAbkar _healthBar;
    [SerializeField]
    private GameObject _right;
    [SerializeField]
    private GameObject _lift;
    private float _liftGround;
    private float _rightGround;

    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
       
        _bossX = _myBody.transform.position.x;
        _liftGround = _lift.transform.position.x;
        _rightGround = _right.transform.position.x;

    }

    void Start()
    {
         _healthBar = new HealthBarFadeAbkar();
     
    }

    void Update()
    {
        

        bossMovement();
    }

    void bossAttack()
    {
        _playerPostionX = _player.transform.position.x;
        _playerPostionY = _player.transform.position.y;
        _bossUp = _up.transform.position.y;
        _bossDown = _down.transform.position.y;


        if ((_playerPostionY < _bossUp) && (_playerPostionY > _bossDown) && (_playerPostionX >= _liftGround && _playerPostionX <= _rightGround))

        {
            if (_bulletState)
            {

                nameAnim = "SuperAttack";

            }
            else if (!_bulletState)
            {
                nameAnim = "Attack1";

            }
        }
        else
        { nameAnim = "Idle"; }
        _anim.Play(nameAnim);
      




    }

    void bossMovement()
    {
        float _playerPostionX = _player.transform.position.x;

  
        if (_playerPostionX > _bossX)
        {
    
            if (!_flip)
            {
                _flip = true;
              
                //flip+
                changeDirection();
            }
          
          
        }
        else if (_playerPostionX <= _bossX)
        {
          
            if (_flip)
            {
                _flip = false;
            
                //flip-
                changeDirection();
            }


         
        }

       bossAttack();


    }

    void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = (transform.localScale.x * -1f);
        transform.localScale = tempScale;

        Vector3 tempPostion = transform.position;
        tempPostion.x =-100f;

        transform.position = tempPostion;


        // transform.transform.Rotate(0f, 180F, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _playerPostionX = _player.transform.position.x;

        if (!_dead) { 
            if (collision.tag == "PlayerBullet")
            {
               

                Destroy(collision.gameObject);

                HealthBarFadeAbkar.damState = true;

                if ((HealthBarFadeAbkar.healthValue >= 50 && HealthBarFadeAbkar.healthValue <= 60) || HealthBarFadeAbkar.healthValue <= 20)
                {
                    
                    _bulletState = true;
                    
                }
                else
                {
                  
                    _bulletState = false;
                   
                }

                if (HealthBarFadeAbkar.EnemyDead)
                {
                    _dead = true;
                    print("dead1");
                    _anim.Play("Abkardead");
                    StartCoroutine(Dead(2.5f));
                }

            }
         
    }


    }

    

    IEnumerator Dead(float time)
    {
        
     
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        _canvas.SetActive(false);
    }

    //IEnumerator wateForATTACK(float time)
    //{

    //    nameAnim ="Idle";
    //    yield return new WaitForSeconds(time);
       
    //}



    //class
}
