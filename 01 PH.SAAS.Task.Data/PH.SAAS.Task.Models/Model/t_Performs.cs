namespace PH.SAAS.Task.Models
{
    public class t_Performs : t_BaseEntity
    {
        public int PerformId { get; set; }
        public int TaskId { get; set; }
        public int NodeId { get; set; }
        public double CPU { get; set; }
        public double Memory { get; set; }
        public double InstallDirzise { get; set; }
    }
}