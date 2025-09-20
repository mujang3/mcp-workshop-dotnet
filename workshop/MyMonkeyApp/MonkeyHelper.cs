using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Static helper class for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new List<Monkey>();
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// Initializes the monkey data from MCP server.
    /// </summary>
    public static async Task InitializeAsync()
    {
        // TODO: Replace with actual MCP server call
        monkeys = await MonkeyMcpClient.GetMonkeysAsync();
    }

    /// <summary>
    /// Gets all monkeys.
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        return monkeys;
    }

    /// <summary>
    /// Gets a monkey by name.
    /// </summary>
    public static Monkey GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        randomMonkeyAccessCount++;
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    public static int GetRandomMonkeyAccessCount()
    {
        return randomMonkeyAccessCount;
    }
}

/// <summary>
/// Simulated MCP client for demonstration. Replace with actual MCP integration.
/// </summary>
public static class MonkeyMcpClient
{
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        // TODO: Replace with actual MCP server call
        await Task.Delay(100); // Simulate async call
        return new List<Monkey>
        {
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Latitude = -8.783195, Longitude = 34.508523 },
            new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Latitude = 12.769013, Longitude = -85.602364 },
            // ... Add other monkeys as needed
        };
    }
}
