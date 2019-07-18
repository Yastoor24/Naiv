using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbkarBoss : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private Animator _anim;
    private GameObject _player;
    //[SerializeField]
    //private GameObject _redLaser;
    //[SerializeField]
    //private GameObject _bullet;
    private string _bulletMood;
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
    private int _laserCount =3;
    private bool _attack = true;
    private bool _flip = true;
    private bool _bulletState = false;
    public  HealthBarFade _healthBar;


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
         _healthBar = new HealthBarFade();
     
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
             _bulletMood = "Attack1";


        }
        else if (!_bulletState)
        {
            _bulletMood = "SuperAttack";
                   }        

        if (_playerPostionY < _bossUp && _playerPostionY > _bossDown)
        {
            _anim.Play(_bulletMood);
        //    // خليه يطلق عليه و ينقص الكاونت ولو خلص حيستدعي مثود الوقت

        //    if (_laserCount>0) {

        //        if (_attack)
        //        {
        //            Instantiate(_bulletMood, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                   
        //            if (_bulletState)
        //            {
        //                _bullet.gameObject.GetComponent<RedLaser>().target = _player.transform;
        //            }
        //            else if (!_bulletState)
        //            {
        //                _redLaser.gameObject.GetComponent<RedLaser>().target = _player.transform;
        //            }

        //            _laserCount--;
        //            _attack = false;
        //            if (_laserCount > 0)
        //            { StartCoroutine(waitForLaser(0.5f));
        //                print(_laserCount);
        //            }

        //            if (_laserCount == 0)
        //            {
        //                StartCoroutine(waitForLaser(5f));
        //            }
        //        }
              
        //    }

           
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

                HealthBarFade.damState = true;

                //if ((HealthBarFade.healthValue<= 70 && HealthBarFade.healthValue <= 80) || (HealthBarFade.healthValue >= 50 && HealthBarFade.healthValue <= 60) || HealthBarFade.healthValue <= 15)
                //{
                //    _bulletState = true;
                //}
                //else
                //{ _bulletState = false; }

                if (HealthBarFade.EnemyDead)
                {
                    StartCoroutine(Dead(1f)) ;
                }

            }
            else
            {
                print("non change");
                // تاثير انه صدها 
            }

            StartCoroutine(waitForCanvas(0.8f));
        }

    }

    IEnumerator waitForCanvas (float time)
    {
       
        yield return new WaitForSeconds(time);
        _canvas.SetActive(false);
    }

    IEnumerator Dead(float time)
    {
        _anim.SetBool("Dead", true);
        //_bulletMood.SetActive(false);
        yield return new WaitForSeconds(time);
       
        this.gameObject.SetActive(false);
    }

    IEnumerator waitForLaser(float time)
    {
        yield return new WaitForSeconds(time);
        if (_laserCount == 0)
        {
            _laserCount = 3;
        }

        _attack = true;

    }






    //class
}
