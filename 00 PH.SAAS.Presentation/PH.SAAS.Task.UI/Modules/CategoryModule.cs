using System;
using Nancy;
using Nancy.ModelBinding;
using PH.SAAS.Task.Data.Dao;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;

namespace PH.SAAS.Task.UI.Modules
{
    public class CategoryModule:BaseModule
    {
        public CategoryModule():base("Category")
        {
            Get["/"] = parameters => View["Index"];
            Get["/Form"] = parameters => View["Form"];
            Get["/List"] = paramsters =>
            {
                var query = this.Bind<jqGridBaseQueryModel>();
                var cateService = new Category();
                return Response.AsJson(cateService.PageCategory(query));
            };
            Post["/SubmitForm"] = parameters =>
            {
                var cate = this.Bind<t_Category>();
                var cateService = new Category();
                return cateService.SaveForm(cate)?Success("操作成功"):Error("操作失败");
            };
        }
    }
}