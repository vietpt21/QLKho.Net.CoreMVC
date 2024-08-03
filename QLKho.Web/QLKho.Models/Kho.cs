using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class Kho
    {
        [Key]
        public int Id { get; set; }
        public string TenKho { get; set; }
        public string HienThi { get; set; }
        public string GhiChu { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

    }
}
