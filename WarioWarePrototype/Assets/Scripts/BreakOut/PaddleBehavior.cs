using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    private const float RIGHTLIMIT = 7.6f;
    private const float LEFTLIMIT = -7.6f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < RIGHTLIMIT)
        {
            transform.Translate(0, -.15f, 0);
        }

        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > LEFTLIMIT)
        {
            transform.Translate(0, .15f, 0); 
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.x < RIGHTLIMIT)
        {
            transform.Translate(0, -.45f, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.x > LEFTLIMIT)
        {
            transform.Translate(0, .45f, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PowerUp")
        {
            transform.localScale = new Vector3(8,transform.localScale.y,0);
        }
    }
}
