using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets.Scripts.Entities
{
    public class MissionTask
    {
        public string id { get; set; }
        public string description { get; set; }

        public string prerequisites { get; set; }
        public List<TaskAction> TaskActions { get; set; }
        public List<TaskCondition> TaskConditions { get; set; } 
    }
}

