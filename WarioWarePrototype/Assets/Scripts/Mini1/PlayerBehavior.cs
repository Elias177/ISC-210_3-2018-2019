using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private bool _isJumping = false;
    private float _speed = 10f;
    public Sprite IdleSprite;
    public Sprite JumpSprite;
    public Sprite HitSprite;
    private SpriteRenderer spriteRenderer;
    private bool _lock = true;

    public AudioSource Jump;
    public AudioSource Hit;
    public AudioSource Scream;

    private bool _Played;
    private bool _PlayedHit;

  
    
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_PlayedHit)
        {
            if ((Input.GetButtonDown("Fire1") || _isJumping) && _lock)
            {
                if (!_Played)
                {
                    Jump.Play();
                    _Played = true;
                }

                _isJumping = true;
                spriteRenderer.sprite = JumpSprite;
                if (transform.position.y < 6)
                {
                    transform.Translate(0, _speed * Time.deltaTime, 0);

                }

                if (transform.position.y >= 4)
                {
                    _isJumping = false;
                }
            }

            if (!_isJumping && transform.position.y > -2.2f)
            {
                _lock = false;
                transform.Translate(0, -_speed * Time.deltaTime, 0);

            }

            if (transform.position.y <= -2.2f)
            {
                spriteRenderer.sprite = IdleSprite;
                _lock = true;
                _Played = false;
            }

            
        }

        if (_PlayedHit)
        {
            transform.Translate(-.5f, 0, 0);

        }

    }

    void OnCollisionEnter(Collision col)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(fail());
        

    }

    IEnumerator fail()
    {
        spriteRenderer.sprite = HitSprite;

        if (!_PlayedHit)
        {
            Scream.Play();

            Hit.Play();
            _PlayedHit = true;
        }
        yield return new WaitForSeconds(3);

        PlayerPrefs.SetInt("MaxLevel",PlayerPrefs.GetInt("MaxLevel") + 1);
        PlayerPrefs.SetInt("LastGame", 0);
        PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") - 1);

        PlayerPrefs.Save();


        SceneManager.LoadScene("MainScreen");


    }



}
