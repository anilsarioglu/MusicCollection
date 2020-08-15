using System.Collections.Generic;
using Shared;

namespace UI_MVC.ViewModels
{
    public class ArtistViewModel
    {
        public IEnumerable<AlbumDto> Albums { get; set; }
        public ArtistDto Artist { get; set; }
    }
}