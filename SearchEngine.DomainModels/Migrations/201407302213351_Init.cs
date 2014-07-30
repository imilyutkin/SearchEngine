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
                        From_Id = c.Int(),
                        To_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Urls", t => t.From_Id)
                .ForeignKey("dbo.Urls", t => t.To_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Address, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlLinks", "To_Id", "dbo.Urls");
            DropForeignKey("dbo.UrlLinks", "From_Id", "dbo.Urls");
            DropIndex("dbo.Urls", new[] { "Address" });
            DropIndex("dbo.UrlLinks", new[] { "To_Id" });
            DropIndex("dbo.UrlLinks", new[] { "From_Id" });
            DropTable("dbo.Urls");
            DropTable("dbo.UrlLinks");
        }
    }
}
