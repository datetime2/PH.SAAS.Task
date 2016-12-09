namespace PH.SAAS.Task.Models
{
    public class t_Config : t_BaseEntity
    {
        public int ConfigId { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Remark { get; set; }
    }
}