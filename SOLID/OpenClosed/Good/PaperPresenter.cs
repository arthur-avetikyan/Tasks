using System;
using System.Collections.Generic;

namespace SOLID.OpenClosed.Good
{
    public class PaperPresenter : IPresenter
    {
        private IOrderer _orderer;

        public PaperPresenter(IOrderer orderer)
        {
            _orderer= orderer;
        }

        public void Present()
        {
            List<Book> lBooks = _orderer.ProvideOrderedBooks(); 
            foreach (Book item in lBooks)
            {
                Console.WriteLine($"{item.Title} by {item.Author} has {item.Words} words.");
            }
        }
    }
}
