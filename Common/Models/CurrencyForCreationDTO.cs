using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CurrencyForCreationDTO
    {
        public string Code { get; set; }
        public string Legend { get; set; }
        public string Symbol { get; set; }
        public double ConvertibilityIndex { get; set; }
    }
}
