namespace lab1
{
    public class BaseGameAccount(string userName) : GameAccount(userName)
    {
        public override void WinGame(Game game, int gameIndex, int rating)
        {
                string opponentName = game.GetOpponentName(this);
                int curRating = game.GetRating(this);
                curRating += rating;
                CurrentRating = curRating;
                var entry = new GameHistory(opponentName, "Win", CurrentRating, gameIndex);
                GameHistory.Add(entry);
        }

        public override void LoseGame(Game game, int gameIndex,int rating)
        {
                string opponentName = game.GetOpponentName(this);
                int curRating = game.GetRating(this); 
                curRating-=5; 
                CurrentRating = curRating;
                var entry = new GameHistory(opponentName, "Lose", CurrentRating, gameIndex);
                GameHistory.Add(entry);
        }
    }
}