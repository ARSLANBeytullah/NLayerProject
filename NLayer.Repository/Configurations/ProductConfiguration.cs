using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); //toplam da 18 karakter virgülden sonra 2 karakter demektir.
            builder.ToTable("Products");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId); //Bunu tanımlamamıza gerek yoktu. Zaten Product entity'mizde ki Category'nin foreign Key olduğunu EF Core anlayacak.Ama ben yine de örnek olması açısından bu satırı da yazdım.
        }
    }
}
