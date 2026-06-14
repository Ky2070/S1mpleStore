using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class GiohangChitiet
{
    public int Magh { get; set; }

    public int Mahh { get; set; }

    public int Soluong { get; set; }

    public virtual Giohang MaghNavigation { get; set; } = null!;

    public virtual Hanghoa MahhNavigation { get; set; } = null!;
}
