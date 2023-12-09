using Loginet.BLL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loginet.Infrastructure.Persistence.EntityConfigs;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);
        
        builder
            .HasMany(x => x.Albums)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(a => a.Street).HasMaxLength(100).IsRequired();
            address.Property(a => a.Suite).HasMaxLength(50).IsRequired();
            address.Property(a => a.City).HasMaxLength(50).IsRequired();
            address.Property(a => a.Zipcode).HasMaxLength(20).IsRequired();
            address.OwnsOne(a => a.Geo, geo =>
            {
                geo.Property(g => g.Lat).HasMaxLength(50).IsRequired();
                geo.Property(g => g.Lng).HasMaxLength(50).IsRequired();
            });
        });

        builder.Property(x => x.Phone).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Website).HasMaxLength(100).IsRequired();

        builder.OwnsOne(x => x.Company, company =>
        {
            company.Property(c => c.Name).HasMaxLength(100).IsRequired();
            company.Property(c => c.CatchPhrase).HasMaxLength(200).IsRequired();
            company.Property(c => c.Bs).HasMaxLength(200).IsRequired();
        });

    }
}