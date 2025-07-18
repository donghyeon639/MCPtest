using System;
using System.Collections.Generic;
using System.Linq;

public static class MonkeyHelper
{
    private static readonly List<Monckey> monkeys = new List<Monckey>
    {
        new Monckey { Name = "Baboon", Location = "Africa & Asia", Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Population = 10000, Latitude = -8.783195, Longitude = 34.508523 },
        new Monckey { Name = "Capuchin Monkey", Location = "Central & South America", Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Population = 23000, Latitude = 12.769013, Longitude = -85.602364 },
        new Monckey { Name = "Blue Monkey", Location = "Central and East Africa", Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg", Population = 12000, Latitude = 1.957709, Longitude = 37.297204 },
        new Monckey { Name = "Squirrel Monkey", Location = "Central & South America", Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg", Population = 11000, Latitude = -8.783195, Longitude = -55.491477 },
        new Monckey { Name = "Golden Lion Tamarin", Location = "Brazil", Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg", Population = 19000, Latitude = -14.235004, Longitude = -51.92528 },
        new Monckey { Name = "Howler Monkey", Location = "South America", Details = "Howler monkeys are among the largest of the New World monkeys.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg", Population = 8000, Latitude = -8.783195, Longitude = -55.491477 },
        new Monckey { Name = "Japanese Macaque", Location = "Japan", Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg", Population = 1000, Latitude = 36.204824, Longitude = 138.252924 },
        new Monckey { Name = "Mandrill", Location = "Southern Cameroon, Gabon, and Congo", Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg", Population = 17000, Latitude = 7.369722, Longitude = 12.354722 },
        new Monckey { Name = "Proboscis Monkey", Location = "Borneo", Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg", Population = 15000, Latitude = 0.961883, Longitude = 114.55485 },
        new Monckey { Name = "Sebastian", Location = "Seattle", Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg", Population = 1, Latitude = 47.606209, Longitude = -122.332071 },
        new Monckey { Name = "Henry", Location = "Phoenix", Details = "An adorable Monkey who is traveling the world with Heather.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg", Population = 1, Latitude = 33.448377, Longitude = -112.074037 },
        new Monckey { Name = "Red-shanked douc", Location = "Vietnam", Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg", Population = 1300, Latitude = 16.111648, Longitude = 108.262122 },
        new Monckey { Name = "Mooch", Location = "Seattle", Details = "An adorable Monkey who is traveling the world with Heather.", ImageUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG", Population = 1, Latitude = 47.608013, Longitude = -122.335167 }
    };

    private static readonly Dictionary<string, int> accessCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    private static readonly Random random = new Random();

    public static List<Monckey> GetMonkeys()
    {
        return monkeys;
    }

    public static Monckey GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        var monkey = monkeys[random.Next(monkeys.Count)];
        TrackAccess(monkey.Name);
        return monkey;
    }

    public static Monckey GetMonkeyByName(string name)
    {
        var monkey = monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (monkey != null)
            TrackAccess(monkey.Name);
        return monkey;
    }

    public static int GetMonkeyAccessCount(string name)
    {
        if (accessCounts.TryGetValue(name, out int count))
            return count;
        return 0;
    }

    private static void TrackAccess(string name)
    {
        if (accessCounts.ContainsKey(name))
            accessCounts[name]++;
        else
            accessCounts[name] = 1;
    }
}
