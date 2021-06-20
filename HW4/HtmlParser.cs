using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HW4
{
    class HtmlParser
    {
        public Dictionary<string, string> GetImagesFromHtml(string html)
        {
            Dictionary<string, string> links = new Dictionary<string, string>();
            Regex regex = new Regex(@"<img.*src=[\''""](\S+.(jpg|png))");
            MatchCollection res = regex.Matches(html);
            
            if (res.Count > 0)
            {
                foreach (Match match in res)
                {
                    Regex rgxname = new Regex(@"[^\/]+.(jpg|png)");
                    MatchCollection rname = rgxname.Matches(match.ToString());

                    if (rname.Count == 1)
                        try
                        {
                            links.Add(match.Groups[1].Value.ToString(), rname[0].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                }
            }
            return links;
        }
    }
}
