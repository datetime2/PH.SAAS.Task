using System;
using System.Collections.Generic;
namespace PH.SAAS.Task.Models
{
    public class t_Categories : t_BaseEntity
    {
        //public t_Categories()
        //{
        //    Task=new HashSet<t_Tasks>();
        //}
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public virtual ICollection<t_Tasks> Task { get; set; } 
    }
}