namespace PH.SAAS.Task.Models
{
    public class t_TempData : t_BaseEntity
    {
        public int TempId { get; set; }
        public int TaskId { get; set; }
        public string TempDataJson { get; set; }
    }
}