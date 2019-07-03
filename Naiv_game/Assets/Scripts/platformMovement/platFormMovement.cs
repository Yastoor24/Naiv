using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platFormMovement : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;
      private

    // Start is called before the first frame update
    void Start()
    {

        nexPos = posB; 
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
    }
}
