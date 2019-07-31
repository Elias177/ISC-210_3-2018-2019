using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{

    public Sprite Mute;
    public Sprite Sound;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("Mute", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (spriteRenderer.sprite == Sound)
        {
            spriteRenderer.sprite = Mute;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Mute",1);
            PlayerPrefs.Save();
        }
        else
        {
            spriteRenderer.sprite = Sound;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("Mute", 0);
            PlayerPrefs.Save();
        }
    }
}
