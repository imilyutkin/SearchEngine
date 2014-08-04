namespace SearchEngine.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Urls", t => t.Source_Id)
                .Index(t => t.Source_Id);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(maxLength: 100),
                        UrlLink_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UrlLinks", t => t.UrlLink_Id)
                .Index(t => t.Address, unique: true)
                .Index(t => t.UrlLink_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlLinks", "Source_Id", "dbo.Urls");
            DropForeignKey("dbo.Urls", "UrlLink_Id", "dbo.UrlLinks");
            DropIndex("dbo.Urls", new[] { "UrlLink_Id" });
            DropIndex("dbo.Urls", new[] { "Address" });
            DropIndex("dbo.UrlLinks", new[] { "Source_Id" });
            DropTable("dbo.Urls");
            DropTable("dbo.UrlLinks");
        }
    }
}
