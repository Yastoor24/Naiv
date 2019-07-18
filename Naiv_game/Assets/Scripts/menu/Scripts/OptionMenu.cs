using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionMenu : MonoBehaviour
{
  public static bool GameIsPaused = false;
  public GameObject PauseMenuUI;
  [SerializeField] string Scene;

    // Start is called before the first frame update
    void Start()
    {

    }
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
           NewGameBtn(Scene);

         }
         void pause(){
           PauseMenuUI.SetActive(true);
           Time.timeScale=0f;
           GameIsPaused = true;

         }

         public void NewGameBtn(string _newGameLevel)
        {   SceneManager.LoadScene(_newGameLevel);  }
}
