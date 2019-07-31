using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    private float _speed = 15f;

    public AudioSource CarSound;

    public GameObject TextJump;
    public Sprite WinSprite;

    private bool _move;
    // Start is called before the first frame update
    void Awake()
    {
        _move = false;
        StartCoroutine(StartCar());
        if(gameObject.name == "Car")
        gameObject.GetComponent<Animator>().SetBool("Run",true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_move)
            transform.Translate(-_speed * Time.deltaTime,0,0);

    }

    void OnCollisionEnter(Collision collision)
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Limit")
        {
            StartCoroutine(winCar());
        }
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("Run", false);

            _speed = 0;

        }

    }

    IEnumerator winCar()
    {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = WinSprite;
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");


    }


    IEnumerator StartCar()
    {
        yield return new WaitForSeconds(2);
        if (gameObject.name == "Car")
        {
            TextJump.SetActive(false);
            CarSound.Play();
        }

        _move = true;
    }
}
