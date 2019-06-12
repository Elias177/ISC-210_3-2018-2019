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

        if (Input.GetMouseButtonUp(0) && Guide.activeSelf)
        {

            Guide.SetActive(false);
            

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ball.GetComponent<Rigidbody>().AddForce(ray.origin.x, 0, 0, ForceMode.Impulse);


            
        }
    }
}
