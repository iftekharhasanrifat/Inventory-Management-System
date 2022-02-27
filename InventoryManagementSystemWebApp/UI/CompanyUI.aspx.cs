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
    public partial class CompanyUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Model.User user = (User)Session["user"];

            if (user != null)
            {
                companyGridView.DataSource = companyManager.GetAllCompanies();
                companyGridView.DataBind();
            }
            else
            {
                Response.Redirect("IndexUI.aspx?logout=true");
            }
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(companyTextBox.Text))
            {
                outputLabel.Text = "Please Enter CompanyName";
            }
            else
            {
                if (companyManager.ValidCompanyNameCheck(companyTextBox.Text))
                {
                    Company company = new Company();
                    company.Name = companyTextBox.Text;
                    outputLabel.Text = companyManager.Save(company);
                    companyGridView.DataSource = companyManager.GetAllCompanies();
                    companyGridView.DataBind();
                }
                else
                {
                    outputLabel.Text = "Please provide letter only";
                }
            }
        }

        protected void updateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton) sender;
            DataControlFieldCell cell=(DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow) cell.Parent;
            HiddenField idHiddenField = (HiddenField) row.FindControl("idHiddenField");
            Response.Redirect("UpdateCompanyUI.aspx?id="+idHiddenField.Value);
        }
    }
}