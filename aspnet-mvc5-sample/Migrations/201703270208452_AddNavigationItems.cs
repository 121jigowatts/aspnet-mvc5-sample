namespace aspnet_mvc5_sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NavigationItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        CategoryName = c.String(),
                        LinkText = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NavigationItems");
        }
    }
}
