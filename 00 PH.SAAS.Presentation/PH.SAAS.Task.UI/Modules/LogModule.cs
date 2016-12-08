namespace PH.SAAS.Task.UI.Modules
{
    public class LogModule : BaseModule
    {
        public LogModule()
            : base("Log")
        {
            Get["/"] = x => View["Index"];
        }
    }
}