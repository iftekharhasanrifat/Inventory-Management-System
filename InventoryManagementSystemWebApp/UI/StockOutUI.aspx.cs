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
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockOutManager stockOutManager = new StockOutManager();
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
            List<Cart> cartList = (List<Cart>)ViewState["Cart"];
            Cart cart = null;
            if (ViewState["Cart"] != null)
            {
                cart = cartList.Find(x => x.ItemId == itemId);
                if (cart == null)
                {
                    Item item = itemManager.GetItemById(itemId);
                    reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                    quantityTextBox.Text = item.Quantity.ToString();
                }
                else
                {
                    quantityTextBox.Text = cart.AvailableQuantity.ToString();
                }
            }

            else
            {
                Item item = itemManager.GetItemById(itemId);
                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                quantityTextBox.Text = item.Quantity.ToString();
            }

        }

        protected void addButton_Click(object sender, EventArgs e)
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
                string itemName = ItemDropdown.SelectedItem.ToString();
                string companyName = companyDropdown.SelectedItem.ToString();
                if (ViewState["Cart"] == null)
                {
                    int quantiy = Convert.ToInt32(quantityTextBox.Text);
                    if (String.IsNullOrWhiteSpace(stockOutTextBox.Text))
                    {
                        outputLabel.Text = "Please enter quantity";
                    }
                    else
                    {

                        if (stockOutManager.ValidQuantityCheck(stockOutTextBox.Text))
                        {
                            if (quantiy < Convert.ToInt32(stockOutTextBox.Text))
                            {
                                outputLabel.Text = "Out Of Stock";
                            }
                            else
                            {
                                List<Cart> cartList = new List<Cart>();
                                Cart cart = new Cart();
                                cart.ItemId = itemId;
                                cart.ItemName = itemName;
                                cart.CompanyName = companyName;
                                cart.Quantity = Convert.ToInt32(stockOutTextBox.Text);
                                int newQuantity = quantiy - cart.Quantity;
                                cart.AvailableQuantity = newQuantity;
                                cartList.Add(cart);
                                quantityTextBox.Text = cart.AvailableQuantity.ToString();
                                ViewState["Cart"] = cartList;
                            }
                        }
                        else
                        {
                            outputLabel.Text = "Please provide valid number in stockout quantiy";
                        }
                    }

                }
                else
                {
                    List<Cart> newCartList = (List<Cart>)ViewState["Cart"];
                    Cart cart = newCartList.Find(x => x.ItemId == itemId);
                    int availableQt = Convert.ToInt32(quantityTextBox.Text);

                    if (String.IsNullOrWhiteSpace(stockOutTextBox.Text))
                    {
                        outputLabel.Text = "Please enter quantity";
                    }
                    else
                    {
                        if (stockOutManager.ValidQuantityCheck(stockOutTextBox.Text))
                        {
                            if (availableQt < Convert.ToInt32(stockOutTextBox.Text))
                            {
                                outputLabel.Text = "Out Of Stock";
                            }
                            else
                            {
                                Cart newCart = null;

                                if (cart == null)
                                {
                                    newCart = new Cart();
                                    newCart.ItemId = itemId;
                                    newCart.ItemName = itemName;
                                    newCart.CompanyName = companyName;
                                    newCart.Quantity = Convert.ToInt32(stockOutTextBox.Text);
                                    int newQuantity = availableQt - newCart.Quantity;
                                    newCart.AvailableQuantity = newQuantity;
                                    newCartList.Add(newCart);
                                    quantityTextBox.Text = newCart.AvailableQuantity.ToString();
                                }
                                else
                                {
                                    //Cart removaleCart = newCartList.Single(x => x.ItemId == itemId);
                                    newCartList.Remove(cart);
                                    newCart = new Cart();
                                    newCart.ItemId = itemId;
                                    newCart.ItemName = itemName;
                                    newCart.CompanyName = companyName;
                                    newCart.Quantity = cart.Quantity + Convert.ToInt32(stockOutTextBox.Text);
                                    int newQuantity = availableQt - Convert.ToInt32(stockOutTextBox.Text);
                                    newCart.AvailableQuantity = newQuantity;
                                    newCartList.Add(newCart);
                                    quantityTextBox.Text = newCart.AvailableQuantity.ToString();
                                }
                                ViewState["Cart"] = newCartList;
                                outputLabel.Text = "";
                            }

                        }
                        else
                        {
                            outputLabel.Text = "Please provide valid number in stockout quantiy";
                        }
                    }
                }
                List<Cart> cartForGridView = (List<Cart>)ViewState["Cart"];
                itemsGridView.DataSource = cartForGridView;
                itemsGridView.DataBind();


                if (cartForGridView != null)
                {
                    Control actionDiv = (Control)FindControl("actionDiv");
                    
                    actionDiv.Visible = true;
                }

                stockOutTextBox.Text = "";
                
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            List<Cart> carts = (List<Cart>)ViewState["Cart"];
            string message = stockOutManager.Save(carts, "Sold");
            itemManager.UpdateCartQuantityByItemId(carts);
            outputLabel.Text = message;
            Control cartDiv = (Control)FindControl("cartDiv");

            cartDiv.Visible = false;
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            List<Cart> carts = (List<Cart>)ViewState["Cart"];
            string message = stockOutManager.Save(carts, "Damaged");
            itemManager.UpdateCartQuantityByItemId(carts);
            outputLabel.Text = message;
            Control cartDiv = (Control)FindControl("cartDiv");

            cartDiv.Visible = false;
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            ItemDropdown.Items[0].Attributes["disabled"] = "disabled";
            List<Cart> carts = (List<Cart>)ViewState["Cart"];
            string message = stockOutManager.Save(carts, "Lost");
            itemManager.UpdateCartQuantityByItemId(carts);
            outputLabel.Text = message;
            Control cartDiv = (Control)FindControl("cartDiv");

            cartDiv.Visible = false;
        }
    }
}