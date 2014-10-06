namespace SearchEngine.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUIdToUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urls", "UId", c => c.Guid(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urls", "UId");
        }
    }
}
