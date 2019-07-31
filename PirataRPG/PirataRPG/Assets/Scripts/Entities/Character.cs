using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Character
    {
        #region "Attributes"
        private GameObject gameObject;
        public int Id { get; set; }
        public string UniqueObjectName { get; set; }
        public string PrefabName { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public string Tag { get; set; }
        #endregion

        #region "Behaviour"

        public Character()
        {

        }

        public Character(GameObject prefab, int id, string uniqueObjectName, string prefabName, float posX, float posY, string tag)
        {
            gameObject = UnityEngine.Object.Instantiate(prefab, new Vector3(posX, posY), Quaternion.identity);
            Id = id;
            UniqueObjectName = uniqueObjectName;
            PrefabName = prefabName;
            PosX = posX;
            PosY = posY;
            Tag = tag;
        }
        #endregion

    }
}
