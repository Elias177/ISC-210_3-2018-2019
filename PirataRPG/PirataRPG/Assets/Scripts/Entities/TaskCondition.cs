namespace Assets.Scripts.Entities
{
    public class TaskCondition
    {
        public enum TaskConditionType
        {
            CloseTo,
            KeyPressed,
            Destroyed,
            Inventoried
        }

        public TaskConditionType Type { get; set; }
        public string uniqueObjectNameFrom { get; set; }
        public string uniqueObjectNameTo { get; set; }
    }
}