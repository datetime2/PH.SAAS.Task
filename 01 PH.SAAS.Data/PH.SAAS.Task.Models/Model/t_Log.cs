namespace PH.SAAS.Task.Models
{
    public class t_Log:t_BaseEntity
    {
        public long LogId { get; set; }
        public int TaskId { get; set; }
        public int NodeId { get; set; }
        public int LogType { get; set; }
        public string LogMsg { get; set; }
    }
}