using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerMouse : MonoBehaviour
{
    public GameObject cross_shair;
    private Vector3 target;

    void start()
    {
        Cursor.visible = false;
    }

    void update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        cross_shair.transform.position = new Vector2(target.x, target.y);
         
    }


} 