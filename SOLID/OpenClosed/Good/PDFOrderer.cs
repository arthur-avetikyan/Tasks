using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosed.Good
{
    public class PDFOrderer : IOrderer
    {
        private List<Book> _books = new BookRetriever().GetBooks();

        public List<Book> ProvideOrderedBooks()
        {
            return _books.OrderBy(o => o.Words).ToList();
        }
    }
}
