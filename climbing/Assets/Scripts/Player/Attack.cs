using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour

{

    private void OnTriggrEnter2D(Collider2D other)
    {
        Debug.Log("Hit : "+ other.name);
    } 
   
  
}
