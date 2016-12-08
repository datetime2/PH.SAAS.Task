using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Task:DbAccess<t_Tasks>
    {
        public bool SaveForm(t_Tasks task)
        {
            return Commit((client) =>
            {
                if (task.TaskId.HasValue)
                {
                    task.LastUpdTime = DateTime.Now;
                    return client.Update(task);
                }
                else
                    return client.Insert(task) > 0;
            });
        }
        public t_Tasks InitForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Tasks>(keyValue));
        }
        public jqGridPagerViewModel<t_Tasks> PageTask(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<t_Tasks>()
            {
                page = query.page,
                size = query.rows
            };
            IList<IPredicate> predList = new List<IPredicate>();
            if (!string.IsNullOrEmpty(query.keyword))
                predList.Add(Predicates.Field<t_Tasks>(p => p.TaskName, Operator.Like, query.keyword));
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
                grid.records = client.Count<t_Tasks>(predGroup);
                grid.rows = client.GetPage<t_Tasks>(predGroup, sort, query.page - 1, query.rows);
                return grid;
            });
        }
    }
}