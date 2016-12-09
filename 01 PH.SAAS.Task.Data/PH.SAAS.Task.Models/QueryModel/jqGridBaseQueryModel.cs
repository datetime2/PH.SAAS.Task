using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.SAAS.Task.Models.QueryModel
{
    public class jqGridBaseQueryModel
    {
        public jqGridBaseQueryModel()
        {
            this.page = 1;
            this.rows = 50;
            this.sord = "asc";
            this.sidx = "Id";
        }
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 分页数
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// 是否倒序
        /// </summary>
        public string sord { get; set; }
        public string keyword { get; set; }
    }
}
