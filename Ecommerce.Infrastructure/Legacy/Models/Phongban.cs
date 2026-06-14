using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Legacy.Models;

public partial class Phongban
{
    public string Mapb { get; set; } = null!;

    public string Tenpb { get; set; } = null!;

    public string? Thongtin { get; set; }

    public virtual ICollection<Phancong> Phancongs { get; set; } = new List<Phancong>();

    public virtual ICollection<Phanquyen> Phanquyens { get; set; } = new List<Phanquyen>();
}
