using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystemWebApp.DAL.Model
{
    public class StockOut
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Date { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}