using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Model;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

namespace InventoryManagementSystemWebApp.DAL.Gateway
{
    public class StockOutGateway : BaseGateway
    {
        public int Save(StockOut stockOut)
        {
            int quantity = ChecKQuantity(stockOut.ItemId, stockOut.Date, stockOut.Type);
            string query = "";
            if (quantity > 0)
            {
                quantity += stockOut.Quantity;
                query = "UPDATE Stockout SET Quantity=" + quantity + " WHERE ItemId =" + stockOut.ItemId + " AND Type='" + stockOut.Type + "'";
            }
            else
            {
                query = "INSERT INTO Stockout VALUES("+stockOut.ItemId+",'"+stockOut.Date+"',"+stockOut.Quantity+",'"+stockOut.Type+"')";
            }
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }
        public int ChecKQuantity(int itemId, string date, string type)
        {
            string query = "SELECT Quantity FROM StockOut WHERE ItemId=" + itemId + " AND Date='" + date +
                           "' AND Type='" + type + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int quantity = 0;
            
            Reader = Command.ExecuteReader();
            Reader.Read();
            if (Reader.HasRows)
            {
                quantity = Convert.ToInt32(Reader["Quantity"]);
            }
            Reader.Close();
            Connection.Close();
            return quantity;
        }

        public List<SalesViewModel> GetAllSalesViewModels(string fromDate, string toDate)
        {
            string query = "SELECT*FROM GetSalesView WHERE Date BETWEEN '" + fromDate + "' AND  '" + toDate + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            SalesViewModel salesViewModel = null;
            List<SalesViewModel> salesViewModels = new List<SalesViewModel>();
            while (Reader.Read())
            {
                salesViewModel = new SalesViewModel();
                salesViewModel.Item = Reader["Item"].ToString();
                salesViewModel.Company = Reader["Company"].ToString();
                salesViewModel.SaleQuantity = Convert.ToInt32(Reader["SaleQuantity"]);
                salesViewModels.Add(salesViewModel);
            }
            Reader.Close();
            Connection.Close();
            return salesViewModels;
        }

    }
}