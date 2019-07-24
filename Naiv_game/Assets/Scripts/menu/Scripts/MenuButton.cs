using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController = null;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField]   int thisIndex ;
	[SerializeField] string Scene;
    // Update is called once per frame
    void Update()
    {
			print (" this is Update");
			if( menuButtonController.index == thisIndex  )
			{
				animator.SetBool ("selected", true);
				if(Input.GetAxis ("Submit") == 1) {
	      animator.SetBool ("pressed", true);
			//	print("sumbit 1");
			//		Time.timeScale =3;
			    NewGameBtn(Scene);
				}else if (animator.GetBool ("pressed")){
	          animator.SetBool ("pressed", false);
	                //if ( Input.GetAxis("Submit") == 2)
	                {
	                //   NewGameBtn(Scene);
										//print ("Submit 2 ");
	          animatorFunctions.disableOnce = true;

	                }
								//	print("Submit ___");
	            }
			}else{
				animator.SetBool ("selected", false);
	          //  if (Input.GetAxis("Submit") == 3)
	          //  {
	              //  NewGameBtn(Scene);
								//	print("submit 3");
	          //  }

	            }
    }

  // the method for PLay .. which will take u to the first level
		public void NewGameBtn(string _newGameLevel)
		{

			 if (_newGameLevel == "Old Village House"){
				 SceneManager.LoadScene(_newGameLevel);
			 } else if(_newGameLevel == "optionMenu"){
				  SceneManager.LoadScene(_newGameLevel);
			 }
				//SceneManager.LoadScene(_newGameLevel);

		      else if (_newGameLevel == "Exit"){
			 Application.Quit();

		 } else if (_newGameLevel == "WelcomeMenu"){
         SceneManager.LoadScene(_newGameLevel);
		 } else   {
				SceneManager.LoadScene(	PlayerPrefs.GetInt("Scene"));
		}

		// for exit the game ..
//		public void ExitGameBtn()
	//	{
		//		Application.Quit();

		}
     //for exit from the level the player gose to welcome m

}
