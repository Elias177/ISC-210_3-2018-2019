using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerBehavior : MonoBehaviour
{ 
    bool _isLeftPlayer;
    private float _speed = 10f;
    Vector3 _deltaPos;
    const float UPPERLIMIT = 3.38f;
    const float LOWERLIMIT = -3.38f;
    static bool _onePlayer;
    private GameObject _ball;

    private void Awake()
    {
        _isLeftPlayer = gameObject.name == "LeftPlayer";
        _ball  = GameObject.Find("Ball");
    }


    // Start is called before the first frame update
    void Start()
    {
        _onePlayer = true; //test
    }

    // Update is called once per frame
    void Update()
    {

        float desde, hasta;

        desde = gameObject.transform.position.y < _ball.transform.position.y
            ? gameObject.transform.position.y
            : _ball.transform.position.y;

        hasta = gameObject.transform.position.y > _ball.transform.position.y
            ? gameObject.transform.position.y
            : _ball.transform.position.y;

        if (_onePlayer && !_isLeftPlayer)
        {
            transform.position = new Vector3(transform.position.x,Mathf.Clamp(Mathf.Lerp(desde,hasta,0.5f),LOWERLIMIT,UPPERLIMIT),transform.position.z);
        }


        _deltaPos = new Vector3(0f,(_isLeftPlayer ? Input.GetAxis("LeftPlayer")  : Input.GetAxis("RightPlayer")) * _speed * Time.deltaTime);
        
        transform.Translate(_deltaPos); 


        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,LOWERLIMIT,UPPERLIMIT),transform.position.z);
    }
}
