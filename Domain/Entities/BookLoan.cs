namespace Domain.Entities
{
    public class BookLoan : EntityBase
    {
        public Guid CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        public Guid BookId { get; set; }

        public virtual Book? Book { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
