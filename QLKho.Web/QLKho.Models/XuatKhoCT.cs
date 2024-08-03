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
    public class XuatKhoCT
    {
        [Key]
        public int Id { get; set; }
        public string LoaiXuat { get; set; }
        [Required]
        public int XuatKhoId { get; set; }
        [ForeignKey("XuatKhoId")]
        [ValidateNever]
        public XuatKho XuatKho { get; set; }
        public DateTime NgayXuat { get; set; }
        [Required]
        public int SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        [ValidateNever]
        public SanPham SanPham { get; set; }
        public string TenSanPham { get; set; }
        public string NhomSanPham { get; set; }
        public string HangSanXuat { get; set; }
        public string HinhAnh { get; set; }
        public string ThongTin { get; set; }
        public string QuyCach { get; set; }
        public string Dvt { get; set; }
        public string SoLo { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int SLXuat { get; set; }
        public int SLXuatTong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiTao { get; set; }
    }
}
