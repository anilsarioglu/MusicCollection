using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }

        public List<TrackArtistDto> TrackArtistList { get; set; }
        public List<AlbumDto> AlbumList { get; set; }
    }
}
