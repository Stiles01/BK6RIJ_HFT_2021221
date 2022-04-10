using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.WPFClient.ViewModels
{
    public class MainWindowViewModel
    {
        public RestCollection<Customer> Customers { get; set; }

        public MainWindowViewModel()
        {
            Customers = new RestCollection<Customer>("http://localhost:9973/", "customer");
        }
    }
}
