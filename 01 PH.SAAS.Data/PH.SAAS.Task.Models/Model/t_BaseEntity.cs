using System;

namespace PH.SAAS.Task.Models
{
    public class t_BaseEntity
    {
        public t_BaseEntity()
        {
            CreateTime=DateTime.Now;
        }
        public DateTime CreateTime { get; set; }
        public DateTime? LastUpdTime { get; set; }
    }
}