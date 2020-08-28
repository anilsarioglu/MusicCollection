namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrackGenre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "MusicCollection.TrackGenres", newName: "TrackGenre");
        }
        
        public override void Down()
        {
            RenameTable(name: "MusicCollection.TrackGenre", newName: "TrackGenres");
        }
    }
}
