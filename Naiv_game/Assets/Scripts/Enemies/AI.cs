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


    public GameObject _bullet;

    private bool _canMove;
    private bool _attack;
    private bool _canAttack;

    GameObject _player;

    [SerializeField]
    private int _health = 1;

    private Material _matWahite;
    private Material _matDefault;
    SpriteRenderer _spr;

    public UnityEngine.Object _explosionRef;

    public float _distanceToMove = 4f;

    private int _touches ;

    // 1 = RollAttack
    // 2 = move
    // 3 = RollAndBackAttack
    // 4 = RollAndBackFromUP1Attack
    // 5 = RollAndBackFromUP2Attack
    // 
    private int _typeOfAttack = 4;


    public GameObject _midPoint ;
    public GameObject _groundPoint;

    void Awake()
    {
        _typeOfAttack = Random.Range(1, 4);
        Debug.Log(_typeOfAttack);
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

        _canMove = false;
        _attack = false;
        _canAttack = false;

        //StartCoroutine(WaitToMove(4));
        StartCoroutine(WaitToCanAttack(4));

        _spr = GetComponent<SpriteRenderer>();

        _matWahite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        _matDefault = _spr.material;

        //_explosionRef = Resources.Load("Explosion");

        //StartCoroutine(changePosition(0.1f));

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Fire();
      
    }

    void Move()
    {
        if (_canMove )
        {
            //Debug.Log("Moved!!");
            _anim.SetBool("Walk_Anim", true);

            transform.Translate(_moveDirection * 4f * Time.smoothDeltaTime);
        }

        if (_canAttack) {
            _anim.SetBool("Walk_Anim", false);
            _anim.SetBool("Roll_Anim", true);

            _canAttack = false;
            StartCoroutine(WaitToAttack(3));
        }

        if (_attack)
        {
            switch (_typeOfAttack)
            {
                case 1:
                    RollAttack();
                    return;

                case 2:
                    RollAndBackAttack();


                    return;
                case 3:
                    RollAndBackFromUP1Attack();

                    return;


            }
        }

    }


     private void  changeDirection(float _dir)
    {
        Vector3 tempScale = transform.localScale;

        if (_dir == 1)
        {
            tempScale.x = Mathf.Abs(transform.localScale.x);
        }else if (_dir == -1)
        {
            tempScale.x = Mathf.Abs(transform.localScale.x)*-1;

        }
        else
        {
            tempScale.x = transform.localScale.x * -1f;
        }

        transform.localScale = tempScale;
        _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f); // to flip the position of firing

        // transform.transform.Rotate(0f, 180F, 0f);

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
                changeDirection(-1);
            }
            else if (transform.position.x <= _player.transform.position.x && _moveDirection == Vector3.left)
            {
                _moveDirection = Vector3.right;


                changeDirection(1);
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
                _canAttack = false;
                _attack = false;
                StartCoroutine(RobotDead());
            }
            else
            {
                StartCoroutine(ResetMaterial(0.1f));
            }
        }


    }

    private void RollAndBackFromUP1Attack()
    {
        if(_touches == 0)
        {
            transform.Translate(_moveDirection * 18f * Time.smoothDeltaTime);
            Debug.Log("Toutch = "+_touches);
        }
        else if (_touches == 1)
        {
                Debug.Log("Toutch = " + _touches);
            transform.Translate(_midPoint.transform.position * 18f * Time.smoothDeltaTime);
        }
        else if (_touches == 2)
        {
                Debug.Log("Toutch = " + _touches);

            //transform.Translate(_groundPoint.transform.position * 10f * Time.smoothDeltaTime);
        }


    }

    private void  RollAttack()
    {
        transform.Translate(_moveDirection * 18f * Time.smoothDeltaTime);
    }

    private void RollAndBackAttack()
    {
        transform.Translate(_moveDirection * 18f * Time.smoothDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "RightEdge")
        {
            switch (_typeOfAttack)
            {
                case 1:
                    _attack = false;
                    _anim.SetBool("Roll_Anim", false);
                    Debug.Log("RightEdge");
                    _moveDirection = Vector3.left;
                    changeDirection(-1);
                    StartCoroutine(WaitToMove(2));
                    
                    StartCoroutine(WaitToCanAttack(4));
                    return;

                case 2:
                    ++_touches;
                    if (_touches == 2)
                    {
                        _touches = 0;
                        _attack = false;
                        _anim.SetBool("Roll_Anim", false);
                        Debug.Log("RightEdge");
                        _moveDirection = Vector3.left;
                        changeDirection(-1);
                        StartCoroutine(WaitToMove(2));

                        StartCoroutine(WaitToCanAttack(4));

                        return;
                    }
                    else
                    {
                        Debug.Log("RightEdge");
                        _moveDirection = Vector3.left;
                        changeDirection(-1);
                    }

                    return;

                case 3:
                    Debug.Log("RightEdge");

                    ++_touches;
                    if (_touches == 2)
                    {
                        _touches = 0;
                        _attack = false;
                        _anim.SetBool("Roll_Anim", false);
                        Debug.Log("RightEdge");
                        _moveDirection = Vector3.left;
                        changeDirection(-1);
                        StartCoroutine(WaitToMove(2));

                        StartCoroutine(WaitToCanAttack(4));
                    }

                    return;

            }

        }
        else if (collision.gameObject.tag == "LeftEdge")
        {
            switch (_typeOfAttack)
            {
                case 1:
                    _attack = false;
                    _anim.SetBool("Roll_Anim", false);
                    Debug.Log("LeftEdge");
                    _moveDirection = Vector3.right;
                    changeDirection(1);
                    StartCoroutine(WaitToMove(2));
                    
                    StartCoroutine(WaitToCanAttack(4));

                    return;

                case 2:
                    ++_touches;
                    if (_touches == 2)
                    {
                        _touches = 0;
                        _attack = false;
                        _anim.SetBool("Roll_Anim", false);
                        Debug.Log("LeftEdge");
                        _moveDirection = Vector3.right;
                        changeDirection(1);
                        StartCoroutine(WaitToMove(2));

                        StartCoroutine(WaitToCanAttack(4));

                        return;
                    }
                    else
                    {
                        Debug.Log("LeftEdge");
                        _moveDirection = Vector3.right;
                        changeDirection(1);
                    }

                    return;

                case 3:
                    Debug.Log("LeftEdge");

                    ++_touches;

                    if (_touches == 2)
                    {
                        _touches = 0;
                        _attack = false;
                        _anim.SetBool("Roll_Anim", false);
                        Debug.Log("LeftEdge");
                        _moveDirection = Vector3.right;
                        changeDirection(1);
                        StartCoroutine(WaitToMove(2));

                        StartCoroutine(WaitToCanAttack(4));

                    }
                    return;
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

    IEnumerator WaitToMove(float time)
    {
        yield return new WaitForSeconds(time);
        _canMove = true;
    }

    IEnumerator WaitToCanAttack(float time)
    {
        yield return new WaitForSeconds(time);
        _typeOfAttack = Random.Range(1, 4);
        Debug.Log("Type of attack : " + _typeOfAttack);
        _canMove = false;
        _canAttack = true;
        _touches = 0;
    }

    IEnumerator WaitToAttack(float time)
    {
        yield return new WaitForSeconds(time);
        _attack = true;
    }
}
