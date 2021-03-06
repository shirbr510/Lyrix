﻿using System;
using System.ComponentModel;
using Lyrix.Attributes;

namespace Lyrix.Data.Abstract
{
    public interface ILyrixTags
    {
        [Description("[ar:Lyrics artist]")]
        [Prefix("ar")]
        string Artist { get; set; }

        [Description("[al:Album where the song is from]")]
        [Prefix("al")]
        string Album { get; set; }

        [Description("[ti:Lyrics (song) title]")]
        [Prefix("ti")]
        string Title { get; set; }

        [Description("[au:Creator of the Songtext]")]
        [Prefix("au")]
        string Author { get; set; }

        [Description("[length:How long the song is]")]
        [Prefix("length")]
        TimeSpan Length { get; set; }

        [Description("[by:Creator of the LRC file]")]
        [Prefix("by")]
        string Creator { get; set; }

        [Description("[offset:+/- Overall timestamp adjustment in milliseconds, + shifts time up, - shifts down]")]
        [Prefix("offset")]
        long Offset { get; set; }

        [Description("[re:The player or editor that created the LRC file]")]
        [Prefix("re")]
        string Redistributer { get; set; }

        [Description("[ve:version of program]")]
        [Prefix("ve")]
        string Version { get; set; }
    }
}
