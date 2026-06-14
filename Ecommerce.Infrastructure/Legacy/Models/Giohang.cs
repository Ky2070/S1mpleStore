using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Giohang
{
    public int Magh { get; set; }

    public string Makh { get; set; } = null!;

    public DateTime? Ngaytao { get; set; }

    public virtual ICollection<GiohangChitiet> GiohangChitiets { get; set; } = new List<GiohangChitiet>();

    public virtual Khachhang MakhNavigation { get; set; } = null!;
}
