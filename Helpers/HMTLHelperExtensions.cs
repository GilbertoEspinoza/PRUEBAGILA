using System;
using System.Web.Mvc;

namespace PRUEBAGILA
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "kt-menu__item--active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            
            string[] words = controller.Split(',');

            if (words.Length > 1)
            {
                if (String.IsNullOrEmpty(action))
                    action = currentAction;

                foreach (var word in words)
                {
                    if (word == currentController) { 
                        controller = word.ToString();
                        break;
                    }
                }

                return controller == currentController && action == currentAction ?
                    cssClass : String.Empty;
            }
            else {
                if (String.IsNullOrEmpty(controller))
                    controller = currentController;

                if (String.IsNullOrEmpty(action))
                    action = currentAction;

                return controller == currentController && action == currentAction ?
                    cssClass : String.Empty;
            }
        }


        public static string IsSelected2(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "kt-menu__item--active";
            
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            int index = controller.IndexOf(',');
           // String[] substrings = currentController.Split(',');

            //if(substrings.Length==1)
            //{ 
            if (String.IsNullOrEmpty(controller))
                controller = currentController;
            //}
            //    else
            //    {
            //        int z = 0;
            //z = substrings.Length;
            //        if (String.IsNullOrEmpty(controller))
            //            controller = substrings[0].ToString();
            //}


            

            string[] words = controller.Split(',');

            //foreach (var word in words)
            //{
            //    System.Console.WriteLine($"<{word}>");
            //}


            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string IsUrl(this HtmlHelper html, string controller = null, string action = null)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            string currentId = (string)html.ViewContext.RouteData.Values["id"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;
            
            if (String.IsNullOrEmpty(action))
                action = currentAction;

            
            if(!String.IsNullOrEmpty(action) || String.IsNullOrEmpty(currentId))
                return "./";
            else
                return "../../";

            //if (action.ToLower().ToString() == "index" && String.IsNullOrEmpty(currentId))
            //    return "..";
            //else
            //    return "../..";

        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["kt-menu__item--active"];
            return currentAction;
        }
    }
}
