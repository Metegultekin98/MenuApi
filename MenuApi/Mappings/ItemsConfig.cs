using MenuApi.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApi.Mappings
{
    public class ItemsConfig : BaseEntityConfig<Items>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Items> builder)
        {
            builder.HasMany(w => w.Categories).WithMany(o => o.ItemList);
            builder.HasMany(p => p.Pictures).WithMany(o=>o.Items);
            builder.HasMany(w => w.Extras);
            builder.HasMany(p => p.Tags).WithMany(o => o.ItemList);
            builder.ToTable("ItemsMap");
        }
    }
}
