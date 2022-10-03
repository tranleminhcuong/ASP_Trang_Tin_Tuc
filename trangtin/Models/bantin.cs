using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trangtin.Models
{
    public class bantin
    {
		public int bantinid { get; set; }

		[Display(Name = "Chủ đề")]
		public int chudeid { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
		[Display(Name = "Tiêu đề")]
		public string tieude { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập tóm tắt.")]
		[Display(Name = "Tóm tắt")]
		public string tomtat { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập nội dung.")]
		[Display(Name = "Nội dung")]
		public string noidung { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Ngày đăng")]
		public DateTime ngaydang { get; set; }

		[Display(Name = "Người đăng")]
		public string nguoidang { get; set; }

		[Display(Name = "Hình ảnh")]
		public string hinhanh { get; set; }

		[Display(Name = "Tiêu đề hình ảnh")]
		public string tieudehinh { get; set; }

		[Display(Name = "Lượt xem")]
		public int luotxem { get; set; }

		[Display(Name = "Đánh dấu tin nổi bật")]
		public bool noibat { get; set; }

		[Display(Name = "Trạng thái kích hoạt")]
		public bool kichhoat { get; set; }

		public chude chude { get; set; }
	}
}
