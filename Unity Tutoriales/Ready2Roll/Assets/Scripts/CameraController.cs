using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject chungus;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - chungus.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = chungus.transform.position + offset;
    }
}
