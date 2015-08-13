using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using TagFile = TagLib.File;
namespace MusicStorer
{
    class Program
    {
        private static ConcurrentBag<TagFile> liste;
        private static string oriPath = @"\\NAS-PERSO\Volume_1\Musique\secret of mana\secret of mana";
        private static List<string>  validExtensions = new List<string>() {".MP3",".FLAC"};
        static void Main(string[] args)
        {
            liste = new ConcurrentBag<TagFile>();
            ProcessFolder(oriPath);
            Console.WriteLine(liste.Count);
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

                    liste.Add(tagFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur sur "+filePath);
                }
            }
        }

        private static TagFile GetTagFile(string filePath)
        {
            
            Stream s = System.IO.File.Open(filePath, FileMode.Open);
            var fsa = new StreamFileAbstraction(Path.GetFileName(filePath), s, s);
            var tagFile = TagFile.Create(fsa);
            return tagFile;
        }
    }
}
