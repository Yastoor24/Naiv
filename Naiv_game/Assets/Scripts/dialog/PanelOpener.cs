using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{

    public float delay = 0.05f;
    public string fullText;

    public string currentText = " ";

    void Start()
    {

       StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
      for (int i = 0; i < fullText.Length; i++ )
     {          currentText = fullText.Substring( 0 , i + 1 );
                this .  GetComponent <  Text  >( ) .text = currentText  +  "    "  ;
            yield return new WaitForSeconds(delay);

        }
        
    }


 
}
