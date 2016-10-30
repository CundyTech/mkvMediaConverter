using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace mkvMediaConverter
{

    class HashCheck
    {
        private static readonly List<byte[]> Bytelist = new List<byte[]>(); //Byte sig of already processed files

        public static bool DoCheck(string file)
        {
            FileInfo info = new FileInfo(file);

            while (FrmMain.IsFileLocked(info)) //Make sure file is finished being copied/moved
            {
                Thread.Sleep(500);
            }

            //Get byte sig of file and if seen before dont process
            byte[] myFileData = File.ReadAllBytes(file);
            byte[] myHash = MD5.Create().ComputeHash(myFileData);

            if (Bytelist.Count != 0)
            {
                for (int i = 0; i < Bytelist.Count; i++)
                {
                    //If seen before ignore
                    if (myHash.SequenceEqual(Bytelist[i]))
                    {
                        return true;
                    }
                }
            }
            Bytelist.Add(myHash);
            return false;
        }

        public static byte[] GetHash(FileSystemEventArgs e)
        {
           //Get byte sig of file 
            byte[] myFileData = File.ReadAllBytes(e.FullPath);
            byte[] myHash = MD5.Create().ComputeHash(myFileData);

           
            return myHash;
        }
    }
}
