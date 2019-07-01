using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    private AudioSource audioManager;
    private Text coinTextScore;
    private int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText ").GetComponent<Text>();
    }

    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if( target.tag == MyTags.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            scoreCount++;
            coinTextScore.text = "X" + scoreCount;
            audioManager.Play();
        }
    }
}
