using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InventoryManager.Commands;
using InventoryManager.Model;

namespace InventoryManager.ViewModel
{
    public class GroceryInventory
    {
        public ICommand AddItemCommand { get; }
        public ObservableCollection<GroceryItem> Items { get; set; }
        public string NewItemName { get; set; } = "";
        public decimal NewItemPrice { get; set; }
        public int NewItemQuantity { get; set; }

        
        public GroceryInventory() { 
            Items = new ObservableCollection<GroceryItem>();
            AddItemCommand = new RelayCommand(AddItem);
        }
        

        public void AddItem()
        {
            GroceryItem item = new GroceryItem();
            item.Name = NewItemName;
            item.Price = NewItemPrice;
            item.Quantity = NewItemQuantity;

            Items.Add(item);
        }
    }
}
