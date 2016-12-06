using Nancy;

namespace PH.SAAS.Task.UI.Modules
{
    public class BaseModule:NancyModule
    {
        public BaseModule()
            : base()
        {

        }
        public BaseModule(string modulePath)
            : base(modulePath)
        {

        }
    }
}