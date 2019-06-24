using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (cycle >= 5)
            SpikeHit = false;

        Debug.Log(cycle);

    }

    public void OnHitted()
    {
        if (!SpikeHit)
        {
            HitPoints--;
            Destroy(GameObject.Find("HitPoints").transform.GetChild(0).gameObject);

            if (HitPoints == 0)
            {
                //Game Over
                gameObject.SetActive(false);
            }

            SpikeHit = true;
        }

    }

    IEnumerator StartGrace()
    { 


            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            animator.enabled = false;
            cycle++;

            yield return new WaitForSeconds(2);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            animator.enabled = true;





    }

}
