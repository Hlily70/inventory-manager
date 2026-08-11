using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using InventoryManager.View;
using System.Windows.Input;
using InventoryManager.Commands;

namespace InventoryManager.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand ShowAddItemCommand { get; }
        public ICommand ShowInventoryCommand { get; }

        private UserControl _currentView = null!;

        public GroceryInventory Inventory { get; }

        public UserControl CurrentView
        {
            get { return _currentView; }

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            ShowAddItemCommand = new RelayCommand(ShowAddItem);
            ShowInventoryCommand = new RelayCommand(ShowInventory);

            Inventory = new GroceryInventory();

            CurrentView = new InventoryView();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private void ShowAddItem()
        {
            CurrentView = new AddItemView();
        }

        private void ShowInventory()
        {
            CurrentView = new InventoryView();
        }
    }
}
