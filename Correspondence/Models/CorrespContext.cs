using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Correspondence.Models
{
    public class CorrespContext : DbContext
    {
        public CorrespContext()
        {
        }

        public CorrespContext(DbContextOptions<CorrespContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Dtype> Dtypes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Main> Mains { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Subevent> Subevents { get; set; }
        public virtual DbSet<Subtheme> Subthemes { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");
               
                entity.HasIndex(e => e.Name, "i_author")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Dtype>(entity =>
            {
                entity.ToTable("dtype");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.Name, "i_event")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("files");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormatData).HasColumnName("format_data");

                entity.Property(e => e.FormatExtension)
                    .HasMaxLength(15)
                    .HasColumnName("format_extension");

                entity.Property(e => e.FormatLength).HasColumnName("format_length");

                entity.Property(e => e.FormatName)
                    .HasMaxLength(50)
                    .HasColumnName("format_name");

                entity.Property(e => e.ScanData).HasColumnName("scan_data");

                entity.Property(e => e.ScanExtension)
                    .HasMaxLength(15)
                    .HasColumnName("scan_extension");

                entity.Property(e => e.ScanLength).HasColumnName("scan_length");

                entity.Property(e => e.ScanName)
                    .HasMaxLength(50)
                    .HasColumnName("scan_name");

                entity.Property(e => e.SverstData).HasColumnName("sverst_data");

                entity.Property(e => e.SverstExtension)
                    .HasMaxLength(15)
                    .HasColumnName("sverst_extension");

                entity.Property(e => e.SverstLength).HasColumnName("sverst_length");

                entity.Property(e => e.SverstName)
                    .HasMaxLength(50)
                    .HasColumnName("sverst_name");
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.ToTable("main");

                entity.HasIndex(e => e.IdAuthor, "id_author");

                entity.HasIndex(e => e.IdDtype, "id_dtype");

                entity.HasIndex(e => e.IdEvent, "id_event");

                entity.HasIndex(e => e.IdFiles, "id_files");

                entity.HasIndex(e => e.IdPlace, "id_place");

                entity.HasIndex(e => e.IdSubevent, "id_subevent");

                entity.HasIndex(e => e.IdSubtheme, "id_subtheme");

                entity.HasIndex(e => e.IdTheme, "id_theme");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasColumnName("comments");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.FDate).HasColumnName("f_date");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("folder");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdDtype).HasColumnName("id_dtype");

                entity.Property(e => e.IdEvent).HasColumnName("id_event");

                entity.Property(e => e.IdFiles).HasColumnName("id_files");

                entity.Property(e => e.IdPlace).HasColumnName("id_place");

                entity.Property(e => e.IdSubevent).HasColumnName("id_subevent");

                entity.Property(e => e.IdSubtheme).HasColumnName("id_subtheme");

                entity.Property(e => e.IdTheme).HasColumnName("id_theme");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.NoPublic).HasColumnName("no_public");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_1");

                entity.HasOne(d => d.IdDtypeNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdDtype)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_7");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_2");

                entity.HasOne(d => d.IdFilesNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdFiles)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("main_ibfk_8");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("main_ibfk_6");

                entity.HasOne(d => d.IdSubeventNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdSubevent)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_3");

                entity.HasOne(d => d.IdSubthemeNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdSubtheme)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_4");

                entity.HasOne(d => d.IdThemeNavigation)
                    .WithMany(p => p.Mains)
                    .HasForeignKey(d => d.IdTheme)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("main_ibfk_5");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.HasIndex(e => e.FullPlace, "i_place")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.FullPlace)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_place");

                entity.Property(e => e.House)
                    .HasMaxLength(255)
                    .HasColumnName("house");

                entity.Property(e => e.Owner)
                    .HasMaxLength(255)
                    .HasColumnName("owner");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Subevent>(entity =>
            {
                entity.ToTable("subevent");

                entity.HasIndex(e => e.Name, "i_subevent")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Subtheme>(entity =>
            {
                entity.ToTable("subtheme");

                entity.HasIndex(e => e.Name, "i_subtheme")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.ToTable("theme");

                entity.HasIndex(e => e.Name, "i_theme")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });
        }
    }
}