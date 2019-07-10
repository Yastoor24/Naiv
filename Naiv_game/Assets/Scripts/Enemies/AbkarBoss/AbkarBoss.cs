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
    public GameObject _firePoint;
    private Vector3 _moveDirection = Vector3.right;

    private float _bossX;
    [SerializeField]
    private GameObject _up;
    [SerializeField]
    private GameObject _down;
    private float _health = 100f;
    private int _laserCount =10;
    private bool _attack = true;
    private bool _flip = true;


    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _bossX = _myBody.transform.position.x;
    }

    void Start()
    {
       

    }

    void Update()
    {
        bossMovement();
    }


    void bossAttack()
    {
        float _playerPostionY = _player.transform.position.y;
        float _bossUp = _up.transform.position.y;
        float _bossDown = _down.transform.position.y;

        if (_playerPostionY < _bossUp && _playerPostionY > _bossDown)
        {
            // خليه يطلق عليه و ينقص الكاونت ولو خلص حيستدعي مثود الوقت

            if (_laserCount>0) {

                if (_attack)
                {
                    Instantiate(_redLaser, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                    _redLaser.gameObject.GetComponent<RedLaser>().target = _player.transform;
                    print(" Attack");
                    _laserCount--;
                    _attack = false;
                    if (_laserCount > 0)
                    { StartCoroutine(waitForLaser(0.5f));
                        print(_laserCount);
                    }

                    if (_laserCount == 0)
                    {
                        StartCoroutine(waitForLaser(4f));
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
                print("flip +");
                // flip +
                changeDirection();
            }
          
            bossAttack();
        }
        else if (_playerPostionX <= _bossX)
        {
            if (_flip)
            {
                _flip = false;               
                print("flip -");
                //flip-
                changeDirection();
            }


            bossAttack();
        }

    


    }

    IEnumerator waitForLaser (float time)
    {
        yield return new WaitForSeconds(time);
        if (_laserCount == 0)
        {
            _laserCount = 10;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);

            // 5%

            float _precentage = (_health / 100) * 5;
            _health -= _precentage;
            print(_health);

        }



        }
























    //class
}
