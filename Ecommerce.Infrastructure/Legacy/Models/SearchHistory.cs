using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class SearchHistory
{
    public int Id { get; set; }

    public string? Makh { get; set; }

    public string? Keyword { get; set; }

    public DateTime? Ngaytim { get; set; }

    public virtual Khachhang? MakhNavigation { get; set; }
}
