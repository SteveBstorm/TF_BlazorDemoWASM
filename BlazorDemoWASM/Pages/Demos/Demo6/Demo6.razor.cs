using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BlazorDemoWASM.Pages.Demos.Demo6
{
    public partial class Demo6
    {
        [Inject]
        public HttpClient client { get; set; }

        [Inject]
        public IJSRuntime js { get; set; }
        public async Task Login()
        {
            client.BaseAddress = new Uri("https://localhost:7073/");
            using (HttpResponseMessage m = await client.GetAsync("api/user/1"))
            {
                if (m.IsSuccessStatusCode)
                {
                    var json = await m.Content.ReadAsStringAsync();
                    await js.InvokeVoidAsync("localStorage.setItem","token", json);
                    Console.WriteLine(json);
                }
                else
                {
                    Console.WriteLine(m.StatusCode);
                }
            }
            //string token = await client.GetFromJsonAsync("api/user/1");
            //Console.WriteLine(token);
        }

        public async Task GetAll()
        {
            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");

            client.BaseAddress = new Uri("https://localhost:7073/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            using (HttpResponseMessage m = await client.GetAsync("api/user"))
            {
                if (m.IsSuccessStatusCode)
                {
                    var json = await m.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                }
                else
                {
                    Console.WriteLine(m.StatusCode);
                }
            }
        }
    }
}
