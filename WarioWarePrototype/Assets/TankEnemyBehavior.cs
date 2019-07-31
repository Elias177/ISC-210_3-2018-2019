using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyBehavior : MonoBehaviour
{

    private float _speed = 1.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
      
            if (other.gameObject.name == "Player")
            {
                transform.right = other.gameObject.transform.position - transform.position;
                transform.Translate(transform.right * Time.deltaTime * _speed,Space.World);
            }
    }
}
