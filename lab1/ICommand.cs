namespace lab1;

public interface ICommand
{
    void Execute();
}

public class AddPlayerCommand : ICommand
{
    private readonly GameAccountServices _accountServices;

    public AddPlayerCommand(GameAccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    public void Execute()
    {
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine();

        Console.WriteLine("Select account type:\n1. Premium\n2. Base");
        int accountType;
        while (!int.TryParse(Console.ReadLine(), out accountType) || (accountType < 1 || accountType > 2))
        {
            Console.WriteLine("Invalid choice, please try again.");
        }

        GameAccount newAccount;
        int nextId = GameAccount.GetNextId();
        if (accountType == 1)
        {
            newAccount = new PremiumGameAccount(username, nextId);
        }
        else
        {
            newAccount = new BaseGameAccount(username, nextId);
        }

        _accountServices.AddGameAccount(newAccount);
        Console.WriteLine($"Account for {username} created as {(accountType == 1 ? "Premium" : "Base")}.");
    }
}

public class ShowPlayersCommand : ICommand
{
    private readonly GameAccountServices _accountServices;

    public ShowPlayersCommand(GameAccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    public void Execute()
    {
        var accounts = _accountServices.ReadAll();
        if (accounts.Count == 0)
        {
            Console.WriteLine("No players found.");
            return;
        }

        Console.WriteLine("Available players:");
        foreach (var account in accounts)
        {
            Console.WriteLine($"ID: {account.Id}, Username: {account.UserName}, Rating: {account.CurrentRating}");
        }
    }
}


public class GetStatsCommand : ICommand
{
    private readonly GameAccountServices _accountServices;
    private readonly GameServices _gameServices;
    

    public GetStatsCommand(GameAccountServices accountServices, GameServices gameServices)
    {
        _accountServices = accountServices;
        _gameServices = gameServices;
    }
    
    public void Execute()
    {
        Console.WriteLine("Enter player ID or username:");
        string input = Console.ReadLine();
        GameAccount account = null;
        if (input is int)
        {
            int id = Int32.Parse(input);
            account = _accountServices.GetAccountById(id);
        }
        else if (input is string)
        {
            account = _accountServices.GetAccountByUserName(input);
        }

        if (account != null) account.GetStats(_gameServices);
    }
}

public class PlayGameCommand : ICommand
{
    private readonly GameAccountServices _accountServices;
    private readonly GameServices _gameServices;

    public PlayGameCommand(GameAccountServices accountServices, GameServices gameServices)
    {
        _accountServices = accountServices;
        _gameServices = gameServices;
    }

    public void Execute()
    {
        var accounts = _accountServices.ReadAll();
        if (accounts.Count < 2)
        {
            Console.WriteLine("At least two accounts are required to play a game.");
            return;
        }
        GameAccount player1 = Program.SelectPlayer(accounts, "Select the first player:");
        GameAccount player2 = Program.SelectPlayer(accounts, "Select the second player (must be different):");

        Console.WriteLine("Enter game type (Base or Training):");
        string gameType = Console.ReadLine();
        Console.WriteLine("Enter number of game to play:");
        int numberOfGames = int.Parse(Console.ReadLine());
        while (!int.TryParse(Console.ReadLine(), out numberOfGames) || numberOfGames <= 0)
        {
            Console.WriteLine("Invalid number. Enter a positive number.");
        }

        Game game = GameFactory.CreateGames(gameType == "Training" ? 2 : 1, player1, player2);
        _gameServices.PlayGame(_gameServices, numberOfGames, game, player1, player2); 
    }
}

public class GetStatsGamesCommand : ICommand
{
    private readonly GameServices _gameServices;

    public GetStatsGamesCommand(GameServices gameServices)
    {
        _gameServices = gameServices;
    }

    public void Execute()
    {
        var gameHistories = _gameServices.ReadAll(); 
        if (gameHistories == null || gameHistories.Count == 0)
        {
            Console.WriteLine("No game history found.");
            return;
        }

        Console.WriteLine("Game Statistics:");
        foreach (var history in gameHistories)
        {
            Console.WriteLine($"Game Index: {history.GameIndex}");
            Console.WriteLine($"Opponent: {history.OpponentName}");
            Console.WriteLine($"Result: {history.Result}");
            Console.WriteLine($"Rating: {history.Rating}");
            Console.WriteLine($"Account ID: {history.AccountId}");
            Console.WriteLine(new string('-', 40));
        }
    }
}

