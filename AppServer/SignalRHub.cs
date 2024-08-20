using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SignalRHub : Hub
{
    public async Task SendMessage(string name, string message)
    {
        var jsonMessage = JsonConvert.SerializeObject(new { Name = name, Message = message });
        Console.WriteLine($"Received message: {jsonMessage}");
        await Clients.All.SendAsync("ReceiveMessage", jsonMessage);
    }

    public Task<List<string>> GetName()
    {
        List<string> names = new List<string> { "Georg", "Den", "Mahito" };
        return Task.FromResult(names);
    }

    public Task ReceiveClientResult(string result)
    {
        Console.WriteLine($"Receive result from client: {result}"); 
        return Task.CompletedTask;
    }
}
