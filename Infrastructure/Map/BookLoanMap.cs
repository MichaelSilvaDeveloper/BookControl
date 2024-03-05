using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Map
{
    public class BookLoanMap : IEntityTypeConfiguration<BookLoan>
    {
        public void Configure(EntityTypeBuilder<BookLoan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerId);
            builder.HasOne(x => x.Customer);

            builder.Property(x => x.BookId);
            builder.HasOne(x => x.Book);
        }
    }
}