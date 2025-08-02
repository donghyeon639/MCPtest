namespace MyMonkeyApp
{
    /// <summary>
    /// Represents a monkey with its characteristics and details
    /// </summary>
    public class Monkey
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Population { get; set; }
        public string Details { get; set; } = string.Empty;
        public string AsciiArt { get; set; } = string.Empty;

        public Monkey(string name, string location, string species, int population, string details, string asciiArt = "")
        {
            Name = name;
            Location = location;
            Species = species;
            Population = population;
            Details = details;
            AsciiArt = asciiArt;
        }

        public override string ToString()
        {
            return $"🐒 {Name} ({Species}) - {Location}";
        }

        public string GetDetailedInfo()
        {
            var info = $@"
╔══════════════════════════════════════════════╗
║                 MONKEY INFO                  ║
╠══════════════════════════════════════════════╣
║ Name: {Name.PadRight(37)}║
║ Species: {Species.PadRight(34)}║
║ Location: {Location.PadRight(33)}║
║ Population: {Population.ToString().PadRight(31)}║
║ Details: {Details.PadRight(34)}║
╚══════════════════════════════════════════════╝";

            if (!string.IsNullOrEmpty(AsciiArt))
            {
                info += $"\n\n{AsciiArt}";
            }

            return info;
        }
    }
}