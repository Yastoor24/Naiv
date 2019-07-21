using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossScript : MonoBehaviour
{
      private bool canvasState;
    [SerializeField]
      private GameObject AbkarCanvase;
        
     void Start()
    {
        canvasState = false;
    }
    private void Update()
    { 


    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
          
            if (canvasState)
            {
                AbkarCanvase.SetActive(false);
                canvasState = false;
             
            }
            else if (!canvasState)
            {
                AbkarCanvase.SetActive(true);
                canvasState = true;
               
            }
        }


    }
}
