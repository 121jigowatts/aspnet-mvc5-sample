using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Models
{
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public HttpPostedFileBase Picture { get; set; }
    }
}