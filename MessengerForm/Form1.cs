using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessengerApp.Core.DTO.Message;
using MessengerForm.Constants;
using MessengerForm.DTO.Authorization;
using MessengerForm.Extensions;
using MessengerForm.Services;
using MessengerForm.Services.Abstraction;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable 4014

namespace MessengerForm
{
    public partial class Form1 : Form
    {
        private static IConfiguration Configuration { get; set; }
        
        private static HubConnection HubConnection { get; set; }

        private readonly IAccountService _accountService;
        
        private readonly IChatService _chatService;
        
        private readonly IContactService _contactService;
        
        private readonly IMessageService _messageService;
        
        private readonly ITokenStorage _tokenStorage;
        
        private ProfileDto _user;

        public Form1()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName.AppSettings))
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IChatService, ChatService>()
                .AddScoped<IContactService, ContactService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<ITokenStorage, JsonFileTokenStorage>()
                .AddScoped<AuthInterceptor>()
                .AddSingleton<IConfiguration>(Configuration)
                .AddHttpClient(
                    nameof(AccountService),
                    client => { client.BaseAddress = new Uri(Api.BaseUrl); }
                )
                .Services
                .AddHttpClient(
                    Client.AuthClient,
                    client => { client.BaseAddress = new Uri(Api.BaseUrl); }
                )
                .AddHttpMessageHandler<AuthInterceptor>()
                .Services
                .BuildServiceProvider();
            
            _accountService = serviceProvider.GetRequiredService<IAccountService>();
            _chatService = serviceProvider.GetRequiredService<IChatService>();
            _contactService = serviceProvider.GetRequiredService<IContactService>();
            _messageService = serviceProvider.GetRequiredService<IMessageService>();
            _tokenStorage = serviceProvider.GetRequiredService<ITokenStorage>();
            
            InitializeComponent();
        }

        private async Task OnHub()
        {
            Configuration.GetReloadToken();
            
            HubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chat")
                .Build();
        
            HubConnection.On<MessageDto>("Send", (messageDto) =>
                Messages.Items.Add(messageDto.Body)
            );
        
            await HubConnection.StartAsync();
        }
        
        private async Task LoadMessages()
        {
            _user = await _accountService.GetProfileAsync(3);

            var messages = await _messageService.GetMessagesInChatPageAsync(_user.Id, 1);

            foreach (var m in messages.Data)
            {
                Messages.Items.Add(m);
            }
        }

        private void Pipe_Load(object sender, EventArgs e)
        {
            var logInUserData = Dto.LogInUserData();
            
            var token = _accountService.GetAccessAndRefreshTokensAsync(logInUserData);

            OnHub();

            LoadMessages();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var newMassage = textBox.Text;

            if (string.IsNullOrEmpty(newMassage))
            {
                return;
            }

            Messages.Items.Add(newMassage);
            
            await HubConnection.SendAsync("SendMessageToOthers", newMassage);

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