using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Model;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

namespace InventoryManagementSystemWebApp.DAL.Gateway
{
    public class ItemGateway : BaseGateway
    {
        public int Save(Item item)
        {
            string query = "INSERT INTO Items VALUES('" + item.Name + "'," + item.CategoryId + "," + item.CompanyId + "," + item.ReorderLevel + "," + item.Quantity + ")";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IsItemExist(string name, int companyId)
        {
            string query = "SELECT*FROM Items WHERE Name='" + name + "' AND CompanyId=" + companyId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

        public List<Item> GetItemsByCompanyId(int companyId)
        {
            string query = "SELECT*FROM Items WHERE CompanyId=" + companyId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Item item = null;
            List<Item> items = new List<Item>();
            while (Reader.Read())
            {
                item = new Item();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.Name = Reader["Name"].ToString();
                item.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.Quantity = Convert.ToInt32(Reader["Quantity"]);
                items.Add(item);
            }
            Reader.Close();
            Connection.Close();
            return items;
        }

        public Item GetItemById(int id)
        {
            string query = "SELECT*FROM Items WHERE Id=" + id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Item item = null;

            if (Reader.HasRows)
            {
                item = new Item();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.Name = Reader["Name"].ToString();
                item.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.Quantity = Convert.ToInt32(Reader["Quantity"]);

            }
            Reader.Close();
            Connection.Close();
            return item;
        }

        public int CheckQuantity(int itemId)
        {
            string query = "SELECT Quantity FROM Items WHERE Id=" + itemId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            int quantity = 0;

            if (Reader.HasRows)
            {
                quantity = Convert.ToInt32(Reader["Quantity"]);

            }
            Reader.Close();
            Connection.Close();
            return quantity;
        }

        public int UpdateQuantityByItemId(int itemId, int quantity)
        {
            string query = "UPDATE ITEMS SET Quantity =" + quantity + " WHERE Id=" + itemId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public List<SearchViewModel> GetAllSearchViewModel()
        {
            string query = "SELECT*FROM GetSearchView";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            SearchViewModel searchViewModel = null;
            List<SearchViewModel> searchViewModels = new List<SearchViewModel>();
            while (Reader.Read())
            {
                searchViewModel = new SearchViewModel();
                searchViewModel.Item = Reader["Item"].ToString();
                searchViewModel.Company = Reader["Company"].ToString();
                searchViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                searchViewModels.Add(searchViewModel);
            }
            Reader.Close();
            Connection.Close();
            return searchViewModels;
        }

        public List<SearchViewModel> GetAllSearchViewModelByCategoryId(int categoryId)
        {
            string query = "SELECT*FROM GetSearchView WHERE CategoryId = " + categoryId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            SearchViewModel searchViewModel = null;
            List<SearchViewModel> searchViewModels = new List<SearchViewModel>();
            while (Reader.Read())
            {
                searchViewModel = new SearchViewModel();
                searchViewModel.Item = Reader["Item"].ToString();
                searchViewModel.Company = Reader["Company"].ToString();
                searchViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                searchViewModels.Add(searchViewModel);
            }
            Reader.Close();
            Connection.Close();
            return searchViewModels;
        }
        public List<SearchViewModel> GetAllSearchViewModelByCompanyId(int companyId)
        {
            string query = "SELECT*FROM GetSearchView WHERE CompanyId = "+companyId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            SearchViewModel searchViewModel = null;
            List<SearchViewModel> searchViewModels = new List<SearchViewModel>();
            while (Reader.Read())
            {
                searchViewModel = new SearchViewModel();
                searchViewModel.Item = Reader["Item"].ToString();
                searchViewModel.Company = Reader["Company"].ToString();
                searchViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                searchViewModels.Add(searchViewModel);
            }
            Reader.Close();
            Connection.Close();
            return searchViewModels;
        }
        public List<SearchViewModel> GetAllSearchViewModelByBothId(int companyId,int categoryId)
        {
            string query = "SELECT*FROM GetSearchView WHERE CompanyId = "+companyId+" AND CategoryId = "+categoryId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            SearchViewModel searchViewModel = null;
            List<SearchViewModel> searchViewModels = new List<SearchViewModel>();
            while (Reader.Read())
            {
                searchViewModel = new SearchViewModel();
                searchViewModel.Item = Reader["Item"].ToString();
                searchViewModel.Company = Reader["Company"].ToString();
                searchViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                searchViewModels.Add(searchViewModel);
            }
            Reader.Close();
            Connection.Close();
            return searchViewModels;
        }
    }
}