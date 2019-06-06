using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    private Rigidbody _ball;

    public GameObject Head;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

    }

}
