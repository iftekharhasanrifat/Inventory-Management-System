using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryManagementSystemWebApp.BLL;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                if (!IsPostBack)
                {
                    companyDropdown.DataSource = companyManager.GetAllCompanies();
                    companyDropdown.DataValueField = "Id";
                    companyDropdown.DataTextField = "Name";
                    companyDropdown.DataBind();
                    companyDropdown.Items.Insert(0, new ListItem("Select Company", "0"));
                    companyDropdown.Items[0].Attributes["disabled"] = "disabled";
                    companyDropdown.Items[0].Attributes["selected"] = "selected";

                    ItemDropdown.Items.Insert(0, new ListItem("Select Company", "0"));
                    ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
                    ItemDropdown.Items[0].Attributes["selected"] = "selected";
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            if (companyDropdown.SelectedValue == "0" && ItemDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please select company and item";
            }
            else if (companyDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please select company";
            }
            else if (ItemDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please select item";
            }
            else
            {
                int itemId = Convert.ToInt32(ItemDropdown.SelectedValue);
                int availableQuantity = itemManager.CheckQuantity(itemId);

                if (itemManager.ValidQuantityCheck(stockInTextBox.Text))
                {
                    int newQuantity = Convert.ToInt32(stockInTextBox.Text);
                    int quantity = availableQuantity + newQuantity;
                    string message = itemManager.UpdateQuantityByItemId(itemId, quantity);

                    Item item = itemManager.GetItemById(itemId);
                    quantityTextBox.Text = item.Quantity.ToString();
                    outputLabel.Text = message;
                    stockInTextBox.Text = "";
                }
                else
                {
                    outputLabel.Text = "Please provide valid number in Stock IN Quantity";
                    stockInTextBox.Text = "";
                }

            }


        }

        protected void companyDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            int companyId = Convert.ToInt32(companyDropdown.SelectedValue);
            ItemDropdown.DataSource = itemManager.GetItemsByCompanyId(companyId);
            ItemDropdown.DataTextField = "Name";
            ItemDropdown.DataValueField = "Id";
            ItemDropdown.DataBind();
            ItemDropdown.Items.Insert(0, new ListItem("Select Company", "0"));
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            ItemDropdown.Items[0].Attributes["selected"] = "selected";
        }

        protected void ItemDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            int itemId = Convert.ToInt32(ItemDropdown.SelectedValue);
            Item item = itemManager.GetItemById(itemId);
            reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            quantityTextBox.Text = item.Quantity.ToString();
        }
    }
}