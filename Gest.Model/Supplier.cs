﻿using System.ComponentModel.DataAnnotations;

namespace Gest.Model
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(5)]
        public string Code { get; set; }

        public decimal Treshold { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string MainEmail { get; set; }

        public bool? IsActive { get; set; }

        public int? TypeOfSupplierId { get; set; }

        public SupplierType TypeOfSupplier { get; set; }
    }
}