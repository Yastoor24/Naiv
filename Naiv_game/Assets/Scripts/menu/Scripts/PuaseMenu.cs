using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//[SerializeField] string Scene;

public class PuaseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
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
       LoadingScens();
     }
     void pause(){
       PauseMenuUI.SetActive(true);
       Time.timeScale=0f;
       GameIsPaused = true;

     }
     void LoadingScens(){
       if(Input.GetAxis ("Vertical") != 0){
   			if(!keyDown){

   				if (Input.GetAxis ("Vertical") < 0) {
   					if(index < maxIndex){

   						index++;
   					}else{
   						index = 0;
   					}
   				} else if(Input.GetAxis ("Vertical") > 0 ){
   					if(index > 0){
   						index --;
   					}else{
   						index = maxIndex;
   					}
   				}
   				keyDown = true;
   			}
   		}else{
   			keyDown = false;
   		}

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
