using Nancy;
using Nancy.ModelBinding;
using PH.SAAS.Task.Data.Dao;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.UI.Modules
{
    public class NodeModule : BaseModule
    {
        public NodeModule()
            : base("/Node")
        {
            Get["/"] = parameters => View["Index"];
            Get["/Form/"] = parameters => View["Form"];
            Get["/Form?keyValue={keyValue:int}"] = parameters => View["Form"];
            Get["/List"] = paramsters =>
            {
                var query = this.Bind<jqGridBaseQueryModel>();
                var nodeService = new Node();
                return Response.AsJson(nodeService.PageNode(query));
            };
            Post["/SubmitForm"] = parameters =>
            {
                var cate = this.Bind<t_Nodes>();
                var nodeService = new Node();
                return nodeService.SaveForm(cate) ? Success("操作成功") : Error("操作失败");
            };
            Get["/InitForm"] = paramsters =>
            {
                var post = this.Bind<EditPostForm>();
                var nodeService = new Node();
                return Response.AsJson(nodeService.InitForm(post.keyValue));
            };
        }
    }
}