using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject A;

    public GameObject B;

    public GameObject C;

    public GameObject D;

    public GameObject E;

    public GameObject F;

    public GameObject G;

    public GameObject H;

    public GameObject I;

    public GameObject J;

    public GameObject K;

    public GameObject Soldier;


    private XmlDocument xmlDoc;
    private const string xmlPath = "level1";
    private GameObject newCell;

    public MissionManager MissionManager;

    void Awake()
    {
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Resources.Load<TextAsset>(xmlPath).text);
    }

    void LoadMap(int xFrom, int xTo, int yFrom, int yTo)
    {
        int xFromCopy = xFrom;
        var selectedNodes =
            xmlDoc.SelectNodes(string.Format("//map/row[position()>={0} and position()<={1}]", yFrom, yTo));

        foreach (XmlNode currentNode in selectedNodes)
        {
            for (xFrom = xFromCopy; xFrom <= xTo && xFrom < currentNode.InnerText.Length; xFrom++)
            {
                switch (currentNode.InnerText[xFrom])
                {
                    case 'A':
                        newCell = A;
                        break;

                    case 'B':
                        newCell = B;
                        break;

                    case 'C':
                        newCell = C;
                        break;

                    case 'D':
                        newCell = D;
                        break;

                    case 'E':
                        newCell = E;
                        break;

                    case 'F':
                        newCell = F;
                        break;

                    case 'G':
                        newCell = G;
                        break;

                    case 'H':
                        newCell = H;
                        break;

                    case 'I':
                        newCell = I;
                        break;

                    case 'J':
                        newCell = J;
                        break;

                    case 'K':
                        newCell = K;
                        break;

                   
              }

                Instantiate(newCell, new Vector3(xFrom, -yFrom,1), Quaternion.identity);
            }

            yFrom++;
        }
        selectedNodes = xmlDoc.SelectNodes("//level/characters/character");


        foreach (XmlNode currentNode in selectedNodes) // For every character...
        {
            switch (currentNode.Attributes["prefabName"].Value)
            {
                case "Soldier":
                    newCell = Soldier;
                    break;

              
            }

            newCell = Instantiate(newCell, new Vector3(Convert.ToSingle(currentNode.Attributes["posX"].Value), -Convert.ToSingle(currentNode.Attributes["posY"].Value)), Quaternion.identity);
            newCell.name = currentNode.Attributes["uniqueObjectName"].Value;
            newCell.tag = currentNode.Attributes["tag"].Value;
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadMap(0,73,0,40);
        MissionManager.LoadMissions(xmlDoc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
