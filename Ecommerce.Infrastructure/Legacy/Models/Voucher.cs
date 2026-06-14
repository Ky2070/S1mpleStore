using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Voucher
{
    public string Mavoucher { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Loai { get; set; }

    public double? Giatri { get; set; }

    public double? Giatritoida { get; set; }

    public double? DieukienToithieu { get; set; }

    public int? Soluong { get; set; }

    public DateTime? Ngaybatdau { get; set; }

    public DateTime? Ngayketthuc { get; set; }

    public bool? Trangthai { get; set; }

    public virtual ICollection<Hoadon> Mahds { get; set; } = new List<Hoadon>();
}
