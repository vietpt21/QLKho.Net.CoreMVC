using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Models
{
    public class NhapKhoCT
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NhapKhoId { get; set; }
        [ForeignKey("NhapKhoId")]
        [ValidateNever]
        public NhapKho NhapKho { get; set; }
        public DateTime NgayNhap { get; set; }
        [Required]
        public int SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        [ValidateNever]
        public SanPham SanPham { get; set; }
        public string NhomSanPham { get; set; }
        public string HangXanXuat { get; set; }
        public string HinhAnh { get; set; }
        public string? ThongTin { get; set; }
        public DateTime HanSuDung { get; set; }
        public string QuyCach { get; set; }
        public string Dvt { get; set; }
        public string Solo { get; set; }
        public double GiaNhap { get; set; }
        public int SLNhap { get; set; }
        public int SLXuat { get; set; }
        public int SLTon { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string Ghichu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string? NguoiTao { get; set; }
    }
}
