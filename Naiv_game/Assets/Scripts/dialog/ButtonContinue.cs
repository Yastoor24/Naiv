using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonContinue : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Panel1;
  
    public void OpenAnthorPanel()
    {
     
        Panel.SetActive(false);
            Panel1.SetActive(true);

   
    }


}
