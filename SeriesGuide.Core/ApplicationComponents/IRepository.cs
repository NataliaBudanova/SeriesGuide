using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public interface IRepository<T>
    {
        IEnumerable<T> Items { get; }
        void Add(T item);
    }
}
