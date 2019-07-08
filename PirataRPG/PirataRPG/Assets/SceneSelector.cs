using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetButtonDown("Submit"))
            return;
   
        switch (gameObject.name)
        {
            case "PiraPongSelector":
                SceneManager.LoadScene(3);
                break;
            case "PiraEssenceSelector":
                SceneManager.LoadScene(2);
                break;
            case "PiraBrickBreakerSelector":
                SceneManager.LoadScene(4);
                break;
        }
        
    }
}
