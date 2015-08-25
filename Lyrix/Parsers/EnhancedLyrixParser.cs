using Lyrix.Parsers.Abstract;

namespace Lyrix.Parsers
{
    /// <summary>
    /// Parses lyrics of the enhanced lrc format
    /// </summary>
    public class EnhancedLyrixParser:ILyrixParser
    {
        public System.Collections.Generic.IDictionary<System.TimeSpan, string> ParseLyrics(string lyrics)
        {
            throw new System.NotImplementedException();
        }

        public string Format
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
