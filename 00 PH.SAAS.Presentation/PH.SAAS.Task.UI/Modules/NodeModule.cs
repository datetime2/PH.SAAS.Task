namespace PH.SAAS.Task.UI.Modules
{
    public class NodeModule:BaseModule
    {
        public NodeModule():base("/Node")
        {
            Get["/"] = parameters => View["Index"];
        }
    }
}