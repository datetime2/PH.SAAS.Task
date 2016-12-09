using PH.SAAS.Task.Models;

namespace PH.SAAS.Task.Data.Dao
{
    public class Logs:DbAccess<t_Log>
    {
        public bool AddLog(t_Log log)
        {
            return Commit((client) => client.Insert(log)>0);
        }
    }
}