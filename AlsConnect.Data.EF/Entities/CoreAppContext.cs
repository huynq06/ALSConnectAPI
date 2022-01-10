using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlsConnect.Data.EF.Entities
{
    public partial class CoreAppContext : DbContext
    {
        public CoreAppContext()
        {
        }

        public CoreAppContext(DbContextOptions<CoreAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public virtual DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
        public virtual DbSet<Advertistment> Advertistments { get; set; }
        public virtual DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUserClaim> AppUserClaims { get; set; }
        public virtual DbSet<AppUserLogin> AppUserLogins { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<AppUserToken> AppUserTokens { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BlogTag> BlogTags { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductQuantity> ProductQuantities { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<WholePrice> WholePrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CoreApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertistmentPosition>(entity =>
            {
                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.AdvertistmentPositions)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<Advertistment>(entity =>
            {
                entity.HasIndex(e => e.PositionId);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PositionId).HasMaxLength(20);

                entity.Property(e => e.Url).HasMaxLength(250);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Advertistments)
                    .HasForeignKey(d => d.PositionId);
            });

            modelBuilder.Entity<AnnouncementUser>(entity =>
            {
                entity.HasIndex(e => e.AnnouncementId);

                entity.Property(e => e.AnnouncementId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.AnnouncementId);
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<AppUserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });
            });

            modelBuilder.Entity<AppUserToken>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasIndex(e => e.BillId);

                entity.HasIndex(e => e.ColorId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.SizeId);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ColorId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.SizeId);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerMessage)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerMobile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

            
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.HasIndex(e => e.BlogId);

                entity.HasIndex(e => e.TagId);

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SeoAlias).HasMaxLength(256);

                entity.Property(e => e.SeoDescription).HasMaxLength(256);

                entity.Property(e => e.SeoKeywords).HasMaxLength(256);

                entity.Property(e => e.SeoPageTitle).HasMaxLength(256);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(250);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ParentId).HasMaxLength(128);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.FunctionId);

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.FunctionId).IsRequired();

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.FunctionId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Caption).HasMaxLength(250);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductQuantity>(entity =>
            {
                entity.HasIndex(e => e.ColorId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.SizeId);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ColorId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.SizeId);
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.TagId);

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SeoAlias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SeoDescription).HasMaxLength(255);

                entity.Property(e => e.SeoKeywords).HasMaxLength(255);

                entity.Property(e => e.Tags).HasMaxLength(255);

                entity.Property(e => e.Unit).HasMaxLength(255);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.GroupAlias)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value5).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WholePrice>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WholePrices)
                    .HasForeignKey(d => d.ProductId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
