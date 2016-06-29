namespace aspnet_mvc5_sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Deadline = c.DateTime(),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
