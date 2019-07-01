using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator takeCoin()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            anim.Play("Stunned");
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.PLAYER_TAG)
        {
           
            myBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(takeCoin());
            gameObject.SetActive(false);



        }
    }
}
