using Microsoft.AspNetCore.Mvc;

namespace WebAPI.ControllersHelpers
{
    public class ControllerHelper
    {
        public virtual string GetControllerName(ControllerBase controller)
        {
            return controller.RouteData.Values["controller"].ToString();
        }

        public virtual string GetActionName(ControllerBase controller)
        {
            return controller.RouteData.Values["action"].ToString();
        }
    }
}
