using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
namespace HW4
{
    class Program
    {
        static void Main(string[] args)
            
        {
            HttpClient httpcl = new HttpClient();
            WebClient webcl = new WebClient();
            URLProc urlproc = new URLProc(httpcl);
            HtmlParser htmlparser = new HtmlParser();
            FileDownloder filedownld = new FileDownloder(webcl);

            string url;
            while (true)
            {
                Console.WriteLine("Введите URL-адрес либо exit для выхода");
                url = Console.ReadLine();
                if (url == string.Empty)
                {
                    Console.WriteLine("URL не указан, попробуйте еще раз");
                    continue;
                }
                else
                if (url == "exit")
                    return;


                string html = urlproc.GetHtmlFromURL(url.Trim()).ConfigureAwait(false).GetAwaiter().GetResult();
                Dictionary<string, string> images = htmlparser.GetImagesFromHtml(html);
                Console.WriteLine("Найдено {0} изображений", images.Count);
                filedownld.DownloadFilesFromWeb(images, url, @"..\..\..\img");
                Console.ReadLine();
            }

        }
    }
}
