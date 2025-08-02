using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyMonkeyApp
{
    class Program
    {
        private static List<Monkey> monkeys = new List<Monkey>();
        private static Random random = new Random();

        static void Main(string[] args)
        {
            InitializeMonkeys();
            ShowWelcomeMessage();
            
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";
                
                switch (choice.ToLower())
                {
                    case "1":
                        ShowAllMonkeys();
                        break;
                    case "2":
                        SearchMonkeyByName();
                        break;
                    case "3":
                        ShowRandomMonkey();
                        break;
                    case "4":
                    case "q":
                    case "quit":
                        running = false;
                        ShowGoodbyeMessage();
                        break;
                    default:
                        Console.WriteLine("❌ Invalid option. Please try again.");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    try
                    {
                        Console.ReadKey();
                    }
                    catch (InvalidOperationException)
                    {
                        // Handle redirected input gracefully
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }

        private static void InitializeMonkeys()
        {
            string monkeyArt = @"
      🐒
    /   \
   |  o o |
   |  \_/ |
    \     /
     |---|
     |   |
    /     \";

            string chimpArt = @"
      🦍
    /-----\
   |  O O  |
   |   <>   |
   |  ___  |
    \     /
     |---|
     |   |
    /     \";

            string orangutanArt = @"
      🦧
    /~~~~~\
   | (o)(o) |
   |    >   |
   |  ___  |
    \     /
     |---|
     |   |
    /     \";

            monkeys.AddRange(new List<Monkey>
            {
                new Monkey("보노보", "콩고 민주 공화국", "보노보", 15000, "평화로운 성격으로 유명한 우리의 가장 가까운 친척", chimpArt),
                new Monkey("오랑우탄", "보르네오, 수마트라", "오랑우탄", 100000, "나무 위에서 생활하며 매우 지능이 높은 유인원", orangutanArt),
                new Monkey("침팬지", "아프리카 중부", "침팬지", 300000, "도구를 사용하고 복잡한 사회 구조를 가진 영장류", chimpArt),
                new Monkey("일본원숭이", "일본", "일본원숭이", 114000, "온천을 즐기는 것으로 유명한 원숭이", monkeyArt),
                new Monkey("바바리원숭이", "지브롤터, 모로코", "바바리원숭이", 8000, "유럽에서 유일한 야생 원숭이 집단", monkeyArt),
                new Monkey("망토비비", "남아프리카", "망토비비", 250000, "매우 사회적이며 복잡한 계급 사회를 이루는 원숭이", monkeyArt),
                new Monkey("긴팔원숭이", "동남아시아", "긴팔원숭이", 200000, "나무에서 나무로 빠르게 이동하는 작은 유인원", monkeyArt),
                new Monkey("골든라이온타마린", "브라질", "골든라이온타마린", 3000, "아름다운 황금색 갈기를 가진 멸종위기 원숭이", monkeyArt),
                new Monkey("마다가스카르여우원숭이", "마다가스카르", "여우원숭이", 100000, "큰 눈과 긴 꼬리를 가진 마다가스카르의 대표 동물", monkeyArt),
                new Monkey("호울러원숭이", "중남미", "호울러원숭이", 500000, "매우 큰 소리를 내며 소통하는 신세계 원숭이", monkeyArt)
            });
        }

        private static void ShowWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                                                                   ║
║    🐒🦍🦧  WELCOME TO THE MONKEY CONSOLE APPLICATION!  🦧🦍🐒    ║
║                                                                   ║
║         Discover amazing primates from around the world!          ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝
");
        }

        private static void ShowMenu()
        {
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                             MENU                                  ║
╠═══════════════════════════════════════════════════════════════════╣
║                                                                   ║
║  1. 🐒 Show all monkeys                                           ║
║  2. 🔍 Search monkey by name                                      ║
║  3. 🎲 Show random monkey                                         ║
║  4. 👋 Quit                                                       ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝
");
            Console.Write("Choose an option (1-4): ");
        }

        private static void ShowAllMonkeys()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                           ALL MONKEYS                             ║
╚═══════════════════════════════════════════════════════════════════╝
");

            for (int i = 0; i < monkeys.Count; i++)
            {
                Console.WriteLine($"{i + 1,2}. {monkeys[i]}");
            }

            Console.WriteLine($"\nTotal: {monkeys.Count} monkeys in our database! 🐒");
        }

        private static void SearchMonkeyByName()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                       SEARCH MONKEY BY NAME                      ║
╚═══════════════════════════════════════════════════════════════════╝
");

            Console.Write("Enter monkey name to search: ");
            string searchName = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(searchName))
            {
                Console.WriteLine("❌ Please enter a valid name.");
                return;
            }

            var foundMonkey = monkeys.FirstOrDefault(m => 
                m.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundMonkey != null)
            {
                Console.WriteLine("✅ Monkey found!");
                Console.WriteLine(foundMonkey.GetDetailedInfo());
            }
            else
            {
                Console.WriteLine($"❌ No monkey found with name containing '{searchName}'.");
                Console.WriteLine("\nAvailable monkeys:");
                foreach (var monkey in monkeys)
                {
                    Console.WriteLine($"  • {monkey.Name}");
                }
            }
        }

        private static void ShowRandomMonkey()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                          RANDOM MONKEY                           ║
╚═══════════════════════════════════════════════════════════════════╝
");

            Console.WriteLine("🎲 Rolling the dice to pick a random monkey...");
            
            // Add some suspense
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            
            Console.WriteLine("\n");

            var randomMonkey = monkeys[random.Next(monkeys.Count)];
            Console.WriteLine("🎉 Your randomly selected monkey is:");
            Console.WriteLine(randomMonkey.GetDetailedInfo());
        }

        private static void ShowGoodbyeMessage()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════╗
║                                                                   ║
║    🐒🦍🦧  Thank you for using Monkey Console App!  🦧🦍🐒       ║
║                                                                   ║
║         Hope you enjoyed learning about our primate friends!      ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝

Goodbye! 👋
");
        }
    }
}
