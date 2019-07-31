using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class PlayerIndoorScript : MonoBehaviour
{

    private Animator animator;

    bool _isLeftPlayer;
    private float _speed = 10f;
    Vector3 _deltaPos;
    Vector3 _deltaY;


    private int _health;

    private bool _dead = false;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("Mute") == 1)
            AudioListener.pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
            _deltaPos = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0f);
            _deltaY = new Vector3( 0f, Input.GetAxis("Vertical") * _speed * Time.deltaTime);

            transform.Translate(_deltaPos);
            transform.Translate(_deltaY);


            if (!_dead)
            {
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

                if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)
                {

                    animator.SetBool("IsMoving", true);

                }


                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    animator.SetBool("IsMoving", false);

                }


        }


    }

    void OnTriggerStay(Collider other)
    {
        
        if(Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(other.gameObject.name);
           
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Soldier"))
        {
            _dead = true;
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Exploration");



    }

}




