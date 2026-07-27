using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Model;

namespace InventoryManager.ViewModel
{
    public class GroceryInventory
    {
        //public ObservableCollection<GroceryItem> Items { get; set; }
        public string nameInput { get; set; }
        public decimal priceInput { get; set; }
        public int quantityInput { get; set; }

        /*
        public GroceryInventory() { 
            //Items = new ObservableCollection<GroceryItem>();
        }
        */

        public void AddItem(GroceryItem item)
        {
            //Items.Add(item);

            GroceryItem newItem = new GroceryItem
            {
                Name = nameInput,
                Price = priceInput,
                Quantity = quantityInput
            };
        }
    }
}
