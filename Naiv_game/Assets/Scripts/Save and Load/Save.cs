using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Save : MonoBehaviour
{


    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerLifeCount", GetComponent<Coin>()._lifeCount);
        PlayerPrefs.SetInt("PlayerAidBoxCount", GetComponent<Coin>()._aidBoxCount);
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("SAVED");
        //Debug.Log("PlayerLifeCount: " + GetComponent<Coin>()._lifeCount);
        //Debug.Log("PlayerAidBoxCount: " + GetComponent<Coin>()._aidBoxCount);
        //Debug.Log("Scene: " + SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadData()
    {
        if(PlayerPrefs.GetInt("Scene")-1 == 1)
        {
            gameObject.GetComponent<Coin>()._lifeCount = 1;
            gameObject.GetComponent<Coin>()._aidBoxCount = 0;
        }
        else
        {
            gameObject.GetComponent<Coin>()._lifeCount = PlayerPrefs.GetInt("PlayerLifeCount");
            gameObject.GetComponent<Coin>()._aidBoxCount = PlayerPrefs.GetInt("PlayerAidBoxCount");
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
