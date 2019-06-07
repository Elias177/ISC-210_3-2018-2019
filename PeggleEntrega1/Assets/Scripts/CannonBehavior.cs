﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private Vector3 _mousePosition;
    private float _angle;
    private Vector3 _cameraPoints;
    private Vector2 _offsetPoints;
    public GameObject Ball;
   


    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetMouseButtonUp(0) && !Ball.activeSelf)
        {

            Ball.transform.SetParent(null);
            Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            Ball.GetComponent<Rigidbody>().useGravity = true;
            Ball.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ball.GetComponent<Rigidbody>().AddForce(ray.origin.x, 0, 0, ForceMode.Impulse);
            
        }
    }
}
