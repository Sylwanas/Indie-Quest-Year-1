using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using WindowsInput;
using WindowsInput.Native;

namespace Real_Text_Based_Game
{
    class Event //Class for the events in the game. 
    {
        public string eventId;
        public string eventName;
        public string eventNarration;
        public item eventItem;
        public bool eventDeath;
        public bool eventEnd;
        public bool eventEscape;
        public List<Choice> listOfChoices = new List<Choice>();
    }
    class Choice //Class for the choices in the game. 
    {
        public string choiceId;
        public string choiceName;
        public string choiceNarration;
        public item choiceItem;
        public int alertAlteration;
        public int alertDeathMinLvl;
        public bool alertDeath;
        public Event nextEvent;
    }
    enum item //Enum for all of the ingame items. 
    {
        nothing,
        dagger,
        kingsCrown,
        bloodyShoes,
        goldenRing,
        turkeyLeg
    }
    internal class Program
    {
        //Constant colors for different things, easily changeable and will affect entire code if const consolecolor.
        const ConsoleColor TitleColor = ConsoleColor.Red;
        const ConsoleColor NarrativeColor = ConsoleColor.Yellow;
        const ConsoleColor PromptColor = ConsoleColor.Magenta;
        const ConsoleColor miscColor = ConsoleColor.DarkCyan;
        const ConsoleColor DeathColor = ConsoleColor.DarkRed;
        const ConsoleColor EscapeColor = ConsoleColor.Green;
        const int PrintPauseMilliseconds = 50;

        static void Print(string text) //Method for writing out information
        {
            string[] words = text.Split(" ");
            foreach (string word in words)
            {
                int totalWidth = Console.WindowWidth - 4;
                int cursourPosition = Console.CursorLeft;
                int charactersLeft = totalWidth - cursourPosition;

                if (charactersLeft < word.Length)
                {
                    Console.WriteLine();
                }

                Console.Write($"{word} ");
                System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Fullscreen
            string OS = System.Environment.OSVersion.VersionString;
            if (OS.Contains("Windows"))
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                if (OperatingSystem.IsWindows())
                {
                    Console.BufferWidth = Console.WindowWidth;
                    Console.BufferHeight = Console.WindowHeight;
                }
                InputSimulator inputSimulator = new InputSimulator();
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F11);
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
            }

            //Text File for all of the choices and events.
            string Narration = File.ReadAllText("Narration.txt");

            MatchCollection eventMatches = Regex.Matches(Narration,
                @"(.*)\n" + //Event ID in code.
                @"eventName: (.*)\n" + //Event Name in game.
                @"eventNarration: (.*)\n" + //Narration for event.
                @"eventItem: (.*)\n" + //Checking if there is an item to be obtained.
                @"eventDeath: (.*)\n" + //Checking if the event is a death event.
                @"eventEnd: (.*)\n" + //Checking if the event is an end node event.
                @"eventEscape: (.*)\n" + //Checking if the event is an escape event.
                @"listOfChoices: (.*)" //Saving for later to collect the choices for the event.
                );

            Dictionary<string, Event> eventDictionary = new Dictionary<string, Event>(); //Dictionary for events

            foreach (Match match in eventMatches) //Matching and storing the values of the event Id, Name, Narration, Potential item, if it is a death event, if it is an end event, if it is an escape event and saving what the choices for the event is for later.
            {
                Event events = new Event();
                events.eventId = match.Groups[1].Value;
                events.eventName = match.Groups[2].Value;
                events.eventNarration = match.Groups[3].Value;
                events.eventItem = Enum.Parse<item>(match.Groups[4].Value);
                events.eventDeath = bool.Parse(match.Groups[5].Value);
                events.eventEnd = bool.Parse(match.Groups[6].Value);
                events.eventEscape = bool.Parse(match.Groups[7].Value);
                eventDictionary.Add(events.eventId, events);
            }

            Dictionary<string, Choice> choiceDictionary = new Dictionary<string, Choice>(); //Dictionary for choices

            MatchCollection choiceMatches = Regex.Matches(Narration,
                @"(.*)\n" + //Choice Id.
                @"choiceName: (.*)\n" + //Choice name. 
                @"choiceNarration: (.*)\n" + //Choice narration.
                @"choiceItem: (.*)\n" + //Checking for item requirements.
                @"alertAlteration: (.*)\n" + //Checking if the alert lvl is increased.
                @"alertDeathMinLvl: (.*)\n" + //Checking the lowest level to die to alert event.
                @"alertDeath: (.*)\n" + //Checking if alert death is true.
                @"nextEvent: (.*)" //Checking what the next event is.
                );

            foreach (Match match in choiceMatches) //Matching and storing the values of the choices Id, Name, Narration, Potential item requirements, Alert change, if there is an alert death and at what lvl and what the next event is.
            {
                Choice choices = new Choice();
                choices.choiceId = match.Groups[1].Value;
                choices.choiceName = match.Groups[2].Value;
                choices.choiceNarration = match.Groups[3].Value;
                choices.choiceItem = Enum.Parse<item>(match.Groups[4].Value);
                choices.alertAlteration = int.Parse(match.Groups[5].Value);
                choices.alertDeathMinLvl = int.Parse(match.Groups[6].Value);
                choices.alertDeath = bool.Parse(match.Groups[7].Value);
                choices.nextEvent = eventDictionary[match.Groups[8].Value];
                choiceDictionary.Add(choices.choiceId, choices);
            }

            foreach (Match match in eventMatches) //Collecting the choices for the event.
            {
                Event events = eventDictionary[match.Groups[1].Value];
                string choiceList = match.Groups[8].Value;
                string[] choiceArray = choiceList.Split(", ");
                events.listOfChoices = new List<Choice>();

                foreach (string choice in choiceArray)
                {
                    events.listOfChoices.Add(choiceDictionary[choice]); //Adding the choices to the list and dictionary
                }
            }

