using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private Transform _barrelTip;
    [SerializeField]
    private GameObject _bullet;
    private Vector2 _lookDirection;
    private float _lookAngle;





    void start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();

            _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
           _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
           transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
        }
    }




    private void FireBullet()
    {
        GameObject fireBullet = Instantiate(_bullet, _barrelTip.position, _barrelTip.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = _barrelTip.up * 10f;

    }



}




