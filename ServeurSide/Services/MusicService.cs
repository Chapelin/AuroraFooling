using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ServeurSide.DTO;

namespace ServeurSide.Services
{
    public class MusicService : IMusicService
    {
        private string originalPath;

        private List<Music> musicList; 

        public MusicService()
        {
            this.originalPath = @"\\NAS-PERSO\Volume_1\Musique\Their Dogs Were Astronauts\";
            this.GenerateListing();
        }

        private void GenerateListing()
        {
            this.musicList = GetListOfMusic(this.originalPath);
        }

        private List<Music> GetListOfMusic(string folderPath)
        {
            var list = new List<Music>();
            foreach (var dirPath in Directory.GetDirectories(folderPath))
            {
                list.AddRange(GetListOfMusic(dirPath));
            }
            foreach (var filePAth in Directory.EnumerateFiles(folderPath))
            {
                var isMusic = true;
                if (isMusic)
                {
                    list.Add(new Music() {Path =filePAth});
                }
            }
            return list;
        }

        public List<Music> ListOfMusic
        {
            get { return this.musicList; }
        } 

 
    }
}