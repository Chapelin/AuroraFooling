using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Practices.Unity;
using ServeurSide.DTO;
using ServeurSide.Services;

namespace ServeurSide.Controllers
{
    public class MusicListingController : ApiController
    {
        [Dependency]
        public IMusicService musicService { get; set; }

     
        public MusicListingController()
        {
            this.musicService = new MusicService();
        }

        public List<Music> Get()
        {
            return musicService.ListOfMusic;
        } 
    }
}
