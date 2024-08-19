using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

public class MyClient
{
    private readonly string _uri;
    private HubConnection _connection;

    public MyClient(string uri)
    {
        _uri = uri;
    }

    public async Task ExecuteAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(_uri)
            .Build();

        _connection.On<string>("ReceiveMessage", message =>
        {
            Console.WriteLine($"Received message from server: {message}");
        });

        await _connection.StartAsync();

        Console.WriteLine("Enter your name:");
        var name = Console.ReadLine();

        Console.WriteLine("You can enter a message. To send a new message, just press Enter)");

        while (true)
        {
  
            var message = Console.ReadLine();
            if (!string.IsNullOrEmpty(message))
            {
                var success = await SendMessageAsync(name, message);
                Console.WriteLine(success ? "Your message has been sent successfully." : "Sending error.");
            }
        }
    }

    public async Task<bool> SendMessageAsync(string name, string message)
    {
        try
        {
            if (_connection != null)
            {
                await _connection.SendAsync("SendMessage", name, message);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
        }
        return false;
    }
}
