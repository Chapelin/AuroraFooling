using System.Collections.Generic;
using ServeurSide.DTO;

namespace ServeurSide.Services
{
    public interface IMusicService
    {
        List<Music> ListOfMusic { get; }
    }
}