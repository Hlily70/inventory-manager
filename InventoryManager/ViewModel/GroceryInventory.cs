using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InventoryManager.Commands;
using InventoryManager.Model;
using InventoryManager.Data;

namespace InventoryManager.ViewModel
{
    public class GroceryInventory
    {
        private InventoryData data;
        public RelayCommand AddItemCommand { get; }
        public RelayCommand DeleteItemCommand { get; }
        public ObservableCollection<GroceryItem> Items { get; set; }
        private GroceryItem? _selectedItem;
        public GroceryItem? SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                DeleteItemCommand.RaiseCanExecuteChanged();
            }
        }
        public string NewItemName { get; set; } = "";
        public decimal NewItemPrice { get; set; }
        public int NewItemQuantity { get; set; }

        
        public GroceryInventory() 
        {
            data = new InventoryData();
            Items = data.Load();
            AddItemCommand = new RelayCommand(AddItem);
            DeleteItemCommand = new RelayCommand(DeleteItem, CanDeleteItem);
        }
        

        public void AddItem()
        {
            GroceryItem item = new GroceryItem();
            item.Name = NewItemName;
            item.Price = NewItemPrice;
            item.Quantity = NewItemQuantity;

            Items.Add(item);
            item.Id = Items.Count;

            data.Save(Items);
        }

        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
                data.Save(Items);
            }
        }
        private bool CanDeleteItem()
        {
            return SelectedItem != null;
        }
    }
}
