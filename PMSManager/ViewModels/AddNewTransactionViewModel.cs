using PMSLibrary.DataAccess;
using PMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PMSManager.ViewModels
{
    public class AddNewTransactionViewModel : ViewModelBase
    {
        private readonly PMSDataManager _dataManager;

        public ObservableCollection<Employee> Employees { get; set; } = new();
        public ObservableCollection<Product> Products { get; set; } = new();

        public Employee SelectedEmployee { get; set; }
        public Product SelectedProduct { get; set; }
        public int Amount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddNewTransactionViewModel()
        {
            _dataManager = new PMSDataManager();
            SaveCommand = new RelayCommand(_ => SaveTransaction());
            CancelCommand = new RelayCommand(_ => ClearForm());

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var employees = await _dataManager.GetAllEmployeesAsync();
            foreach (var emp in employees) Employees.Add(emp);

            var products = await _dataManager.GetAllProductsAsync();
            foreach (var prod in products) Products.Add(prod);
        }

        private async void SaveTransaction()
        {
            if (SelectedEmployee == null || SelectedProduct == null || Amount <= 0)
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            var transaction = new SalesTransaction
            {
                EmployeeId = SelectedEmployee.Id,
                ProductCode = SelectedProduct.Code,
                Amount = Amount,
                SaleDate = SaleDate
            };

            await _dataManager.AddTransactionAsync(transaction);
            MessageBox.Show("Transaction saved successfully!");
            ClearForm();
        }

        private void ClearForm()
        {
            SelectedEmployee = null;
            SelectedProduct = null;
            Amount = 0;
            SaleDate = DateTime.Now;
            OnPropertyChanged(nameof(SelectedEmployee));
            OnPropertyChanged(nameof(SelectedProduct));
            OnPropertyChanged(nameof(Amount));
            OnPropertyChanged(nameof(SaleDate));
        }
    }
}
