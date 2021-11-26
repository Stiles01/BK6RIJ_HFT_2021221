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
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Company { get; set; }
        public int DeliveryDays { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public Delivery()
        {
            Orders = new HashSet<Order>();
        }
    }
}
