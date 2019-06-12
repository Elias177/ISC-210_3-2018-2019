using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    private bool _switch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
            transform.Translate(Vector3.left * 0.03f);

            if (gameObject.transform.position.y > 20f)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,-20,0);
    }
}
