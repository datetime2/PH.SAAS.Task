using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data
{
    using MySql.Data.MySqlClient;
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbType
    {
        SqlServer,
        MySql
    }
    public class DbAccess<T> where T : class, new()
    {
        /// <summary>
        /// Void
        /// </summary>
        /// <param name="action"></param>
        protected void Void(Action<IDatabase> action)
        {
            using (var client = DbFactory.CreateDb(DbType.MySql))
            {
                action(client);
            }
        }

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected IEnumerable<T> FindBy(Func<IDatabase, IEnumerable<T>> func)
        {
            using (var client = DbFactory.CreateDb(DbType.MySql))
            {
                return func(client);
            }
        }
        /// <summary>
        /// Pager
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected jqGridPagerViewModel<T> Pager(Func<IDatabase, jqGridPagerViewModel<T>> func)
        {
            using (var client = DbFactory.CreateDb(DbType.MySql))
            {
                return func(client);
            }
        }
        /// <summary>
        /// FirstOrDefault
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected T FirstOrDefault(Func<IDatabase, T> func)
        {
            using (var client = DbFactory.CreateDb(DbType.MySql))
            {
                return func(client);
            }
        }
        /// <summary>
        ///  Insert、Update、Delete
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected bool Commit(Func<IDatabase, bool> func)
        {
            using (var client = DbFactory.CreateDb(DbType.MySql))
            {
                return func(client);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class DbFactory
    {
        public static IDatabase CreateDb(DbType dbType)
        {
            IDbConnection connection = null;
            IDatabase dbDatabase = null;
            var config=new DapperExtensionsConfiguration();
            switch (dbType)
            {
                case DbType.SqlServer:
                    connection = new SqlConnection(GlobalVariables.Db_String);
                    config = new DapperExtensionsConfiguration(typeof (AutoClassMapper<>), new List<Assembly>(),
                        new SqlServerDialect());
                    
                    break;
                case DbType.MySql:
                    connection = new MySqlConnection(GlobalVariables.Db_String);
                    config = new DapperExtensionsConfiguration(typeof (AutoClassMapper<>), new List<Assembly>(),
                        new MySqlDialect());
                    break;
            }
            var sqlGenerator = new SqlGeneratorImpl(config);
            dbDatabase = new Database(connection, sqlGenerator);
            return dbDatabase;
        }
    }
}