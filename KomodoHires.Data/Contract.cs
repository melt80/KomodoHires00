using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Data
{
    public class Contract
    {
        [Key]
        public int ContractID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public int DeveloperID { get; set; }
        [Required]
        public int TeamID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Team Team { get; set; }

    }
}
