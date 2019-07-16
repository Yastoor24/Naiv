using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{

    public GameObject Panel;
 

    public void OpenPanel()
    {
        if (Panel != null  )
        {
            Panel.SetActive(false);
            Time.timeScale = 1.0f;
           



        }



    



    }
}
