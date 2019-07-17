using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    private Rigidbody2D _mybody;
    private Animator _anim;

    public GameObject _firePoint;

    private Vector3 _moveDirection = Vector3.right;
    private Vector3 _originPosition;
    private Vector3 _movePosition;

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




    }

    // Start is called before the first frame update
    void Start()
    {
        _originPosition = transform.position;
        _originPosition.x += _distanceToMove;

        _movePosition = transform.position;
        _movePosition.x -= _distanceToMove;

        _canMove = true;

        _spr = GetComponent<SpriteRenderer>();

        _matWahite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        _matDefault = _spr.material;

        //_explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        if (_canMove)
        {
            transform.Translate(_moveDirection * 2f * Time.smoothDeltaTime);

            if (transform.position.x >= _originPosition.x)
            {
                _moveDirection = Vector3.left;
                changeDirection();
            }
            else if (transform.position.x <= _movePosition.x)
            {
                _moveDirection = Vector3.right;

                changeDirection();
            }
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
            _canMove = true;
            _anim.Play("Walk_Rifle_IP");
        }

        if (_distance < 5)
        {
            _canMove = false;

            if (_attack)
            {
                _anim.Play("Attack_Rifle");
                Instantiate(_bullet, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                _bullet.gameObject.GetComponent<RedLaser>().target = _player.transform;   //pass the player position to bullet script

                _attack = false;

                _anim.Play("Idel_Rifle");                               //TODO:change the animation

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
            Debug.Log("Health: " + _health);
            if (_health <= 0)
            {


                _canMove = false;

                _anim.Play("Death_Rifle");
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

}

