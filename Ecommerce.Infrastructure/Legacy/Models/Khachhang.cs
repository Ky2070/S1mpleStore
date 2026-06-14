using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Khachhang
{
    public string Makh { get; set; } = null!;

    public string? Matkhau { get; set; }

    public string Hoten { get; set; } = null!;

    public bool Gioitinh { get; set; }

    public DateTime Ngaysinh { get; set; }

    public string? Diachi { get; set; }

    public string? Dienthoai { get; set; }

    public string Email { get; set; } = null!;

    public string? Hinh { get; set; }

    public bool Hieuluc { get; set; }

    public int Vaitro { get; set; }

    public string? Randomkey { get; set; }

    public virtual ICollection<Banbe> Banbes { get; set; } = new List<Banbe>();

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();

    public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();

    public virtual ICollection<Yeuthich> Yeuthiches { get; set; } = new List<Yeuthich>();
}
