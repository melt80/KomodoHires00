using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Models.Contract
{
    public class ContractDetail
    {
        public int ContractID { get; set; }
        public int DeveloperID { get; set; }
        public int TeamID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
