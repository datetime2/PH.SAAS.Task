using Dapper;
using DapperExtensions;
using PH.SAAS.Task.Models;

namespace PH.SAAS.Task.Data.Dao
{
    public class Category : DbAccess<t_Category>
    {
        public bool SaveForm(t_Category category, int? keyValue)
        {
            return Commit((client) => keyValue.HasValue ? client.Update(category) : client.Insert(category));
        }
    }
}