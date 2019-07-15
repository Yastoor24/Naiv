using UnityEngine;
using System.Collections;

public class PlatFormMovement1 : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }

    }

}