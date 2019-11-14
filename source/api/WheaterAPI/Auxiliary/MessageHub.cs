using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WheaterAPI.Auxiliary
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string username, string message) 
        {
            await Clients.All.SendAsync("ReceivedMessage", username, message);
        }
    }
}
