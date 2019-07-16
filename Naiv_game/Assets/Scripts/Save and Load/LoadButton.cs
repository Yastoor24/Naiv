using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{

    private int _sceneToLoad;

    public void LoadGame()
    {
        _sceneToLoad = PlayerPrefs.GetInt("Scene"); 
        
        if (_sceneToLoad != 0)
        {
            Debug.Log("Load # : " + _sceneToLoad);
            SceneManager.LoadScene(_sceneToLoad);            
        }
        else
        {
            Debug.Log("Load # : " + _sceneToLoad);

            return;
        }
    }
}
