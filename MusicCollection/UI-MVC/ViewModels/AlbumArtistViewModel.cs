using System.Collections.Generic;
using Shared;

namespace UI_MVC.ViewModels
{
    public class AlbumArtistViewModel
    {
        public IEnumerable<ArtistDto> Artists { get; set; }
        public AlbumDto Album { get; set; }
    }
}