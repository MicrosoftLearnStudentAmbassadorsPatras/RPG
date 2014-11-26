using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Program
    {
        static Player player;

        static Map map;

        static int selection;
        static bool running = true;
        
        static void Main(string[] args)
        {
            Initialize();
            getPlayerInfo();
            mainGameLoop();
        }

        static void Initialize()
        {
            player = new Player();
            selection = -1;
            running = true;
            map = new Map();
        }

        static void mainGameLoop()
        {
            while (running)
            {
                mainMenu();
            }
        }

        static void mainMenu()
        {
            printInfo();
            Console.Out.WriteLine("What is thy bidding, "+player.name+"?");
            Console.Out.WriteLine("0: Exit");
            Console.Out.WriteLine("1: Travel forward");
            Console.Out.WriteLine("2: Travel backward");
            Console.Out.WriteLine("3: Heal wounds");
            Console.Out.WriteLine("4: Level up! (500 coin)");

            getInput:
            try
            {
                selection = int.Parse(Console.In.ReadLine());
            }
            catch (FormatException)
            {
                goto getInput;
            }

            switch (selection)
            {
                case 0:
                {
                    running = false;
                    break;
                }
                case 1:
                {
                    map.moveForward();
                    break;
                }
                case 2:
                {
                    map.moveBackward();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("How much health do you wish to restore?");
                    int h = Console.Read();
                    if (h < map.getPop()) { h = map.getPop(); }
                    player.heal(h);
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Upgrade Health(1) or Damage(2)?");
                    updgrade();
                    break;
                }
            }

            if (map.getBandits() > 0)
            {
                Battle();
            }

            Console.WriteLine("Hit any key to continue...");
            Console.Read();
            Console.Clear();
        }

        static void updgrade()
        {
            if (player.money < 300)
            {
                Console.WriteLine("insuficient money");
                return;
            }
            int x = 0;
            x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                player.upgradeH();
                player.money -= 300;
            }
            else if (x == 2)
            {
                player.upgradeD();
                player.money -= 300;
            }
        }

        static void printInfo()
        {
            Console.WriteLine("Health: " + player.getHealth().ToString());
            Console.WriteLine("Location: " + map.getLocation().ToString());
            Console.WriteLine("Money: " + player.money);
            Console.WriteLine("Population:" + map.getPop());
            Console.WriteLine("Bandits encountered in area:" + map.getBandits());
        }


        static void getPlayerInfo()
        {
            Console.Out.WriteLine("What is thy name, brave warrior?");
            player.name = Console.In.ReadLine();
            Console.Out.WriteLine("Locations are conected in a circle. In each location you can heal as much of your damage as is the population for 50 coin.");
        }

        static void Battle()
        {
            List<Bandit> bandits = new List<Bandit>();
            for (int i = 0; i < map.getBandits(); i++)
            {
                bandits.Add(new Bandit());
            }

            Console.WriteLine("You were suprised by bandits!");

            while (player.getHealth() > 0 && bandits.Count > 0)
            {
                foreach (Bandit b in bandits)
                {
                    player.heal(-b.attack());
                }
                bandits.First().takeDamage(player.attack());
                if (bandits.First().getHealth() <= 0)
                {
                    bandits.Remove(bandits.First());
                }
            }
            if (player.getHealth() <= 0)
            {
                Console.WriteLine("You did not survive the fight, try again? (Y/N)");
                string input;
                read:
                input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                    {
                        Initialize();
                        break;
                    }
                    case "N":
                    {
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    default:
                    {
                        goto read;
                        break;
                    }
                }
            }
        }
    }
}
