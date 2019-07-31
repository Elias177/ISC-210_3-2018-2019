using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private float _speed = 1.8f;

    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
      
            if (other.gameObject.tag == "Player")
            {
                transform.right = other.gameObject.transform.position - transform.position;
                transform.Translate(transform.right * Time.deltaTime * _speed,Space.World);
                animator.SetBool("IsMoving", true);

            }
    }

    void OnTriggerExit(Collider co)
    {
        animator.SetBool("IsMoving", false);
    }
}
