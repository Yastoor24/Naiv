using System.Collections;
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

				animator.SetBool ("pressed", true);
				  NewGameBtn( Scene);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);

				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
			 ExitGameBtn();
		}
    }
   // the method for PLay .. which will take u to the first level
		public void NewGameBtn(string _newGameLevel)
    {
        SceneManager.LoadScene(_newGameLevel);

    }
		// for exit the game ..
		public void ExitGameBtn()
		{
				Application.Quit();

		}
}
