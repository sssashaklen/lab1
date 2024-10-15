namespace lab1;

public class BaseGameAccount : GameAccount
{

    public BaseGameAccount(string? userName) : base(userName){ }
    public override void WinGame(string? opponentName, int rating, int gameIndex)
    {
        var entry = new GameHistory(opponentName, "Win", rating, gameIndex);
        CurrentRating += rating;
        gameHistory.Add(entry);
    }

    public override void LoseGame(string? opponentName, int rating, int gameIndex)
    {
        var entry = new GameHistory(opponentName, "Lose", rating, gameIndex);
        CurrentRating -= rating;
        gameHistory.Add(entry);
    }
}

