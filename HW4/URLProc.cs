using System.Threading.Tasks;
using System.Net.Http;

namespace HW4
{
    public class URLProc
    {
        private readonly HttpClient _httpcl;

        public URLProc(HttpClient httpcl)
        {
            _httpcl = httpcl;
        }

        public async Task<string> GetHtmlFromURL(string url)
        {
            string htmltext;
            using (HttpResponseMessage response = await _httpcl.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    htmltext = await content.ReadAsStringAsync();
                }
            }
            return htmltext;
        }
    }
}
