using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Gateway;

namespace InventoryManagementSystemWebApp.BLL
{
    public class UserManager
    {
        UserGateway userGateway = new UserGateway();
        public string ValidateUser(string name, string pass)
        {
            if (userGateway.ValidateUser(name, pass))
            {
                return "Success";
            }
            else
            {
                return "wrong credentials!";
            }
            
        }
    }
}