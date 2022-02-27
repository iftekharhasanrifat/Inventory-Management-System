using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystemWebApp.DAL.Model.ViewModel
{
    public class SalesViewModel
    {
        public string Item { get; set; }
        public string Company { get; set; }
        public int SaleQuantity { get; set; }
    }
}