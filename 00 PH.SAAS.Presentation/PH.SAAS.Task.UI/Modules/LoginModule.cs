using Nancy.ModelBinding;
using PH.SAAS.Task.Models;

namespace PH.SAAS.Task.UI.Modules
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginModule : BaseModule
    {
        public LoginModule()
            : base("/Login")
        {
            Get["/"] = parameters => View["index"];

            Get["/photo/{slug}"] = parameters => string.Format(
                "<h1>I'm sorry</h1><p> We're having some problems finding photo '{0}' for the moment.</p>",
                parameters.slug);
            //登录
            Post["/Info"] = parameters =>
            {
                var user = this.Bind<t_Users>();
                return "";
            };
            //注销
            Post["/Exit"] = parameters =>
            {

                return "";
            };
        }
    }
}