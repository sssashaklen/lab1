namespace lab1
{
    public class PremiumGameAccount(string userName) : GameAccount(userName)
    {

        private const int BonusThreshold = 3;
        private const int BonusPoints = 2;

        public override void WinGame(Game game, int gameIndex, int rating)
        {
                string opponentName = game.GetOpponentName(this);
                int curRating = game.GetRating(this);
                int consecutiveWins = CalculateConsecutiveWins();
                    if (consecutiveWins >= BonusThreshold)
                    {
                        curRating += (BonusPoints + rating);
                    }
                    else
                    {
                        curRating += rating;
                    }
                CurrentRating = curRating;
                var entry = new GameHistory(opponentName, "Win", CurrentRating, gameIndex); 
                GameHistory.Add(entry); 
        }
        
        public override void LoseGame(Game game, int gameIndex,int rating)
        {
                string opponentName = game.GetOpponentName(this);
                CurrentRating = game.GetRating(this); 
                var entry = new GameHistory(opponentName, "Lose", CurrentRating, gameIndex);
                GameHistory.Add(entry);
        }
        
        private int CalculateConsecutiveWins()
        {
            var lastLoss = GameHistory.FindLast(entry => entry.Result == "Lose");
            if (lastLoss == null)
            {
                return GameHistory.Count;
            }
            int lastLossIndex = GameHistory.IndexOf(lastLoss);
            return GameHistory.Count - lastLossIndex - 1;
        }
    }
}