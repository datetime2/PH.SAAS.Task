namespace PH.SAAS.Task.UI.Modules
{
    public class PerformsModule:BaseModule
    {
        public PerformsModule()
            : base("/Performs")
        {
            Get["/Task"] = paramsters => View["/Task"];
            Get["/Node"] = paramsters => View["/Node"];
        }
    }
}