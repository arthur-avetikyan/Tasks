using System;
using System.Collections.Generic;

namespace SOLID.OpenClosed.Bad
{
    public class PaperPresenter
    {
        Orderer _orderer = new Orderer();

        public void PresentOnPaper()
        {
            List<Book> lBooks = _orderer.ProvideOrderedBooksForPaper();

            foreach (Book item in lBooks)
            {
                Console.WriteLine($"{item.Title} by {item.Author} has {item.Words} words.");
            }
        }
    }
}
