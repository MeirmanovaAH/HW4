using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HW4
{
    class FileDownloder
    {
        private readonly WebClient _webcl;
        public FileDownloder(WebClient webcl)
        {
            _webcl = webcl;
        }

        public void DownloadFilesFromWeb(Dictionary<string, string> Files, string Host, string Path)
        {
            System.IO.Directory.CreateDirectory(Path);
            foreach (KeyValuePair<string, string> File in Files)
            {
                try
                {
                    _webcl.DownloadFile(File.Key, Path + @"\" + File.Value);
                }
                catch (Exception)
                {
                    try
                    {
                        _webcl.DownloadFile(Host + File.Key, Path + @"\" + File.Value);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            _webcl.DownloadFile("Https:" + File.Key, Path + @"\" + File.Value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось скачать файл по ссылке: {0}", "Https:" + File.Key);
                        }
                    }
                }
            }
        }

    }
}
