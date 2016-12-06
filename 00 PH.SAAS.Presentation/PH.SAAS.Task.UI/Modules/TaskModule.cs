namespace PH.SAAS.Task.UI.Modules
{
    public class TaskModule : BaseModule
    {
        public TaskModule()
            : base("/Task")
        {
            Get["/"] = parameters => View["Index"];
        }
    }
}