using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    private bool _switch;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= -4)
            _switch = true;

        if (gameObject.transform.position.x >= 4)
            _switch = false;

        if (_switch)
            transform.Translate(Vector3.back * 0.1f);
       

        if (!_switch)
            transform.Translate(Vector3.forward * 0.1f);

        Debug.Log(gameObject.transform.position.x);
    }
}
