using System;
using System.Collections.Generic;
using Lyrix.Data.Abstract;

namespace Lyrix.Data
{
    public class LyrixObject:ILyrixObject
    {
        public ILyrixTags Tags { get; set; }

        public IDictionary<TimeSpan, string> Lyrics { get; set; } 
    }
}
