using System.IO;
using DbAccess;
using File = TagLib.File;

namespace MusicStorer
{
    public static class MusicInfoFactory
    {
        public static MusicInfo CreateMusicInfo(File f, string path)
        {
            
            var mi = new MusicInfo
            {
                Album = f.Tag.Album,
                Artist = f.Tag.FirstAlbumArtist??  f.Tag.FirstPerformer,
                AudioRate = f.Properties.AudioBitrate,
                Genres = f.Tag.JoinedGenres,
                Title = f.Tag.Title ?? Path.GetFileNameWithoutExtension(path),
                Track = (int) f.Tag.Track,
                Year = (int) f.Tag.Year,
                Path = path
            };
            return mi;

        }
    }
}
