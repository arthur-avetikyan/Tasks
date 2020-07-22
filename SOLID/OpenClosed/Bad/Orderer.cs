using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosed.Bad
{
    public class Orderer
    {
        private List<Book> _books = new BookRetriever().GetBooks();

        public List<Book> ProvideOrderedBooksForPaper()
        {
            return _books.OrderBy(o => o.Author).ThenBy(t => t.Title).ToList();
        }

        public List<Book> ProvideOrderedBooksForPDF()
        {
            return _books.OrderBy(o => o.Words).ToList();
        }
    }
}
