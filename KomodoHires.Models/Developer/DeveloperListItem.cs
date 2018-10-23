using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Models.Developer
{
    public class DeveloperListItem
    {
        public int DeveloperID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
