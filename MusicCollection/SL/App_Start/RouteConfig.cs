using System.Web.Mvc;
using System.Web.Routing;

namespace SL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "TrackGenres",
            //    "tracks/all/genres",
            //    new {controller = "Tracks", action = "GetTracksWithGenres"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
