using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.CMS.Models {
    public class ListUsersViewModel {
        public IList<UserList> UserList { get; set; }
    }

    public class UserList {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}