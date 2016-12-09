using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperExtensions;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Category : DbAccess<t_Categories>
    {
        public bool SaveForm(t_Categories category)
        {
            return Commit((client) =>
            {
                if (category.CategoryId.HasValue)
                {
                    category.LastUpdTime = DateTime.Now;
                    return client.Update(category);
                }
                else
                    return client.Insert(category) > 0;
            });
        }
        public t_Categories InitForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Categories>(keyValue));
        }
        public jqGridPagerViewModel<t_Categories> PageCategory(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<t_Categories>()
            {
                page = query.page,
                size = query.rows
            };
            IList<IPredicate> predList = new List<IPredicate>();
            if (!string.IsNullOrEmpty(query.keyword))
                predList.Add(Predicates.Field<t_Categories>(p => p.CategoryName, Operator.Like, query.keyword));
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
                grid.records = client.Count<t_Categories>(predGroup);
                grid.rows = client.GetPage<t_Categories>(predGroup, sort, query.page - 1, query.rows);
                return grid;
            });
        }

        public IEnumerable<dynamic> CategortSelect()
        {
            return FindBy((client) =>
            {
                return client.GetList<t_Categories>().Select(s => new
                {
                    id = s.CategoryId,
                    text = s.CategoryName
                });
            });
        }
    }
}