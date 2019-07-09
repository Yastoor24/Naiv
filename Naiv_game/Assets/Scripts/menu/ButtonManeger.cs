using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManeger : MonoBehaviour
{
    // Start is called before the first frame update
    //for start new Game .. which named by welcome Menue
    public void NewGameBtn(string _newGameLevel)
    {
        SceneManager.LoadScene(_newGameLevel);

    }
    // for going to setting menu  
    public void SettingGameBtn(string _setting)
    {
        SceneManager.LoadScene(_setting);

    }  
    // for close the game during playing and moving the player to welcome menu
    public  void ExitLocalFromGameBtn(string _exit)
    {
        SceneManager.LoadScene(_exit);

    }

    public void ExitGameBtn()
    {
        Application.Quit();

    }
}
