﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHires.Data
{
    public class Developer
    {
        [Key]
        public int DeveloperID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
