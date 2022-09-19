using Microsoft.AspNetCore.Mvc;

namespace WebAPI.ControllersHelpers
{
    public class LoggerHelper
    {
        public virtual string LogControllerAndAction(ControllerBase controller)
        {
            string controllerName = controller.RouteData.Values["controller"].ToString();
            string actionName = controller.RouteData.Values["action"].ToString();

            return $"Controller: {controllerName}\n" +
                $"Action: {actionName}\n" +
                $"Called at: {DateTime.Now.TimeOfDay}";
        }
    }
}
