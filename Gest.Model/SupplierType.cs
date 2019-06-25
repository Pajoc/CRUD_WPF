using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Gest.Model
{
    public class SupplierType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
