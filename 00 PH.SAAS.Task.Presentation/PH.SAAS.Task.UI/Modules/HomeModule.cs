namespace PH.SAAS.Task.UI.Modules
{
    public class HomeModule : BaseModule
    {
        public HomeModule()
            : base("/Home")
        {
            Get["/"] = parameters =>
            {
                ViewBag.Title = "任务调度平台";
                return View["index"];
            };
        }
    }
}