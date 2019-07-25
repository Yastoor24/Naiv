using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour {

	private Animator anim;

	public LayerMask playerLayer;

	private GameObject player;

    private bool fire = true;

    private bool attack = true;

    public GameObject _bullet;

    public GameObject _firePoint;


	void Awake() 
    {
		anim = GetComponent<Animator> ();
	}

	void Start () 
    {
        fire = true; 
	}

	void Update() 
    {

    }

    void Fire()
    {
        if (fire == true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance > 8f)
            {
                anim.Play("FrogIdleLeft");
            }

            if (distance < 5)
            {
                if (attack == true)
                {
                    anim.Play("FrogAttack");
                    Instantiate(_bullet, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);
                    _bullet.gameObject.GetComponent<RedLaser>().target = player.transform;   //pass the player position to bullet script

                    attack = false;

                    StartCoroutine(WaitToFire(Random.Range(3f, 4f)));
                }

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

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerBullet")
        {
            anim.Play("FrogDead");
            OnDestroy();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnDestroy()
    {
        Destroy(gameObject, 1);
    }

    IEnumerator WaitToFire(float time)
    {
        yield return new WaitForSeconds(time);
        Wait();
        attack = true;
    }


} // class
















































