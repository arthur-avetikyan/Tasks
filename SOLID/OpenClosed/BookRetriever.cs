using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.OpenClosed
{
    public class BookRetriever
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Author="Shakespeare W.",
                    Title ="Hamlet",
                    Words= 30557
                },
                new Book
                {
                    Author="Hemingway E.",
                    Title ="The Old Man and the Sea",
                    Words= 27000
                }
            };
        }
    }
}
