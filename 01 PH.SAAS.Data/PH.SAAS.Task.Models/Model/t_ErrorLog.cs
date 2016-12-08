namespace PH.SAAS.Task.Models
{
    public class t_ErrorLog : t_BaseEntity
    {
        public long ErrorId { get; set; }
        public int TaskId { get; set; }
        public int NodeId { get; set; }
        public int ErrorType { get; set; }
        public string ErrorMsg { get; set; }
    }
}