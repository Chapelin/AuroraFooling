using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbAccess;

namespace ServeurSide
{
    public abstract class BaseSonicController : ApiController
    {
        public static DataService musicService { get; set; }

        static BaseSonicController()
        {
            musicService = new DataService();
        }
    }
}