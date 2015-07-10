using System;
using System.ComponentModel;

namespace Lyrix.Data.Abstract
{
    public interface ILyrixTags
    {
        [Description("[ar:Lyrics artist]")]
        string Artist { get; set; }

        [Description("[al:Album where the song is from]")]
        string Album { get; set; }

        [Description("[ti:Lyrics (song) title]")]
        string Title { get; set; }

        [Description("[au:Creator of the Songtext]")]
        string Author { get; set; }

        [Description("[length:How long the song is]")]
        TimeSpan Length { get; set; }

        [Description("[by:Creator of the LRC file]")]
        string Creator { get; set; }

        [Description("[offset:+/- Overall timestamp adjustment in milliseconds, + shifts time up, - shifts down]")]
        long Offset { get; set; }

        [Description("[re:The player or editor that created the LRC file]")]
        string Redistributer { get; set; }

        [Description("[ve:version of program]")]
        string Version { get; set; }
    }
}
