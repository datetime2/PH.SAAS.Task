using System;

namespace PH.SAAS.Task.Models
{
    public class t_M_Tasks: t_BaseEntity
    {
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public int CategoryId { get; set; }
        public int NodeId { get; set; }
        public DateTime? TaskLastStartTime { get; set; }
        public DateTime? TaskLastEndTime { get; set; }
        public DateTime? TaskLastErrorTime { get; set; }
        public int TaskErrorCount { get; set; }
        public int TaskRunCount { get; set; }
        public int TaskCreateUserId { get; set; }
        public bool TaskState { get; set; }
        public int TaskVersion { get; set; }
        public string TaskAppConfigJson { get; set; }
        public string TaskCron { get; set; }
        public string TaskMainClassDllFileName { get; set; }
        public string TaskMainClassNamespace { get; set; }
        public string TaskRemark { get; set; }
        public string ZipFile { get; set; }
        public string TempDataJson { get; set; }
        public string RootPath { get; set; }
        public string TaskFile { get; set; }
        public string FileName { get; set; }
    }
}