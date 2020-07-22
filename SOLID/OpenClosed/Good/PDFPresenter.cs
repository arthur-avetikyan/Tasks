using System;
using System.Collections.Generic;

namespace SOLID.OpenClosed.Good
{
    public class PDFPresenter : IPresenter
    {
        private IOrderer _orderer;

        public PDFPresenter(IOrderer orderer)
        {
            _orderer = orderer;
        }

        public void Present()
        {
            List<Book> lBooks = _orderer.ProvideOrderedBooks();

            foreach (Book item in lBooks)
            {
                Console.WriteLine($"{item.Author} wrote {item.Words} words in {item.Title}");
            }
        }
    }
}
