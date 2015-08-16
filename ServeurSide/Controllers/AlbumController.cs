using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DbAccess;

namespace ServeurSide.Controllers
{
    public class AlbumController : BaseSonicController
    {

        public IEnumerable<string> Get()
        {
            return musicService.GetAll<MusicInfo>().Select(x => x.Album).Distinct();
        }

        [HttpGet]
        [ActionName("ByArtist")]
        public IEnumerable<string> GetByArtist(string artist)
        {
            return musicService.Query(x => x.Artist == artist, x => x.Album).Distinct();
        }
    }
}