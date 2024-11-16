using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Conversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; }
        public Currency SourceCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public DateTime ConversionDate { get; set; } = DateTime.Now;
        public decimal ConvertedAmount { get; set; }
        public decimal ConvertedOutput { get; set; }
    }
}
