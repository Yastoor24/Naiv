using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEdge : MonoBehaviour
{


    public GameObject _rightEdge;
    public GameObject _door;
    public GameObject _AI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rightEdge.SetActive(true);
            _door.GetComponent<activeDoor>()._anim.Play("CloseDoor");
            _door.GetComponent<BoxCollider2D>().isTrigger = false;
            _AI.GetComponent<AI>()._start = true;
            Debug.Log("Worked");
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rightEdge.SetActive(true);
            _door.GetComponent<activeDoor>()._anim.Play("CloseDoor");
            GameObject AI = GameObject.FindGameObjectWithTag("AI");
            AI.GetComponent<AI>()._start = true;
            Debug.Log("Worked");
            gameObject.SetActive(false);
            
        }
    }

}
