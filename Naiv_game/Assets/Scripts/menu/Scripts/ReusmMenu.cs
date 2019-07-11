using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReusmMenu : MonoBehaviour
{

    public static bool GameIsPaused =false;
    public GameObject PauseMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            PauseMenuUi.SetActive(true);

        }
        else if (GameIsPaused!= true)
        {
            PauseMenuUi.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        
            if (GameIsPaused)
            {
               // print("I am paused");
                //Pause();
               Reueme();
            }
            else
            {
               // print("I am resumed");
               // Reueme();
                Pause();
            }
        }
      
    }

     public void Reueme()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false; 
    }
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("loading menu ");
    }
    public void QuitGame()
    {
        Debug.Log("quit ..");
    }


}
