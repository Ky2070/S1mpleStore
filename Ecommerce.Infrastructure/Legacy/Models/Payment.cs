using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Payment
{
    public string PaymentId { get; set; } = null!;

    public int Mahd { get; set; }

    public string? Phuongthuc { get; set; }

    public double Sotien { get; set; }

    public string? Trangthai { get; set; }

    public string? TransId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Hoadon MahdNavigation { get; set; } = null!;
}
