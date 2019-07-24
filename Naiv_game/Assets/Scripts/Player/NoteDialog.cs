using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NoteDialog : MonoBehaviour
{

public GameObject _object;
    private bool _stop = false;
    public GameObject _noteDialog;
   float duration = 8;

    // Start is called before the first frame update
    void Start()
    {  }
    // Update is called once per frame
    void Update()
    {
      //this if for duration of the text how many sec will apear
      if (Time.time > duration){
        _stop = false;
        _noteDialog.SetActive(false);
_object.SetActive(false);
      }

    //    if (_stop)
      //  {
            //Time.timeScale = 0f;
           // _noteDialog.SetActive(false);
        //}
        //else
        //{
            //Time.timeScale = 1f;
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            _stop = true;

            _noteDialog.SetActive(true);

            //show dialog with exit
            //when exit close the dialog and active the player
            Debug.Log("Dialooog!!");


        } 
        else {
          _noteDialog.SetActive(false);
        }

    }


}
