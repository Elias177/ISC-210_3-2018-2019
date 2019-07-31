using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour2 : MonoBehaviour
{
    private bool _isLoose = false;
    private bool _isStop = false;
    private float _speed = 10f;
    public AudioSource SlideCherry;
    private bool _Played;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !_Played)
        {
            _isLoose = true;
            if (!_Played)
            {
                SlideCherry.Play();
                _Played = true;

            }

        }

        if (_isLoose && !_isStop)
        {
            transform.Translate(0, -_speed * Time.deltaTime, 0);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            _isStop = true;
        }
    }
}
