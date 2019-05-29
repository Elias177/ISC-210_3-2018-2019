using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerBehavior : MonoBehaviour
{ 
    bool _isLeftPlayer;
    private float _speed = 10f;
    Vector3 _deltaPos;
    const float UPPERLIMIT = 3.3f;
    const float LOWERLIMIT = -3.3f;

    private void Awake()
    {
        _isLeftPlayer = gameObject.name == "LeftPlayer";
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos = new Vector3(0f,(_isLeftPlayer ? Input.GetAxis("LeftPlayer") : Input.GetAxis("RightPlayer")) * _speed * Time.deltaTime);
        
        transform.Translate(_deltaPos);
        Debug.Log(_deltaPos);

        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,LOWERLIMIT,UPPERLIMIT),transform.position.z);
    }
}
