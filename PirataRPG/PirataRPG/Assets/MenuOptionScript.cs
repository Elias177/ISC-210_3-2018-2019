using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptionScript : MonoBehaviour
{

    public GameObject Essence;
    public GameObject Pong;
    public GameObject BreakOut;

    public GameObject Play;

    public GameObject Mini;

    public GameObject Exit;

    public GameObject Credits;
    public GameObject Logo;

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

                SceneManager.LoadScene("Tavern");
                break;

            case "Minigames":

                if (BreakOut.activeSelf)
                {
                    BreakOut.SetActive(false);
                    Pong.SetActive(false);
                    Essence.SetActive(false);
                }
                else
                {
                    BreakOut.SetActive(true);
                    Pong.SetActive(true);
                    Essence.SetActive(true);
                }
                   

                break;

            case "Essence":
                SceneManager.LoadScene("Essence");
                break;

            case "BreakOut":
                SceneManager.LoadScene("BreakOut");
                break;

            case "Pong":
                SceneManager.LoadScene("Pong");
                break;
            case "Credits":
                if (Play.activeSelf)
                {
                   
                    Play.SetActive(false);
                    Exit.SetActive(false);
                    Mini.SetActive(false);
                    Credits.SetActive(true);
                    Logo.SetActive(true);

                    BreakOut.SetActive(false);
                    Pong.SetActive(false);
                    Essence.SetActive(false);
                }
                else
                {
                    Play.SetActive(true);
                    Exit.SetActive(true);
                    Mini.SetActive(true);
                    Credits.SetActive(false);
                    Logo.SetActive(false);

                }

                break;
            case "Exit":
                Application.Quit();
                break;
        }

    }
}
