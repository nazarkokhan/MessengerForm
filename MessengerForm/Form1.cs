using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessengerApp.Core.DTO.Message;
using MessengerForm.Services;
using MessengerForm.Services.Abstraction;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable 4014

namespace MessengerForm
{
    public partial class Form1 : Form
    {
        private ServiceProvider _service;
        
        static HubConnection HubConnection { get; set; }

        public Form1()
        {
            _service = new ServiceCollection()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IChatService, ChatService>()
                .AddScoped<IContactService, ContactService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddScoped<AuthInterceptor>()
                .AddSingleton<IConfiguration>(configuration)
                .AddHttpClient(
                    nameof(LoginService),
                    client => { client.BaseAddress = new Uri(configuration.GetApiBaseUrl()); }
                )
                .Services
                .AddHttpClient(
                    Client.AuthClient,
                    client => { client.BaseAddress = new Uri(configuration.GetApiBaseUrl()); }
                )
                .AddHttpMessageHandler<AuthInterceptor>()
                .Services
                .BuildServiceProvider();
            InitializeComponent();
        }

        private async Task OnHub()
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chat")
                .Build();
        
            HubConnection.On<MessageDto, string>("SendOth", (messageDto, message) =>
                // Console.WriteLine($"{messageDto}: {message}")
                Messages.Items.Add(messageDto.Body)
            );
        
            await HubConnection.StartAsync();
        
            while (true)
            {
                var message = Console.ReadLine();
        
                if (message is "end")
                    break;
        
                await HubConnection.SendAsync("SendMessageToOthers", message);
            }
        }

        private void Pipe_Load(object sender, EventArgs e)
        {
            OnHub();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newMassage = textBox.Text;

            if (string.IsNullOrEmpty(newMassage))
            {
                return;
            }

            Messages.Items.Add(newMassage);

            textBox.Text = string.Empty;
        }

        private void Messages_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}