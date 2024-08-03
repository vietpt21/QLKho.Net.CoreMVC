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
        public string HienThi { get; set; }
        public string TenDayDu { get; set; }
        public string LoaiNCC { get; set; }
        public string Logo { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SDT { get; set; }
        public string TinhTrang { get; set; }
        public string NVPhuTrach { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

    }
}
