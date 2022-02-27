using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using InventoryManagementSystemWebApp.DAL.Gateway;
using InventoryManagementSystemWebApp.DAL.Model;
using InventoryManagementSystemWebApp.DAL.Model.ViewModel;

namespace InventoryManagementSystemWebApp.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();
        public string Save(Item item)
        {
            bool isExist = itemGateway.IsItemExist(item.Name, item.CompanyId);
            if (isExist)
            {
                return "Item in this company already exist";
            }
            else
            {
                int rowEffect = itemGateway.Save(item);
                if (rowEffect > 0)
                {
                    return "Item Saved Successfully!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
            
        }

        public List<Item> GetItemsByCompanyId(int companyId)
        {
            return itemGateway.GetItemsByCompanyId(companyId);
        }

        public Item GetItemById(int id)
        {
            return itemGateway.GetItemById(id);
        }

        public int CheckQuantity(int itemId)
        {
            return itemGateway.CheckQuantity(itemId);
        }

        public string UpdateQuantityByItemId(int itemId, int quantity)
        {
            int rowEffect = itemGateway.UpdateQuantityByItemId(itemId, quantity);
            if (rowEffect > 0)
            {
                return "Succesfully Added in Stock";
            }
            else
            {
                return "Somethign went wrong!";
            }
        }

        public string UpdateCartQuantityByItemId(List<Cart> carts)
        {
            int rowEffect = 0;
            foreach (Cart cart in carts)
            {
                Item item = new Item();
                item.Id = cart.ItemId;
                item.Quantity = cart.AvailableQuantity;

                rowEffect = itemGateway.UpdateQuantityByItemId(item.Id, item.Quantity);
            }
            if (rowEffect > 0)
            {
                return "Successfull";
            }
            else
            {
                return "Something Went wrong!";
            }
        }

        public List<SearchViewModel> GetAllSearchViewModel()
        {
            return itemGateway.GetAllSearchViewModel();
        }

        public List<SearchViewModel> GetAllSearchViewModelByCategoryId(int categoryId)
        {
            return itemGateway.GetAllSearchViewModelByCategoryId(categoryId);
        }

        public List<SearchViewModel> GetAllSearchViewModelByCompanyId(int companyId)
        {
            return itemGateway.GetAllSearchViewModelByCompanyId(companyId);
        }

        public List<SearchViewModel> GetAllSearchViewModelByBothId(int companyId, int categoryId)
        {
            return itemGateway.GetAllSearchViewModelByBothId(companyId, categoryId);
        }

        public bool ValidItemNameCheck(string name)
        {
            if (Regex.IsMatch(name, "^.*[a-zA-Z].*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidReorderLevelCheck(string reorderlevel)
        {
            if (Regex.IsMatch(reorderlevel, "^[0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidQuantityCheck(string quantity)
        {
            if (Regex.IsMatch(quantity, "^[0-9]*$"))
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