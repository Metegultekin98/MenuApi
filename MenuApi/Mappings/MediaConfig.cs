using MenuApi.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApi.Mappings
{
    public class MediaConfig : BaseEntityConfig<Picture>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("MediasMap");
        }
    }
}


