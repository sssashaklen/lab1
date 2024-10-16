namespace lab1
{
    public class BaseGameAccount(string? userName) : GameAccount(userName)
    {
        public override void WinGame(Game? game, int gameIndex, bool isTrainingGame)
        {
            if (game != null)
            {
                string opponentName = game.GetOpponentName(this);
                int rating = game.GetRating(this);
                if (!isTrainingGame)
                {
                    rating+=5;
                }
                CurrentRating = rating;
                var entry = new GameHistory(opponentName, "Win", CurrentRating, gameIndex);
                GameHistory.Add(entry);
            }
        }

        public override void LoseGame( Game? game, int gameIndex, bool isTrainingGame)
        {
            if (game != null)
            {
                string opponentName = game.GetOpponentName(this);
                int rating = game.GetRating(this); 
                if (!isTrainingGame)
                {
                    rating-=5; 
                }
                CurrentRating = rating;
                var entry = new GameHistory(opponentName, "Lose", CurrentRating, gameIndex);
                GameHistory.Add(entry);
            }
        }
    }
}