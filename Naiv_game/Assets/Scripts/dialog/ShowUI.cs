using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{

    public GameObject Panel;
   



    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);


    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D p)
    {

        if (p.gameObject.tag == "Player")
        {

          
            Panel.SetActive(true);
           

            Time.timeScale = 0.0f;

           


        }

    }


}
