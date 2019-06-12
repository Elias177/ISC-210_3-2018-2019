using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlaneBehavior : MonoBehaviour
{
    public GameObject BallSpawn;
    public GameObject DeadBalls;
    public GameObject BallQueue;
    public GameObject Guide;
    public TextMesh BallCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && gameObject.name == "KillPlane")
        {

            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = DeadBalls.transform.position;
            other.gameObject.SetActive(false);
            other.gameObject.transform.SetParent(DeadBalls.transform);
            Guide.SetActive(true);
        }

        if (other.gameObject.tag == "Ball" && gameObject.name == "BucketPlane")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            other.gameObject.transform.position = BallSpawn.transform.position;
            other.gameObject.transform.SetParent(BallQueue.transform);
            Guide.SetActive(true);
            BallCount.text = (Convert.ToInt32(BallCount.text) + 1).ToString();

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
