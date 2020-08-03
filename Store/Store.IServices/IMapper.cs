using System;
using System.Collections.Generic;
using System.Text;

namespace Store.IServices
{
    public interface IMapper
    {
        TDestination MapTo<TDestination, TSource>(TSource source);
    }
}
