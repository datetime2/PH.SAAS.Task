namespace PH.SAAS.Task.Models
{
    public class t_Command : t_BaseEntity
    {
        public int CommandId { get; set; }
        public int TaskId { get; set; }
        public int NodeId { get; set; }
        public string CommandName { get; set; }
        public string Command { get; set; }
    }
}