using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Analytics;

namespace Assets.Scripts.Entities
{
    class Game
    {
        public string PlayerName { get; set; }

        public Level CurrentLevel { get; set; }

        private static Game _instance;

        public Game Instance()
        {
            if (_instance == null)
            {
                _instance = new Game();
                _instance.CurrentLevel = new Level();
                _instance.CurrentLevel.Characters = new List<Character>();
             //   _instance.CurrentLevel.Items = new List<Item>();

            }

            return _instance;
        }
    }
}
