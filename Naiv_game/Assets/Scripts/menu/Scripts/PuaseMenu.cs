using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//[SerializeField] string Scene;

public class PuaseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

//	[SerializeField] string Scene;

    // Update is called once per frame
    void Update()
    {
      if ( Input.GetKeyDown(KeyCode.Escape)){
        if(GameIsPaused){
          resume();
        } else  {
          pause();
        }
       }
    }
  public  void resume(){
       PauseMenuUI.SetActive(false);
       Time.timeScale=1f;
       GameIsPaused = false;

     }
     void pause(){
       PauseMenuUI.SetActive(true);
       Time.timeScale=0f;
       GameIsPaused = true;

     }


      public void LoadMenu(){
         Debug.Log("Loading menu");
          //  SceneManager.LoadScene("WelcomeMenu");
      }
       public void QuitGame(){
         Debug.Log( " Qutting game");
         SceneManager.LoadScene("WelcomeMenu");
       }
}
