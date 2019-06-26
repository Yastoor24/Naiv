using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {

        }


        gameObject.SetActive(false);
    }



}
