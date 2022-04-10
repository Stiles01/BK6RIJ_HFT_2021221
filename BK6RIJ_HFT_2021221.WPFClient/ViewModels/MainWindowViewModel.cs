using BK6RIJ_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BK6RIJ_HFT_2021221.WPFClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set 
            { 
                SetProperty(ref selectedCustomer, value);
                (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                //(UpdateCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }

        public MainWindowViewModel()
        {
            Customers = new RestCollection<Customer>("http://localhost:9973/", "customer");
            CreateCustomerCommand = new RelayCommand(() => 
            {
                Customers.Add(new Customer()
                {
                    FirstName = "FirstName",
                    LastName = "LastName"
                });
            });

            DeleteCustomerCommand = new RelayCommand(() => 
            {
                Customers.Delete(selectedCustomer.Id);
            }, () => SelectedCustomer != null);
        }
    }
}
