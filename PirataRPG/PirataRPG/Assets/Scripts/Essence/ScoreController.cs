using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    Dictionary<string, int> essenceScores = new Dictionary<string, int>
    {
        {"Blue",0 },
        {"Red", 0},
        {"Yellow", 0},
        {"Green", 0},
        {"Purple", 0},
        {"Orange", 0}
    };

    public TextMesh BlueText;
    public TextMesh GreenText;
    public TextMesh OrangeText;
    public TextMesh PurpleText;
    public TextMesh RedText;
    public TextMesh YellowText;



    // Start is called before the first frame update
    void Start()
    {
        ResetTextScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEssence(string Tag)
    {
        essenceScores[Tag]++;

        switch (Tag)
        {
            case "Blue":
                BlueText.text = essenceScores[Tag].ToString();
                break;
            case "Red":
                RedText.text = essenceScores[Tag].ToString();
                break;
            case "Green":
                GreenText.text = essenceScores[Tag].ToString();
                break;
            case "Orange":
                OrangeText.text = essenceScores[Tag].ToString();
                break;
            case "Purple":
               PurpleText.text = essenceScores[Tag].ToString();
                break;
            case "Yellow":
                YellowText.text = essenceScores[Tag].ToString();
                break;



        }
    }

   public void ResetTextScores()
    {

        BlueText.text = essenceScores["Blue"].ToString();

        GreenText.text = essenceScores["Green"].ToString();
        OrangeText.text = essenceScores["Orange"].ToString();
        PurpleText.text = essenceScores["Purple"].ToString();
        RedText.text = essenceScores["Red"].ToString();
        YellowText.text = essenceScores["Yellow"].ToString();
    }
}
