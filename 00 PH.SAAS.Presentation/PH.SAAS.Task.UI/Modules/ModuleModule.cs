namespace PH.SAAS.Task.UI.Modules
{
    public class ModuleModule : BaseModule
    {
        public ModuleModule()
            : base("/Module")
        {
            Get["/"] = parameters => View["Index"];
        }
    }
}