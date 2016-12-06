using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.SAAS.Task.Core.Net
{
    /// <summary>
    /// 集群节点配置信息
    /// </summary>
    public class NodeAppConfigInfo
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeId { get; set; }
        /// <summary>
        /// 任务数据库连接
        /// </summary>
        public string TaskDataBaseConnectString { get; set; }
    }
}
