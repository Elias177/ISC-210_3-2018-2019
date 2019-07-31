using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankScript : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private GameObject Head;
    private GameObject Bullet;

    public Sprite XSprite;
    public Sprite XSpriteHead;

    public Sprite NSprite;
    public Sprite NSpriteHead;

    public Sprite Smoke;

    public AudioSource EngineSound;
    public AudioSource MissionFaild;
    public AudioSource noice;

    private bool dead;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Head = gameObject.transform.GetChild(0).gameObject;
        Bullet = Head.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!dead)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0, .05f * Time.timeScale, 0);


                Head.transform.localPosition = new Vector3(0, .24f, -1f);

                spriteRenderer.flipY = false;
                spriteRenderer.sprite = NSprite;
                Head.GetComponent<SpriteRenderer>().sprite = NSpriteHead;
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(0, -.05f * Time.timeScale, 0);

                Head.transform.localPosition = new Vector3(0, -.24f, -1f);

                spriteRenderer.flipY = true;
                spriteRenderer.sprite = NSprite;
                Head.GetComponent<SpriteRenderer>().sprite = NSpriteHead;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(.05f * Time.timeScale, 0, 0);
                spriteRenderer.sprite = XSprite;
                Head.GetComponent<SpriteRenderer>().sprite = XSpriteHead;


                Head.transform.localPosition = new Vector3(.24f , 0, -1f);

                spriteRenderer.flipX = false;
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(-.05f * Time.timeScale, 0, 0);
                spriteRenderer.sprite = XSprite;
                Head.GetComponent<SpriteRenderer>().sprite = XSpriteHead;


                Head.transform.localPosition = new Vector3(-.24f , 0, -1f);

                spriteRenderer.flipX = true;
            }

            if (Input.anyKey)
                EngineSound.volume = .4f;
            else
                EngineSound.volume = .2f;
        }

       
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit")
        {
            gameObject.transform.position = new Vector3(100,100,0);
            StartCoroutine(win());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Tank"))
        {
            dead = true;
            StartCoroutine(loseCake());
        }
    }

    IEnumerator win()
    {
        EngineSound.volume = 0f;
        noice.Play();
        gameObject.transform.GetChild(5).gameObject.transform.SetParent(null);



        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("MaxLevel", 1);
        PlayerPrefs.SetInt("LastGame", 1);
        PlayerPrefs.SetInt("Looped",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");

    }
    IEnumerator loseCake()
    {
        Head.SetActive(false);

        EngineSound.volume = 0f;
        spriteRenderer.sprite = Smoke;
        MissionFaild.Play();
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel", 5);
        PlayerPrefs.SetInt("LastGame", 0);
        PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") - 1);

        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScreen");
    }

}
