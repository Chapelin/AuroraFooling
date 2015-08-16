using System.Collections.Generic;
using System.Web.Http;
using DbAccess;
using Microsoft.Practices.Unity;

namespace ServeurSide.Controllers
{
    public class MusicListingController : ApiController
    {
        [Dependency]
        public static DataService musicService { get; set; }

     
        static MusicListingController()
        {
            musicService = new DataService();
        }

        public MusicListingController() { }

        public IEnumerable<MusicInfo> Get()
        {
            return musicService.GetAll();
        } 
    }
}
