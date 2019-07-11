﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] string Scene;



    // Update is called once per frame

    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
                LoadScene(Scene);
                animator.SetBool ("pressed", true);
				  
			}else if (animator.GetBool ("pressed")){

                animator.SetBool ("pressed", false);
                if (Input.GetAxis("Submit") == 2)
                {
                    LoadScene(Scene);
                    animatorFunctions.disableOnce = true;
                }
            }
		}else{
			animator.SetBool ("selected", false);
            if (Input.GetAxis("Submit") == 3)
            {
                LoadScene(Scene);
            }

            }
    }
   // the method for PLay .. which will take u to the first level
		public void LoadScene(string _newGameLevel)
    {
        SceneManager.LoadScene(_newGameLevel);

    }

		// for exit the game ..
		public void ExitGameBtn()
		{
				Application.Quit();

		} 
     //for exit from the level the player gose to welcome m

}
