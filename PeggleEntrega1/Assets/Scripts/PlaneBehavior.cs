using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlaneBehavior : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Head;
    public GameObject BallSpawn;
    public GameObject DeadBalls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && gameObject.name != "BucketPlane")
        {

            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Ball.transform.position = DeadBalls.transform.position;
            Ball.SetActive(false);
        }

        if (collision.gameObject.tag == "Ball" && gameObject.name == "BucketPlane")
        {
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            Ball.transform.position = BallSpawn.transform.position;
        }
    }

   /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball.SetActive(false);

            Ball.GetComponent<Rigidbody>().useGravity = false;

            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Ball.transform.position = Head.transform.position;
            Ball.transform.SetParent(Head.transform);
        }
    }
    */
}
