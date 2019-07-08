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

    private int _laserCount = 5;
    //private bool _count = true;


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

                Instantiate(_redLaser, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                _redLaser.gameObject.GetComponent<RedLaser>().target = _player.transform;
                print(" Attack");
                _laserCount--;
              }
        }
      

    }

    void bossMovement()
    {
        float _playerPostionX = _player.transform.position.x;

        

        if (_playerPostionX > _bossX)
        {
            
            print("flip +");
            // flip +
          
            bossAttack();
        }
        else if (_playerPostionX <= _bossX)
        {

            
            print("flip -");
            //flip-
            bossAttack();
        }

    


    }

    IEnumerator wait (float time)
    {
        yield return new WaitForSeconds(time);
        _laserCount = 20;
    }


    void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = transform.localScale.x * -1f;
        transform.localScale = tempScale;

        // transform.transform.Rotate(0f, 180F, 0f);

        _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f); // to flip the position of firing
    }



























    //class
}
