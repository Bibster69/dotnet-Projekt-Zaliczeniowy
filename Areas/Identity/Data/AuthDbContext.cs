using Kalkulatol.Areas.Identity.Data;
using Kalkulatol.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalkulatol.Data;

public class AuthDbContext : IdentityDbContext<KalkulatolUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration ( new ApplicationUserEntityConfiguration());
    }

    public DbSet<SkladnikModel> Skladniki { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<KalkulatolUser>
{
    public void Configure(EntityTypeBuilder<KalkulatolUser> builder)
    {
        builder.Property(y => y.Imie).HasMaxLength(255);
        builder.Property(y => y.Waga).HasDefaultValue(0);
    }
}


