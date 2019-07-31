using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    private Animator animator;

    bool _isLeftPlayer;
    private float _speed = 10f;
    Vector3 _deltaPos;
    Vector3 _deltaY;

    private bool _isJumping = false;
    private bool _lock = true;
    private bool _onFloor = true;
    public AudioSource Jump;
    public AudioSource Hit;

    private bool _Played;
    private bool _dead;


    private int _health;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        _health = 3;
        animator.SetInteger("Health",_health);
        if(PlayerPrefs.GetInt("Mute") == 1)
            AudioListener.pause = true;

    }

    // Update is called once per frame
    void Update()
    {


        if (!_dead)
        {

            _deltaPos = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0f);

            transform.Translate(new Vector3(_deltaPos.x, _deltaY.y));

            if (!_onFloor)
            {
                transform.Translate(new Vector3(0, -.1f));

            }

            if (Input.GetButtonDown("Fire1") || _isJumping)
            {
                if (!_Played)
                {
                    Jump.Play();
                    _Played = true;
                }

                transform.Translate(new Vector3(0, .3f));

                _isJumping = true;

                StartCoroutine(Jumping());


            }






            if (Input.GetAxis("Horizontal") < 0)
            {


                GetComponent<SpriteRenderer>().flipX = true;

                animator.SetBool("IsMoving", true);

            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                animator.SetBool("IsMoving", true);


            }


            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.SetBool("IsMoving", false);

            }


        }


        //  transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LOWERLIMIT, UPPERLIMIT), transform.position.z);

        Debug.Log("Floor "+ _onFloor);

    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "BreakOut":
                SceneManager.LoadScene("BreakOut");
                break;
            case "Essence":
                SceneManager.LoadScene("Essence");
                break;
        }

        if (other.gameObject.tag == "Floor" && !_isJumping)
        {
            _onFloor = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            _dead = true;
            StartCoroutine(Dead());
        }




    }

    void OnTriggerEnter()
    {
        _dead = true;
        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(Finish());
    }

    IEnumerator Jumping()
    {
        _isJumping = true;
        _onFloor = false;
        yield return new WaitForSeconds(.23f);

        _isJumping = false;
        _Played = false;

    }

    IEnumerator Dead()
    {
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Platformer");



    }
    IEnumerator Finish()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Exploration");



    }
}
