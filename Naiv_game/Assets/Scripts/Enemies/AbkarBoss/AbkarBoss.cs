using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbkarBoss : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private Animator _anim;
    private GameObject _player;
    [SerializeField]
    private GameObject _redLaser;
    [SerializeField]
    private GameObject _bullet;
    private GameObject _bulletMood;
    public GameObject _firePoint;
    private Vector3 _moveDirection = Vector3.right;

    private float _bossX;
    [SerializeField]
    private GameObject _up;
    [SerializeField]
    private GameObject _down;
    [SerializeField]
    private GameObject _right;
    private float _rightGround;
    [SerializeField]
    private GameObject _lift;
    [SerializeField]
    private GameObject _canvas;
    private float _bossUp;
    private float _bossDown;
    private float _playerPostionY;
    private float _playerPostionX;
    private float _liftGround;
    private float _health = 100f;
    private int _laserCount =1;
    private bool _attack = true;
    private bool _flip = true;
    private bool _bulletState = false;


    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
       
        _bossX = _myBody.transform.position.x;
        _liftGround = _lift.transform.position.x;
        _rightGround = _right.transform.position.x;             
    }



    void Update()
    {
        

        bossMovement();
    }


    void bossAttack()
    {
        _playerPostionY = _player.transform.position.y;
        _bossUp = _up.transform.position.y;
        _bossDown = _down.transform.position.y;
    
        if (_bulletState)
        {
             _bulletMood = _bullet;
      
        }
        else if (!_bulletState)
        {
            _bulletMood = _redLaser;
                   }        

        if (_playerPostionY < _bossUp && _playerPostionY > _bossDown)
        {
            // خليه يطلق عليه و ينقص الكاونت ولو خلص حيستدعي مثود الوقت

            if (_laserCount>0) {

                if (_attack)
                {
                    Instantiate(_bulletMood, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                   
                    if (_bulletState)
                    {
                        _bullet.gameObject.GetComponent<RedLaser>().target = _player.transform;
                    }
                    else if (!_bulletState)
                    {
                        _redLaser.gameObject.GetComponent<RedLaser>().target = _player.transform;
                    }

                    _laserCount--;
                    _attack = false;
                    if (_laserCount > 0)
                    { StartCoroutine(waitForLaser(0.5f));
                        print(_laserCount);
                    }

                    if (_laserCount == 0)
                    {
                        StartCoroutine(waitForLaser(5f));
                    }
                }
              
            }

           
        }
      

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

    IEnumerator waitForLaser (float time)
    {
        yield return new WaitForSeconds(time);
        if (_laserCount == 0)
        {
            _laserCount = 1;
        }

        _attack = true;

    }

 


    void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = transform.localScale.x * -1f;
        transform.localScale = tempScale;

        // transform.transform.Rotate(0f, 180F, 0f)
        _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f); // to flip the position of firing
    }





 
    void OnTriggerEnter2D(Collider2D collision)
    {
      
    
        if (collision.tag == "PlayerBullet")
        {
            _canvas.SetActive(true);
            _playerPostionX = _player.transform.position.x;
           
            Destroy(collision.gameObject);
            if (_playerPostionX <= _rightGround && _playerPostionX > _liftGround) { 
            // 5%
            float _precentage = (_health / 100) * 5;
            _health -=(int) _precentage;
                print(_health);
              
                
                if ((_health <= 71 && _health >= 63) || (_health <= 46 && _health >= 39) || _health <= 21)
                {
                    _bulletState = true;
                }
                else
                { _bulletState = false; }

                if (_health == 19)
                {
                    dead();
                }
               
            }
            else
            {
                print("non change");
                // تاثير انه صدها 
            }
            StartCoroutine(waitForCanvas(0.5f));
        }

       
     
    }



    IEnumerator waitForCanvas (float time)
    {
        yield return new WaitForSeconds(time);
        _canvas.SetActive(false);
    }


    



    void dead()
    {

        this.gameObject.SetActive(false);
    }








        //class
    }
