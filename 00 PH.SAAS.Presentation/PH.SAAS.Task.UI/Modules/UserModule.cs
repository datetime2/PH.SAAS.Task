using Nancy;
using Nancy.ModelBinding;
using PH.SAAS.Task.Data.Dao;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;

namespace PH.SAAS.Task.UI.Modules
{
    public class UserModule : BaseModule
    {
        public UserModule()
            : base("/User")
        {
            Get["/"] = pmrameters => View["Index"];
            Get["/Form"] = pmrameters => View["Form"];
            //列表
            Get["/List"] = parameters =>
            {
                var userService = new Users();
                var query = this.Bind<jqGridBaseQueryModel>();
                return Response.AsJson(userService.PageUsers(query));
            };
            //更新
            Put["/Update"] = paramsters =>
            {
                var userService = new Users();
                var user = this.Bind<t_Users>();
                return Response.AsJson(userService.Update(user) ? Success("操作成功") : Error("操作失败"));
            };
        }
    }
}