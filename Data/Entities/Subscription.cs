using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public int? ConversionLimit { get; set; }
        public decimal Price { get; set; }
    }
}
