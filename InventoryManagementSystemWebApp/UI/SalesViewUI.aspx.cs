using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryManagementSystemWebApp.BLL;
using InventoryManagementSystemWebApp.DAL.Model;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

namespace InventoryManagementSystemWebApp.UI
{
    public partial class SalesViewUI : System.Web.UI.Page
    {
        StockOutManager stockOutManager = new StockOutManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user == null)
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Control printButton = (Control)FindControl("printButton");
            outputLabel.Text = "";
            string fromDate = fromDatePicker.Text;
            string toDate = toDatePicker.Text;
            List<SalesViewModel> salesViewModels = null;
            
            if (fromDate != "" && toDate != "")
            {
                if (stockOutManager.ChkDateValidity(fromDate, toDate))
                {
                    salesViewModels = stockOutManager.GetAllSalesViewModels(fromDate, toDate);
                    if (salesViewModels.Count > 0)
                    {
                        salesGridView.DataSource = salesViewModels;
                        salesGridView.DataBind();
                        outputLabel.Text = "";
                        printButton.Visible = true;
                    }
                    else
                    {
                        salesGridView.DataSource = null;
                        salesGridView.DataBind();
                        outputLabel.Text = "Data Not Found";
                        printButton.Visible = false;
                    }
                }
                else
                {
                    outputLabel.Text = "To Date must be greater than From Date ";
                    salesGridView.DataSource = null;
                    salesGridView.DataBind();
                    printButton.Visible = false;
                }
            }
            
            else
            {
                outputLabel.Text = "Please Select Both dates";
            }
        }
    }
}