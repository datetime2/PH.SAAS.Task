using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSF.Serialization;
using BSF.Extensions;
using BSF.Db;
using PH.SAAS.Task.Models;
using Newtonsoft.Json;
namespace PH.SAAS.Task.Base.SystemRuntime
{
    /// <summary>
    /// 任务运行时底层操作类
    /// 仅平台内部使用
    /// </summary>
    public class TaskSystemRuntimeOperator
    {
        /// <summary>
        /// 任务dll实例引用
        /// </summary>
        protected BaseTask DllTask = null;
        protected string localtempdatafilename = "localtempdata.json.txt";

        public TaskSystemRuntimeOperator(BaseTask dlltask)
        {
            DllTask = dlltask;
        }

        public void SaveLocalTempData(object obj)
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + localtempdatafilename;
            var json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(filename, json);
        }
        public T GetLocalTempData<T>() where T : class
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + localtempdatafilename;
            if (!System.IO.File.Exists(filename))
                return null;
            var content = System.IO.File.ReadAllText(filename);
            var obj = JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
    }
}
