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
                        LastName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ArtistName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MusicCollection.SongArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("MusicCollection.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "MusicCollection.Song",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Duration = c.Int(nullable: false),
                        Label = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "MusicCollection.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MusicCollection.SongPlaylists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MusicCollection.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("MusicCollection.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "MusicCollection.Playlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MusicCollection.Album", "ArtistId", "MusicCollection.Artist");
            DropForeignKey("MusicCollection.SongPlaylists", "SongId", "MusicCollection.Song");
            DropForeignKey("MusicCollection.SongPlaylists", "PlaylistId", "MusicCollection.Playlist");
            DropForeignKey("MusicCollection.SongArtists", "SongId", "MusicCollection.Song");
            DropForeignKey("MusicCollection.Song", "GenreId", "MusicCollection.Genre");
            DropForeignKey("MusicCollection.SongArtists", "ArtistId", "MusicCollection.Artist");
            DropIndex("MusicCollection.SongPlaylists", new[] { "PlaylistId" });
            DropIndex("MusicCollection.SongPlaylists", new[] { "SongId" });
            DropIndex("MusicCollection.Song", new[] { "GenreId" });
            DropIndex("MusicCollection.SongArtists", new[] { "ArtistId" });
            DropIndex("MusicCollection.SongArtists", new[] { "SongId" });
            DropIndex("MusicCollection.Album", new[] { "ArtistId" });
            DropTable("MusicCollection.Playlist");
            DropTable("MusicCollection.SongPlaylists");
            DropTable("MusicCollection.Genre");
            DropTable("MusicCollection.Song");
            DropTable("MusicCollection.SongArtists");
            DropTable("MusicCollection.Artist");
            DropTable("MusicCollection.Album");
        }
    }
}
