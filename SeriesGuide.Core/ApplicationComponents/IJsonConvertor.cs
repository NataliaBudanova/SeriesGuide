using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public interface IJsonConvertor
    {
        T UpLoad<T>(string path);
        void Save<T>(T item, string path);
    }
}
