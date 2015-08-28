using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lyrix.Data;
using Lyrix.Data.Abstract;
using Lyrix.Extensions;
using Lyrix.Parsers.Abstract;

namespace Lyrix.Parsers
{
    public static class LrcParser
    {
        private static readonly ITagsParser TagsParser;

        private static readonly IEnumerable<ILyrixParser> LyrixParsers;

        static LrcParser()
        {
            TagsParser = new TagsParser();
            LyrixParsers = new ILyrixParser[]
            {
                new StandardLyrixParser(), 
                new EnhancedLyrixParser()
            };
        }

        public static ILyrixObject Parse(string lyrics)
        {
            var lyrix = new LyrixObject();
            lyrix.SetTags(lyrics);
            lyrix.SetLyrics(lyrics);
            if (lyrix.Tags == null && lyrix.Lyrics == null)
            {
                return null;
            }
            return lyrix;
        }

        private static void SetLyrics(this ILyrixObject lyrix, string lyrics)
        {
            var parsedLyrics = ParseLyricsCollection(lyrics);
            lyrix.Lyrics = parsedLyrics;
        }

        private static void SetTags(this ILyrixObject lyrix, string lyrics)
        {
            var tagsMatchCollection = Regex.Matches(lyrics, TagsParser.Format);
            var tagsSection = tagsMatchCollection.JoinMatches();
            lyrix.Tags = TagsParser.ParseTags(tagsSection);
        }

        private static IDictionary<TimeSpan, string> ParseLyricsCollection(string lyrics)
        {
            if (lyrics == null) throw new ArgumentNullException("lyrics");
            foreach (var lyrixParser in LyrixParsers)
            {
                var lyricsSection = Regex.Matches(lyrics, lyrixParser.Format).JoinMatches();
                if (lyricsSection != string.Empty)
                {
                    return lyrixParser.ParseLyrics(lyricsSection);
                }
            }
            return null;
        }
    }
}
