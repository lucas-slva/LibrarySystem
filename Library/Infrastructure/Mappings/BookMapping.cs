using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Mappings;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Title).HasMaxLength(200).IsRequired();
        builder.Property(b => b.Author).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Isbn).HasMaxLength(13).IsRequired();
        builder.HasIndex(b => b.Isbn).IsUnique();
    }
}