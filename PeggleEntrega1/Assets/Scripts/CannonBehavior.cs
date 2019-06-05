using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private Vector3 _mousePosition;
    private float _angle;
    private Vector3 _cameraPoints;
    private Vector2 _offsetPoints;
    public GameObject ball;

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
        if (Input.GetButtonDown("Fire1"))
        {

            ball.transform.SetParent(null);
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.SetActive(true);
           
        }
    }
}
