using Dapper;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Users : DbAccess<t_Users>
    {
        public t_Users GetForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Users>(keyValue));
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
                grid.rows = client.GetList<t_Users>();
                return grid;
            });
        }
        public bool Update(t_Users user)
        {
            return Commit((client) =>
            {
                //client.GetPage<t_Users>()

                return false;//client.Execute("") > 0;
            });
        }
    }
}