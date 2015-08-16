using System.Collections.Generic;
using System.Web.Http;
using DbAccess;
using Microsoft.Practices.Unity;

namespace ServeurSide.Controllers
{
    public class MusicListingController : BaseSonicController
    {
       
        public IEnumerable<MusicInfo> Get()
        {
            return musicService.GetAll< MusicInfo>();
        }

        [HttpGet]
        [ActionName("ByArtist")]
        public IEnumerable<MusicInfo> GetByArtist(string id)
        {
            return musicService.Query(x => x.Artist == id);
        }

        [HttpGet]
        [ActionName("ByAlbum")]
        public IEnumerable<MusicInfo> GetByAlbum(string id)
        {
            return musicService.Query(x => x.Album == id);
        }

    }
}
