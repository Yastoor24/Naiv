using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip MusicClip;
   
    // the component that Unity uses to play your clip
    public AudioSource MusicSource;
    private bool sound = false;
    // Use this for initialization
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MusicSource.Play();
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
      
            MusicSource.Play();
        }
    }
}
