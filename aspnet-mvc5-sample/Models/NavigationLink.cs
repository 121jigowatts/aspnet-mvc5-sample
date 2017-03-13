using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Models
{
    public class NavigationLink
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public int RoleId { get; set; }
        public string CategoryName { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public IEnumerable<NavigationLink> ChildMenu { get; set; }
        public int Order { get; set; }
    }
}