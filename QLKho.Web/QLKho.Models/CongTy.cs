using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class CongTy
    {
        [Key]
        public int Id { get; set; }
        public string TenCTy { get; set; }
    }
}
