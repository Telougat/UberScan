using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace UberScan.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task SendMessage(string message)
        {
            var user = _httpContextAccessor.HttpContext.User.Identity.Name; //Get current user
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}