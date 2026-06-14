using System;
using System.Collections.Generic;
using Ecommerce.Infrastructure.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Legacy;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banbe> Banbes { get; set; }

    public virtual DbSet<Chitiethd> Chitiethds { get; set; }

    public virtual DbSet<Chude> Chudes { get; set; }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<GiohangChitiet> GiohangChitiets { get; set; }

    public virtual DbSet<Gopy> Gopies { get; set; }

    public virtual DbSet<Hanghoa> Hanghoas { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hoidap> Hoidaps { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Phancong> Phancongs { get; set; }

    public virtual DbSet<Phanquyen> Phanquyens { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<Trangthai> Trangthais { get; set; }

    public virtual DbSet<Trangweb> Trangwebs { get; set; }

    public virtual DbSet<VProductDetail> VProductDetails { get; set; }

    public virtual DbSet<Vchitiethoadon> Vchitiethoadons { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<Yeuthich> Yeuthiches { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banbe>(entity =>
        {
            entity.HasKey(e => e.Mabb).HasName("pk_promotions");

            entity.ToTable("banbe");

            entity.Property(e => e.Mabb)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mabb");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Ghichu).HasColumnName("ghichu");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Ngaygui)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaygui");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Banbes)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_banbe_hanghoa");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Banbes)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("fk_banbe_khachhang");
        });

        modelBuilder.Entity<Chitiethd>(entity =>
        {
            entity.HasKey(e => e.Mact).HasName("pk_orderdetails");

            entity.ToTable("chitiethd");

            entity.Property(e => e.Mact)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mact");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthd_hoadon");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthd_hanghoa");
        });

        modelBuilder.Entity<Chude>(entity =>
        {
            entity.HasKey(e => e.Macd).HasName("pk_chude");

            entity.ToTable("chude");

            entity.Property(e => e.Macd)
                .UseIdentityAlwaysColumn()
                .HasColumnName("macd");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Tencd)
                .HasMaxLength(50)
                .HasColumnName("tencd");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Chudes)
                .HasForeignKey(d => d.Manv)
                .HasConstraintName("fk_chude_nhanvien");
        });

        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity.HasKey(e => e.Madg).HasName("danhgia_pkey");

            entity.ToTable("danhgia");

            entity.HasIndex(e => e.Mahh, "idx_danhgia_mahh");

            entity.Property(e => e.Madg)
                .UseIdentityAlwaysColumn()
                .HasColumnName("madg");
            entity.Property(e => e.Binhluan).HasColumnName("binhluan");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Sosao).HasColumnName("sosao");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_danhgia_hanghoa");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_danhgia_khachhang");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.Magh).HasName("giohang_pkey");

            entity.ToTable("giohang");

            entity.HasIndex(e => e.Makh, "idx_giohang_makh");

            entity.Property(e => e.Magh)
                .UseIdentityAlwaysColumn()
                .HasColumnName("magh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaytao");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("giohang_makh_fkey");
        });

        modelBuilder.Entity<GiohangChitiet>(entity =>
        {
            entity.HasKey(e => new { e.Magh, e.Mahh }).HasName("giohang_chitiet_pkey");

            entity.ToTable("giohang_chitiet");

            entity.Property(e => e.Magh).HasColumnName("magh");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MaghNavigation).WithMany(p => p.GiohangChitiets)
                .HasForeignKey(d => d.Magh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("giohang_chitiet_magh_fkey");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.GiohangChitiets)
                .HasForeignKey(d => d.Mahh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("giohang_chitiet_mahh_fkey");
        });

        modelBuilder.Entity<Gopy>(entity =>
        {
            entity.HasKey(e => e.Magy).HasName("pk_gopy");

            entity.ToTable("gopy");

            entity.Property(e => e.Magy)
                .HasMaxLength(50)
                .HasColumnName("magy");
            entity.Property(e => e.Cantraloi).HasColumnName("cantraloi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(50)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Macd).HasColumnName("macd");
            entity.Property(e => e.Ngaygy).HasColumnName("ngaygy");
            entity.Property(e => e.Ngaytl).HasColumnName("ngaytl");
            entity.Property(e => e.Noidung).HasColumnName("noidung");
            entity.Property(e => e.Traloi)
                .HasMaxLength(50)
                .HasColumnName("traloi");

            entity.HasOne(d => d.MacdNavigation).WithMany(p => p.Gopies)
                .HasForeignKey(d => d.Macd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gopy_chude");
        });

        modelBuilder.Entity<Hanghoa>(entity =>
        {
            entity.HasKey(e => e.Mahh).HasName("pk_products");

            entity.ToTable("hanghoa");

            entity.HasIndex(e => e.Maloai, "idx_hanghoa_loai");

            entity.HasIndex(e => e.Mancc, "idx_hanghoa_ncc");

            entity.Property(e => e.Mahh)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mahh");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Maloai).HasColumnName("maloai");
            entity.Property(e => e.Mancc)
                .HasMaxLength(50)
                .HasColumnName("mancc");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Motadonvi)
                .HasMaxLength(50)
                .HasColumnName("motadonvi");
            entity.Property(e => e.Ngaysx)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaysx");
            entity.Property(e => e.Solanxem)
                .HasDefaultValue(0)
                .HasColumnName("solanxem");
            entity.Property(e => e.Tenalias)
                .HasMaxLength(50)
                .HasColumnName("tenalias");
            entity.Property(e => e.Tenhh)
                .HasMaxLength(50)
                .HasColumnName("tenhh");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Hanghoas)
                .HasForeignKey(d => d.Maloai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hanghoa_loai");

            entity.HasOne(d => d.ManccNavigation).WithMany(p => p.Hanghoas)
                .HasForeignKey(d => d.Mancc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hanghoa_ncc");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("pk_orders");

            entity.ToTable("hoadon");

            entity.HasIndex(e => e.Makh, "idx_hoadon_makh");

            entity.Property(e => e.Mahd)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mahd");
            entity.Property(e => e.Cachthanhtoan)
                .HasMaxLength(50)
                .HasColumnName("cachthanhtoan");
            entity.Property(e => e.Cachvanchuyen)
                .HasMaxLength(50)
                .HasColumnName("cachvanchuyen");
            entity.Property(e => e.Diachi)
                .HasMaxLength(60)
                .HasColumnName("diachi");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("ghichu");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Matrangthai).HasColumnName("matrangthai");
            entity.Property(e => e.Ngaycan)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaycan");
            entity.Property(e => e.Ngaydat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaydat");
            entity.Property(e => e.Ngaygiao)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaygiao");
            entity.Property(e => e.Phivanchuyen).HasColumnName("phivanchuyen");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoadon_khachhang");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Manv)
                .HasConstraintName("fk_hoadon_nhanvien");

            entity.HasOne(d => d.MatrangthaiNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Matrangthai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoadon_trangthai");

            entity.HasMany(d => d.Mavouchers).WithMany(p => p.Mahds)
                .UsingEntity<Dictionary<string, object>>(
                    "HoadonVoucher",
                    r => r.HasOne<Voucher>().WithMany()
                        .HasForeignKey("Mavoucher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("hoadon_voucher_mavoucher_fkey"),
                    l => l.HasOne<Hoadon>().WithMany()
                        .HasForeignKey("Mahd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("hoadon_voucher_mahd_fkey"),
                    j =>
                    {
                        j.HasKey("Mahd", "Mavoucher").HasName("hoadon_voucher_pkey");
                        j.ToTable("hoadon_voucher");
                        j.IndexerProperty<int>("Mahd").HasColumnName("mahd");
                        j.IndexerProperty<string>("Mavoucher")
                            .HasMaxLength(20)
                            .HasColumnName("mavoucher");
                    });
        });

        modelBuilder.Entity<Hoidap>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("pk_hoidap");

            entity.ToTable("hoidap");

            entity.Property(e => e.Mahd)
                .ValueGeneratedNever()
                .HasColumnName("mahd");
            entity.Property(e => e.Cauhoi)
                .HasMaxLength(255)
                .HasColumnName("cauhoi");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Ngaydua).HasColumnName("ngaydua");
            entity.Property(e => e.Traloi)
                .HasMaxLength(255)
                .HasColumnName("traloi");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Hoidaps)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoidap_nhanvien");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makh).HasName("pk_customers");

            entity.ToTable("khachhang");

            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Diachi)
                .HasMaxLength(60)
                .HasColumnName("diachi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(24)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");
            entity.Property(e => e.Hieuluc)
                .HasDefaultValue(true)
                .HasColumnName("hieuluc");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Randomkey)
                .HasMaxLength(50)
                .HasColumnName("randomkey");
            entity.Property(e => e.Vaitro)
                .HasDefaultValue(0)
                .HasColumnName("vaitro");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("pk_categories");

            entity.ToTable("loai");

            entity.Property(e => e.Maloai)
                .UseIdentityAlwaysColumn()
                .HasColumnName("maloai");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(50)
                .HasColumnName("tenloai");
            entity.Property(e => e.Tenloaialias)
                .HasMaxLength(50)
                .HasColumnName("tenloaialias");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.Mancc).HasName("pk_suppliers");

            entity.ToTable("nhacungcap");

            entity.Property(e => e.Mancc)
                .HasMaxLength(50)
                .HasColumnName("mancc");
            entity.Property(e => e.Diachi)
                .HasMaxLength(50)
                .HasColumnName("diachi");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(50)
                .HasColumnName("dienthoai");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Logo)
                .HasMaxLength(50)
                .HasColumnName("logo");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Nguoilienlac)
                .HasMaxLength(50)
                .HasColumnName("nguoilienlac");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(50)
                .HasColumnName("tencongty");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv).HasName("pk_nhanvien");

            entity.ToTable("nhanvien");

            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Phuongthuc)
                .HasMaxLength(20)
                .HasColumnName("phuongthuc");
            entity.Property(e => e.Sotien).HasColumnName("sotien");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("trangthai");
            entity.Property(e => e.TransId)
                .HasMaxLength(100)
                .HasColumnName("trans_id");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_mahd_fkey");
        });

        modelBuilder.Entity<Phancong>(entity =>
        {
            entity.HasKey(e => e.Mapc).HasName("pk_phancong");

            entity.ToTable("phancong");

            entity.Property(e => e.Mapc)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mapc");
            entity.Property(e => e.Hieuluc).HasColumnName("hieuluc");
            entity.Property(e => e.Manv)
                .HasMaxLength(50)
                .HasColumnName("manv");
            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Ngaypc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaypc");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Phancongs)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phancong_nhanvien");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.Phancongs)
                .HasForeignKey(d => d.Mapb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phancong_phongban");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.Mapq).HasName("pk_phanquyen");

            entity.ToTable("phanquyen");

            entity.Property(e => e.Mapq)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mapq");
            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Matrang).HasColumnName("matrang");
            entity.Property(e => e.Sua)
                .HasDefaultValue(false)
                .HasColumnName("sua");
            entity.Property(e => e.Them)
                .HasDefaultValue(false)
                .HasColumnName("them");
            entity.Property(e => e.Xem)
                .HasDefaultValue(false)
                .HasColumnName("xem");
            entity.Property(e => e.Xoa)
                .HasDefaultValue(false)
                .HasColumnName("xoa");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.Phanquyens)
                .HasForeignKey(d => d.Mapb)
                .HasConstraintName("fk_phanquyen_phongban");

            entity.HasOne(d => d.MatrangNavigation).WithMany(p => p.Phanquyens)
                .HasForeignKey(d => d.Matrang)
                .HasConstraintName("fk_phanquyen_trangweb");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.Mapb).HasName("pk_phongban");

            entity.ToTable("phongban");

            entity.Property(e => e.Mapb)
                .HasMaxLength(7)
                .HasColumnName("mapb");
            entity.Property(e => e.Tenpb)
                .HasMaxLength(50)
                .HasColumnName("tenpb");
            entity.Property(e => e.Thongtin).HasColumnName("thongtin");
        });

        modelBuilder.Entity<ProductView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_view_pkey");

            entity.ToTable("product_view");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.ViewedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("viewed_at");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.Mahh)
                .HasConstraintName("product_view_mahh_fkey");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("product_view_makh_fkey");
        });

        modelBuilder.Entity<SearchHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("search_history_pkey");

            entity.ToTable("search_history");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Keyword)
                .HasMaxLength(255)
                .HasColumnName("keyword");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Ngaytim)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaytim");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.SearchHistories)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("search_history_makh_fkey");
        });

        modelBuilder.Entity<Trangthai>(entity =>
        {
            entity.HasKey(e => e.Matrangthai).HasName("pk_trangthai");

            entity.ToTable("trangthai");

            entity.Property(e => e.Matrangthai)
                .ValueGeneratedNever()
                .HasColumnName("matrangthai");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.Tentrangthai)
                .HasMaxLength(50)
                .HasColumnName("tentrangthai");
        });

        modelBuilder.Entity<Trangweb>(entity =>
        {
            entity.HasKey(e => e.Matrang).HasName("pk_trangweb");

            entity.ToTable("trangweb");

            entity.Property(e => e.Matrang)
                .UseIdentityAlwaysColumn()
                .HasColumnName("matrang");
            entity.Property(e => e.Tentrang)
                .HasMaxLength(50)
                .HasColumnName("tentrang");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("url");
        });

        modelBuilder.Entity<VProductDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_product_detail");

            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Tenhh)
                .HasMaxLength(50)
                .HasColumnName("tenhh");
            entity.Property(e => e.TotalReview).HasColumnName("total_review");
        });

        modelBuilder.Entity<Vchitiethoadon>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vchitiethoadon");

            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Giamgia).HasColumnName("giamgia");
            entity.Property(e => e.Mact).HasColumnName("mact");
            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Tenhh)
                .HasMaxLength(50)
                .HasColumnName("tenhh");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Mavoucher).HasName("voucher_pkey");

            entity.ToTable("voucher");

            entity.Property(e => e.Mavoucher)
                .HasMaxLength(20)
                .HasColumnName("mavoucher");
            entity.Property(e => e.DieukienToithieu).HasColumnName("dieukien_toithieu");
            entity.Property(e => e.Giatri).HasColumnName("giatri");
            entity.Property(e => e.Giatritoida).HasColumnName("giatritoida");
            entity.Property(e => e.Loai)
                .HasMaxLength(20)
                .HasColumnName("loai");
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaybatdau");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngayketthuc");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Ten)
                .HasMaxLength(100)
                .HasColumnName("ten");
            entity.Property(e => e.Trangthai)
                .HasDefaultValue(true)
                .HasColumnName("trangthai");
        });

        modelBuilder.Entity<Yeuthich>(entity =>
        {
            entity.HasKey(e => e.Mayt).HasName("pk_favorites");

            entity.ToTable("yeuthich");

            entity.Property(e => e.Mayt)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mayt");
            entity.Property(e => e.Mahh).HasColumnName("mahh");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .HasColumnName("makh");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");
            entity.Property(e => e.Ngaychon)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngaychon");

            entity.HasOne(d => d.MahhNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Mahh)
                .HasConstraintName("fk_yeuthich_hanghoa");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("fk_yeuthich_khachhang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
