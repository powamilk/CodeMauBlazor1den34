using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHocSinhShare.Entities
{
    public class HocSinh
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên học sinh không được để trống")]
        [StringLength(50, ErrorMessage = "Tên học sinh không được quá 50 ký tự")]
        public string TenHocSinh { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; }

        [Range(1, 120, ErrorMessage = "Tuổi phải nằm trong khoảng từ 1 đến 120")]
        public int Tuoi { get; set; }

        [NotMapped] 
        public bool IsSelected { get; set; } = false;
    }

}
