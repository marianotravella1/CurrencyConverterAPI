using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SubscriptionsForViewDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? ConversionLimit { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
