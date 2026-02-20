using PMSManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMSManager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowListViewCommand { get; }
        public ICommand ShowAddViewCommand { get; }
        public ICommand ExitCommand { get; }

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(); 
            }
        }

        private readonly ListEditAllTransactionsView _listView;
        private readonly AddNewTransactionView _addView;

        public MainWindowViewModel()
        {
            _listView = new ListEditAllTransactionsView
            {
                DataContext = new ListEditAllTransactionsViewModel()
            };

            _addView = new AddNewTransactionView
            {
                DataContext = new AddNewTransactionViewModel()
            };

            ShowListViewCommand = new RelayCommand(_ => ShowListView());
            ShowAddViewCommand = new RelayCommand(_ => ShowAddView());
            ExitCommand = new RelayCommand(_ => System.Windows.Application.Current.Shutdown());

            CurrentViewModel = _listView;
        }

        private void ShowListView()
        {
            System.Diagnostics.Debug.WriteLine("Switched to List View");
            CurrentViewModel = _listView;
        }
        private void ShowAddView() => CurrentViewModel = _addView;
    }
}
