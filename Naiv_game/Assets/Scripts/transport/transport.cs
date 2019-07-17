using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport : MonoBehaviour
{
    public string level;
    public int x;
    public int y;


    void LoadHighScoreLevel()
    {

        Application.LoadLevel(level);

        //print("load");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("Canvas");
        //GameObject[] aa = GameObject.FindGameObjectsWithTag("PlayerBullet");
        if (collision.tag == "Player")
        {
            // DontDestroyOnLoad(collision.gameObject);
            //DontDestroyOnLoad(objs[0]);
            // DontDestroyOnLoad(aa[0]);
            collision.gameObject.GetComponent<Save>().SaveData();

            LoadHighScoreLevel();
            print("on trigger");
            //collision.gameObject.transform.Translate(x, y, 1);
        }
    }


}
