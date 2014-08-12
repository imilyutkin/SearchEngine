namespace SearchEngine.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTableUrlsLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Urls", "UrlLink_Id", "dbo.UrlLinks");
            DropForeignKey("dbo.UrlLinks", "Source_Id", "dbo.Urls");
            DropIndex("dbo.UrlLinks", new[] { "Source_Id" });
            DropIndex("dbo.Urls", new[] { "UrlLink_Id" });
            DropColumn("dbo.Urls", "UrlLink_Id");
            DropTable("dbo.UrlLinks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UrlLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Urls", "UrlLink_Id", c => c.Int());
            CreateIndex("dbo.Urls", "UrlLink_Id");
            CreateIndex("dbo.UrlLinks", "Source_Id");
            AddForeignKey("dbo.UrlLinks", "Source_Id", "dbo.Urls", "Id");
            AddForeignKey("dbo.Urls", "UrlLink_Id", "dbo.UrlLinks", "Id");
        }
    }
}
