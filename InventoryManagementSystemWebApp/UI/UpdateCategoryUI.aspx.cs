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
    public partial class UpdateCategoryUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Category category = categoryManager.GetCategoryById(id);
                    if (category != null)
                    {
                        categoryTextBox.Text = category.Name;
                    }
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }


            

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Category category = new Category();
            category.Id = id;
            category.Name = categoryTextBox.Text;
            string message = categoryManager.Update(category);
            if (message == "Category Updated Successfully!")
            {
                Response.Redirect("CategoryUI.aspx");
            }
            else
            {
                outputLabel.Text = categoryManager.Update(category);
            }
        }
    }
}