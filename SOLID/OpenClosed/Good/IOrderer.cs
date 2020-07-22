using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.OpenClosed.Good
{
    public interface IOrderer
    {
        List<Book> ProvideOrderedBooks();
    }
}
