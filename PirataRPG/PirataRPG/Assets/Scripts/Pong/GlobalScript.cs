using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GlobalScript : MonoBehaviour
{
    public int LeftScore;
    public int RightScore;



    public TextMesh LeftScoreText;
    public TextMesh RightScoreText;
    public AudioSource Error;
    public AudioSource Success;

    // Start is called before the first frame update
    void Start()
    {
        LeftScore = 0;
        RightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Score s = new Score();
            StartCoroutine(SendRequest("http://localhost:2468/api/Score/GetScores"));
            Debug.Log("********************");
            StartCoroutine(PostRequest("http://localhost:2468/api/Score", s));

        }
    }

    public void IncrementScore(bool IsLeftPlayer, bool oneplayer)
    {
        if (IsLeftPlayer)
        {
            LeftScore++;
            LeftScoreText.text = LeftScore.ToString();

            if (oneplayer)
                Error.Play();
            else
                Success.Play();

            
        }

        else
        {
            RightScore++;
            RightScoreText.text = RightScore.ToString();

            Success.Play();

        }

    }


    IEnumerator SendRequest(string url)
    {

        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        Debug.Log(webRequest.downloadHandler.text);

    }

    IEnumerator PostRequest(string url, Score newScore)
    {

        string score = JsonUtility.ToJson(newScore);
        UnityWebRequest webRequest = UnityWebRequest.Put(url, score);
       webRequest.SetRequestHeader("Content-Type", "application/json");
       
        yield return webRequest.SendWebRequest();

        Debug.Log(webRequest.downloadHandler.text);

    }

    [Serializable]
    public class Score : object
    {

        public string PlayerName = "Unity";
        public float Score1 = 100f;

    }
}
