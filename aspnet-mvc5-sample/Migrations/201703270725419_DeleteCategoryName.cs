namespace aspnet_mvc5_sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NavigationItems", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NavigationItems", "CategoryName", c => c.String());
        }
    }
}
