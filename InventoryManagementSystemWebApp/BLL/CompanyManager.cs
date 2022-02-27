using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Gateway;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.BLL
{

    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();
        public string Save(Company Company)
        {
            bool isExist = companyGateway.IscompanyExist(Company.Name);
            if (isExist)
            {
                return "Company name already exist";
            }
            else
            {
                int rowEffect = companyGateway.Save(Company);
                if (rowEffect > 0)
                {
                    return "Company saved Successfully!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
        }

        public List<Company> GetAllCompanies()
        {
            return companyGateway.GetAllCompanies();
        }

        public string Update(Company Company)
        {
            bool isExist = companyGateway.IscompanyExist(Company.Name);
            if (isExist)
            {
                return "Company name already exist";
            }
            else
            {
                int rowEffect = companyGateway.Update(Company);
                if (rowEffect > 0)
                {
                    return "Company Updated Successfully!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
        }

        public Company GetCompanyById(int id)
        {
            return companyGateway.GetCompanyById(id);
        }
        public bool ValidCompanyNameCheck(string name)
        {
            if (Regex.IsMatch(name, "^[a-zA-Z]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}