using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DapperExtensions;
using PH.SAAS.Task.Core;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data.Dao
{
    public class Tasks : DbAccess<t_Tasks>
    {
        public bool SaveForm(t_M_Tasks mtask)
        {
            var task = Mapper.Map<t_M_Tasks, t_Tasks>(mtask);
            return Commit((client) =>
            {
                if (task.TaskId.HasValue)
                {
                    #region 编辑任务
                    task.LastUpdTime = DateTime.Now;
                    return client.Update(task);
                    #endregion
                }
                else
                {
                    #region 新增任务
                    var flag = false;
                    try
                    {
                        client.BeginTransaction();
                        task.TaskLastEndTime = null;
                        task.TaskLastErrorTime = null;
                        task.TaskLastStartTime = null;
                        var taskId = client.Insert(task);
                        if (taskId != null)
                        {
                            //version
                            var versionId = client.Insert(new t_Version
                            {
                                TaskId = taskId,
                                Versino = 1,
                                ZipFileName = mtask.ZipFile,
                                ZipFile = IOHelper.FileToByte(mtask.ZipFile)
                            });
                            //tempdata
                            var tempId = client.Insert(new t_TempData
                            {
                                TaskId = taskId,
                                TempDataJson = mtask.TempDataJson
                            });
                            flag = tempId > 0;
                            client.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        client.Rollback();
                        throw ex;
                    }
                    return flag;
                    #endregion
                }
            });
        }
        public t_Tasks InitForm(int keyValue)
        {
            return FirstOrDefault((client) => client.Get<t_Tasks>(keyValue));
        }
        public jqGridPagerViewModel<dynamic> PageTask(jqGridBaseQueryModel query)
        {
            var grid = new jqGridPagerViewModel<dynamic>()
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
                grid.rows = client.GetPage<t_Tasks>(predGroup, sort, query.page - 1, query.rows).Select(s => new
                {
                    taskId = s.TaskId,
                    taskName = s.TaskName,
                    categoryId = s.CategoryId,
                    nodeId = s.NodeId,
                    taskLastStartTime = s.TaskLastStartTime,
                    taskLastEndTime = s.TaskLastEndTime,
                    taskLastErrorTime = s.TaskLastErrorTime,
                    taskErrorCount = s.TaskErrorCount,
                    taskRunCount = s.TaskRunCount,
                    taskCron = s.TaskCron,
                    taskState = s.TaskState,
                    taskOperate = s.TaskState,
                    taskRemark = s.TaskRemark,
                    createTime = s.CreateTime,
                    lastUpdTime = s.LastUpdTime
                });
                return grid;
            });
        }
    }
}