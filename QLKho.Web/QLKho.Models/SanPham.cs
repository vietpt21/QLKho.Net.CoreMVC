using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public string HienThi { get; set; }
        public string NhomSanPham { get; set; }
        public string HangSanXuat { get; set; }
        public string? HinhAnh { get; set; }
        public string DiaChi { get; set; }
        public string ThongTin { get; set; }
        public DateTime HanSuDung { get; set; }
        public string QuyCach { get; set; }
        public string Dvt { get; set; }
        public double GiaNhap { get; set; }
        public int SLToiThieu { get; set; }
        public int SLToiDa { get; set; }
        public int SLNhap { get; set; }
        public int SLXuat{ get; set; }
        public int SLTon { get; set; }
        public string TrangThai { get; set; }
        public string Ghichu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string? NguoiTao { get; set; }
        
    }
}
