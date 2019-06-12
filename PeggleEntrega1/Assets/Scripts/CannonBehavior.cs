using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private Vector3 _mousePosition;
    private float _angle;
    private Vector3 _cameraPoints;
    private Vector2 _offsetPoints;
    private GameObject Ball;
    public GameObject BallQueue;
    public GameObject Guide;
    public TextMesh BallCount;
    public AudioSource LaunchBall;
    public GameObject Perdiste;
    private bool _end =  false;



    // Start is called before the first frame update
    void Awake()
    {
        BallCount.text = "10";
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        _cameraPoints = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offsetPoints = new Vector2(_mousePosition.x - _cameraPoints.x, _mousePosition.y - _cameraPoints.y);
        _angle = Mathf.Atan2(_offsetPoints.y, _offsetPoints.x) * Mathf.Rad2Deg;
        
        if (_angle > -169 && _angle < -10)
        {
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
        ShootBall();
      
       

    }

    public void ShootBall()
    {
        if (BallQueue.transform.childCount <= 0)
        {
            Perdiste.SetActive(true);
            _end = true;
        }

        if (Input.GetMouseButtonUp(0) && Guide.activeSelf && !_end)
        {
            Debug.Log(BallQueue.transform.childCount);
            Guide.SetActive(false);
            BallCount.text = (Convert.ToInt32(BallCount.text) - 1).ToString();

            //If no children left game over.
            Ball = BallQueue.transform.GetChild(0).gameObject;
            Ball.transform.SetParent(gameObject.transform.GetChild(0));
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Ball.transform.position = gameObject.transform.GetChild(0).transform.position;
            Ball.GetComponent<Rigidbody>().useGravity = false;
            Ball.SetActive(false);



            Ball.transform.SetParent(null);
            Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            Ball.GetComponent<Rigidbody>().useGravity = true;
            Ball.SetActive(true);

            LaunchBall.Play();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ball.GetComponent<Rigidbody>().AddForce(ray.origin.x * 1.2f, 0, 0, ForceMode.Impulse);


            
        }
    }
}
