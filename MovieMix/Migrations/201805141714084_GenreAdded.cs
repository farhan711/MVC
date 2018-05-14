namespace MovieMix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreNs",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreN_Id", c => c.Byte());
            CreateIndex("dbo.Movies", "GenreN_Id");
            AddForeignKey("dbo.Movies", "GenreN_Id", "dbo.GenreNs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreN_Id", "dbo.GenreNs");
            DropIndex("dbo.Movies", new[] { "GenreN_Id" });
            DropColumn("dbo.Movies", "GenreN_Id");
            DropTable("dbo.GenreNs");
        }
    }
}
