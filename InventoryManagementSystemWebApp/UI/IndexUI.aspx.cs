using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryManagementSystemWebApp.BLL;
using InventoryManagementSystemWebApp. DAL.Model;

namespace InventoryManagementSystemWebApp.UI
{
    public partial class IndexUI : System.Web.UI.Page
    {
        UserManager userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (!IsPostBack)
            {
                //Session.Clear();
                Session.Abandon();
                //Session.RemoveAll();
                if (Request.QueryString["logout"] == "true")
                {
                    outputLabel.Text = "Please login first to contine";
                }
            }
        }

        protected void logginButton_Click(object sender, EventArgs e)
        {
            DAL.Model.User user = new User();
            user.UsrName = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            string message = userManager.ValidateUser(user.UsrName, user.Password);
            if (message == "Success")
            {
                Session["user"] = user;
                Response.Redirect("CategoryUI.aspx");       
            }
            else
            {
                outputLabel.Text = message;
            }
        }
    }
}