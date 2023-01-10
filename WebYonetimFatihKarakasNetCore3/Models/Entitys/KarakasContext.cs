using KarakasWenAdmin.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace WebYonetimFatihKarakasNetCore3.Models.Entitys
{
    public class KarakasContext : DbContext
    {
        public KarakasContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserControl> UserControl { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Mesajlar> Mesajlar { get; set; }
        public DbSet<Hakkimda> Hakkimda { get; set; }
        public DbSet<Referanslar> Referanslar { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<SystemError> SystemErrors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IpAdres).HasMaxLength(50);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Comment_dbo.Post_PostId");
            });

            modelBuilder.Entity<Hakkimda>(entity =>
            {
                entity.Property(e => e.About)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<HastaneBilgi>(entity =>
            {
                entity.Property(e => e.HastaneAdi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Vkn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Mesajlar>(entity =>
            {
                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Ipadres)
                    .HasColumnName("IPAdres")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Mesaj)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TamAd)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Zaman)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PicturePath).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Post_dbo.Category_CategoryId");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PostTag_dbo.Post_PostId");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PostTag_dbo.Tag_TagId");
            });



            modelBuilder.Entity<Referanslar>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aciklama)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CalismaSuresi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Kurum).HasMaxLength(250);

                entity.Property(e => e.LinUrl).HasMaxLength(50);

                entity.Property(e => e.Platform).HasMaxLength(50);

                entity.Property(e => e.ResimAdres).HasMaxLength(150);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SelectedValue).HasMaxLength(500);
            });

            modelBuilder.Entity<SystemError>(entity =>
            {
                entity.Property(e => e.ErrorDate).HasColumnType("datetime");
            });



            modelBuilder.Entity<UserControl>(entity =>
            {
                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });


        }
    }
}
