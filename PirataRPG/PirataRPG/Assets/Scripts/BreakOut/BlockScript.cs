using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private int _hitpoints;
    private bool _haspower;
    private GameObject PowerUp;
    private GameObject BlocksText;

    // Start is called before the first frame update
    void Awake()
    {
        PowerUp = GameObject.Find("Power");
        BlocksText = GameObject.Find("Bricks");
        switch (gameObject.transform.parent.tag)
        {
            case "BottomRow":
                _hitpoints = 1;
                break;

            case "MiddleBottomRow":
                _hitpoints = 2;
                break;

            case "MiddleRow":
                _hitpoints = 3;
                break;

            case "MiddleTopRow":
                _hitpoints = 4;
                break;

            case "TopRow":
                _hitpoints = 5;
                break;
        }

        if (gameObject.name == "power")
        {
            _haspower = true;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
            _hitpoints--;
        }

        if (_hitpoints <= 0)
        {
            gameObject.SetActive(false);

            BlocksText.GetComponent<TextMesh>().text = (Convert.ToInt32(BlocksText.GetComponent<TextMesh>().text) + 1).ToString();
          if(_haspower)
              Instantiate(PowerUp, transform.position, Quaternion.identity);
        }
        
    }

    void HasPower()
    {
        _haspower = true;

    }
}
