namespace PH.SAAS.Task.Models
{
    public class t_Nodes : t_BaseEntity
    {
        public int? NodeId { get; set; }
        public string NodeName { get; set; }
        public string NodeIp { get; set; }
        public bool CheckState { get; set; }
    }
}