using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QLKho.Models
{
    public class NhapKho
    {
        [Key]
        public int Id { get; set; }
        public string LoaiNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        [Required]
        public int NhaCungCapId { get; set; }
        [ForeignKey("NhaCungCapId")]
        [ValidateNever]
        public NhaCungCap NhaCungCap { get; set; }

        [Required]
        public int KhoId { get; set; }
        [ForeignKey("KhoId")]
        [ValidateNever]
        public Kho Kho { get; set; }
        public int SoLuongNhap { get; set; }
        public string Nguoigiao { get; set; }
        public string NoiDungNhap { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? NguoiTao { get; set; }
    }
}
