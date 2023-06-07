using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorDemoWASM.Pages.Exo.Exo2
{
    public partial class Ajout
    {
        [Inject]
        public HttpClient client { get; set; }

        public Article ArticleForm { get; set; }

        public Ajout()
        {
            ArticleForm = new Article();
        }

        public async Task OnSubmit()
        {
            string content = JsonConvert.SerializeObject(ArticleForm);
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await client.PostAsync("article/", httpContent))
            {
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("cool");
                    
                }
            }
        }
    }
}
