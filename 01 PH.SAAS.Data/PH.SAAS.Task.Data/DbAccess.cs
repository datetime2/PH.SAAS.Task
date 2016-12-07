using System;
using System.Collections.Generic;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.Data
{
    using MySql.Data.MySqlClient;

    public class DbAccess<T> where T : class, new()
    {
        /// <summary>
        /// Void
        /// </summary>
        /// <param name="action"></param>
        protected void Void(Action<MySqlConnection> action)
        {
            using (var client = new MySqlConnection(GlobalVariablesManager.G_Strconn))
            {
                action(client);
            }
        }

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected IEnumerable<T> FindBy(Func<MySqlConnection, IEnumerable<T>> func)
        {
            using (var client = new MySqlConnection(GlobalVariablesManager.G_Strconn))
            {
                return func(client);
            }
        }
        /// <summary>
        /// Pager
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected jqGridPagerViewModel<T> Pager(Func<MySqlConnection, jqGridPagerViewModel<T>> func)
        {
            using (var client = new MySqlConnection(GlobalVariablesManager.G_Strconn))
            {
                return func(client);
            }
        }
        /// <summary>
        /// FirstOrDefault
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected T FirstOrDefault(Func<MySqlConnection, T> func)
        {
            using (var client = new MySqlConnection(GlobalVariablesManager.G_Strconn))
            {
                return func(client);
            }
        }
        /// <summary>
        ///  Insert、Update、Delete
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected bool Commit(Func<MySqlConnection, bool> func)
        {
            using (var client = new MySqlConnection(GlobalVariablesManager.G_Strconn))
            {
                return func(client);
            }
        }
    }
}