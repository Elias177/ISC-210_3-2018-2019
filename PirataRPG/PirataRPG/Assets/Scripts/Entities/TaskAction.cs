namespace Assets.Scripts.Entities
{
    public class TaskAction
    {
        public enum TaskActionType
        {
            ShowMessage,
            InventoryAdd,
            LoadScene
        }

        public TaskActionType Type { get; set; }
        public string uniqueObjectNameFrom { get; set; }
        public string uniqueObjectNameTo { get; set; }
    }
}