using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InputModels
{
    public class BookInputModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public int PublicationYear { get; set; }
    }
}