using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RealEstateMVC.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendPropertyNotification(string title)
        {
            await Clients.All.SendAsync("ReceiveNotification", title);
        }
    }
}
