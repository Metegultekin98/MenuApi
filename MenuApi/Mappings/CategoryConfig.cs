using MenuApi.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApi.Mappings
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.ItemList).WithMany(c=>c.Categories);
            builder.HasOne(c => c.PictureModel);
            builder.ToTable("CategoryMap");
        }
    }
}
