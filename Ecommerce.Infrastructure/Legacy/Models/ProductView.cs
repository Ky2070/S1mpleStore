using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class ProductView
{
    public int Id { get; set; }

    public int? Mahh { get; set; }

    public string? Makh { get; set; }

    public DateTime? ViewedAt { get; set; }

    public virtual Hanghoa? MahhNavigation { get; set; }

    public virtual Khachhang? MakhNavigation { get; set; }
}
