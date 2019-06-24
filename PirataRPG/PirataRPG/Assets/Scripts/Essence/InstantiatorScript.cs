using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorScript : MonoBehaviour
{

    public List<GameObject> Essences;
    public GameObject Spike;

    private float _spikeRatio = 0.3f;

    private const int _essenceQuantity = 6;

    private float _nextTime;
    private const float _LOWERTIME = 1f;
    private const float _UPPERTIME = 2f;
    private const float NORTHLIMIT = 4f;
    private const float SOUTHLIMIT = -4f;


    private GameObject _newObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiatorCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiatorCorutine()
    {
        _nextTime = Random.Range(_LOWERTIME, _UPPERTIME);


        while (true)
        {
            yield return new WaitForSeconds(_nextTime);

            if (Random.Range(0f, 1f) > _spikeRatio % 1)
                _newObject = Spike;
            else
            {
                _newObject = Essences[Random.Range(0, 6)];
            }

            Instantiate(_newObject, new Vector3(11f, Random.Range(SOUTHLIMIT, NORTHLIMIT)), Quaternion.identity);
            _spikeRatio *= 1.2f;
        }
    }
}
