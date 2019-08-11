
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AkuSpriteEditor
{
    // linux support class

    class lnx
    {
        public static System.Drawing.Image LoadImg(string filename)
        {
            // this gives Out of Memory on Linux
            filename = PathFix(filename);
            if (!File.Exists(filename))
            {
                VbX.MsgBox("File not found:" + filename);
                return null;
            }
            if (!IsLinux) return System.Drawing.Image.FromFile(filename);

            // I understand this does work on linux

            //	VbX.MsgBox (filename);
            Stream sr = new FileStream(filename, FileMode.Open);
            System.Drawing.Image im = System.Drawing.Image.FromStream(sr);
            sr.Close();
            sr = null;
            return im;
            //return null;

        }
        public static string addslash(string lin)
        {

            if (lin.Length == 0) return "";
            if (VbX.Right(lin, 1) == "/" || VbX.Right(lin, 1) == "\\") return lin;
            return lin + slash;
        }
        public static string slash = Path.DirectorySeparatorChar.ToString();
        public static bool exists(string lin)
        {

            return System.IO.File.Exists(PathFix(lin));
        }
        public static bool IsLinux // found this online, it detects if current os is linux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }
        public static string PathFix(string lin)
        {
            // right now this is a fix only for linux
            // It switches slash symbols, and corrects case of folders and files
            if (!IsLinux) return lin;

            if (slash == "/")
            {
                lin = lin.Replace("\\", slash);
            }
            else
            {
                lin = lin.Replace("/", slash);
            }

            string buildup = "";
            int ii = ss.CountItems(lin, slash);
            for (int i = 0; i <= ii; i++)
            {
                if (i < ii)
                {
                    buildup = PathFixDir(buildup, ss.GetItem(lin, slash, i));
                }
                else
                {
                    buildup = PathFixFile(buildup, ss.GetItem(lin, slash, i));
                }

            }
            return buildup;
        }
        public static string PathFixDir(string path, string lookfor)
        {
            if (lookfor.Length == 0) return slash;
            string path2 = "";
            if (path.Length > 0)
            {
                if (VbX.Right(path, 1) != slash) path += slash;
                path2 = path;
            }
            else
            {
                path2 = "." + slash;
            }
            foreach (string dir in Directory.GetDirectories(path2))
            {
                if (dir.ToLower() == path + lookfor.ToLower()) return dir;
            }
            if (path.Length > 0) lookfor = path + slash + lookfor;
            return lookfor;
        }
        public static string PathFixFile(string path, string lookfor)
        {
            string path2 = "";
            if (path.Length > 0)
            {
                if (VbX.Right(path, 1) != slash) path += slash;
                path2 = path;
            }
            else
            {
                path2 = "." + slash;
            }
            try
            {
                foreach (string dir in Directory.GetFiles(path2))
                {
                    if (dir.ToLower() == path + lookfor.ToLower()) return dir;
                }
            }
            catch (Exception ex)
            {
                VbX.MsgBox(ex.ToString());
            }
            return path + lookfor;
        }
    }
}
