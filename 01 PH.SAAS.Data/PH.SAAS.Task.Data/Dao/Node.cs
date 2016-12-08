using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Node : DbAccess<t_Nodes>
    {
        public bool SaveForm(t_Nodes node)
        {
            return Commit((client) =>
            {
                if (node.NodeId.HasValue)
                {
                    node.LastUpdTime = DateTime.Now;
                    return client.Update(node);
                }
                else
                    return client.Insert(node) > 0;
            });
        }
        public t_Nodes InitForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Nodes>(keyValue));
        }
        public jqGridPagerViewModel<t_Nodes> PageNode(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<t_Nodes>()
            {
                page = query.page,
                size = query.rows
            };
            IList<IPredicate> predList = new List<IPredicate>();
            if (!string.IsNullOrEmpty(query.keyword))
                predList.Add(Predicates.Field<t_Nodes>(p => p.NodesName, Operator.Like, query.keyword));
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
                grid.records = client.Count<t_Nodes>(predGroup);
                grid.rows = client.GetPage<t_Nodes>(predGroup, sort, query.page - 1, query.rows);
                return grid;
            });
        }
        public IEnumerable<dynamic> NodeSelect()
        {
            return FindBy((client) =>
            {
                return client.GetList<t_Nodes>().Select(s => new
                {
                    id = s.NodeId,
                    text = s.NodesName
                });
            });
        }
    }
}