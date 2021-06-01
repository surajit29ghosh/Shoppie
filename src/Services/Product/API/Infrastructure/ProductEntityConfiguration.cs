using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Infrastructure
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Product.API.Models.Product>
	{
		public void Configure(EntityTypeBuilder<Models.Product> builder)
		{
            builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            builder.ToTable("Products", "Product");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasKey(k => k.Id);

            builder.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

            builder.Property(e => e.InStock).HasDefaultValueSql("((10))");

            builder.Property(e => e.Price).HasColumnType("money");

            builder.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(500);

        }
	}
}
