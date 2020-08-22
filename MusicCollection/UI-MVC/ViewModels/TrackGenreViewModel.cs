using System.Collections.Generic;
using Shared;

namespace UI_MVC.ViewModels
{
    public class TrackGenreViewModel
    {
        public IEnumerable<GenreDto> Genres { get; set; }
        public TrackGenreDto TrackGenre { get; set; }
        public TrackDto Track { get; set; }
    }
}