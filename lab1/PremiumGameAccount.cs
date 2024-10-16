namespace lab1
{
    public class PremiumGameAccount(string userName) : GameAccount(userName)
    {
        private int _consecutiveWins;
        private const int BonusThreshold = 3;
        private const int BonusPoints = 2;

        public override void WinGame(Game? game, int gameIndex, bool isTrainingGame)
        {
            if (game != null)
            {
                string opponentName = game.GetOpponentName(this);
                int rating = game.GetRating(this); 
                if (!isTrainingGame)
                {
                    _consecutiveWins++;
                    if (_consecutiveWins >= BonusThreshold)
                    {
                        rating += (BonusPoints+5); 
                    }
                    else
                    {
                        rating += 5; 
                    }
                }
                CurrentRating = rating;
                var entry = new GameHistory(opponentName, "Win", CurrentRating, gameIndex); 
                GameHistory.Add(entry); 
            }
        }
        
        public override void LoseGame(Game? game, int gameIndex, bool isTrainingGame)
        {
            if (game != null)
            {
                string opponentName = game.GetOpponentName(this);
                int rating = game.GetRating(this); 
                _consecutiveWins = 0;
                CurrentRating = rating;
                var entry = new GameHistory(opponentName, "Lose", CurrentRating, gameIndex);
                GameHistory.Add(entry);
            }
        }
    }
}