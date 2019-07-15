using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinue : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Panel1;

    public void OpenAnthorPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
            Panel1.SetActive(true);

        }
    }
}
