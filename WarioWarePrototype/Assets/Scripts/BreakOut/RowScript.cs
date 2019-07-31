using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    private bool _powered;



    // Start is called before the first frame update
    void Awake()
    {
        int decider = Random.Range(0, 2);

        if (decider == 1)
        {
            int block = Random.Range(0, 11);
            gameObject.transform.GetChild(block).SendMessage("HasPower");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
