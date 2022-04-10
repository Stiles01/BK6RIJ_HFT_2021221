using BK6RIJ_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BK6RIJ_HFT_2021221.WPFClient.ViewModels
{
    public class DeliveryWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Delivery> Deliveries { get; set; }

        private Delivery selectedDeliveries;

        public Delivery SelectedDeliveries
        {
            get { return selectedDeliveries; }
            set
            {
                if (value != null)
                {
                    selectedDeliveries = new Delivery()
                    {
                        Company = value.Company,
                        DeliveryDays = value.DeliveryDays,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteDeliveryCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }


        public ICommand CreateDeliveryCommand { get; set; }
        public ICommand DeleteDeliveryCommand { get; set; }
        public ICommand UpdateDeliveryCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public DeliveryWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Deliveries = new RestCollection<Delivery>("http://localhost:9973/", "delivery", "hub");
                CreateDeliveryCommand = new RelayCommand(() =>
                {
                    Deliveries.Add(new Delivery()
                    {
                        DeliveryDays = SelectedDeliveries.DeliveryDays,
                        Company = SelectedDeliveries.Company
                    });
                });

                UpdateDeliveryCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Deliveries.Update(SelectedDeliveries);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteDeliveryCommand = new RelayCommand(() =>
                {
                    Deliveries.Delete(SelectedDeliveries.Id);
                }, () =>
                {
                    return SelectedDeliveries != null;
                });
                SelectedDeliveries = new Delivery();

            }

        }
    }
}
