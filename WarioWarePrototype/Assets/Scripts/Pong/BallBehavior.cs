using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour
{
   

    private float _startingSpeed =  8f;
    private bool _wait;
    public AudioSource Boop;
    public AudioSource Kick;
    public AudioSource Dead;
    public AudioSource Win;

    public GameObject TextDefend;

    void Awake()
    {
        StartCoroutine(WaitBall());
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      

       
    }

    public void OnCollisionEnter(Collision other)
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (!_wait)
        {
            Boop.Play();
            _wait = true;
        }
        StartCoroutine(winCar());

    }

    public void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag == "DeadZone")
        {

            StartCoroutine(fail());

        }
    }

    IEnumerator WaitBall()
    {
        yield return new WaitForSeconds(2);
        TextDefend.SetActive(false);
        for (int i = 0; i < gameObject.transform.GetChild(0).childCount; i++)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>()
                .enabled = true;
        }
        Kick.Play();
        gameObject.transform.GetChild(0).SetParent(null);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-7f, 7f), -_startingSpeed * Time.timeScale);

        
    }

    IEnumerator fail()
    {
       
       Dead.Play();
           
        
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") - 1);

        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame", 0);
        PlayerPrefs.Save();


        SceneManager.LoadScene("MainScreen");


    }

    IEnumerator winCar()
    {
        Win.Play();
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");


    }


}
