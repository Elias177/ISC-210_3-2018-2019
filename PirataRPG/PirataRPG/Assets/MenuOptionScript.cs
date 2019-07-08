using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {


        switch (gameObject.name)
        {
            case "Play":

                SceneManager.LoadScene("Taverna");
                break;

            case "Minigames":
                break;

            case "Exit":
                Application.Quit();
                break;
        }

    }
}
