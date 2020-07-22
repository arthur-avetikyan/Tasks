using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.OpenClosed.Bad
{
  public  class PdfPresenter
    {
        Orderer _orderer = new Orderer();

         public void PresentOnPdf()
        {
            List<Book> lBooks = _orderer.ProvideOrderedBooksForPDF();

            foreach (Book item in lBooks)
            {
                Console.WriteLine($"{item.Title} by {item.Author} has {item.Words} words.");
            }
        }
    }
}
