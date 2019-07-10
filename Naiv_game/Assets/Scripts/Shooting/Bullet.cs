using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public static PlayerAnimation _PlayerAnim;
    private AudioSource _GunAudio;
    [SerializeField]
    private Transform _barrelTip;
    public GameObject _fireBullet;
    [SerializeField]
    private GameObject _bullet;
    private Vector2 _lookDirection;
    private float _lookAngle;
   
    [SerializeField]
    int _maxBullets = 5;
    int _bullets;
    private bool _resetJumped = false;
    private bool _canShoot = true;
    private AmmoText _AmmoText;
    private Animator anim;
    [SerializeField]
    public static Player _Player;

    public static bool b1 = true;
    public static bool b2 = false;

    void Awake()
    {
        _GunAudio = GameObject.Find("Bullet").GetComponent<AudioSource>();
        _bullets = _maxBullets;
          _AmmoText = GameObject.FindWithTag("ScreenManagerAmmo").GetComponent<AmmoText>();
         anim = GetComponent<Animator>();
    }


    void start() {
        _Player = GetComponent<Player>();
       
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(_canShoot);


        if (_canShoot)
        {
            if ((Input.GetMouseButtonDown(0) && _bullets >= 0) || Input.GetButton("XboxY"))
            {

                Debug.Log("HHHHHHHHH");
               
                _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
                GameObject fireBullet = Instantiate(_bullet, _barrelTip.position, _barrelTip.rotation);
                fireBullet.GetComponent<Rigidbody2D>().velocity = _barrelTip.up * 10f;
            
                FireBullet(fireBullet);

              
            }



        }



            else if (Input.GetKeyDown(KeyCode.R) || _bullets <= 0)
            {
                Debug.Log("Wait to Reload");
                _canShoot = false;


                StartCoroutine(Reload());
            }

        }



    private void FireBullet(GameObject fireBullet)
    {
        _bullets -= 1;

          _AmmoText.UpdateAmmoText(_bullets, _maxBullets);

        Debug.Log("Shoot: " + _bullets);
          fireBullet.GetComponent<FireBullet>().Speed *= -transform.localScale.x;

    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
         _AmmoText.UpdateAmmoText(_maxBullets, _maxBullets);
        _bullets = 5;
        _canShoot = true;
        Debug.Log("Reloaded");

    }
}
