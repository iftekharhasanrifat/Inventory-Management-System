using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystemWebApp.DAL.Gateway
{
    public class UserGateway:BaseGateway
    {
        public bool ValidateUser(string name,string pass)
        {
            string query = "SELECT*FROM Users WHERE UserName='" + name + "' AND Password='"+pass+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
    }
}