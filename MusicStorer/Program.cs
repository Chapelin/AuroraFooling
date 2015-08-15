using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TagLib;
using TagFile = TagLib.File;
using DbAccess;
namespace MusicStorer
{
    class Program
    {
        private static ConcurrentBag<MusicInfo> liste;
        private static string oriPath = @"\\NAS-PERSO\Volume_1\Musique\";
        private static List<string> validExtensions = new List<string>() { ".MP3", ".FLAC" };
        private static DataService service;

        private static void Main(string[] args)
        {
            service = new DataService();
            liste = new ConcurrentBag<MusicInfo>();
            service.Clean<MusicInfo>();
            ProcessFolder(oriPath);
            Console.WriteLine(liste.Count);

            service.AddRange(liste.ToList());

            Console.ReadLine();

            foreach (var title in service.GetAll<MusicInfo>().Select(x => x.Title))
            {
                Console.WriteLine(title);
            }

            Console.ReadLine();

        }


        public static void ProcessFolder(string folderPath)
        {
            Parallel.ForEach(Directory.EnumerateDirectories(folderPath), ProcessFolder);
            Parallel.ForEach(Directory.EnumerateFiles(folderPath), ProcessFile);
        }

        public static void ProcessFile(string filePath)
        {

            if (validExtensions.Contains(Path.GetExtension(filePath).ToUpper()))
            {
                //GO ! 
                try
                {
                    var tagFile = GetTagFile(filePath);

                    liste.Add(MusicInfoFactory.CreateMusicInfo(tagFile));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur sur " + filePath);
                }
            }
        }

        private static TagFile GetTagFile(string filePath)
        {
            TagFile tg;
            using (var s = System.IO.File.Open(filePath, FileMode.Open))
            {
                var fsa = new StreamFileAbstraction(Path.GetFileName(filePath), s, s);
                tg = TagFile.Create(fsa);
            }
            return tg;
        }
    }
}
