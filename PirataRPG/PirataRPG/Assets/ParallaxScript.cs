using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Renderer quadRenderer;

    float scrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        quadRenderer = GetComponent<Renderer>();

        switch (gameObject.name)
        {

            case "L3":
                scrollSpeed = .15f;
                break;

            case "L4":
                scrollSpeed = 1.5f;
                break;
            case "L5":
                scrollSpeed = .07f;
                break;
            case "L6":
                scrollSpeed = .03f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 textureOffset = new Vector2(Time.time * scrollSpeed, 0);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
}
