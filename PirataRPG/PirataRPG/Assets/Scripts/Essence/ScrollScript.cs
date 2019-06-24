using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    private bool wait = false;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        transform.Translate(-.1f,0,0);

        if (transform.position.x < -18.09 && !wait)
        {
            Instantiate(gameObject, new Vector3(18, 0, 0), Quaternion.identity);
            wait = true;
        }

        if (transform.position.x < -36)
        {
            Destroy(gameObject);
        }



    }
}
