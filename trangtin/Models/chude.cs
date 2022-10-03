using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trangtin.Models
{
    public class chude
    {
        public int chudeid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên chủ đề.")]
        [Display(Name = "Tên chủ đề")]
        public string tenchude { get; set; }
        [Display(Name = "Thuộc chuyên mục")]
        public int chuyenmucid { get; set; }
        [Display(Name = "Thứ tự")]
        public int thutu { get; set; }
        [Display(Name = "Kích hoạt")]
        public int kichhoat { get; set; }
        public chuyenmuc chuyenmuc { get; set; }
        public ICollection<bantin> bantins { get; set; }
    }
}
