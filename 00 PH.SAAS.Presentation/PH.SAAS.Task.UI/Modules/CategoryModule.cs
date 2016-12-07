using Nancy;
using Nancy.ModelBinding;
using PH.SAAS.Task.Data.Dao;
using PH.SAAS.Task.Models.QueryModel;

namespace PH.SAAS.Task.UI.Modules
{
    public class CategoryModule:BaseModule
    {
        public CategoryModule():base("/Category")
        {
            Get["/"] = parameters => View["Index"];
            Get["/List"] = paramsters =>
            {
                var cateService = new Category();
                var query = this.Bind<jqGridBaseQueryModel>();
                return Response.AsJson(cateService.PageCategory(query));
            };
        }
    }
}