using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string SoLo { get; set; }
        public string Distribution { get; set; }
    }
}
