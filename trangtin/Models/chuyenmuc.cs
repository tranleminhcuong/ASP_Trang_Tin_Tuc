using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trangtin.Models
{
    public class chuyenmuc
    {
        public int chuyenmucid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên chuyên mục.")]
        [Display(Name = "Tên chuyên mục")]
        public string tenchuyenmuc { get; set; }
        [Display(Name = "Thứ tự")]
        public int thutu { get; set; }
        
        public ICollection<chude> chudes { get; set; }
    }
}
