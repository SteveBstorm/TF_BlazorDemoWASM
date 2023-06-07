using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorDemoWASM.Pages.Exo.Exo2
{
    public partial class Detail
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public HttpClient client { get; set; }

        public Article CurrentArticle { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            using (HttpResponseMessage message = await client.GetAsync("article/"+Id))
            {
                if (message.IsSuccessStatusCode)
                {

                    string json = await message.Content.ReadAsStringAsync();
                    CurrentArticle = JsonConvert.DeserializeObject<Article>(json);
                    StateHasChanged();
                }
            }
        }
    }
}
