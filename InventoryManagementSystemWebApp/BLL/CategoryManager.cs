using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Gateway;
using InventoryManagementSystemWebApp.DAL.Model;

namespace InventoryManagementSystemWebApp.BLL
{
    public class CategoryManager
    {
        private CategoryGateway categoryGateway;

        public CategoryManager()
        {
            categoryGateway = new CategoryGateway();
        }

        public string Save(Category category)
        {
            bool isExist = categoryGateway.IsCategoryExist(category.Name);
            if (isExist)
            {
                return "Category name already exist";
            }
            else
            {
                int rowEffect = categoryGateway.Save(category);
                if (rowEffect > 0)
                {
                    return "Category saved Successfully!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public string Update(Category category)
        {
            bool isExist = categoryGateway.IsCategoryExist(category.Name);
            if (isExist)
            {
                return "Category name already exist";
            }
            else
            {
                int rowEffect = categoryGateway.Update(category);
                if (rowEffect > 0)
                {
                    return "Category Updated Successfully!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
        }

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        public bool ValidCategoryNameCheck(string name)
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
