using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    bool? isLeftPlayer;

    private float _startingSpeed =  10f;
    private bool _wait = true;
    public AudioSource Boop;

    private bool dead = false;

    public GameObject HP;

    public GameObject DeadText;


    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        UpdateBallState();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftPlayer != null && Input.GetButtonDown("Fire1") && _wait && !dead) 
        {
            Debug.Log("FIREBALL");
            
            if (gameObject.transform.parent.transform.position.x < gameObject.transform.position.x)
                _startingSpeed = -_startingSpeed;

            gameObject.transform.SetParent(null);

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(_startingSpeed,_startingSpeed * (Random.Range(0,2) == 0 ? 1 : -1));

            _wait = false;
        }

        if (gameObject.tag == "ArkBall" && Input.GetButtonDown("Fire1") && _wait)
        {
            _startingSpeed = 5;
         

            if (gameObject.transform.parent.transform.position.x < gameObject.transform.position.x)
                _startingSpeed = -_startingSpeed;

            gameObject.transform.SetParent(null);

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(_startingSpeed, _startingSpeed * (Random.Range(0, 2) == 0 ? 1 : -1));

            _wait = false;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Boop.Play();

    }

    public void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag == "DeadZone")
        {

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.SetParent(Player.transform);

            Player.transform.position = new Vector3(0.13f, -4.43f,0);
            gameObject.transform.position = new Vector3(0.23f, -4.12f, 0);
            _wait = true;

            if (HP.transform.childCount > 0)
            {

                Destroy(HP.transform.GetChild(0).gameObject);
                Debug.Log(HP.transform.childCount);

            }
            else
            {
                dead = true;
                DeadText.SetActive(true);

            }
        }
    }

    public void UpdateBallState()
    {
        switch (transform.parent.name)
        {
            case "LeftPlayer":
                isLeftPlayer = true;
                break;
            case "RightPlayer":
                isLeftPlayer = false;
                break;
            default:
                isLeftPlayer = null;
                break;
                
        }

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        _wait = true;

    }
}
