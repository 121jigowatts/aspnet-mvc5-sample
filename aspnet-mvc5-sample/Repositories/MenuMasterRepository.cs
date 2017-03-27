using aspnet_mvc5_sample.Data;
using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Repositories
{
    public class MenuMasterRepository
    {
        public IEnumerable<NavigationLink> GetMenu()
        {
            var menu = new List<NavigationLink>();

            using (var context = new AppDbContext())
            {
                var data = context.NavigationItems
                            .OrderBy(n => n.Order)
                            .ToList();

                var mainMenu = data.Where(n => n.ParentId == null);

                foreach (var item in mainMenu)
                {
                    NavigationLink linkItem = MappingLinkItems(item);
                    menu.Add(linkItem);
                }

                SetChildMenu(menu, data);
            }
            return menu;
            //return new List<NavigationLink>
            //{
            //    new NavigationLink {Id=1,LinkText="ホーム",ActionName="Index", ControllerName="Home" ,Order=1},
            //    new NavigationLink {Id=2,LinkText="詳細", ActionName="About", ControllerName="Home" ,Order=2},
            //    new NavigationLink {Id=3,LinkText="連絡先", ActionName="Contact", ControllerName="Home" ,Order=3},
            //    new NavigationLink {
            //        Id=4,
            //        CategoryName ="サンプル",
            //        ChildMenu = new List<NavigationLink> {
            //            new NavigationLink {Id=5,ParentId=4,LinkText="Upload",ActionName="Upload",ControllerName="Home",Order=1 },
            //            new NavigationLink {Id=6,ParentId=4,LinkText="Autocomplete",ActionName="Create",ControllerName="Home",Order=2 },
            //            new NavigationLink
            //            {
            //                Id=7,
            //                CategoryName="Sample",
            //                ChildMenu = new List<NavigationLink>
            //                {
            //                    new NavigationLink {Id=8,ParentId=7,LinkText="Sample01" ,ActionName="Index",ControllerName="Home",Order=1},
            //                    new NavigationLink {Id=9,ParentId=7,LinkText="Sample02" ,ActionName="Index",ControllerName="Home",Order=2},
            //                    new NavigationLink {
            //                        Id =10,
            //                        CategoryName = "More Options",
            //                        ChildMenu = new List<NavigationLink>
            //                        {
            //                            new NavigationLink {Id=11,ParentId=10,LinkText="Google",ActionName="Index",ControllerName="Home",Order=1 },
            //                            new NavigationLink {Id=12,ParentId=10,LinkText="Yahoo",ActionName="Index",ControllerName="Home",Order=2 },
            //                        }
            //                    },
            //                },
            //                Order=3
            //            },
            //            new NavigationLink {Id=13,ParentId=4,LinkText="LogViewer",ActionName="Index",ControllerName="Logging",Order=4 },
            //            new NavigationLink {Id=14,ParentId=4,LinkText="Todo",ActionName="Index",ControllerName="Todo",Order=5 },
            //        }
            //        ,Order=4},
            //};
        }

        private static NavigationLink MappingLinkItems(NavigationItem item)
        {
            var linkItem = new NavigationLink();
            linkItem.Id = item.Id;
            linkItem.RoleId = item.RoleId;
            linkItem.ParentId = item.ParentId;
            linkItem.CategoryName = item.CategoryName;
            linkItem.LinkText = item.LinkText;
            linkItem.ActionName = item.ActionName;
            linkItem.ControllerName = item.ControllerName;
            linkItem.Order = item.Order;
            return linkItem;
        }

        private void SetChildMenu(IEnumerable<NavigationLink> menu, List<NavigationItem> data)
        {
            foreach (var item in menu)
            {
                if (item.CategoryName != null && item.ChildMenu == null)
                {
                    var childMenu = GetChildMenu(data, item.Id);
                    item.ChildMenu = childMenu;

                    SetChildMenu(childMenu, data);
                }
            }
        }

        private static IEnumerable<NavigationLink> GetChildMenu(IEnumerable<NavigationItem> data, int id)
        {
            var child = data.Where(n => id == n.ParentId)
                .OrderBy(n => n.Order).ToList();

            var childMenu = new List<NavigationLink>();
            foreach (var childItem in child)
            {
                NavigationLink childLinkItem = MappingLinkItems(childItem);
                childMenu.Add(childLinkItem);
            }
            return childMenu;
        }
    }
}