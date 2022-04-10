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
    public class ProductWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Product> Products { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value != null)
                {
                    selectedProduct = new Product()
                    {
                        Name = value.Name,
                        Price = value.Price,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteProductCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }


        public ICommand CreateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ProductWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Products = new RestCollection<Product>("http://localhost:9973/", "product", "hub");
                CreateProductCommand = new RelayCommand(() =>
                {
                    Products.Add(new Product()
                    {
                        Name = SelectedProduct.Name,
                        Price = SelectedProduct.Price
                    });
                });

                UpdateProductCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Products.Update(SelectedProduct);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteProductCommand = new RelayCommand(() =>
                {
                    Products.Delete(SelectedProduct.Id);
                }, () =>
                {
                    return SelectedProduct != null;
                });
                SelectedProduct = new Product();

            }

        }
    }
}
