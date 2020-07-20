﻿using System;
using System.Collections.Generic;

namespace Shared
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<SongArtistDto> SongArtistList { get; set; }
        public List<AlbumDto> AlbumList { get; set; }
    }
}
