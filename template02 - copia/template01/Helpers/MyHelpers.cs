using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace template01.helpers
{
    public static class MyHelpers
    {
        // Render BootStrap menu item with active class
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper,
                                             string text, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction,
                              action,
                              StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController,
                              controller,
                              StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            if (routeValues != null)
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues).ToHtmlString();
            }
            else
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            null,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller).ToHtmlString();
            }
            return MvcHtmlString.Create(li.ToString());
        }


        // As the text the: "<span class='glyphicon glyphicon-plus'></span>" can be entered
        public static MvcHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper,
                                             string text, string title, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("a");
            builder.InnerHtml = text;
            builder.Attributes["title"] = title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

            return MvcHtmlString.Create(builder.ToString());
        }
        
        public static MvcHtmlString ActionLinkSpan(this HtmlHelper helper, string linkText, string actionName, string controllerName, object htmlAttributes)
        {
            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.InnerHtml = linkText;

            return MvcHtmlString.Create(BuildNestedAnchor(spanBuilder.ToString(), string.Format("/{0}/{1}", controllerName, actionName), htmlAttributes));
        }

        private static string BuildNestedAnchor(string innerHtml, string url, object htmlAttributes)
        {
            TagBuilder anchorBuilder = new TagBuilder("a");
            anchorBuilder.Attributes.Add("href", url);
            anchorBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
            anchorBuilder.InnerHtml = innerHtml;

            return anchorBuilder.ToString();
        }

        /// <summary>
        /// Obtiene la direcion IP del equipo que ejecuta la aplicación
        /// </summary>
        /// <returns>Direccion I.P.</returns>
        public static string GetIpAddress()
        {
            //IPHostEntry host;
            //string localip = "";

            //host = Dns.GetHostEntry(Dns.GetHostName());

            //foreach (IPAddress ip in host.AddressList)
            //{
            //    if (ip.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        localip = ip.ToString();
            //    }
            //}

            //return localip;

            String strHostName = Dns.GetHostName();
            Socket socket = null;

            //IPAddress hostIPAddress1 = (Dns.Resolve(strHostName)).AddressList[0];

            IPAddress hostIPAddress1 = (Dns.GetHostEntry(strHostName)).AddressList[1];
            IPEndPoint hostIPEndPoint = new IPEndPoint(hostIPAddress1, 80);
            socket = new Socket(hostIPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(hostIPEndPoint);
            string ipRemote = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
            string ipLocal = ((IPEndPoint)socket.LocalEndPoint).Address.ToString();

            return ipLocal;
        }

        /// <summary>
        /// ActionImage: Realiza una funcion parsonalizada para un control Razor-MVC
        /// </summary>
        /// <param name="html">Definicion de tipo html para la vista mvc la reconozca</param>
        /// <param name="action">Accion del controlador especificada</param>
        /// <param name="routeValues">PArmetros estilos y deás que se definen para el control</param>
        /// <param name="imagePath">Ruta de la imagen que va a mostrar en l vista</param>
        /// <param name="alt">Texto tipo "tooltip" que se verá desde la vista</param>
        /// <returns></returns>
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            //Construye el tag de la imagen <img>
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            //Construye el tag de <a>
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
            anchorBuilder.InnerHtml = imgHtml; //Adentro incluye el tag <img> 
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }
    }
}