namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MusicCollection.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ReleaseDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Artist", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "MusicCollection.Artist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MusicCollection.TrackArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("MusicCollection.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "MusicCollection.Track",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Duration = c.Int(nullable: false),
                        Label = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MusicCollection.PlaylistTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("MusicCollection.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "MusicCollection.Playlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MusicCollection.TrackGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("MusicCollection.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "MusicCollection.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MusicCollection.Album", "ArtistId", "MusicCollection.Artist");
            DropForeignKey("MusicCollection.TrackGenres", "TrackId", "MusicCollection.Track");
            DropForeignKey("MusicCollection.TrackGenres", "GenreId", "MusicCollection.Genre");
            DropForeignKey("MusicCollection.TrackArtists", "TrackId", "MusicCollection.Track");
            DropForeignKey("MusicCollection.PlaylistTracks", "TrackId", "MusicCollection.Track");
            DropForeignKey("MusicCollection.PlaylistTracks", "PlaylistId", "MusicCollection.Playlist");
            DropForeignKey("MusicCollection.TrackArtists", "ArtistId", "MusicCollection.Artist");
            DropIndex("MusicCollection.TrackGenres", new[] { "GenreId" });
            DropIndex("MusicCollection.TrackGenres", new[] { "TrackId" });
            DropIndex("MusicCollection.PlaylistTracks", new[] { "PlaylistId" });
            DropIndex("MusicCollection.PlaylistTracks", new[] { "TrackId" });
            DropIndex("MusicCollection.TrackArtists", new[] { "ArtistId" });
            DropIndex("MusicCollection.TrackArtists", new[] { "TrackId" });
            DropIndex("MusicCollection.Album", new[] { "ArtistId" });
            DropTable("MusicCollection.Genre");
            DropTable("MusicCollection.TrackGenres");
            DropTable("MusicCollection.Playlist");
            DropTable("MusicCollection.PlaylistTracks");
            DropTable("MusicCollection.Track");
            DropTable("MusicCollection.TrackArtists");
            DropTable("MusicCollection.Artist");
            DropTable("MusicCollection.Album");
        }
    }
}
