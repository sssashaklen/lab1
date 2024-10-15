namespace lab1
{
    public class PremiumGameAccount(string userName) : GameAccount(userName)
    {
        private int _consecutiveWins; 
        private const int BonusThreshold = 3; 
        private const int BonusPoints = 2;

        public override void WinGame(string? opponentName, int rating, int gameIndex)
        {
            if (Game.IsTrainingGame()) 
            {
                rating = 1; 
            }
            else
            {
                _consecutiveWins++;
                if (_consecutiveWins >= BonusThreshold)
                {
                    rating += BonusPoints; 
                }
            }
            
            var entry = new GameHistory(opponentName, "Win", rating, gameIndex);
            CurrentRating += rating; 
            gameHistory.Add(entry); 
        }

        public override void LoseGame(string? opponentName, int rating, int gameIndex)
        {
            _consecutiveWins = 0; 
            var entry = new GameHistory(opponentName, "Lose", rating, gameIndex);
            gameHistory.Add(entry); 
        }
    }
}