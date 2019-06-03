using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    private Rigidbody _ball;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          //  _ball.AddForce(10, -10, 0, ForceMode.Impulse);

        }
        _ball.AddForce(100, -10, 0, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KillPlane")
        {
            Debug.Log("COL");
            Destroy(gameObject);

        }
    }

}
