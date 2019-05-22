using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChungusController : MonoBehaviour
{

    

    public float speed;
    public Text scoreText;
    public Text winText;
    public AudioSource bite;

    private Rigidbody rb;
    private int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        scoreCount = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(Horizontal, 0.0f, Vertical);

        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carrot"))
        {
            other.gameObject.SetActive(false);
            scoreCount = scoreCount + 1;
            SetCountText();
            bite.Play();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Carrots: " + scoreCount.ToString();
        if (scoreCount >= 11)
        {
            winText.text = "Exito!";
        }
    }
}
