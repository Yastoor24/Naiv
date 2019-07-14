using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PauseMenuUI;
         [SerializeField]private bool isPaused;
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused =!isPaused;
          }
          if(isPaused){
            ActiveMenu();
          }
          else {
            DeactiveMenue();

          }

    }
         void ActiveMenu(){
            Time.timeScale= 0;
            AudioListener.pause = true;
             PauseMenuUI.SetActive(true);
         }
          void DeactiveMenue(){

              Time.timeScale= 1;
              AudioListener.pause = false;
            PauseMenuUI.SetActive(false);
          }
    }
