using MenuApi.Entities.Categories;
using MenuApi.Entities.Items;
using MenuApi.Entities.Media;
using Microsoft.EntityFrameworkCore;

namespace MenuApi.Data
{
    public class Context : DbContext
    {

        private const string ConnectionString = @"Data Source=213.142.148.200;Initial Catalog=peersMenuDB;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Lemoon1453!;Enlist=False;Pooling=True;Min Pool Size=1;Max Pool Size=100;Connect Timeout=15;User Instance=False";
        DbSet<Category> CategoryDtos { get; set; }
        DbSet<Items> ItemsDtos { get; set; }
        DbSet<ItemsTag> ItemsTagDtos { get; set; }
        DbSet<Picture> PictureDtos { get; set; }
        DbSet<MediaGallery> MediaGalleryDtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
