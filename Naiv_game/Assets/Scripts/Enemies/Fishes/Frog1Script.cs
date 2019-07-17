using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog1Script : MonoBehaviour
{
    private Animator anim;

    private string coroutine_Name = "FrogJumpLeft";

    public LayerMask playerLayer;

    private GameObject player;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    void Update()
    {
    
    }

    void LateUpdate()
    {
        if (animation_Finished && animation_Started)
        {
            animation_Started = false;
            lifeScoreCount=1;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        animation_Started = true;
        animation_Finished = false;

        jumpedTimes++;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }

        StartCoroutine(coroutine_Name);

    }


  void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerBullet")
        {



                lifeScoreCount--;

                if (lifeScoreCount >= 0)
                {


                    target.gameObject.SetActive(false);
                }

                if (lifeScoreCount == 0)
                {


                    gameObject.SetActive(false);
                    target.gameObject.SetActive(false);





            }

        }
    }

} // class
