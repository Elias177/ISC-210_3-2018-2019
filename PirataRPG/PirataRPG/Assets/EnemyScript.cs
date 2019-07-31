using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool _switch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_switch)
        {
            transform.Translate(new Vector3(.1f, 0));
            

        }
        else
        {
            transform.Translate(new Vector3(-.1f, 0));
           

        }


        if (transform.position.x >= 15f)
        {
            StartCoroutine(WaitSwitch());

            _switch = false;

        }

        if (transform.position.x <= 12f)
        {
            StartCoroutine(WaitSwitch());
            _switch = true;

        }

    }

    IEnumerator WaitSwitch()
    {
        yield return new WaitForSeconds(.6f);
    }
}
