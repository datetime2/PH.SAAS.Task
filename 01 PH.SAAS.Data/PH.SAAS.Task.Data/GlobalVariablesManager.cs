namespace PH.SAAS.Task.Data
{
    using System.Configuration;
    public class GlobalVariablesManager
    {
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string G_Strconn
        {
            get
            {
                return ConfigurationManager.AppSettings["Task.Conn"];
            }
        }
    }
}