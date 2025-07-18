using System;

class Program
{
    static void Main(string[] args)
    {
        string[] asciiArts = new string[]
        {
            @"  (o.o)\n  /)_/)\n //   \\",
            @"  ( ᵔᴥᵔ )\n  /|   |\\\n  /_| |_\\",
            @"  ( ^.^ )\n  /|_|\\\n   / ",
            @"  (ಠ_ಠ)\n  /|_|\\\n  /   ",
            @"  (•‿•)\n  /|\\\n  / ",
            @"  (='.'=)\n  (')_(')",
            @"  (>'-')>\n  <('-'<)\n  ^(' - ')^",
            @"  (._.)\n  <| |\n  / ",
            @"  (o_O)\n  /|\\\n  / ",
            @"  (¬_¬)\n  /|\\\n  / ",
            @"  (•_•)\n  /|\\\n  / ",
            @"  (='x'=)\n  (')_(')"
        };

        while (true)
        {
            Console.WriteLine("\nMonkey App Menu:");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var monkeys = MonkeyHelper.GetMonkeys();
                    Console.WriteLine("\nAll Monkeys:");
                    foreach (var m in monkeys)
                    {
                        Console.WriteLine($"- {m.Name} ({m.Location})");
                    }
                    break;
                case "2":
                    Console.Write("Enter monkey name: ");
                    var name = Console.ReadLine();
                    var monkey = MonkeyHelper.GetMonkeyByName(name);
                    if (monkey != null)
                    {
                        Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nImage: {monkey.ImageUrl}");
                        Console.WriteLine($"Accessed {MonkeyHelper.GetMonkeyAccessCount(monkey.Name)} times.");
                    }
                    else
                    {
                        Console.WriteLine("Monkey not found.");
                    }
                    break;
                case "3":
                    var randMonkey = MonkeyHelper.GetRandomMonkey();
                    if (randMonkey != null)
                    {
                        Console.WriteLine($"\nRandom Monkey: {randMonkey.Name}\nLocation: {randMonkey.Location}\nPopulation: {randMonkey.Population}\nDetails: {randMonkey.Details}\nImage: {randMonkey.ImageUrl}");
                        Console.WriteLine($"Accessed {MonkeyHelper.GetMonkeyAccessCount(randMonkey.Name)} times.");
                        // 랜덤 ASCII 아트 출력
                        var rand = new Random();
                        var art = asciiArts[rand.Next(asciiArts.Length)];
                        Console.WriteLine("\nASCII Art:\n" + art);
                    }
                    else
                    {
                        Console.WriteLine("No monkeys available.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
