using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask ladderMask;
    public enum detectionModes
    {
        layerMask, tag
    }
    public detectionModes dtectionMode;
    private float inputHorizontal, inputVertical;
    private Rigidbody2D rb;
    private bool isClimping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, 0f);
        if (isClimping)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 20;
        }
        if (dtectionMode == detectionModes.layerMask)
        {
            if (rb.IsTouchingLayers(ladderMask))
            {
                isClimping = true;
            }
            else
            {
                isClimping = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dtectionMode == detectionModes.tag)
        {
            if (collision.tag == ("lader"))
            {
                isClimping = true;
            }
        }
    }
    private void OnTriggerExid2D(Collider2D collision)
    {
        if (dtectionMode == detectionModes.tag)
        {
            if (collision.tag == ("lader"))
            {
                isClimping = false;
            }
        }
    }
}


