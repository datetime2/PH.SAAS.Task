namespace PH.SAAS.Task.Data
{
    using System.Configuration;
    public class GlobalVariables
    {
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string Db_String
        {
            get
            {
                return ConfigurationManager.AppSettings["Task.Conn"];
            }
        }
    }
}