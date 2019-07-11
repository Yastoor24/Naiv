using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    private Rigidbody2D _mybody;
    private Animator _anim;

    public GameObject _firePoint;

    private Vector3 _moveDirection = Vector3.right;
    private Vector3 _originPosition;
    private Vector3 _movePosition;

    private Vector3 _position1;
    private Vector3 _position2;
    private Vector3 _position3;
    private Vector3 _position4;


    public GameObject _bullet;
    //public LayerMask _playerLayer;

    private bool _canMove;
    private bool _attack = true;

    private bool _leftDirction = false;

    GameObject _player;


    [SerializeField]
    private int _health = 1;

    private Material _matWahite;
    private Material _matDefault;
    SpriteRenderer _spr;

    public UnityEngine.Object _explosionRef;

    public float _distanceToMove = 4f;


    void Awake()
    {
        _mybody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _position1 = new Vector3(11.76f, -2.05f,0f);
        _position2 = new Vector3(-10.96f, -2.05f, 0f);
        _position3 = new Vector3(-4.69f, 3.04f, 0f);
        _position4 = new Vector3(4.96f, 3.04f, 0f);


    }

    // Start is called before the first frame update
    void Start()
    {
        //_originPosition = transform.position;
        //_originPosition.x += _distanceToMove;

        //_movePosition = transform.position;
        //_movePosition.x -= _distanceToMove;

        _canMove = true;

        _spr = GetComponent<SpriteRenderer>();

        _matWahite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        _matDefault = _spr.material;

        //_explosionRef = Resources.Load("Explosion");

        StartCoroutine(changePosition(0.1f));

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
      
    }

    void Move()
    {
        if (_canMove )
        {
            Vector3 temp = transform.position;


            if (transform.position.x != _moveDirection.x)
            {
                if (transform.position.x < _moveDirection.x)
                {
                    temp.x += 0.25f;

                }
                else if (transform.position.x > _moveDirection.x)
                {
                    temp.x -= 0.25f;

                }
            }
            

            if (transform.position.y <= _moveDirection.y)
            {
                temp.y += 1;

            }
            Debug.Log("Moved!!");
            //_canMove = false;


            //transform.Translate(_moveDirection * 2f * Time.smoothDeltaTime);

            
            transform.position = temp;

            //if (transform.position.x >= _originPosition.x)
            //{
            //    _moveDirection = Vector3.left;
            //    changeDirection();
            //}
            //else if (transform.position.x <= _movePosition.x)
            //{
            //    _moveDirection = Vector3.right;

            //    changeDirection();
            //}
        }
    }


    void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = transform.localScale.x * -1f;
        transform.localScale = tempScale;

        // transform.transform.Rotate(0f, 180F, 0f);

        _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f); // to flip the position of firing
    }


    void Fire()
    {

        float _distance = Vector3.Distance(transform.position, _player.transform.position);

        if (_distance > 8f)
        {
            //_canMove = true;
           // _anim.Play("Woman_Rifle_Walk");
        }

        if (_distance < 5)
        {
            _canMove = false;

            if (_attack)
            {
                _anim.Play("Women_Rifle_Shoot");
                Instantiate(_bullet, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                _bullet.gameObject.GetComponent<RedLaser>().target = _player.transform;   //pass the player position to bullet script

                _attack = false;

               // _anim.Play("Idel_Rifle");                               //TODO:change the animation

                StartCoroutine(WaitToFire(1f));
            }

            //to flip the enemy
            if (transform.position.x >= _player.transform.position.x && _moveDirection != Vector3.left)
            {
                _moveDirection = Vector3.left;
                changeDirection();
            }
            else if (transform.position.x <= _player.transform.position.x && _moveDirection == Vector3.left)
            {
                _moveDirection = Vector3.right;


                changeDirection();
            }

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            //Debug.Log("got Hit");
            _spr.material = _matWahite;
            _health -= 1;               // decrease the health
            _anim.Play("Woman_FH_Get_Hit");
            Debug.Log("Health: " + _health);
            if (_health <= 0)
            {


                _canMove = false;

                
                StartCoroutine(RobotDead());

            }
            else
            {
                StartCoroutine(ResetMaterial(0.1f));
            }

        }
    }

    IEnumerator RobotDead()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("IT IS DEAD: ");

        GameObject _explosion = (GameObject)Instantiate(_explosionRef);
        _explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
    }

    IEnumerator WaitToFire(float time)
    {
        yield return new WaitForSeconds(time);
        _attack = true;
    }

    IEnumerator ResetMaterial(float time)
    {
        yield return new WaitForSeconds(time);
        _spr.material = _matDefault;
    }

    IEnumerator changePosition(float time)
    {
        yield return new WaitForSeconds(time);
        int _random = Random.Range(0, 4);

        switch (_random)
        {
            case 0:
                _moveDirection = _position1 ;
                break;

            case 1:
                _moveDirection = _position2;


                break;

            case 2:
                _moveDirection = _position3;


                break;

            case 3:
                _moveDirection = _position4;

                break;
        }

    }





}
