using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehavior : MonoBehaviour
{

    private Rigidbody _ball;

    private int cont;
    private int OldScore;
    private int NewScore;

    public GameObject Head;

    public TextMesh Score;

    public GameObject DisplayScore;

    private Vector3 TextPosition;

    private List<GameObject> TouchPegs = new List<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        _ball = GetComponent<Rigidbody>();
        OldScore = 0;
        NewScore = 0;
}

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Peg")
        {
            TouchPegs.Add(collision.gameObject);
            NewScore += 10;
            Debug.Log(NewScore);

            DisplayScore.SetActive(true);
            TextPosition = collision.gameObject.transform.position;
            DisplayScore.transform.position = TextPosition;
            StartCoroutine(DisplayText());


        }


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "KillPlane" || collision.gameObject.name == "BucketPlane")
        {
            OldScore = Convert.ToInt32(Score.text) + NewScore;
            SetCountText(OldScore);
            Debug.Log(OldScore + " Old");

            foreach (var peg in TouchPegs)
            {
                peg.SetActive(false);
            }

            TextPosition = collision.gameObject.transform.position;
            DisplayScore.transform.position = TextPosition;
            StartCoroutine(DisplayText());

        }

    }

    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(.8f);

        DisplayScore.SetActive(false);
    }


    void SetCountText(int value)
    {
        Score.text = value.ToString();
    }

}
