namespace aspnet_mvc5_sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNavigationItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NavigationItems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NavigationItems", "Discriminator");
        }
    }
}
