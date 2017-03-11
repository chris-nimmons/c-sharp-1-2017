using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class UserModel
    {
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }

        public UserModel()
        {
            Roles = new List<string>();
        }

    }
}