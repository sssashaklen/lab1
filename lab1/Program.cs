namespace lab1
{
    public class Program
    {
        static GameAccount? SelectPlayer(List<GameAccount?> accounts, string prompt)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i]?.UserName}");
            }

            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > accounts.Count)
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

            return accounts[index - 1];
        }

        public static void Main(string[] args)
        {
            List<GameAccount?> accounts = new List<GameAccount?>();
            bool continuePlaying = true;

            while (continuePlaying)
            {
                Console.WriteLine("Choose an option:\n1. Add a new account\n2. Start a game\n3. Exit");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Adding new account:");
                            Console.WriteLine("Enter username:");
                            string? username = Console.ReadLine();

                            Console.WriteLine("Select account type:\n1. Premium\n2. Base");
                            int accountType;
                            while (!int.TryParse(Console.ReadLine(), out accountType) || (accountType < 1 || accountType > 2))
                            {
                                Console.WriteLine("Invalid choice, please try again.");
                            }

                            GameAccount? newAccount = null;
                            if (accountType == 1)
                            {
                                if (username != null) newAccount = new PremiumGameAccount(username);
                            }
                            else
                            {
                                newAccount = new BaseGameAccount(username);
                            }

                            accounts.Add(newAccount);
                            Console.WriteLine($"Account for {username} has been created as a {(accountType == 1 ? "Premium" : "Base")} account.");
                            break;

                        case 2:
                            Console.Clear();
                            if (accounts.Count < 2)
                            {
                                Console.WriteLine("At least two accounts are required to start a game.");
                            }
                            else
                            {
                                GameAccount? account1 = SelectPlayer(accounts, "Select the first player:");
                                GameAccount? account2 = SelectPlayer(accounts, "Select the second player (must be different):");
                                Console.Clear();

                                while (account1 == account2)
                                {
                                    Console.WriteLine("Second player must be different from the first player. Try again.");
                                    account2 = SelectPlayer(accounts, "Select the second player (must be different):");
                                }

                                Console.WriteLine("Choose the type of game:\n1. Base Game\n2. Training Game");
                                int gameChoice;
                                while (!int.TryParse(Console.ReadLine(), out gameChoice) || (gameChoice < 1 || gameChoice > 2))
                                {
                                    Console.WriteLine("Invalid choice, please try again.");
                                }
                                
                                Console.WriteLine("How many games would you like to simulate?");
                                int numberOfGames;
                                while (!int.TryParse(Console.ReadLine(), out numberOfGames) || numberOfGames <= 0)
                                {
                                    Console.WriteLine("Please enter a valid positive number.");
                                } 
                                GameFactory.CreateGames(gameChoice, account1, account2, numberOfGames);
                                if (account1 != null)
                                {
                                    if (account2 != null)
                                        Console.WriteLine("\nFinal player stats after all games:");
                                    account1.GetStats();
                                }

                                account2?.GetStats();
                            }

                            break;

                        case 3:
                            Console.WriteLine("Goodbye!");
                            continuePlaying = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}
