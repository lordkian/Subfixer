using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Subfixer2_libs
{
    public delegate void ShowError(string text);
    public class libs
    {
        private static List<string> typs;
        private static bool subDir = true;
        private static ShowError errorHandler;

        public static void head(ShowError errorHandler, bool subDir, List<string> typs, params string[] paths)
        {
            libs.subDir = subDir;
            libs.typs = typs;
            libs.errorHandler = errorHandler;

            FileAttributes fattr;
            foreach (string item in paths)
            {
                fattr = File.GetAttributes(item);
                if (fattr.HasFlag(FileAttributes.Directory))
                    find(item);
                else
                    fix(item);
            }
        }
        public static void find(string path)
        {
            find(new DirectoryInfo(path));
        }

        public static void find(DirectoryInfo di)
        {
            if (!di.Exists)
                return;

            foreach (FileInfo item in di.GetFiles())
                if (typs.Contains(item.Extension))
                    fix(item.FullName);

            if (subDir)
                foreach (DirectoryInfo item in di.GetDirectories())
                    find(item);
        }
        public static void fix(string name)
        {
            try
            {
                Console.WriteLine("fixed " + name);
                StreamReader streamReader = new StreamReader(name, Encoding.GetEncoding("Windows-1256"));
                string value = streamReader.ReadToEnd();
                streamReader.Close();
                StreamWriter streamWriter = new StreamWriter(name.Substring(0, name.Length - 4) + ".edited.srt", false, Encoding.UTF8);
                streamWriter.Write(value);
                streamWriter.Close();
            }
            catch
            {
                errorHandler("Bad or corrupted file!");
            }
        }
    }
}
