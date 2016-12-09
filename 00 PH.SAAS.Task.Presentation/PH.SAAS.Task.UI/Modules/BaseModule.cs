using Nancy;
using PH.SAAS.Task.Core;

namespace PH.SAAS.Task.UI.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule()
            : base()
        {

        }
        public BaseModule(string modulePath)
            : base(modulePath)
        {

        }

        #region Response

        protected virtual Response Success(string message)
        {
            return Response.AsJson(new AjaxResult { state = ResultType.success.ToString(), message = message });
        }
        protected virtual Response Success(string message, object data)
        {
            return Response.AsJson(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data });
        }
        protected virtual Response Error(string message)
        {
            return Response.AsJson(new AjaxResult { state = ResultType.error.ToString(), message = message });
        }
        #endregion

    }
}