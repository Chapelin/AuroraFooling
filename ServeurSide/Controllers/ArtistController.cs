using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServeurSide.Controllers
{
    public class ArtistController : BaseSonicController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return musicService.GetAll().Select(x=> x.Artist).Distinct();
        }

       
    }
}