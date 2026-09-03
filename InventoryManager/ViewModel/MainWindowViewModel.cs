using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryManager.Commands;
using InventoryManager.Model;
using InventoryManager.View;

namespace InventoryManager.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand ShowAddItemCommand { get; }
        public ICommand ShowInventoryCommand { get; }
        public RelayCommand ShowEditItemCommand { get; }
        public RelayCommand AddCloseCommand { get; }
        public RelayCommand EditCloseCommand { get; }


        private UserControl _currentView = null!;

        public GroceryInventory Inventory { get; }
        public GroceryItem? CurrentItem
        {
            get { return Inventory.SelectedItem; }
            set
            {
                Inventory.SelectedItem = value;
                ShowEditItemCommand.RaiseCanExecuteChanged();
            }
        }

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
            ShowEditItemCommand = new RelayCommand(ShowEditItem, CanShowEditItem);
            AddCloseCommand = new RelayCommand(AddItemAndClose);
            EditCloseCommand = new RelayCommand(EditItemAndClose);

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

        private void ShowEditItem()
        {
            CurrentView = new EditItemView();
        }
        private bool CanShowEditItem()
        {
            return CurrentItem != null;
        }
        private void AddItemAndClose()
        {
            Inventory.AddItem();
            ShowInventory();
        }
        private void EditItemAndClose()
        {
            Inventory.EditItem();
            ShowInventory();
        }

    }
}
