using aspnet_mvc5_mongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_mongodb.ViewModels
{
    public class UserSearchViewModel
    {
        #region Constructors
        public UserSearchViewModel()
        {
            users = new List<User>();
            userSearchCondition = new UserSearchCondition();
        }
        #endregion

        public IEnumerable<User> users { get; set; }
        public UserSearchCondition userSearchCondition { get; set; }
    }

    public class UserSearchCondition
    {
        public string userName { get; set; }
        public string fromUserAge { get; set; }
        public string toUserAge { get; set; }
        public string userEmail { get; set; }
        public string userAddress { get; set; }
    }
}