using Dapper;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Users : DbAccess<t_Users>
    {
        public System.Collections.Generic.IEnumerable<t_Users> GetUsers()
        {
            return FindBy((client) => client.Query<t_Users>("SELECT * FROM t_Users"));
        }

        public jqGridPagerViewModel<t_Users> PageUsers(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<t_Users>()
            {
                page = query.page,
                size = query.rows
            };
            return Pager((client) =>
            {
                grid.rows = client.Query<t_Users>("SELECT * FROM t_Users");
                return grid;
            });
        }
    }
}