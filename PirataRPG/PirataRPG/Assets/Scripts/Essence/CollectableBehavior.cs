using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    private float accelX = -10f;

    private float currentSpeedX = 0;

    private float deltaX;

    private BoatPlayerBehavior boatPlayerBehavior;

    private ScoreController scoreController;

    private bool SpikeHit = false;
    // Start is called before the first frame update

    void Awake()
    {
        boatPlayerBehavior = GameObject.Find("BoatBoi").GetComponent<BoatPlayerBehavior>();
        scoreController = GameObject.Find("Global Scripts").GetComponent<ScoreController>();
    }
    void Start()
    {
        //Vf = V0 + at
        currentSpeedX += accelX * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Xf = X0 + V0t + (at^2)/2
        deltaX = currentSpeedX * Time.deltaTime + accelX * (Mathf.Pow(Time.deltaTime,2))/2;
        transform.Translate(new Vector3(deltaX,0f));
        currentSpeedX += accelX * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Enemy" && other.gameObject.name == "BoatBoi")
        {

                boatPlayerBehavior.OnHitted();
            
                Debug.Log("SpikeHit");
            

        }
        else if(other.gameObject.name == "BoatBoi")
        {
            scoreController.AddEssence(gameObject.tag);
        }
        Destroy(gameObject);

    }

}
