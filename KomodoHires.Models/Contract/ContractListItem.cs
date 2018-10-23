using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Models.Contract
{
    public class ContractListItem
    {
        public int ContractID { get; set; }
        public int DeveloperID { get; set; }
        public int TeamID { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
