using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{

    public GameObject Ball;
    public GameObject LeftPlayer;
    public GameObject RightPlayer;
    public GlobalScript GlobalScript;
    private bool _isLeftDeadZonel;

    // Start is called before the first frame update
    void Start()
    {
        _isLeftDeadZonel = gameObject.name == "LeftDeadZone";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Ball")
            return;

        GlobalScript.IncrementScore(_isLeftDeadZonel);

        

        Ball.transform.SetParent(_isLeftDeadZonel ? RightPlayer.transform : LeftPlayer.transform);

        Ball.transform.localPosition = new Vector3(_isLeftDeadZonel ? -2.5f : 2.5f,0);



        Ball.SendMessage("UpdateBallState");

        RightPlayer.transform.localPosition = new Vector3(7.70f, 0);
        LeftPlayer.transform.localPosition = new Vector3(-7.70f, 0);

    }

    
}
