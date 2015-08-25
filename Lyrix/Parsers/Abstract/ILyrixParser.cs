using System;
using System.Collections.Generic;

namespace Lyrix.Parsers.Abstract
{
    public interface ILyrixParser:IParser
    {
        IDictionary<TimeSpan, string> ParseLyrics(string lyrics);
    }
}
