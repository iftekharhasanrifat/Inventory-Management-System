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
    public partial class UpdateCompanyUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Company company = companyManager.GetCompanyById(id);
                    if (company != null)
                    {
                        companyTextBox.Text = company.Name;
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
            Company company = new Company();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            company.Id = id;
            company.Name = companyTextBox
                .Text;
            string message = companyManager.Update(company);
            if (message == "Company Updated Successfully!")
            {
                Response.Redirect("CompanyUI.aspx");
            }
            else
            {
                outputLabel.Text = message;
            }
        }
    }
}