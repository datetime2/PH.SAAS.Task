namespace PH.SAAS.Task.UI.Modules
{
    public class CommandModule:BaseModule
    {
        public CommandModule():base("Command")
        {
            Get["/"] = x => View["Index"];
        }
    }
}