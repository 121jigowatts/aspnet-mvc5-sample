using aspnet_mvc5_sample.Models;
using aspnet_mvc5_sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Framework
{
    public class RoleManager
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public RoleManager(string id)
        {
            UserId = id;
            // 権限取得
            Role = "Admin";
        }

        public IEnumerable<NavigationLink> GetMenu()
        {
            return new MenuMasterRepository().GetMenu();
        }
    }
}