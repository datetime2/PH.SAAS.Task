using System;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using PH.SAAS.Task.Core;
using PH.SAAS.Task.Data.Dao;
using PH.SAAS.Task.Models;
using PH.SAAS.Task.Models.QueryModel;
using PH.SAAS.Task.Models.ViewModel;

namespace PH.SAAS.Task.UI.Modules
{
    public class TaskModule : BaseModule
    {
        public TaskModule(IRootPathProvider pathProvider)
            : base("/Task")
        {
            var uploadDirectory = Path.Combine(pathProvider.GetRootPath(), "Uploads", "TaskFiles");
            Get["/"] = parameters => View["Index"];
            Get["/Form/"] = parameters => View["Form"];
            Get["/Form?keyValue={keyValue:int}"] = parameters => View["Form"];
            Get["/List"] = paramsters =>
            {
                var query = this.Bind<jqGridBaseQueryModel>();
                var cateService = new Tasks();
                return Response.AsJson(cateService.PageTask(query));
            };
            Post["/SubmitForm"] = parameters =>
            {
                var cate = this.Bind<t_M_Tasks>();
                cate.RootPath = pathProvider.GetRootPath();
                cate.ZipFile = cate.TaskFile;
                cate.FileName = cate.TaskFile.Substring(cate.TaskFile.LastIndexOf('/'),
                    cate.TaskFile.Length - cate.TaskFile.LastIndexOf('/'));
                var cateService = new Tasks();
                return cateService.SaveForm(cate) ? Success("操作成功") : Error("操作失败");
            };
            Get["/InitForm"] = paramsters =>
            {
                var post = this.Bind<EditPostForm>();
                var cateService = new Tasks();
                return Response.AsJson(cateService.InitForm(post.keyValue));
            };
            Post["/Upload"] = x =>
            {
                if (!Directory.Exists(uploadDirectory))
                    Directory.CreateDirectory(uploadDirectory);
                try
                {
                    var upfile = Request.Files.FirstOrDefault();
                    var responseFile = string.Format("/Uploads/TaskFiles/{0}", upfile.Name);
                    var filename = Path.Combine(uploadDirectory, upfile.Name);
                    using (var fileStream = new FileStream(filename, FileMode.Create))
                    {
                        upfile.Value.CopyTo(fileStream);
                    }
                    return Response.AsJson(new
                    {
                        code = 0,
                        path = responseFile,
                        name = upfile.Name,
                        size = upfile.Value.Length
                    });
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new
                    {
                        code = -1,
                        path = "",
                        name ="",
                        size = ""
                    });
                }
            };
        }
    }
}