using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var uri = "http://localhost:7054/current-time"; 

        var client = new MyClient(uri);
        await client.ExecuteAsync();
    }
}
