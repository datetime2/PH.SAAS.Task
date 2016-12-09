using PH.SAAS.Task.Models;

namespace PH.SAAS.Task.Data.Dao
{
    public class ErrorLog:DbAccess<t_ErrorLog>
    {
        public bool AddErrorLog(t_ErrorLog log)
        {
            return Commit((client) => client.Insert(log) > 0);
        }
    }
}