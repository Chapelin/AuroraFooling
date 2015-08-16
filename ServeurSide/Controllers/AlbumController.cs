using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServeurSide.Controllers
{
    public class AlbumController : BaseSonicController
    {

        public IEnumerable<string> Get()
        {
            return musicService.GetAll().Select(x => x.Album).Distinct();
        }

        [HttpGet]
        [ActionName("ByArtist")]
        public IEnumerable<string> GetByArtist(string artist)
        {
            return musicService.Query(x => x.Artist == artist).Select(x => x.Album).Distinct();
        } 
    }
}