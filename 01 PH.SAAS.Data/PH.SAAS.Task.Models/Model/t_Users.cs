using System;

namespace PH.SAAS.Task.Models
{
    public class t_Users
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PassSalt { get; set; }
        public string RealName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdDate { get; set; }
        public int IsEnabled { get; set; }
        public string Remark { get; set; }
    }
}