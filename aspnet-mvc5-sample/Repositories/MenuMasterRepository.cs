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
            return new List<NavigationLink>
            {
                new NavigationLink {Id=1,LinkText="ホーム",ActionName="Index", ControllerName="Home" ,Order=1},
                new NavigationLink {Id=2,LinkText="詳細", ActionName="About", ControllerName="Home" ,Order=2},
                new NavigationLink {Id=3,LinkText="連絡先", ActionName="Contact", ControllerName="Home" ,Order=3},
                new NavigationLink {
                    Id=4,
                    CategoryName ="サンプル"
                    ,ChildMenu= new List<NavigationLink> {
                        new NavigationLink {Id=5,ParentId=4,LinkText="Upload",ActionName="Upload",ControllerName="Home",Order=1 },
                        new NavigationLink {Id=6,ParentId=4,LinkText="Autocomplete",ActionName="Create",ControllerName="Home",Order=2 },
                    }
                    ,Order=4},
            };
        }
    }
}