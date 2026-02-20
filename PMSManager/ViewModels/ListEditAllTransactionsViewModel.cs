using PMSLibrary.DataAccess;
using PMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSManager.ViewModels
{
    public class ListEditAllTransactionsViewModel : ViewModelBase
    {
        private readonly PMSDataManager _dataManager;

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<SalesTransaction> SalesTransactions { get; set; }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
                LoadSalesTransactionsAsync();
            }
        }

        public ListEditAllTransactionsViewModel()
        {
            _dataManager = new PMSDataManager();
            Employees = new ObservableCollection<Employee>();
            SalesTransactions = new ObservableCollection<SalesTransaction>();
            LoadEmployeesAsync();
        }

        private async void LoadEmployeesAsync()
        {
            var employees = await _dataManager.GetAllEmployeesAsync();
            Employees.Clear();
            foreach (var emp in employees)
                Employees.Add(emp);
        }

        private async void LoadSalesTransactionsAsync()
        {
            if (SelectedEmployee == null) return;
            var transactions = await _dataManager.GetTransactionsByEmployeeIdAsync(SelectedEmployee.Id);
            SalesTransactions.Clear();
            foreach (var txn in transactions)
                SalesTransactions.Add(txn);
        }
    }
}
