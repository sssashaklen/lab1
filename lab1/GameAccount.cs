namespace lab1
{
    public abstract class GameAccount
    {
        private int _currentRating = 1;
        public string? UserName { get; protected set; }

        public int CurrentRating
        {
            get { return _currentRating; }
            set
            {
                if (value <= 0)
                {
                    _currentRating = 1;
                }
                else
                {
                    _currentRating = value;
                }
            }
        }

        protected GameAccount(string? userName)
        {
            UserName = userName;
        }

        public int GameCount => gameHistory.Count;

        public List<GameHistory> gameHistory = new List<GameHistory>();
        
        protected int consecutiveWins = 0; 
        protected const int bonusPointsPerWin = 5; 

        public abstract void WinGame(string? opponentName, int rating, int gameIndex);
        
        public abstract void LoseGame(string? opponentName, int rating, int gameIndex);

        public void GetStats()
        {
            Console.WriteLine($"\nStats for {UserName}:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Game Index | Opponent      | Result | Rating  |");
            Console.WriteLine("-------------------------------------------------");
            foreach (var entry in gameHistory)
            {
                Console.WriteLine($"| {entry.GameIndex,-11} | {entry.OpponentName,-12} | {entry.Result,-6} | {entry.Rating,-7} |");
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Current Rating: {CurrentRating}, Total Games Played: {GameCount}");
        }
        
        protected void ResetConsecutiveWins() 
        {
            consecutiveWins = 0; 
        }
    }
}
