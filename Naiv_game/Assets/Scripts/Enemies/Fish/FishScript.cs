using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{

    private Animator anim;

    private bool animation_Started;
    private bool animation_Finished;

    private int jumpedTimes;
    private bool jumpLeft = true;

    private string coroutine_Name = "FishJump";
    public int JumpsNum;

    public LayerMask playerLayer;

    private GameObject player;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
        //player = GameObject.FindGameObjectWithTag (MyTags.PLAYER_TAG);
    }

    void Update()
    {
        //if(Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer)) {
        //player.GetComponent<PlayerDamage> ().DealDamage ();
        //}
        print("anim start" + animation_Started);
        print("anim finish" + animation_Finished);

    }

    void LateUpdate()
    {
        if (animation_Finished && animation_Started)
        {
            animation_Started = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FishJump()
    {
        yield return new WaitForSeconds(3);

        animation_Started = true;
        animation_Finished = false;

        jumpedTimes++;

        if (jumpLeft)
        {
            anim.Play("FishJumpLeft");
        }
        else
        {
            anim.Play("FishJumpRight");
        }

        StartCoroutine(coroutine_Name);

    }

    void AnimationFinished()
    {

        animation_Finished = true;

        if (jumpLeft)
        {
            anim.Play("FishIdleLeft");
        }
        else
        {
            anim.Play("FishIdleRight");
        }

        if (jumpedTimes == JumpsNum)
        {
            jumpedTimes = 0;

            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;

            jumpLeft = !jumpLeft;
        }
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerBullet")
        {
            anim.Play("FishDead");
            OnDestroy();

            //GetComponent<BoxCollider2D>().isTrigger = true;

            //myBody.bodyType = RigidbodyType2D.Dynamic;

            //_canMove = false;

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

} // class
















































