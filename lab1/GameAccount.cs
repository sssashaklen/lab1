namespace lab1
{
    public abstract class GameAccount(string userName)
    {
        private int _currentRating = 1;
        public string UserName { get; protected set; } = userName;

        public int CurrentRating
        {
            get => _currentRating;
            protected set => _currentRating = Math.Max(value, 1);
        }
        private int GameCount => GameHistory.Count;
        protected readonly List<GameHistory> GameHistory = new();
        
        
        public abstract void WinGame(Game game, int gameIndex,int rating);
        public abstract void LoseGame(Game game, int gameIndex,int rating);
        
        public void GetStats()
        {
            Console.WriteLine($"\nStats for {UserName}:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Game Index | Opponent      | Result | Rating  |");
            Console.WriteLine("-------------------------------------------------");
            foreach (var entry in GameHistory)
            {
                Console.WriteLine($"| {entry.GameIndex,-11} | {entry.OpponentName,-12} | {entry.Result,-6} | {entry.Rating,-7} |");
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Current Rating: {CurrentRating}, Total Games Played: {GameCount}");
        }

    }
}
