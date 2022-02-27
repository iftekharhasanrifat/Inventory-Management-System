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
    public partial class ItemUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                if (!IsPostBack)
                {
                    categoryDropdown.DataSource = categoryManager.GetAllCategories();
                    categoryDropdown.DataValueField = "Id";
                    categoryDropdown.DataTextField = "Name";
                    categoryDropdown.DataBind();
                    categoryDropdown.Items.Insert(0, new ListItem("Select Category", "0"));
                    //categoryDropdown.Items.Insert(0, "Select Category");
                    categoryDropdown.Items[0].Attributes["disabled"] = "disabled";
                    categoryDropdown.Items[0].Attributes["selected"] = "selected";

                    companyDropdown.DataSource = companyManager.GetAllCompanies();
                    companyDropdown.DataValueField = "Id";
                    companyDropdown.DataTextField = "Name";
                    companyDropdown.DataBind();
                    //companyDropdown.Items.Insert(0, "Select Company");
                    companyDropdown.Items.Insert(0, new ListItem("Select Company", "0"));
                    companyDropdown.Items[0].Attributes["disabled"] = "disabled";
                    companyDropdown.Items[0].Attributes["selected"] = "selected";
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }



        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryDropdown.SelectedValue == "0" && companyDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please Select Category And Company";
            }
            else if (categoryDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please Select Category";
            }
            else if (companyDropdown.SelectedValue == "0")
            {
                outputLabel.Text = "Please Select Company";
            }
            else
            {
                if (String.IsNullOrWhiteSpace(itemTextBox.Text))
                {
                    outputLabel.Text = "Please Provide Item Name";
                }
                else
                {
                    if (itemManager.ValidItemNameCheck(itemTextBox.Text))
                    {
                        Item item = new Item();
                        item.Name = itemTextBox.Text;
                        item.CategoryId = Convert.ToInt32(categoryDropdown.SelectedValue);
                        item.CompanyId = Convert.ToInt32(companyDropdown.SelectedValue);
                        if (String.IsNullOrWhiteSpace(reorderLevelTextBox.Text))
                        {
                            item.ReorderLevel = 0;
                        }
                        else
                        {
                            if (itemManager.ValidReorderLevelCheck(reorderLevelTextBox.Text))
                            {

                                item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                                item.Quantity = 0;
                                string message = itemManager.Save(item);

                                outputLabel.Text = message;


                            }
                            else
                            {
                                outputLabel.Text = "Please provide valid reorder level or leave it empty";
                            }

                        }
                    }
                    else
                    {
                        outputLabel.Text = "Please provide at least one alphabet as itemaname";
                    }
                }
            }
        }
    }
}