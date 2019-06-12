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
    

    public TextMesh Score;

    public GameObject DisplayScore;

    private Vector3 TextPosition;

    private List<GameObject> TouchPegs = new List<GameObject>();

    public GameObject PlayScore;

    private int barIncrement = 1;

    public AudioSource PegCollison;
    private int multiplier = 0;

    public GameObject PeggArray;


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

            DisplayScore.SetActive(true);
            TextPosition = collision.gameObject.transform.position;
            DisplayScore.transform.position = TextPosition;
            StartCoroutine(DisplayText());
            
            PegCollison.Play();
            PegCollison.pitch = PegCollison.pitch + 0.1f;
            
        }


    }


    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "ScorePlane")
        {
            PlayScore.GetComponent<TextMesh>().text = NewScore + " x " + TouchPegs.Count + "\n\t" + NewScore * TouchPegs.Count;
            PlayScore.SetActive(true);
            StartCoroutine(DisplayPlayText());
        }

        if (collision.gameObject.tag == "KillPlane" || collision.gameObject.name == "BucketPlane")
        {
            OldScore = Convert.ToInt32(Score.text) + (NewScore* TouchPegs.Count);
            SetCountText(OldScore);

          

            foreach (var peg in TouchPegs)
            {
                peg.SetActive(false);
            }

            TextPosition = collision.gameObject.transform.position;
            DisplayScore.transform.position = TextPosition;

            if(gameObject.activeSelf)
            StartCoroutine(DisplayText());
            
         
          
            TouchPegs.Clear();
            PeggArray.SendMessage("CheckOrange");
            PegCollison.pitch = 1;
        }

    }

    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(.8f);

        DisplayScore.SetActive(false);
    }

    private IEnumerator DisplayPlayText()
    {
        yield return new WaitForSeconds(.8f);

        PlayScore.SetActive(false);

    }


    void SetCountText(int value)
    {
        Score.text = value.ToString();
    }

}
