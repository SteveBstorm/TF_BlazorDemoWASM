using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace BlazorDemoWASM.Pages.Exo.Exo2
{
    public partial class Liste
    {
        HubConnection hubConnection;
        [Inject]
        public HttpClient client { get; set; }
        public List<Article> ArticleList { get; set; }

        public int SelectedId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ArticleList = new List<Article>();
            //client.BaseAddress = new Uri("https://localhost:7073/api/");
            
            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("http://bstormBlazorDemo.somee.com/articlehub")).Build();

            hubConnection.On("GetArticle", async () =>
            {
                using(HttpResponseMessage message = await client.GetAsync("article"))
                {
                    if (message.IsSuccessStatusCode)
                    {
                        Console.WriteLine("test");   
                        string json = await message.Content.ReadAsStringAsync(); 
                        ArticleList = JsonConvert.DeserializeObject<List<Article>>(json);
                        StateHasChanged();
                    }
                }
            });

            await hubConnection.StartAsync();
            await hubConnection.SendAsync("NewArticle");
        }

        public void SetSelectedId(int id)
        {
            SelectedId = id;
        }
    }
}
