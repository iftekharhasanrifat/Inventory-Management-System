using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystemWebApp.DAL.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UsrName { get; set; }
        public string Password { get; set; }
    }
}