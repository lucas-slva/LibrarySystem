using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Mappings;

public class LoanMapping : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");
        
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.LoanDate).IsRequired();
        builder.Property(l => l.ReturnDate).IsRequired();
        
        // relationship
        builder.HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId);
        
        builder.HasOne(l => l.User)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.UserId);
    }
}