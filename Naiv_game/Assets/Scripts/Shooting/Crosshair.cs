﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("XboxLB"))
        {
            this.transform.position = Input.mousePosition;
        }
        this.transform.position = Input.mousePosition;
    }
}
