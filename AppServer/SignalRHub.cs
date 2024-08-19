using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

public class SignalRHub : Hub
{
    public async Task SendMessage(string name, string message)
    {
        var jsonMessage = JsonConvert.SerializeObject(new { Name = name, Message = message });
        
        Console.WriteLine($"Received message: {jsonMessage}");

        await Clients.All.SendAsync("ReceiveMessage", jsonMessage);
    }
}
