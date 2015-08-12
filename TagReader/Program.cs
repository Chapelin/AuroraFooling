using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using File = System.IO.File;

namespace TagReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"\\NAS-PERSO\Volume_1\Musique\Lamb of God\(2009) Wrath";

            var list = Directory.EnumerateFiles(path, "*.mp3");
            foreach (var file in list)
            {
                Stream s = System.IO.File.Open(file, FileMode.Open);
                var fsa = new StreamFileAbstraction(Path.GetFileName(file), s, s);
                var tagFile = TagLib.File.Create(fsa);

                var tags = tagFile.GetTag(TagTypes.Id3v2);
                Console.WriteLine();
            }
        }
    }
}
