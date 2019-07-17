using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Save : MonoBehaviour
{


    public void SaveData()
    {
//PlayerPrefs.SetInt("PlayerLifeCount", GetComponent<HealthBarFade>().healthValue);
  //      PlayerPrefs.SetInt("PlayerAidBoxCount", GetComponent<Coin>()._MedKitCount);
    //    PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("SAVED");
        //Debug.Log("PlayerLifeCount: " + GetComponent<Coin>()._lifeCount);
        //Debug.Log("PlayerAidBoxCount: " + GetComponent<Coin>()._aidBoxCount);
        //Debug.Log("Scene: " + SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadData()
    {
        if(PlayerPrefs.GetInt("Scene")-1 == 1)
        {
          //  gameObject.GetComponent<HealthBarFade>().healthValue = 1;
            //gameObject.GetComponent<Coin>()._MedKitCount = 0;
        }
        else
        {
            //gameObject.GetComponent<HealthBarFade>().healthValue = PlayerPrefs.GetInt("PlayerLifeCount");
            //gameObject.GetComponent<Coin>()._MedKitCount = PlayerPrefs.GetInt("PlayerAidBoxCount");
        }
        //Debug.Log("Loded");
        //Debug.Log("PlayerLifeCount: " + PlayerPrefs.GetInt("PlayerLifeCount"));
        //Debug.Log("PlayerAidBoxCount: " + PlayerPrefs.GetInt("PlayerAidBoxCount"));

        //Debug.Log("Scene: " + SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    } 
}
