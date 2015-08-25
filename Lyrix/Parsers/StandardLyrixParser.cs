using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Lyrix.Parsers.Abstract;

namespace Lyrix.Parsers
{
    public class StandardLyrixParser:ILyrixParser
    {
        public string Format
        {
            get { return @"(?<Timestamps>(?:\[[\d:.]*\])+)(?<Lyric>.*)"; }
        }

        public IDictionary<TimeSpan, string> ParseLyrics(string lyrics)
        {
            var lyricsObject = new Dictionary<TimeSpan, string>();
            var matchCollection = Regex.Matches(lyrics, Format);
            if (matchCollection.Count ==0)
            {
                return null;
            }
            foreach (Match match in matchCollection)
            {
                var value = match.Groups["Lyric"].Value;
                var timestamps = Regex.Matches(match.Groups["Timestamps"].Value, @"(?:\[(?<Timestamp>[\d:.]*)\])+");
                foreach (
                    var timestamp in
                        timestamps.OfType<Match>()
                            .Select(
                                timestampMatch =>
                                    TimeSpan.Parse(string.Format(":{0}", timestampMatch.Groups["Timestamp"].Value))))
                {
                    lyricsObject.Add(timestamp,value);
                }
            }
            return lyricsObject;
        }
    }
}
