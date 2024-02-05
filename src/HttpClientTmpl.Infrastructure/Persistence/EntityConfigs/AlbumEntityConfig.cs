using HttpClientTmpl.BLL.Entities.Albums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HttpClientTmpl.Infrastructure.Persistence.EntityConfigs;

public class AlbumEntityConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("albums");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.UserId).IsRequired();

        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
    }
}