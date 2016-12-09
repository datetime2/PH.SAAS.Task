using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Users : DbAccess<t_Users>
    {
        public t_Users InitForm(int keyValue)
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
            IList<IPredicate> predList = new List<IPredicate>();
            if (!string.IsNullOrEmpty(query.keyword))
                predList.Add(Predicates.Field<t_Users>(p => p.UserName, Operator.Eq, query.keyword));
            var predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());
            var sort = new List<ISort>
            {
                new Sort
                {
                    Ascending = query.sord == "desc",
                    PropertyName = query.sidx
                }
            };
            return Pager((client) =>
            {
                grid.records = client.Count<t_Users>(predGroup);
                grid.rows = client.GetPage<t_Users>(predGroup, sort, query.page - 1, query.rows);
                return grid;
            });
        }

        public bool SaveForm(t_Users user)
        {
            return Commit((client) => user.UserId.HasValue ? client.Update(user) : client.Insert(user));
        }
    }
}