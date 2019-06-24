using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource EssenceFX;
    public AudioSource SpikeHit;
    public AudioSource BGMusic;
    public AudioSource Boom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEssenceFX()
    {
        EssenceFX.Play();
    }
    public void SpikePlay()
    {
        SpikeHit.Play();
    }
    public void BoomPlay()
    {
        Boom.Play();
    }

    public void BGMuiscPlay()
    {
        BGMusic.Play();
    }
}
