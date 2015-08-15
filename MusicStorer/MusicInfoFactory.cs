using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MusicStorer
{
    public static class MusicInfoFactory
    {
        public static MusicInfo CreateMusicInfo(File f)
        {
            var mi = new MusicInfo();
            mi.Album = f.Tag.Album;
            mi.Artist = f.Tag.FirstAlbumArtist;
            mi.AudioRate = f.Properties.AudioBitrate;
            mi.Genre = f.Tag.JoinedGenres;
            mi.Title = f.Tag.Title;
            mi.Track = (int) f.Tag.Track;
            mi.Year = (int) f.Tag.Year;
            return mi;

        }
    }
}
