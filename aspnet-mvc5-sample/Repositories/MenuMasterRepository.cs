﻿using aspnet_mvc5_sample.Models;
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
                    CategoryName ="サンプル",
                    ChildMenu = new List<NavigationLink> {
                        new NavigationLink {Id=5,ParentId=4,LinkText="Upload",ActionName="Upload",ControllerName="Home",Order=1 },
                        new NavigationLink {Id=6,ParentId=4,LinkText="Autocomplete",ActionName="Create",ControllerName="Home",Order=2 },
                        new NavigationLink
                        {
                            Id=7,
                            CategoryName="Sample",
                            ChildMenu = new List<NavigationLink>
                            {
                                new NavigationLink {Id=8,ParentId=7,LinkText="Sample01" ,ActionName="Index",ControllerName="Home",Order=1},
                                new NavigationLink {Id=9,ParentId=7,LinkText="Sample02" ,ActionName="Index",ControllerName="Home",Order=2},
                                new NavigationLink {
                                    Id =10,
                                    CategoryName = "More Options",
                                    ChildMenu = new List<NavigationLink>
                                    {
                                        new NavigationLink {Id=11,ParentId=10,LinkText="Google",ActionName="Index",ControllerName="Home",Order=1 },
                                        new NavigationLink {Id=12,ParentId=10,LinkText="Yahoo",ActionName="Index",ControllerName="Home",Order=2 },
                                    }
                                },
                            },
                            Order=3
                        },
                        new NavigationLink {Id=13,ParentId=4,LinkText="LogViewer",ActionName="Index",ControllerName="Logging",Order=4 },
                        new NavigationLink {Id=14,ParentId=4,LinkText="Todo",ActionName="Index",ControllerName="Todo",Order=5 },
                    }
                    ,Order=4},
            };
        }
    }
}