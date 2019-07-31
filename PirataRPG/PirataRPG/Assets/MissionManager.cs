using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Entities;
using UnityEngine;
using System.Linq;

public class MissionManager : MonoBehaviour
{
    List<Mission> loadedMissions = new List<Mission>();
    List<MissionTask> taskRemoved = new List<MissionTask>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (Mission mission in GetNextMission())
        //{
        //    foreach (MissionTask task in mission.MissionTasks)
        //    {
        //        if (ConditionsMet(task))
        //        {
        //            ExecuteActions(task);
        //            taskRemoved.Add(task);
        //        }
        //    }


        //    foreach (var missionTask in taskRemoved)
        //    {
        //        mission.MissionTasks.Remove(missionTask);
        //    }
        //}

    }

    //private bool ConditionsMet(MissionTask task)
    //{
    //    bool result = true;

    //    foreach (TaskCondition condition in task.TaskConditions)
    //    {
    //        switch (condition.Type)
    //        {
    //            case TaskCondition.TaskConditionType.CloseTo:
    //                break;
    //            case TaskCondition.TaskConditionType.Destroyed:
    //                break;
    //            case TaskCondition.TaskConditionType.Inventoried:
    //                break;
    //            case TaskCondition.TaskConditionType.KeyPressed:
    //                break;
    //        }
    //    }
    //}

    public void LoadMissions(XmlDocument xmlDoc)
    {
        Mission newMission;
        MissionTask newMissionTask;
        TaskCondition newTaskCondition;
        TaskAction newTaskAction;

        var selectedNodes =
            xmlDoc.SelectNodes("//level/missions/mission");

        foreach (XmlNode currentNode in selectedNodes)
        {
            newMission = new Mission
            {
                id = currentNode.Attributes["id"].Value,
                description = currentNode.Attributes["description"].Value,
                prerequisites = currentNode.Attributes["prerequisites"].Value
            };

            newMission.MissionTasks = new List<MissionTask>();


            var selectedTask =
                xmlDoc.SelectNodes(string.Format("//level/missions/mission[@id='{0}']/tasks/task",newMission.id));

            foreach (XmlNode currentTask in selectedTask)
            {
                newMissionTask = new MissionTask
                {
                    id = currentTask.Attributes["id"].Value,
                    description = currentTask.Attributes["description"].Value

                };
                newMissionTask.TaskConditions = new List<TaskCondition>();

                var selectedTaskConditions = xmlDoc.SelectNodes(string.Format("//level/missions/mission[@id='{0}']/tasks/task[@id='{1}']/conditions/condition", newMission.id,newMissionTask.id));
                foreach (XmlNode currentTaskCondition in selectedTaskConditions)
                {
                    newTaskCondition = new TaskCondition
                    {
                        Type = (TaskCondition.TaskConditionType) Enum.Parse(typeof(TaskCondition.TaskConditionType),
                            currentTaskCondition.Attributes["type"].Value),
                        uniqueObjectNameFrom = currentTaskCondition.Attributes["uniqueObjectNameFrom"].Value,
                        uniqueObjectNameTo = currentTaskCondition.Attributes["uniqueObjectNameTo"].Value
                    };
                    newMissionTask.TaskConditions.Add(newTaskCondition);
                }

                newMissionTask.TaskActions = new List<TaskAction>();

                var selectedTaskActions = xmlDoc.SelectNodes(string.Format("//level/missions/mission[@id='{0}']/tasks/task[@id='{1}']/actions/action", newMission.id, newMissionTask.id));
                foreach (XmlNode currentTaskCondition in selectedTaskActions)
                {
                    newTaskAction = new TaskAction
                    {
                        Type = (TaskAction.TaskActionType)Enum.Parse(typeof(TaskAction.TaskActionType),
                            currentTaskCondition.Attributes["type"].Value),
                        uniqueObjectNameFrom = currentTaskCondition.Attributes["uniqueObjectNameFrom"].Value,
                        uniqueObjectNameTo = currentTaskCondition.Attributes["uniqueObjectNameTo"].Value
                    };

                    newMissionTask.TaskActions.Add(newTaskAction);
                }
                newMission.MissionTasks.Add(newMissionTask);
            }

            loadedMissions.Add(newMission);
        }
    }

    List<Mission> GetNextMission()
    {
        return loadedMissions.Where(m => string.IsNullOrEmpty(m.prerequisites)).ToList();
    }

    void CheckPrerequistes(string missionId)
    {
        foreach (Mission mission in loadedMissions.Where(m => m.prerequisites.Split(',').Contains(missionId)))
        {
            List<string> newPrerequisites = mission.prerequisites.Split(',').ToList();
            newPrerequisites.Remove(missionId);
            mission.prerequisites = JoinPrerequistes(newPrerequisites);

        }
    }

    string JoinPrerequistes(List<string> prerequisites)
    {
        string str = string.Empty;


        foreach (string prerequisite in prerequisites)
        {
            str += prerequisite + ",";
        }

        str.Remove(str.Length - 1);
        return str;
    }
}
