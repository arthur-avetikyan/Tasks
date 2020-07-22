using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.OpenClosed.Good
{
    public class PaperOrderer : IOrderer
    {
        private List<Book> _books = new BookRetriever().GetBooks();

        public List<Book> ProvideOrderedBooks()
        {
            return _books.OrderBy(o => o.Author).ThenBy(t => t.Title).ToList();
        }
    }
}
