using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{

    public float delay = 0;
    public Text fullText;
    private string currentText = "";

    void Start()
    {
      
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.text.Length; i++)
        {
            currentText = fullText.text.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
         
    }
}
