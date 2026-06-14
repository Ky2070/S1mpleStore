using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Danhgium
{
    public int Madg { get; set; }

    public int Mahh { get; set; }

    public string Makh { get; set; } = null!;

    public int? Sosao { get; set; }

    public string? Binhluan { get; set; }

    public DateTime? Ngaytao { get; set; }

    public virtual Hanghoa MahhNavigation { get; set; } = null!;

    public virtual Khachhang MakhNavigation { get; set; } = null!;
}
