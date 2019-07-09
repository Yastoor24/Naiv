using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlscript : MonoBehaviour
{
    float directionX;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       //directionX =.GetAxis("Horizontal");
    }
}
