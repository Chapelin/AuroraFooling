using DbAccess;
using TagLib;

namespace MusicStorer
{
    public static class MusicInfoFactory
    {
        public static MusicInfo CreateMusicInfo(File f, string path)
        {
            
            var mi = new MusicInfo
            {
                Album = f.Tag.Album,
                Artist = f.Tag.FirstAlbumArtist,
                AudioRate = f.Properties.AudioBitrate,
                Genre = f.Tag.JoinedGenres,
                Title = f.Tag.Title,
                Track = (int) f.Tag.Track,
                Year = (int) f.Tag.Year,
                Path = path
            };
            return mi;

        }
    }
}
