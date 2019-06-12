using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PegHandler : MonoBehaviour
{

    List<GameObject>  _OrangePegs = new List<GameObject>(23);

    System.Random rnd = new System.Random();

    private int selector = 0;
    private int endCount = 0;

    public Material Orange;

    public GameObject win;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < _OrangePegs.Capacity; i++)
        {
            selector = rnd.Next(0, 96);

       
            gameObject.transform.GetChild(selector).GetComponent<MeshRenderer>().material.color = Color.yellow;

            _OrangePegs.Add(gameObject.transform.GetChild(selector).gameObject);
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOrange()
    {
        foreach (var orangePeg in _OrangePegs)
        {
            if (!orangePeg.activeSelf)
                endCount++;
        }

        if (endCount == _OrangePegs.Count)
        {
            win.SetActive(true);
        }

    }
}
