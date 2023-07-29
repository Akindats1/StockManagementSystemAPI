using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Entities;

namespace Infrastructure.Context;

public partial class StockManagementDbContext : IdentityDbContext<User>
{
    public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options) : base(options)
    {
       
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Measurement> Measurements { get; set; } = null!;
    public DbSet<Size> Sizes { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(c => c.Name, "UQ__Categories__447D36EA65149136")
            .IsUnique();

            entity.Property(c => c.Name)
                .HasMaxLength(50)
                .HasColumnName("Name")
                .IsRequired();

            entity.Property(c => c.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasIndex(m => m.UnitSizeType, "UQ__Measurement__547D36EA65149136")
                .IsUnique();

            entity.Property(e => e.UnitSizeType)
                .HasMaxLength(50)
                .HasColumnName("UnitSizeType");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasOne(m => m.Measurement)
                .WithMany(s => s.Sizes)
                .HasForeignKey(d => d.MeasurementId)
                .HasConstraintName("FK_Sizes_ToTable")
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.ProductName)
            .HasMaxLength(50)
            .IsRequired();

            entity.Property(d => d.Description)
            .HasMaxLength(250);

            entity.Property(e => e.UnitCostPrice)
            .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.UnitPrice)
            .HasColumnType("decimal(18, 2)");

            entity.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("FK_Products_ToTable")
                .OnDelete(DeleteBehavior.Restrict);
        });



        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "23cb4de6-901e-41f0-9c37-811f0219e91b"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "0720f3b6-7d35-4239-a9fc-c0f8beb01c3a"
            }
        );

        var hasher = new PasswordHasher<User>();

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "6d887c8c-d649-4f11-a84f-0ca02a003f07",
                Email = "admin@app.com",
                NormalizedEmail = "ADMIN@APP.COM",
                UserName = "admin@app.com",
                NormalizedUserName = "ADMIN@APP.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null!, "P@ssword1")
            },
            new User
            {
                Id = "e58f3f49-0be4-4449-b304-71c4cb6e406d",
                Email = "user@app.com",
                NormalizedEmail = "USER@APP.COM",
                UserName = "user@app.com",
                NormalizedUserName = "USER@APP.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null!, "P@ssword1")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "6d887c8c-d649-4f11-a84f-0ca02a003f07",
                RoleId = "0720f3b6-7d35-4239-a9fc-c0f8beb01c3a"
            },
            new IdentityUserRole<string>
            {
                UserId = "e58f3f49-0be4-4449-b304-71c4cb6e406d",
                RoleId = "23cb4de6-901e-41f0-9c37-811f0219e91b"
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}