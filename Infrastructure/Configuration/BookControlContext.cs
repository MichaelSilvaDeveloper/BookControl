using Domain.Entities;
using Infrastructure.Map;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class BookControlContext : DbContext
    {
        public BookControlContext(DbContextOptions<BookControlContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookLoan> BookLoans {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(100);
                e.Property(x => x.Author).IsRequired().HasMaxLength(100);
                e.Property(x => x.Isbn).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(255);
                e.Property(x => x.Email).IsRequired().HasMaxLength(255);
                e.Property(x => x.Age).IsRequired().HasMaxLength(255);
                e.Property(x => x.CreatedAt);
            });

            modelBuilder.Entity<BookLoan>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(e => e.Customer).WithMany().HasForeignKey(e => e.CustomerId);

                e.HasOne(e => e.Book).WithMany().HasForeignKey(e => e.BookId);
            });

            /*
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new BookLoanMap());

            base.OnModelCreating(modelBuilder);
            */
        }
    }
}