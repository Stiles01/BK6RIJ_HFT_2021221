using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public Product()
        {
            Orders = new HashSet<Order>();
        }
    }
}
