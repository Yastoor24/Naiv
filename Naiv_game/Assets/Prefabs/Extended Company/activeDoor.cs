using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeDoor : MonoBehaviour
{

    public Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.Play("OpenDoor");
            GetComponent<BoxCollider2D>().isTrigger = true;
            
        }
    }
}
