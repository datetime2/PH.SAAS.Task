using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Command:DbAccess<t_Command>
    {
        public bool SaveForm(t_Command category)
        {
            return Commit((client) =>
            {
                if (category.CommandId.HasValue)
                {
                    category.LastUpdTime = DateTime.Now;
                    return client.Update(category);
                }
                else
                    return client.Insert(category) > 0;
            });
        }
        public t_Command InitForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Command>(keyValue));
        }
        public jqGridPagerViewModel<t_Command> PageCategory(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<t_Command>()
            {
                page = query.page,
                size = query.rows
            };
            IList<IPredicate> predList = new List<IPredicate>();
            if (!string.IsNullOrEmpty(query.keyword))
                predList.Add(Predicates.Field<t_Command>(p => p.CommandName, Operator.Like, query.keyword));
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
                grid.records = client.Count<t_Command>(predGroup);
                grid.rows = client.GetPage<t_Command>(predGroup, sort, query.page - 1, query.rows);
                return grid;
            });
        }
    }
}