using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapPlatformerManager : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    
   public GameObject Player;
   public GameObject Mace;

    private XmlDocument xmlDoc;
    private const string xmlPath = "plat";

    private GameObject newCell;

    private bool _isBG;

    void Awake()
    {
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Resources.Load<TextAsset>(xmlPath).text);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadMap(0, 128, 0, 128);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadMap(int xFrom, int xTo, int yFrom, int yTo)
    {
        int xFromCopy = xFrom;
        var selectedNodes =
            xmlDoc.SelectNodes(string.Format("//map/row[position()>={0} and position()<={1}]", yFrom, yTo));

        //Tiles
        foreach (XmlNode currentNode in selectedNodes)
        {
            for (xFrom = xFromCopy; xFrom <= xTo && xFrom < currentNode.InnerText.Length; xFrom++)
            {
                switch (currentNode.InnerText[xFrom])
                {
                    case 'A':
                        newCell = A;
                        _isBG = true;
                        break;

                    case 'B':
                        newCell = B;
                        _isBG = false;
                        break;


                }
                
                if(_isBG)
                Instantiate(newCell, new Vector3(xFrom, -yFrom,4), Quaternion.identity);
                else
                    Instantiate(newCell, new Vector3(xFrom, -yFrom), Quaternion.identity);

            }

            yFrom++;
        }

        selectedNodes = xmlDoc.SelectNodes("//level/characters/character");


        foreach (XmlNode currentNode in selectedNodes) // For every character...
        {
            switch (currentNode.Attributes["prefabName"].Value)
            {
                case "Player":
                    newCell = Player;
                    break;

                case "Mace":
                    newCell = Mace;
                    break;


            }

            newCell = Instantiate(newCell, new Vector3(Convert.ToSingle(currentNode.Attributes["posX"].Value), -Convert.ToSingle(currentNode.Attributes["posY"].Value), -0.04f), Quaternion.identity);
            newCell.name = currentNode.Attributes["uniqueObjectName"].Value;
            newCell.tag = currentNode.Attributes["tag"].Value;
            if (newCell.tag == "Player")
            {
                Camera.main.transform.SetParent(newCell.transform);
                Camera.main.transform.localPosition = new Vector3(0, 0, -10);
            }
        }

        selectedNodes = xmlDoc.SelectNodes("//level/items/item");



        foreach (XmlNode currentNode in selectedNodes)
        {
            switch (currentNode.Attributes["prefabName"].Value)
            {
                
            }

            newCell = Instantiate(newCell,
                new Vector3(Convert.ToSingle(currentNode.Attributes["posX"].Value),
                    -Convert.ToSingle(currentNode.Attributes["posY"].Value)), Quaternion.identity);
            newCell.name = currentNode.Attributes["uniqueObjectName"].Value;
            newCell.tag = currentNode.Attributes["tag"].Value;

        }
    }
}
