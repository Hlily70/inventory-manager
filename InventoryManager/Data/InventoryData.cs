using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InventoryManager.Model;
using System.IO;

namespace InventoryManager.Data
{
    public class InventoryData
    {
        private string filePath = "inventory.json";

        public void Save(ObservableCollection<GroceryItem> items)
        {
            string json = JsonSerializer.Serialize(items);

            File.WriteAllText(filePath, json);
        }

        public ObservableCollection<GroceryItem> Load()
        {
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<GroceryItem>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new ObservableCollection<GroceryItem>();
            }

            ObservableCollection<GroceryItem>? items =
                JsonSerializer.Deserialize<ObservableCollection<GroceryItem>>(json);

            return items ?? new ObservableCollection<GroceryItem>();
        }


    }
}
