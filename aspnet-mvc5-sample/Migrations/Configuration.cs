namespace aspnet_mvc5_sample.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<aspnet_mvc5_sample.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "aspnet_mvc5_sample.Data.AppDbContext";
        }

        protected override void Seed(aspnet_mvc5_sample.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Unicode(UTF-8) - コードページ65001で保存
            context.NavigationItems.AddOrUpdate(
                p => p.LinkText,
                new NavigationItem { ParentId = null, RoleId = 0, LinkText = "ホーム", ActionName = "Index", ControllerName = "Home", Order = 1 },
                new NavigationItem { ParentId = null, RoleId = 0, LinkText = "詳細", ActionName = "About", ControllerName = "Home", Order = 2 },
                new NavigationItem { ParentId = null, RoleId = 0, LinkText = "連絡先", ActionName = "Contact", ControllerName = "Home", Order = 3 },
                new NavigationItem { ParentId = null, RoleId = 0, LinkText = "サンプル", ActionName = null, ControllerName = null, Order = 4 },
                new NavigationItem { ParentId = 4, RoleId = 0, LinkText = "Upload", ActionName = "Upload", ControllerName = "Home", Order = 1 },
                new NavigationItem { ParentId = 4, RoleId = 0, LinkText = "Autocomplete", ActionName = "Create", ControllerName = "Home", Order = 2 },
                new NavigationItem { ParentId = 4, RoleId = 0, LinkText = "Sample", ActionName = null, ControllerName = null, Order = 3 },
                new NavigationItem { ParentId = 7, RoleId = 0, LinkText = "Sample01", ActionName = "Index", ControllerName = "Home", Order = 1 },
                new NavigationItem { ParentId = 7, RoleId = 0, LinkText = "Sample02", ActionName = "Index", ControllerName = "Home", Order = 2 },
                new NavigationItem { ParentId = 7, RoleId = 0, LinkText = "More Options", ActionName = null, ControllerName = null, Order = 3 },
                new NavigationItem { ParentId = 10, RoleId = 0, LinkText = "Google", ActionName = "Index", ControllerName = "Home", Order = 1 },
                new NavigationItem { ParentId = 10, RoleId = 0, LinkText = "Yahoo", ActionName = "Index", ControllerName = "Home", Order = 2 },
                new NavigationItem { ParentId = 4, RoleId = 0, LinkText = "LogViewer", ActionName = "Index", ControllerName = "Logging", Order = 4 },
                new NavigationItem { ParentId = 4, RoleId = 0, LinkText = "Todo", ActionName = "Index", ControllerName = "Todo", Order = 5 }
                );
        }
    }
}
