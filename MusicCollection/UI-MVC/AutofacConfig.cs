using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace UI_MVC
{
    public static class AutoFacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<AlbumManager>().As<IManager<AlbumDto>>();
            //builder.RegisterType<ArtistManager>().As<IManager<ArtistDto>>();
            //builder.RegisterType<GenreManager>().As<IManager<GenreDto>>();
            //builder.RegisterType<PlaylistManager>().As<IManager<PlaylistDto>>();
            //builder.RegisterType<TrackManager>().As<IManager<TrackDto>>();

            return builder.Build();
        }
    }
}