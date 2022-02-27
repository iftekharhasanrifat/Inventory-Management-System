using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.DAL.Gateway
{
    public class CompanyGateway:BaseGateway
    {
        public int Save(Company company)
        {
            string query = "INSERT INTO Companies VALUES('" + company.Name + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IscompanyExist(string name)
        {
            string query = "SELECT*FROM Companies WHERE Name='" + name + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

        public List<Company> GetAllCompanies()
        {
            string query = "SELECT*FROM Companies";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> companyList = new List<Company>();
            while (Reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.Name = Reader["Name"].ToString();
                companyList.Add(company);
            }
            Reader.Close();
            Connection.Close();
            return companyList;
        }

        public int Update(Company company)
        {
            string query = "UPDATE Companies SET Name='" + company.Name + "' WHERE Id =" + company.Id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public Company GetCompanyById(int id)
        {
            string query = "SELECT*FROM Companies WHERE Id=" + id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Company company = new Company();
            Reader.Read();
            if (Reader.HasRows)
            {
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return company;
        }
    }
}