            //Title
            Console.ForegroundColor = TitleColor;
            string title = File.ReadAllText("Title.txt");
            Console.WriteLine(title);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Please press ENTER to start."));
            Console.ReadKey();
            Console.Clear();

            //Route Variables
            Event currentEvent = null;
            int alertLvl = 0;
            List<item> inventory = new List<item>();

            //Session Variables
            List<Event> achievedDeaths = new List<Event>();

            //Gameloop
            bool GameOver = false;
            do
            {
                //Making sure that the first event in the game is the DungeonCell event as well as putting it back to the DungeonCell event if you die.
                Console.ForegroundColor = NarrativeColor;
                if (currentEvent == null || currentEvent.eventId == "Death")
                {
                    currentEvent = eventDictionary["DungeonCell"];
                }

                if (currentEvent.eventItem != item.nothing && !inventory.Contains(currentEvent.eventItem))
                {
                    inventory.Add(currentEvent.eventItem);
                }

                //Writing the current events narration.
                if (currentEvent.eventDeath == true)
                {
                    Console.ForegroundColor = TitleColor;
                }
                Print(currentEvent.eventNarration);

                //Presenting the current events choices.
                for (int i = 0; i < currentEvent.listOfChoices.Count; i++)
                {
                    Console.ForegroundColor = PromptColor;
                    Print($"\n{i + 1}. {currentEvent.listOfChoices[i].choiceNarration}");
                }

                //Presenting the current items in the players inventory
                if (currentEvent.eventEscape != true || !currentEvent.eventDeath != true)
                {
                    Console.ForegroundColor = miscColor;
                    Console.WriteLine();
                    Console.Write($"Current items in Inventory: ");
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.Write(string.Join(", ", inventory));
                        break;
                    }
                    Console.WriteLine($"\nCurrent alert level: {alertLvl}");
                }

                //Catchall for things that are not numbers or between 1 and 3, as well as Choice Selection
                bool inputIsGood;
                int chosenNumber;
                do
                {
                    // Get input
                    Console.ForegroundColor = PromptColor;
                    Console.WriteLine();
                    string chooseNumber = Console.ReadLine();

                    // Validate input
                    bool inputIsNumber = Int32.TryParse(chooseNumber, out chosenNumber);

                    // Provide feedback
                    if (!inputIsNumber)
                    {
                        Console.WriteLine("Please enter a number between 1 and 3.");
                        inputIsGood = false;
                    }
                    else if (chosenNumber < 0 || chosenNumber > 3)
                    {
                        Console.WriteLine("Please enter a number between 1 and 3.");
                        inputIsGood = false;
                    }
                    else
                    {
                        Console.WriteLine();

                        //Increasing the alert level by 1 if the alteration is set to 1
                        Choice selectedChoice = currentEvent.listOfChoices[chosenNumber - 1];
                        if (selectedChoice.alertAlteration != 0)
                        {
                            alertLvl++;
                        }

                        //Killing the player if their alert level is equal to the minimun level for an alert death and if an alertdeath is set to true.
                        if (alertLvl >= selectedChoice.alertDeathMinLvl && selectedChoice.alertDeath == true)
                        {
                            currentEvent = eventDictionary["AlertDeathLvl3"];
                            alertLvl = 0;
                            inventory.Clear();
                            break;
                        }

                        //Killing the player if the alertlvl reaches 4, regardless of their location
                        if (alertLvl == 4)
                        {
                            currentEvent = eventDictionary["AlertDeathLvl4"];
                            alertLvl = 0;
                            inventory.Clear();
                            break;
                        }

                        if (selectedChoice.choiceItem != (item.nothing) && !inventory.Contains(selectedChoice.choiceItem))
                        {
                            Console.WriteLine("This option is currently unavailable, please choose another option.");
                            break;
                        }

                        Console.WriteLine($"{selectedChoice.choiceName}");

                        //Checking if the player has reached a death event and adding it to the current list of deaths, as well as resetting the items to unobtained and the alert lvl to 0.
                        if (currentEvent.eventDeath == true)
                        {
                            achievedDeaths.Add(currentEvent);
                            Console.ForegroundColor = TitleColor;
                            Console.WriteLine("Achieved deaths");
                            foreach (Event deaths in achievedDeaths)
                            {
                                Console.WriteLine($"{deaths.eventName}");
                            }

                            //Resetting the variables and geneal gamestate
                            alertLvl = 0;
                            inventory.Clear();
                            Console.ReadKey();
                            Console.Clear();
                        }

                        currentEvent = selectedChoice.nextEvent;

                        //Checking if it is an end event and displaying the end the player got, the title and the deaths they achieved during their run.
                        if (currentEvent.eventEscape == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = EscapeColor;
                            Console.WriteLine(title);
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", $"{currentEvent.eventName}"));

                            //Listing player deaths
                            if (achievedDeaths.Count > 0)
                            {
                                Console.WriteLine("Achieved deaths");
                                foreach (Event deaths in achievedDeaths)
                                {
                                    Console.ForegroundColor = TitleColor;
                                    Console.WriteLine($"{deaths.eventName}");
                                }
                            }

                            //resetting game state
                            alertLvl = 0;
                            inventory.Clear();
                            achievedDeaths.Clear();
                        }

                        //Quits the game if the player chooses the option.
                        if (selectedChoice.choiceId == "Quit")
                        {
                            Environment.Exit(0);
                        }
                        //setting the next event to the current event based on what the player picked as well as presenting the name of the choice. 
                        inputIsGood = true;
                    }
                } while (!inputIsGood);
            }
            while (!GameOver);
        }
    }
}
