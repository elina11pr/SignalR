using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string serverUrl = "http://localhost:5000/";

            var connection = new HubConnectionBuilder()
                .WithUrl(serverUrl)
                .Build();

            try
            {
                await connection.StartAsync();

                Console.WriteLine("З'єднано");

                while (true)
                {
                    Console.Write(" Введіть ім'я: ");
                    string userName = Console.ReadLine();

                    Console.Write(" Повідомлення: ");
                    string message = Console.ReadLine();

                    var data = new { UserName = userName, Message = message };
                    string json = JsonSerializer.Serialize(data);

                    await connection.InvokeAsync("SendMessage", json);

                    Console.WriteLine("Ваше повідомлення відправлено");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Помилка: {err.Message}");
            }
        }
    }
}