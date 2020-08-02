using Autofac;
using BLL.managers;
using BLL.managers.interfaces;
using Shared;

namespace SL
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AlbumManager>().As<IManager<AlbumDto>>();
            builder.RegisterType<ArtistManager>().As<IManager<ArtistDto>>();
            builder.RegisterType<GenreManager>().As<IManager<GenreDto>>();
            builder.RegisterType<PlaylistManager>().As<IManager<PlaylistDto>>();
            builder.RegisterType<TrackManager>().As<IManager<TrackDto>>();

            return builder.Build();
        }
    }
}