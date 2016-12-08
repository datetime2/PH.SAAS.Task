namespace PH.SAAS.Task.Models
{
    public class t_Version : t_BaseEntity
    {
        public int VersionId { get; set; }
        public int TaskId { get; set; }
        public int Versino { get; set; }
        public byte[] ZipFile { get; set; }
        public string ZipFileName { get; set; }
    }
}