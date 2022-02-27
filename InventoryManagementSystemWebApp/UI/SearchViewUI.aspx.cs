using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryManagementSystemWebApp.BLL;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using InventoryManagementSystemWebApp.DAL.Model;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace InventoryManagementSystemWebApp.UI
{
    public partial class SearchViewUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        CategoryManager categoryManager = new CategoryManager();
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

        protected void searchButton_Click(object sender, EventArgs e)
        {
            companyDropdown.Items[0].Attributes["disabled"] = "disabled";
            categoryDropdown.Items[0].Attributes["disabled"] = "disabled";
            categoryDropdown.Items[0].Attributes["selected"] = "selected";
            Control printButton = (Control)FindControl("printButton");
            int companyId = Convert.ToInt32(companyDropdown.SelectedValue);
            int categoryId = Convert.ToInt32(categoryDropdown.SelectedValue);
            List<SearchViewModel> searchViewModels = null;
            if (companyId > 0 && categoryId > 0)
            {
                searchViewModels = itemManager.GetAllSearchViewModelByBothId(companyId, categoryId);
                if (searchViewModels.Count > 0)
                {
                    searchGridView.DataSource = searchViewModels;
                    searchGridView.DataBind();
                    printButton.Visible = true;
                    outputLabel.Text = "";
                }
                else
                {
                    searchGridView.DataSource = null;
                    searchGridView.DataBind();
                    outputLabel.Text = "Data Not Found";
                    printButton.Visible = false;
                }


            }
            else if (companyId > 0)
            {
                searchViewModels = itemManager.GetAllSearchViewModelByCompanyId(companyId);
                if (searchViewModels.Count > 0)
                {
                    searchGridView.DataSource = searchViewModels;
                    searchGridView.DataBind();
                    outputLabel.Text = "";
                    printButton.Visible = true;
                }
                else
                {
                    searchGridView.DataSource = null;
                    searchGridView.DataBind();
                    outputLabel.Text = "Data Not Found";
                    printButton.Visible = false;
                }

            }
            else if (categoryId > 0)
            {
                searchViewModels = itemManager.GetAllSearchViewModelByCategoryId(categoryId);
                if (searchViewModels.Count > 0)
                {
                    searchGridView.DataSource = searchViewModels;
                    searchGridView.DataBind();
                    outputLabel.Text = "";
                    printButton.Visible = true;
                }
                else
                {
                    searchGridView.DataSource = null;
                    searchGridView.DataBind();
                    outputLabel.Text = "Data Not Found";
                    printButton.Visible = false;
                }
            }

            else
            {
                searchViewModels = itemManager.GetAllSearchViewModel();
                if (searchViewModels.Count > 0)
                {
                    searchGridView.DataSource = searchViewModels;
                    searchGridView.DataBind();
                    outputLabel.Text = "";
                    printButton.Visible = true;
                }
                else
                {
                    searchGridView.DataSource = null;
                    searchGridView.DataBind();
                    outputLabel.Text = "Data Not Found";
                    printButton.Visible = false;
                }
            }
           
            

        }
    }
}