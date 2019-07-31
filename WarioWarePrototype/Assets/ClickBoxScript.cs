using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBoxScript : MonoBehaviour
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
        PlayerPrefs.SetInt("MaxLevel", 1);
        PlayerPrefs.SetInt("Life", 4);
        PlayerPrefs.SetInt("Loop", 0);
        PlayerPrefs.SetInt("Looped", 1);
        PlayerPrefs.SetInt("LastGame", 3);
        PlayerPrefs.Save();
        // load a new scene

        SceneManager.LoadScene("MainScreen");
    }

}
