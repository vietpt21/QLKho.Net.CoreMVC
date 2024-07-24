using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
