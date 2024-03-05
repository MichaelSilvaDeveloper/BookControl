using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class BookLoanViewModel
    {
        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }
    }
}