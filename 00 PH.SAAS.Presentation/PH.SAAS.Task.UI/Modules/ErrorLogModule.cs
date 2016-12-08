namespace PH.SAAS.Task.UI.Modules
{
    public class ErrorLogModule:BaseModule
    {
        public ErrorLogModule():base("ErrorLog")
        {
            Get["/"] = x => View["Index"];
        }
    }
}