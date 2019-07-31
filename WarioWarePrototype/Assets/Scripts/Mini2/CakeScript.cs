using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CakeScript : MonoBehaviour
{
    private float _speed = 15f;

    public GameObject TextJump;
    public AudioSource Go;
    public AudioSource Yayy;
    public AudioSource TouchCakeFX;
    public AudioSource QuackFX;


    private bool _move;
    // Start is called before the first frame update
    void Awake()
    {
        _move = false;
        StartCoroutine(StartCar());
        if (gameObject.name == "Car")
            gameObject.GetComponent<Animator>().SetBool("Run", true);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Limit")
        {
            QuackFX.Play();
            StartCoroutine(loseCake());
        }
        if (other.gameObject.name == "Player")
        {
            TouchCakeFX.Play();
            Go.Play();
            Yayy.Play();
            _speed = 0;
            StartCoroutine(winCake());
        }

    }

    IEnumerator winCake()
    {
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame", 1);

        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");
    }

    IEnumerator loseCake()
    {
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame", 0);
        PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") - 1);

        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");
    }


    IEnumerator StartCar()
    {
        yield return new WaitForSeconds(2);
        if (gameObject.name == "Cake")
        {
            TextJump.SetActive(false);
        }

        _move = true;
    }
}
