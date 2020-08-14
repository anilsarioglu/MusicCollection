using System;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date of Release")]
        public DateTime ReleaseDate { get; set; }

        public ArtistDto Artist { get; set; }
    }
}
