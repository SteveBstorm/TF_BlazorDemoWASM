using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDemoWASM.Pages.Demos.Demo7
{
    public partial class Demo7
    {
        public HubConnection _hubConnection { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }

        public List<string> Messages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = new List<string>();
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7073/chathub")).Build();

            _hubConnection.On<string, string>("ReceiveMessage", 
                (username, message) => {
                    Messages.Add($"{username} : {message}");
                    StateHasChanged();
                });

            await _hubConnection.StartAsync();
            Console.WriteLine(_hubConnection.ConnectionId);
            IsConnected = _hubConnection.State == HubConnectionState.Connected;
        }

        public async Task JoinGroup()
        {
            _hubConnection.On<string, string>("FromGroup",
                (username, message) =>
                {
                    Messages.Add($"{username} : {message}");
                    StateHasChanged();
                });

            await _hubConnection.SendAsync("JoinGroup", "monGroupe");
        }
        public async Task SendToGroup()
        {
            
            await _hubConnection.SendAsync("SendToGroup","monGroupe", Username, Message);
        }
        public async Task Send()
        {
            Console.WriteLine("send");
            await _hubConnection.SendAsync("SendMessage", Username, Message);
        }

        public bool IsConnected { get; set; }
    }
}
