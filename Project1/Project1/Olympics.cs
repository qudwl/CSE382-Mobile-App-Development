using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Project1;
public class Olympics
{
    public static List<Participant>? participants;
    public static List<string> hosts = new List<string>();

    public static List<Participant> ReadParticipants(string fname)
    {
        participants = new List<Participant>();
        using (StreamReader input = new StreamReader(fname))
        {
            string? header = input.ReadLine();
            while (!input.EndOfStream)
            {
                string? line = input.ReadLine();
                if (line == null)
                {
                    continue;
                }
                Participant p = new Participant(line);
                participants.Add(p);
            }
        }
        return participants;
    }

    public static void ListHosts()
    {
        if (hosts.Count() == 0)
        {
            foreach (Participant pt in participants)
            {
                if (hosts.IndexOf(pt.Location) == -1)
                {
                    hosts.Add(pt.Location);
                }
            }

            hosts.Sort();
        }

        foreach (string host in hosts)
        {
            Console.WriteLine(host);
        }
    }

    public static void ListCount(string inputStr, bool checkForGold = false)
    {
        string[] parameters = inputStr.Trim().Split(' ');
        string cmd = checkForGold ? "golds" : "count";
        if (parameters.Length < 2)
        {
            Console.WriteLine($"Wrong format! {cmd} <year> <country>");
            return;
        }

        int medalCount = 0;
        string countryName = "";
        int year;
        if (!int.TryParse(parameters[0], out year))
        {
            Console.WriteLine($"Wrong format! {cmd} <year> <country>");
            return;
        }

        for (int i = 1; i < parameters.Length; i++)
        {
            countryName += parameters[i] + " ";
        }

        countryName = countryName.Trim();

        foreach (Participant pt in participants)
        {
            if (pt.Country == countryName && pt.Year == year && pt.Medal != Participant.MedalType.None)
            {
                if (checkForGold)
                {
                    if (pt.Medal == Participant.MedalType.Gold)
                    {
                        medalCount++;
                    }
                }
                else
                {
                    medalCount++;
                }
            }
        }
        string color = checkForGold ? " gold" : "";
        Console.WriteLine($"{countryName} has won {medalCount}{color} medals.");
    }

    public static void Podium(string inputStr)
    {
        string[] parameters = inputStr.Trim().Split(' ');
        if (parameters.Length < 3)
        {
            Console.WriteLine("Wrong format! podium <year> <season> <event>");
            return;
        }

        int year;
        if (!int.TryParse(parameters[0], out year))
        {
            Console.WriteLine("Wrong format! podium <year> <season> <event>");
            return;
        }

        Participant.SeasonType season = parameters[1] == "Summer" ? Participant.SeasonType.Summer : Participant.SeasonType.Winter;
        string sptEvent = string.Join(" ", parameters.Skip(2).Take(parameters.Length - 1).ToArray());

        Console.WriteLine($"The {year} {season} Olympics {sptEvent} Medalists:");

        List<List<Participant>> medals = new List<List<Participant>>();
        medals.Add(new List<Participant>());
        medals.Add(new List<Participant>());
        medals.Add(new List<Participant>());

        foreach (Participant p in participants)
        {
            if (p.Year == year && p.Season == season && p.Event == sptEvent)
            {
                switch(p.Medal)
                {
                    case Participant.MedalType.Gold:
                        medals[0].Add(p); break;
                    case Participant.MedalType.Silver:
                        medals[1].Add(p); break;
                    case Participant.MedalType.Bronze:
                        medals[2].Add(p);break;
                    default:
                        break;
                }
            }
        }

        string[] medalNames = { "Gold", "Silver", "Bronze" };
        for(int i = 0; i < medals.Count(); i++)
        {
            string s = medals[i].Count() > 1 ? "s" : "";
            Console.WriteLine($"{medalNames[i]} Medalist{s}:");
            foreach (Participant p in medals[i])
            {
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Country: {p.Country}");
                Console.WriteLine($"Age: {p.Age}");
            }
            Console.WriteLine();
        }
    }
    public static void Main(string[] args)
    {
        while (participants == null)
        {
            ReadParticipants("olympics.tsv");
        }

        while (true)
        {
            Console.Write(">> ");
            string? userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                if (userInput == "hosts")
                {
                    ListHosts();
                }
                else if (userInput == "exit")
                {
                    return;
                }
                else if (userInput.Split(' ')[0] == "count")
                {
                    ListCount(userInput.Substring(5));
                }
                else if (userInput.Split(' ')[0] == "golds")
                {
                    ListCount(userInput.Substring(5), true);
                }
                else if (userInput.Split(' ')[0] == "podium")
                {
                    Podium(userInput.Substring(6));
                }
                else
                {
                    Console.WriteLine("Command not found.");
                    Console.WriteLine("Available Commands:");
                    Console.WriteLine("count: Show the number of medals a country has won in a year.");
                    Console.WriteLine("\tcount <year> <country>");
                    Console.WriteLine("golds: Show the number of gold medals a country has won in a year.");
                    Console.WriteLine("\tgolds <year> <country>");
                    Console.WriteLine("podium: Show the medalists of an event of a particular year.");
                    Console.WriteLine("\tpodium <year> <season> <event>");
                }

                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}