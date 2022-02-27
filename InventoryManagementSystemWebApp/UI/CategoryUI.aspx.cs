using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryManagementSystemWebApp.BLL;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.UI
{
    public partial class CategoryUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                categoryGridView.DataSource = categoryManager.GetAllCategories();
                categoryGridView.DataBind();
            }
            else
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                outputLabel.Text = "Please enter categoryname";
            }
            else
            {
                if (categoryManager.ValidCategoryNameCheck(categoryTextBox.Text))
                {
                    Category category = new Category();
                    category.Name = categoryTextBox.Text;
                    outputLabel.Text = categoryManager.Save(category);
                    categoryGridView.DataSource = categoryManager.GetAllCategories();
                    categoryGridView.DataBind();
                }
                else
                {
                    outputLabel.Text = "Please Enter Letters Only";
                }
            }
        }

        protected void updateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton) sender;
            DataControlFieldCell cell = (DataControlFieldCell) linkButton.Parent;
            GridViewRow row = (GridViewRow) cell.Parent;
            HiddenField idHiddenField = (HiddenField) row.FindControl("idHiddenField");
            //Response.Write(idHiddenField.Value);
            Response.Redirect("UpdateCategoryUI.aspx?id="+idHiddenField.Value);

        }
    }
}