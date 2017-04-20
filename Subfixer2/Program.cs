using System;
using System.Collections.Generic;
using System.IO;
using Subfixer2_libs;

namespace Subfixer2
{
    class Program
    {
        static List<string> typs;
        static bool subDir = true;

        static void Main(string[] args)
        {
            typs = new List<string>();
            List<string> files = new List<string>();

            if (args.Length == 0)
            {
                typs.Add(".srt");
                files.Add(Directory.GetCurrentDirectory());
            }
            else
            {
                List<string> tmp = files;
                foreach (string item in args)
                {
                    if (item == "-f" || item == "--files")
                        tmp = files;
                    else if (item == "-t" || item == "--types")
                        tmp = typs;
                    else if (item == "--no-subdir")
                        subDir = false;
                    else
                        tmp.Add(item);
                }
                if (files.Count == 0)
                    files.Add(Directory.GetCurrentDirectory());
                if (typs.Count == 0)
                    typs.Add("srt");
                for (int j = typs.Count, i = 0; i < j; i++)
                    typs[i] = $".{typs[i]}";
            }
            ShowError se = Console.WriteLine;
            libs.head(se, subDir, typs, files.ToArray());
            Console.WriteLine("done");
            Console.ReadKey();
        }

    }
}
