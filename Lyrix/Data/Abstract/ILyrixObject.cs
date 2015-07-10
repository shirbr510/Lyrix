using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lyrix.Data.Abstract
{
    public interface ILyrixObject
    {
        ILyrixTags Tags { get; set; }

        IDictionary<TimeSpan, string> Lyrics { get; set; } 
    }
}
