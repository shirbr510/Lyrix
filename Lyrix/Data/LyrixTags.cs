using System;
using System.ComponentModel;
using Lyrix.Attributes;
using Lyrix.Data.Abstract;

namespace Lyrix.Data
{
    public class LyrixTags:ILyrixTags
    {
        [Description("[ar:Lyrics artist]")]
        [Prefix("ar")]
        public string Artist { get; set; }

        [Description("[al:Album where the song is from]")]
        [Prefix("al")]
        public string Album { get; set; }

        [Description("[ti:Lyrics (song) title]")]
        [Prefix("ti")]
        public string Title { get; set; }

        [Description("[au:Creator of the Songtext]")]
        [Prefix("au")]
        public string Author { get; set; }

        [Description("[length:How long the song is]")]
        [Prefix("length")]
        public TimeSpan Length { get; set; }

        [Description("[by:Creator of the LRC file]")]
        [Prefix("by")]
        public string Creator { get; set; }

        [Description("[offset:+/- Overall timestamp adjustment in milliseconds, + shifts time up, - shifts down]")]
        [Prefix("offset")]
        public long Offset { get; set; }

        [Description("[re:The player or editor that created the LRC file]")]
        [Prefix("re")]
        public string Redistributer { get; set; }

        [Description("[ve:version of program]")]
        [Prefix("ve")]
        public string Version { get; set; }
    }
}
