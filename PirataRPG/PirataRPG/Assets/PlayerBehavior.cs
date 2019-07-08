using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(.1f,0,0);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-.1f, 0, 0);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(0, .1f, 0);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(0, -.1f, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "BreakOut":
                SceneManager.LoadScene("BreakOut");
                break;
            case "Essence":
                SceneManager.LoadScene("Essence");
                break;
        }
    }
}
