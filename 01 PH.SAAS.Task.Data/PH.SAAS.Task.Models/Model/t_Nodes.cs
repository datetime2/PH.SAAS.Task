using System.Collections.Generic;

namespace PH.SAAS.Task.Models
{
    public class t_Nodes : t_BaseEntity
    {
        //public t_Nodes()
        //{
        //    Task = new HashSet<t_Tasks>();
        //}
        public int? NodeId { get; set; }
        public string NodesName { get; set; }
        public string NodeIp { get; set; }
        public bool CheckState { get; set; }
        //public virtual ICollection<t_Tasks> Task { get; set; } 

    }
}