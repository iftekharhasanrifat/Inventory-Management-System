using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Gateway;
using InventoryManagementSystemWebApp.DAL.Model;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

namespace InventoryManagementSystemWebApp.BLL
{
    public class StockOutManager
    {
        StockOutGateway stockOutGateway = new StockOutGateway();

        public string Save(List<Cart> carts, string type)
        {
            DateTime dateTime = DateTime.Now.Date;
            int rowEffect = 0;
            foreach (Cart cart in carts)
            {
                StockOut stockOut = new StockOut();
                stockOut.ItemId = cart.ItemId;
                stockOut.Date = dateTime.ToString("yyyy MMMM dd");
                stockOut.Type = type;
                stockOut.Quantity = cart.Quantity;
                rowEffect = stockOutGateway.Save(stockOut);
            }
            if (rowEffect > 0)
            {
                return "Item has been " + type;
            }
            else
            {
                return "Something went wrong!";
            }
        }

        public List<SalesViewModel> GetAllSalesViewModels(string fromDate, string toDate)
        {
            return stockOutGateway.GetAllSalesViewModels(fromDate, toDate);
        }

        public bool ChkDateValidity(string fromDate, string toDate)
        {

            DateTime fd = ParseDate(fromDate);
            DateTime td = ParseDate(toDate);
           
            if (fd <= td)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime ParseDate(string input)
        {
            DateTime result;

            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return result;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return result;
            if (DateTime.TryParseExact(input, "mm/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return result;
            throw new FormatException();
        }
        public bool ValidQuantityCheck(string quantity)
        {
            if (Regex.IsMatch(quantity, "^[0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}