using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLTHPT.Models
{
    public partial class acomptec_qlthptContext : DbContext
    {
        public acomptec_qlthptContext()
        {
        }

        public acomptec_qlthptContext(DbContextOptions<acomptec_qlthptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bacluong> Bacluong { get; set; }
        public virtual DbSet<Canbo> Canbo { get; set; }
        public virtual DbSet<ChitietChucvu> ChitietChucvu { get; set; }
        public virtual DbSet<Chitietdanhgia> Chitietdanhgia { get; set; }
        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<Chuyennganh> Chuyennganh { get; set; }
        public virtual DbSet<Coquan> Coquan { get; set; }
        public virtual DbSet<Cosovatchat> Cosovatchat { get; set; }
        public virtual DbSet<Dantoc> Dantoc { get; set; }
        public virtual DbSet<Hinhthuc> Hinhthuc { get; set; }
        public virtual DbSet<Hocky> Hocky { get; set; }
        public virtual DbSet<Hocsinh> Hocsinh { get; set; }
        public virtual DbSet<Khenthuong> Khenthuong { get; set; }
        public virtual DbSet<Khenthuongcb> Khenthuongcb { get; set; }
        public virtual DbSet<Khoi> Khoi { get; set; }
        public virtual DbSet<Kyluat> Kyluat { get; set; }
        public virtual DbSet<Kyluatcb> Kyluatcb { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        public virtual DbSet<Monhoc> Monhoc { get; set; }
        public virtual DbSet<Namhoc> Namhoc { get; set; }
        public virtual DbSet<Ngachluong> Ngachluong { get; set; }
        public virtual DbSet<Phonghoc> Phonghoc { get; set; }
        public virtual DbSet<Quanhuyen> Quanhuyen { get; set; }
        public virtual DbSet<Sodanhgia> Sodanhgia { get; set; }
        public virtual DbSet<Thietbidayhoc> Thietbidayhoc { get; set; }
        public virtual DbSet<Thietbigiangday> Thietbigiangday { get; set; }
        public virtual DbSet<Thoikhoabieu> Thoikhoabieu { get; set; }
        public virtual DbSet<Thongtindaotao> Thongtindaotao { get; set; }
        public virtual DbSet<Thongtinluong> Thongtinluong { get; set; }
        public virtual DbSet<Thu> Thu { get; set; }
        public virtual DbSet<Tiethoc> Tiethoc { get; set; }
        public virtual DbSet<Tinhthanh> Tinhthanh { get; set; }
        public virtual DbSet<Tinhtrang> Tinhtrang { get; set; }
        public virtual DbSet<UpdateImages> UpdateImages { get; set; }
        public virtual DbSet<Vanbang> Vanbang { get; set; }
        public virtual DbSet<Xaphuong> Xaphuong { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=210.245.90.239;Database=acomptec_qlthpt;User Id=acomptec_group11718;Password=group@11718");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "acomptec_group11718");

             modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("LOGIN", "dbo");

                entity.Property(e => e.UserName)
                    .HasColumnName("UN_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .HasColumnName("Pw")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Bacluong>(entity =>
            {
                entity.HasKey(e => e.BlMa);

                entity.ToTable("BACLUONG", "dbo");

                entity.Property(e => e.BlMa)
                    .HasColumnName("BL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BlTen)
                    .HasColumnName("BL_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Canbo>(entity =>
            {
                entity.HasKey(e => e.CbMa);

                entity.ToTable("CANBO", "dbo");

                entity.HasIndex(e => e.CoquanCqMa)
                    .HasName("IX_FK_COQUANCANBO");

                entity.HasIndex(e => e.KhenthuongcbKtcbMa)
                    .HasName("IX_FK_KHENTHUONGCBCANBO");

                entity.HasIndex(e => e.KyluatcbKlcbMa)
                    .HasName("IX_FK_KYLUATCBCANBO");

                entity.Property(e => e.CbMa)
                    .HasColumnName("CB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CbCmnd)
                    .IsRequired()
                    .HasColumnName("CB_CMND")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CbDiachi)
                    .HasColumnName("CB_DIACHI")
                    .HasMaxLength(200);

                entity.Property(e => e.CbGioitinh)
                    .HasColumnName("CB_GIOITINH")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CbHoten)
                    .IsRequired()
                    .HasColumnName("CB_HOTEN")
                    .HasMaxLength(50);

                entity.Property(e => e.CbNgaysinh)
                    .HasColumnName("CB_NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.CoquanCqMa)
                    .IsRequired()
                    .HasColumnName("COQUAN_CQ_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KhenthuongcbKtcbMa)
                    .IsRequired()
                    .HasColumnName("KHENTHUONGCB_KTCB_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KyluatcbKlcbMa)
                    .IsRequired()
                    .HasColumnName("KYLUATCB_KLCB_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoquanCqMaNavigation)
                    .WithMany(p => p.Canbo)
                    .HasForeignKey(d => d.CoquanCqMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COQUANCANBO");

                entity.HasOne(d => d.KhenthuongcbKtcbMaNavigation)
                    .WithMany(p => p.Canbo)
                    .HasForeignKey(d => d.KhenthuongcbKtcbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHENTHUONGCBCANBO");

                entity.HasOne(d => d.KyluatcbKlcbMaNavigation)
                    .WithMany(p => p.Canbo)
                    .HasForeignKey(d => d.KyluatcbKlcbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KYLUATCBCANBO");
            });

            modelBuilder.Entity<ChitietChucvu>(entity =>
            {
                entity.HasKey(e => e.CtCvId);

                entity.ToTable("CHITIET_CHUCVU", "dbo");

                entity.HasIndex(e => e.CanboCbMa)
                    .HasName("IX_FK_CANBOCHITIET_CHUCVU");

                entity.HasIndex(e => e.ChucvuCvMa)
                    .HasName("IX_FK_CHUCVUCHITIET_CHUCVU");

                entity.Property(e => e.CtCvId).HasColumnName("CT_CV_ID");

                entity.Property(e => e.CanboCbMa)
                    .IsRequired()
                    .HasColumnName("CANBO_CB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChucvuCvMa)
                    .IsRequired()
                    .HasColumnName("CHUCVU_CV_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CanboCbMaNavigation)
                    .WithMany(p => p.ChitietChucvu)
                    .HasForeignKey(d => d.CanboCbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANBOCHITIET_CHUCVU");

                entity.HasOne(d => d.ChucvuCvMaNavigation)
                    .WithMany(p => p.ChitietChucvu)
                    .HasForeignKey(d => d.ChucvuCvMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHUCVUCHITIET_CHUCVU");
            });

            modelBuilder.Entity<Chitietdanhgia>(entity =>
            {
                entity.HasKey(e => e.CtdgMa);

                entity.ToTable("CHITIETDANHGIA", "dbo");

                entity.HasIndex(e => e.HocsinhHsMa)
                    .HasName("IX_FK_HOCSINHCHITIETDANHGIA");

                entity.HasIndex(e => e.SodanhgiaSdgMa)
                    .HasName("IX_FK_SODANHGIACHITIETDANHGIA");

                entity.Property(e => e.CtdgMa)
                    .HasColumnName("CTDG_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CtdgNgaydg)
                    .HasColumnName("CTDG_NGAYDG")
                    .HasColumnType("datetime");

                entity.Property(e => e.HocsinhHsMa)
                    .IsRequired()
                    .HasColumnName("HOCSINH_HS_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SodanhgiaSdgMa)
                    .IsRequired()
                    .HasColumnName("SODANHGIA_SDG_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.HocsinhHsMaNavigation)
                    .WithMany(p => p.Chitietdanhgia)
                    .HasForeignKey(d => d.HocsinhHsMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOCSINHCHITIETDANHGIA");

                entity.HasOne(d => d.SodanhgiaSdgMaNavigation)
                    .WithMany(p => p.Chitietdanhgia)
                    .HasForeignKey(d => d.SodanhgiaSdgMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SODANHGIACHITIETDANHGIA");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.CvMa);

                entity.ToTable("CHUCVU", "dbo");

                entity.Property(e => e.CvMa)
                    .HasColumnName("CV_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvTen)
                    .HasColumnName("CV_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Chuyennganh>(entity =>
            {
                entity.HasKey(e => e.CnMa);

                entity.ToTable("CHUYENNGANH", "dbo");

                entity.Property(e => e.CnMa)
                    .HasColumnName("CN_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CnTen)
                    .HasColumnName("CN_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coquan>(entity =>
            {
                entity.HasKey(e => e.CqMa);

                entity.ToTable("COQUAN", "dbo");

                entity.Property(e => e.CqMa)
                    .HasColumnName("CQ_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CqTen)
                    .HasColumnName("CQ_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cosovatchat>(entity =>
            {
                entity.HasKey(e => e.CsvcMa);

                entity.ToTable("COSOVATCHAT", "dbo");

                entity.HasIndex(e => e.PhonghocPhMa)
                    .HasName("IX_FK_PHONGHOCCOSOVATCHAT");

                entity.HasIndex(e => e.ThietbidayhocTbdhMa)
                    .HasName("IX_FK_THIETBIDAYHOCCOSOVATCHAT");

                entity.HasIndex(e => e.ThietbigiangdayTbgdMa)
                    .HasName("IX_FK_THIETBIGIANGDAYCOSOVATCHAT");

                entity.HasIndex(e => e.TinhtrangTtMa)
                    .HasName("IX_FK_TINHTRANGCOSOVATCHAT");

                entity.Property(e => e.CsvcMa)
                    .HasColumnName("CSVC_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CsvcSoluong).HasColumnName("CSVC_SOLUONG");

                entity.Property(e => e.PhonghocPhMa)
                    .IsRequired()
                    .HasColumnName("PHONGHOC_PH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThietbidayhocTbdhMa)
                    .IsRequired()
                    .HasColumnName("THIETBIDAYHOC_TBDH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThietbigiangdayTbgdMa)
                    .IsRequired()
                    .HasColumnName("THIETBIGIANGDAY_TBGD_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TinhtrangTtMa)
                    .IsRequired()
                    .HasColumnName("TINHTRANG_TT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.PhonghocPhMaNavigation)
                    .WithMany(p => p.Cosovatchat)
                    .HasForeignKey(d => d.PhonghocPhMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHONGHOCCOSOVATCHAT");

                entity.HasOne(d => d.ThietbidayhocTbdhMaNavigation)
                    .WithMany(p => p.Cosovatchat)
                    .HasForeignKey(d => d.ThietbidayhocTbdhMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THIETBIDAYHOCCOSOVATCHAT");

                entity.HasOne(d => d.ThietbigiangdayTbgdMaNavigation)
                    .WithMany(p => p.Cosovatchat)
                    .HasForeignKey(d => d.ThietbigiangdayTbgdMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THIETBIGIANGDAYCOSOVATCHAT");

                entity.HasOne(d => d.TinhtrangTtMaNavigation)
                    .WithMany(p => p.Cosovatchat)
                    .HasForeignKey(d => d.TinhtrangTtMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TINHTRANGCOSOVATCHAT");
            });

            modelBuilder.Entity<Dantoc>(entity =>
            {
                entity.HasKey(e => e.DtMa);

                entity.ToTable("DANTOC", "dbo");

                entity.Property(e => e.DtMa)
                    .HasColumnName("DT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DtTen)
                    .IsRequired()
                    .HasColumnName("DT_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hinhthuc>(entity =>
            {
                entity.HasKey(e => e.HtMa);

                entity.ToTable("HINHTHUC", "dbo");

                entity.Property(e => e.HtMa)
                    .HasColumnName("HT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HtTen)
                    .HasColumnName("HT_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hocky>(entity =>
            {
                entity.HasKey(e => e.HkMa);

                entity.ToTable("HOCKY", "dbo");

                entity.Property(e => e.HkMa)
                    .HasColumnName("HK_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HkTen)
                    .IsRequired()
                    .HasColumnName("HK_TEN");
            });

            modelBuilder.Entity<Hocsinh>(entity =>
            {
                entity.HasKey(e => e.HsMa);

                entity.ToTable("HOCSINH", "dbo");

                entity.HasIndex(e => e.DantocDtMa)
                    .HasName("IX_FK_DANTOCHOCSINH");

                entity.HasIndex(e => e.KhenthuongKtMa)
                    .HasName("IX_FK_KHENTHUONGHOCSINH");

                entity.HasIndex(e => e.KhoiKhoiMa)
                    .HasName("IX_FK_KHOIHOCSINH");

                entity.HasIndex(e => e.KyluatKlMa)
                    .HasName("IX_FK_KYLUATHOCSINH");

                entity.HasIndex(e => e.LopLopMa)
                    .HasName("IX_FK_LOPHOCSINH");

                entity.HasIndex(e => e.QuanhuyenQhMa)
                    .HasName("IX_FK_QUANHUYENHOCSINH");

                entity.HasIndex(e => e.TinhthanhTtMa)
                    .HasName("IX_FK_TINHTHANHHOCSINH");

                entity.HasIndex(e => e.XaphuongXpMa)
                    .HasName("IX_FK_XAPHUONGHOCSINH");

                entity.Property(e => e.HsMa)
                    .HasColumnName("HS_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DantocDtMa)
                    .IsRequired()
                    .HasColumnName("DANTOC_DT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsGioitinh)
                    .HasColumnName("HS_GIOITINH")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsHoten)
                    .IsRequired()
                    .HasColumnName("HS_HOTEN")
                    .HasMaxLength(50);

                entity.Property(e => e.HsNgaysinh)
                    .HasColumnName("HS_NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.HsTongiao)
                    .HasColumnName("HS_TONGIAO")
                    .HasMaxLength(20);

                entity.Property(e => e.KhenthuongKtMa)
                    .IsRequired()
                    .HasColumnName("KHENTHUONG_KT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KhoiKhoiMa)
                    .IsRequired()
                    .HasColumnName("KHOI_KHOI_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KyluatKlMa)
                    .IsRequired()
                    .HasColumnName("KYLUAT_KL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LopLopMa)
                    .IsRequired()
                    .HasColumnName("LOP_LOP_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QuanhuyenQhMa)
                    .IsRequired()
                    .HasColumnName("QUANHUYEN_QH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TinhthanhTtMa)
                    .IsRequired()
                    .HasColumnName("TINHTHANH_TT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.XaphuongXpMa)
                    .IsRequired()
                    .HasColumnName("XAPHUONG_XP_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DantocDtMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.DantocDtMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANTOCHOCSINH");

                entity.HasOne(d => d.KhenthuongKtMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.KhenthuongKtMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHENTHUONGHOCSINH");

                entity.HasOne(d => d.KhoiKhoiMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.KhoiKhoiMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHOIHOCSINH");

                entity.HasOne(d => d.KyluatKlMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.KyluatKlMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KYLUATHOCSINH");

                entity.HasOne(d => d.LopLopMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.LopLopMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOPHOCSINH");

                entity.HasOne(d => d.QuanhuyenQhMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.QuanhuyenQhMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUANHUYENHOCSINH");

                entity.HasOne(d => d.TinhthanhTtMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.TinhthanhTtMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TINHTHANHHOCSINH");

                entity.HasOne(d => d.XaphuongXpMaNavigation)
                    .WithMany(p => p.Hocsinh)
                    .HasForeignKey(d => d.XaphuongXpMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XAPHUONGHOCSINH");
            });

            modelBuilder.Entity<Khenthuong>(entity =>
            {
                entity.HasKey(e => e.KtMa);

                entity.ToTable("KHENTHUONG", "dbo");

                entity.Property(e => e.KtMa)
                    .HasColumnName("KT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KtGhichu)
                    .HasColumnName("KT_GHICHU")
                    .HasMaxLength(100);

                entity.Property(e => e.KtNgaykhenthuong)
                    .HasColumnName("KT_NGAYKHENTHUONG")
                    .HasColumnType("datetime");

                entity.Property(e => e.KtThanhtich)
                    .HasColumnName("KT_THANHTICH")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Khenthuongcb>(entity =>
            {
                entity.HasKey(e => e.KtcbMa);

                entity.ToTable("KHENTHUONGCB", "dbo");

                entity.Property(e => e.KtcbMa)
                    .HasColumnName("KTCB_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KtcbNgay)
                    .IsRequired()
                    .HasColumnName("KTCB_NGAY");

                entity.Property(e => e.KtcbThanhtich)
                    .IsRequired()
                    .HasColumnName("KTCB_THANHTICH");
            });

            modelBuilder.Entity<Khoi>(entity =>
            {
                entity.HasKey(e => e.KhoiMa);

                entity.ToTable("KHOI", "dbo");

                entity.Property(e => e.KhoiMa)
                    .HasColumnName("KHOI_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KhoiTen)
                    .HasColumnName("KHOI_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kyluat>(entity =>
            {
                entity.HasKey(e => e.KlMa);

                entity.ToTable("KYLUAT", "dbo");

                entity.Property(e => e.KlMa)
                    .HasColumnName("KL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KlHinhthuc)
                    .HasColumnName("KL_HINHTHUC")
                    .HasMaxLength(50);

                entity.Property(e => e.KlNgaykyluat)
                    .HasColumnName("KL_NGAYKYLUAT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Kyluatcb>(entity =>
            {
                entity.HasKey(e => e.KlcbMa);

                entity.ToTable("KYLUATCB", "dbo");

                entity.Property(e => e.KlcbMa)
                    .HasColumnName("KLCB_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KlcbHt)
                    .IsRequired()
                    .HasColumnName("KLCB_HT");

                entity.Property(e => e.KlcbNgay)
                    .IsRequired()
                    .HasColumnName("KLCB_NGAY");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.LopMa);

                entity.ToTable("LOP", "dbo");

                entity.Property(e => e.LopMa)
                    .HasColumnName("LOP_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LopTen)
                    .HasColumnName("LOP_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.MhMa);

                entity.ToTable("MONHOC", "dbo");

                entity.HasIndex(e => e.ChitietdanhgiaCtdgMa)
                    .HasName("IX_FK_CHITIETDANHGIAMONHOC");

                entity.Property(e => e.MhMa)
                    .HasColumnName("MH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChitietdanhgiaCtdgMa)
                    .IsRequired()
                    .HasColumnName("CHITIETDANHGIA_CTDG_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MhTen)
                    .HasColumnName("MH_TEN")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ChitietdanhgiaCtdgMaNavigation)
                    .WithMany(p => p.Monhoc)
                    .HasForeignKey(d => d.ChitietdanhgiaCtdgMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETDANHGIAMONHOC");
            });

            modelBuilder.Entity<Namhoc>(entity =>
            {
                entity.HasKey(e => e.NhMa);

                entity.ToTable("NAMHOC", "dbo");

                entity.Property(e => e.NhMa)
                    .HasColumnName("NH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NhNamhoc)
                    .HasColumnName("NH_NAMHOC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ngachluong>(entity =>
            {
                entity.HasKey(e => e.NlMa);

                entity.ToTable("NGACHLUONG", "dbo");

                entity.Property(e => e.NlMa)
                    .HasColumnName("NL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NlTen)
                    .HasColumnName("NL_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Phonghoc>(entity =>
            {
                entity.HasKey(e => e.PhMa);

                entity.ToTable("PHONGHOC", "dbo");

                entity.Property(e => e.PhMa)
                    .HasColumnName("PH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhTen)
                    .IsRequired()
                    .HasColumnName("PH_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Quanhuyen>(entity =>
            {
                entity.HasKey(e => e.QhMa);

                entity.ToTable("QUANHUYEN", "dbo");

                entity.Property(e => e.QhMa)
                    .HasColumnName("QH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QhTen)
                    .IsRequired()
                    .HasColumnName("QH_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sodanhgia>(entity =>
            {
                entity.HasKey(e => e.SdgMa);

                entity.ToTable("SODANHGIA", "dbo");

                entity.HasIndex(e => e.NamhocNhMa)
                    .HasName("IX_FK_NAMHOCSODANHGIA");

                entity.Property(e => e.SdgMa)
                    .HasColumnName("SDG_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamhocNhMa)
                    .IsRequired()
                    .HasColumnName("NAMHOC_NH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SdgDiem)
                    .HasColumnName("SDG_DIEM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SdgGhichu)
                    .HasColumnName("SDG_GHICHU")
                    .HasMaxLength(50);

                entity.HasOne(d => d.NamhocNhMaNavigation)
                    .WithMany(p => p.Sodanhgia)
                    .HasForeignKey(d => d.NamhocNhMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NAMHOCSODANHGIA");
            });

            modelBuilder.Entity<Thietbidayhoc>(entity =>
            {
                entity.HasKey(e => e.TbdhMa);

                entity.ToTable("THIETBIDAYHOC", "dbo");

                entity.Property(e => e.TbdhMa)
                    .HasColumnName("TBDH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TbdhTen)
                    .IsRequired()
                    .HasColumnName("TBDH_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thietbigiangday>(entity =>
            {
                entity.HasKey(e => e.TbgdMa);

                entity.ToTable("THIETBIGIANGDAY", "dbo");

                entity.Property(e => e.TbgdMa)
                    .HasColumnName("TBGD_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TbgdTen)
                    .IsRequired()
                    .HasColumnName("TBGD_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thoikhoabieu>(entity =>
            {
                entity.HasKey(e => e.TkbMa);

                entity.ToTable("THOIKHOABIEU", "dbo");

                entity.HasIndex(e => e.CanboCbMa)
                    .HasName("IX_FK_CANBOTHOIKHOABIEU");

                entity.HasIndex(e => e.HockyHkMa)
                    .HasName("IX_FK_HOCKYTHOIKHOABIEU");

                entity.HasIndex(e => e.LopLopMa)
                    .HasName("IX_FK_LOPTHOIKHOABIEU");

                entity.HasIndex(e => e.MonhocMhMa)
                    .HasName("IX_FK_MONHOCTHOIKHOABIEU");

                entity.HasIndex(e => e.ThuThuMa)
                    .HasName("IX_FK_THUTHOIKHOABIEU");

                entity.HasIndex(e => e.TiethocThMa)
                    .HasName("IX_FK_TIETHOCTHOIKHOABIEU");

                entity.Property(e => e.TkbMa)
                    .HasColumnName("TKB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CanboCbMa)
                    .IsRequired()
                    .HasColumnName("CANBO_CB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HockyHkMa)
                    .IsRequired()
                    .HasColumnName("HOCKY_HK_MA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LopLopMa)
                    .IsRequired()
                    .HasColumnName("LOP_LOP_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonhocMhMa)
                    .IsRequired()
                    .HasColumnName("MONHOC_MH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThuThuMa)
                    .IsRequired()
                    .HasColumnName("THU_THU_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TiethocThMa)
                    .IsRequired()
                    .HasColumnName("TIETHOC_TH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CanboCbMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.CanboCbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANBOTHOIKHOABIEU");

                entity.HasOne(d => d.HockyHkMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.HockyHkMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOCKYTHOIKHOABIEU");

                entity.HasOne(d => d.LopLopMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.LopLopMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOPTHOIKHOABIEU");

                entity.HasOne(d => d.MonhocMhMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.MonhocMhMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MONHOCTHOIKHOABIEU");

                entity.HasOne(d => d.ThuThuMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.ThuThuMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUTHOIKHOABIEU");

                entity.HasOne(d => d.TiethocThMaNavigation)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.TiethocThMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIETHOCTHOIKHOABIEU");
            });

            modelBuilder.Entity<Thongtindaotao>(entity =>
            {
                entity.HasKey(e => e.TtdtMa);

                entity.ToTable("THONGTINDAOTAO", "dbo");

                entity.HasIndex(e => e.CanboCbMa)
                    .HasName("IX_FK_CANBOTHONGTINDAOTAO");

                entity.HasIndex(e => e.ChuyennganhCnMa)
                    .HasName("IX_FK_CHUYENNGANHTHONGTINDAOTAO");

                entity.HasIndex(e => e.HinhthucsHtMa)
                    .HasName("IX_FK_THONGTINDAOTAOHINHTHUC");

                entity.HasIndex(e => e.VanbangVbMa)
                    .HasName("IX_FK_VANBANGTHONGTINDAOTAO");

                entity.Property(e => e.TtdtMa)
                    .HasColumnName("TTDT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CanboCbMa)
                    .IsRequired()
                    .HasColumnName("CANBO_CB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChuyennganhCnMa)
                    .IsRequired()
                    .HasColumnName("CHUYENNGANH_CN_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HinhthucsHtMa)
                    .IsRequired()
                    .HasColumnName("HINHTHUCs_HT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VanbangVbMa)
                    .IsRequired()
                    .HasColumnName("VANBANG_VB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CanboCbMaNavigation)
                    .WithMany(p => p.Thongtindaotao)
                    .HasForeignKey(d => d.CanboCbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANBOTHONGTINDAOTAO");

                entity.HasOne(d => d.ChuyennganhCnMaNavigation)
                    .WithMany(p => p.Thongtindaotao)
                    .HasForeignKey(d => d.ChuyennganhCnMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHUYENNGANHTHONGTINDAOTAO");

                entity.HasOne(d => d.HinhthucsHtMaNavigation)
                    .WithMany(p => p.Thongtindaotao)
                    .HasForeignKey(d => d.HinhthucsHtMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THONGTINDAOTAOHINHTHUC");

                entity.HasOne(d => d.VanbangVbMaNavigation)
                    .WithMany(p => p.Thongtindaotao)
                    .HasForeignKey(d => d.VanbangVbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VANBANGTHONGTINDAOTAO");
            });

            modelBuilder.Entity<Thongtinluong>(entity =>
            {
                entity.HasKey(e => e.TtlMa);

                entity.ToTable("THONGTINLUONG", "dbo");

                entity.HasIndex(e => e.BacluongBlMa)
                    .HasName("IX_FK_BACLUONGTHONGTINLUONG");

                entity.HasIndex(e => e.CanboCbMa)
                    .HasName("IX_FK_CANBOTHONGTINLUONG");

                entity.HasIndex(e => e.NgachluongNlMa)
                    .HasName("IX_FK_NGACHLUONGTHONGTINLUONG");

                entity.Property(e => e.TtlMa)
                    .HasColumnName("TTL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BacluongBlMa)
                    .IsRequired()
                    .HasColumnName("BACLUONG_BL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CanboCbMa)
                    .IsRequired()
                    .HasColumnName("CANBO_CB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgachluongNlMa)
                    .IsRequired()
                    .HasColumnName("NGACHLUONG_NL_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TtlHesoluong)
                    .HasColumnName("TTL_HESOLUONG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TtlNgaynhanluong)
                    .HasColumnName("TTL_NGAYNHANLUONG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.BacluongBlMaNavigation)
                    .WithMany(p => p.Thongtinluong)
                    .HasForeignKey(d => d.BacluongBlMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BACLUONGTHONGTINLUONG");

                entity.HasOne(d => d.CanboCbMaNavigation)
                    .WithMany(p => p.Thongtinluong)
                    .HasForeignKey(d => d.CanboCbMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANBOTHONGTINLUONG");

                entity.HasOne(d => d.NgachluongNlMaNavigation)
                    .WithMany(p => p.Thongtinluong)
                    .HasForeignKey(d => d.NgachluongNlMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NGACHLUONGTHONGTINLUONG");
            });

            modelBuilder.Entity<Thu>(entity =>
            {
                entity.HasKey(e => e.ThuMa);

                entity.ToTable("THU", "dbo");

                entity.Property(e => e.ThuMa)
                    .HasColumnName("THU_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThuTen)
                    .IsRequired()
                    .HasColumnName("THU_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tiethoc>(entity =>
            {
                entity.HasKey(e => e.ThMa);

                entity.ToTable("TIETHOC", "dbo");

                entity.Property(e => e.ThMa)
                    .HasColumnName("TH_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThTen)
                    .IsRequired()
                    .HasColumnName("TH_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tinhthanh>(entity =>
            {
                entity.HasKey(e => e.TtMa);

                entity.ToTable("TINHTHANH", "dbo");

                entity.Property(e => e.TtMa)
                    .HasColumnName("TT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TtTen)
                    .IsRequired()
                    .HasColumnName("TT_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tinhtrang>(entity =>
            {
                entity.HasKey(e => e.TtMa);

                entity.ToTable("TINHTRANG", "dbo");

                entity.Property(e => e.TtMa)
                    .HasColumnName("TT_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TtMota)
                    .HasColumnName("TT_MOTA")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<UpdateImages>(entity =>
            {
                entity.ToTable("UpdateImages", "dbo");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("Image_url")
                    .HasMaxLength(100);

                entity.Property(e => e.NameIm)
                    .HasColumnName("Name_im")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vanbang>(entity =>
            {
                entity.HasKey(e => e.VbMa);

                entity.ToTable("VANBANG", "dbo");

                entity.Property(e => e.VbMa)
                    .HasColumnName("VB_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VbTen)
                    .HasColumnName("VB_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Xaphuong>(entity =>
            {
                entity.HasKey(e => e.XpMa);

                entity.ToTable("XAPHUONG", "dbo");

                entity.Property(e => e.XpMa)
                    .HasColumnName("XP_MA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.XpTen)
                    .IsRequired()
                    .HasColumnName("XP_TEN")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
