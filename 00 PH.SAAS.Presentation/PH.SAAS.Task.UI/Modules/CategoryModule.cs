namespace PH.SAAS.Task.UI.Modules
{
    public class CategoryModule:BaseModule
    {
        public CategoryModule():base("/Category")
        {
            Get["/"] = parameters => View["Index"];
        }
    }
}