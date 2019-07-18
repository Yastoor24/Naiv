using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedOptions : MonoBehaviour
{

    public GameObject medKitBox;
    public Text _MedKitTextScore;




    void Start()
    {

        _MedKitTextScore = GameObject.Find("MedKitText").GetComponent<Text>();


    }

    public void Yes()
    {
        //  yes

        HealthBarFade.amount = 20;
        HealthBarFade.heelState = true;

        GetComponentInParent<Coin>()._MedKitCount -= 3;
       _MedKitTextScore.text = "MedKit " + GetComponentInParent<Coin>()._MedKitCount;
        medKitBox.SetActive(false);

     
    }
    public void No()
    {

       medKitBox.SetActive(false);
        
    }

  
    }
