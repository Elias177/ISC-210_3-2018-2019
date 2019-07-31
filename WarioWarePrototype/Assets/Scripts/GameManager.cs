using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameManager : MonoBehaviour
{

    

    public GameObject Life;

    public GameObject MiniNumber;


    public AudioSource FailAudio;

    public AudioSource OhNo;
    public AudioSource Harsh;
    public AudioSource Uncool;
    public AudioSource TooSlow;
    public AudioSource ComeOn;
    public AudioSource UnGroovy;

    public AudioSource WinAudio;
    public AudioSource Groovy;
    public AudioSource LetsGo;
    public AudioSource Smooth;
    public AudioSource Yeah;
    public AudioSource RightOn;


    public int result;
    private int loopcont=0;

    public static bool ready;

    private bool dead;

    private Animator animator;
    // Start is called before the first frame update

    void Awake()
    {
        if (PlayerPrefs.GetInt("Looped") == 1)
        {
            PlayerPrefs.SetInt("Loop",PlayerPrefs.GetInt("Loop") + 1);
            Time.timeScale = Time.timeScale + 0.5f;
            PlayerPrefs.SetInt("Looped", 0);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("Life") >= 0)
        {
            for (int i = 0; i < 4 - PlayerPrefs.GetInt("Life"); i++)
            {
                Debug.Log(Life.transform.GetChild(i).gameObject.name);
                Destroy(Life.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            //Lose all
            StartCoroutine(PostRequest("http://localhost:3000/api/Scores"));
            dead = true;
        }

        MiniNumber.GetComponent<TextMeshPro>().text = PlayerPrefs.GetInt("MaxLevel").ToString();
        animator = gameObject.GetComponent<Animator>();
        result = PlayerPrefs.GetInt("LastGame");
        switch (result)
        {
            case 0:
                StartCoroutine(LoseState());
                break;
            case 1:
                StartCoroutine(WinState());
                break;
                
        }



        StartCoroutine(LoadMini());
    }
    void Start()
    {
   
    }

  
    // Update is called once per frame
    void Update()
    {
        if (ready && !dead)
        {
            StartCoroutine(LoadMini());
        }

        if (dead)
        {
            StartCoroutine(LoseState());
        }
    }


    IEnumerator  LoadMini()
    {
        

        ready = false;

        yield return new WaitForSeconds(4);


        if (PlayerPrefs.GetInt("MaxLevel") == 5)
        {
            SceneManager.LoadScene("Boss");

        }
        else
        {
            SceneManager.LoadScene("Mini" + PlayerPrefs.GetInt("MaxLevel"));

        }




    }

    

    IEnumerator WinState()
    {

        WinAudio.PlayDelayed(.3f);

        int selector = UnityEngine.Random.Range(0, 4);

        switch (selector)
        {
            case 0:
                Groovy.Play();
                break;
            case 1:
                LetsGo.Play();
                break;
            case 2:
                Smooth.Play();
                break;
            case 3:
                Yeah.Play();
                break;
            case 4:
                RightOn.Play();
                break;
           
        }

        animator.SetBool("Win", true);
        for (int i = 0; i < Life.transform.childCount; i++)
        {
            Life.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("Win", true);
        }
       

        yield return new WaitForSeconds(3);
        animator.SetBool("Win", false);
        for (int i = 0; i < Life.transform.childCount; i++)
        {
            Life.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("Win", false);
        }
    }

    IEnumerator LoseState()
    {
        animator.SetBool("Lose",true);

        FailAudio.PlayDelayed(.3f);

        int selector = UnityEngine.Random.Range(0, 5);

        switch (selector)
        {
            case 0:
                OhNo.Play();
                break;
            case 1:
                Harsh.Play();
                break;
            case 2:
                Uncool.Play();
                break;
            case 3:
                TooSlow.Play();
                break;
            case 4:
                ComeOn.Play();
                break;
            case 5:
                UnGroovy.Play();
                break;
        }

        

        for (int i = 0; i < Life.transform.childCount; i++)
        {
            Life.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("Lose",true);
        }
   

        yield return new WaitForSeconds(3);
        animator.SetBool("Lose", false);

        for (int i = 0; i < Life.transform.childCount; i++)
        {
            Life.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("Lose", false);
        }

    }


    IEnumerator PostRequest(string url)
    {
        loopcont = PlayerPrefs.GetInt("Loop");

        WWWForm form = new WWWForm();
        form.AddField("loops", loopcont);
        form.AddField("name", "Unity");
        form.AddField("cantcleared",0);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        Debug.Log("Recibido: " + uwr.downloadHandler.text);

    }
}
