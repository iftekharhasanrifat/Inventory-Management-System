using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.DAL.Gateway
{
    public class CategoryGateway:BaseGateway
    {
        public int Save(Category category)
        {
            string query = "INSERT INTO Categories VALUES('" + category.Name + "')";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IsCategoryExist(string name)
        {
            string query = "SELECT*FROM Categories WHERE Name='" + name + "'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT*FROM Categories";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category> categoryList = new List<Category>();
            while (Reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.Name = Reader["Name"].ToString();
                categoryList.Add(category);
            }
            Reader.Close();
            Connection.Close();
            return categoryList;
        }

        public int Update(Category category)
        {
            string query = "UPDATE Categories SET Name='" + category.Name + "' WHERE Id ="+category.Id+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public Category GetCategoryById(int id)
        {
            string query = "SELECT*FROM Categories WHERE Id="+id+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Category category = new Category();
            Reader.Read();
            if (Reader.HasRows)
            {
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return category;
        }
    }
}