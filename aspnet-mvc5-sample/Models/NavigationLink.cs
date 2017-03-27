using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Models
{
    public class NavigationLink : NavigationItem
    {
        public IEnumerable<NavigationLink> ChildMenu { get; set; }        
    }

    public class NavigationItem
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int RoleId { get; set; }
        [Required]
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int Order { get; set; }
    }
}