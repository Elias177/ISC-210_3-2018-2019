using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BoatPlayerBehavior : MonoBehaviour
{
    private float _speed = 10f;
    private Vector3 _deltaPos;
    private Animator animator;
    private const float NORTHLIMIT = 4f;
    private const float SOUTHLIMIT = -4f;
    private const int _startingHitPoints = 3;
    public int HitPoints;
    private bool SpikeHit = false;
    private int cycle;

    public AudioSource Hit;
    public AudioSource Pick;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HitPoints = _startingHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos = new Vector3(0, Input.GetAxis("Vertical") * _speed * Time.deltaTime);

        animator.SetFloat("Orientation",_deltaPos.y);

        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y,SOUTHLIMIT,NORTHLIMIT));

        if (SpikeHit)
        {
            StartCoroutine(StartGrace());

        }

      
      
    }

    public void OnHitted()
    {
        if (!SpikeHit)
        {
            HitPoints--;

            if(HitPoints >= 0)
            Destroy(GameObject.Find("HitPoints").transform.GetChild(0).gameObject);

            if (HitPoints == 0)
            {
                //Game Over
                //ScoreClass sc = new ScoreClass {Id_Score = Random.Range(1,999999), Game = "Essence", Name = "Unity", Score = _score };
                StartCoroutine(PostRequest("http://localhost:3000/api/Scores"));
                StartCoroutine(ResetScene());
            }

            SpikeHit = true;
            Hit.Play();
        }

    }

    IEnumerator StartGrace()
    { 


            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            animator.enabled = false;
          

            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            animator.enabled = true;
            SpikeHit = false;


    }


    void OnTriggerEnter(Collider co)
    {
        if(co.gameObject.tag != "Enemy")
            _score++;
    }

    IEnumerator ResetScene()
    {
       

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Essence");
        _score = 0;
    }

    IEnumerator SendRequest(string url)
    {

        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        Debug.Log(webRequest.downloadHandler.text);

    }

    //IEnumerator PostRequest(string url, ScoreClass newScore)
    //{

       
    //    UnityWebRequest webRequest = UnityWebRequest.Put(url, JsonUtility.ToJson(newScore));
    //    webRequest.SetRequestHeader("Content-Type", "application/json");

    //    yield return webRequest.SendWebRequest();

    //    Debug.Log(webRequest.downloadHandler.text);

    //}

    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
       // form.AddField("Id_Score", cont);
        form.AddField("Score", _score);
        form.AddField("Id_Score", Random.Range(1,99999999));
        form.AddField("Name", "Unity");
        form.AddField("Game", "Essence");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        Debug.Log("Recibido: " + uwr.downloadHandler.text);

    }

    [Serializable]
    public class ScoreClass
    {
        public int Id_Score { get; set; }
        public string Name { get; set; }

        public float Score { get; set; }
        public string Game { get; set; }
          
    }

}
