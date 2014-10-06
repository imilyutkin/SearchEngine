namespace SearchEngine.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Label, unique: true);
            
            CreateTable(
                "dbo.WordLinks",
                c => new
                    {
                        UrlId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UrlId, t.WordId })
                .ForeignKey("dbo.Words", t => t.UrlId, cascadeDelete: false)
                .ForeignKey("dbo.Urls", t => t.WordId, cascadeDelete: false)
                .Index(t => t.UrlId)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordLinks", "WordId", "dbo.Urls");
            DropForeignKey("dbo.WordLinks", "UrlId", "dbo.Words");
            DropIndex("dbo.WordLinks", new[] { "WordId" });
            DropIndex("dbo.WordLinks", new[] { "UrlId" });
            DropIndex("dbo.Words", new[] { "Label" });
            DropTable("dbo.WordLinks");
            DropTable("dbo.Words");
        }
    }
}
