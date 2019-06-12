using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegFX : MonoBehaviour
{
    public Transform ParticlePrefab;

    void Start()
    {
        ParticlePrefab.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void OnTriggerEnter()
    {
        ParticlePrefab.GetComponent<ParticleSystem>().enableEmission = true;

        StartCoroutine(stopParticle());
    }

    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(.2f);
        ParticlePrefab.GetComponent<ParticleSystem>().enableEmission = true;

    }

}
