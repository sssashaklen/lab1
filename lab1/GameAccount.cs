namespace lab1
{
    public abstract class GameAccount(string? userName)
    {
        private int _currentRating = 1;
        public string? UserName { get; protected set; } = userName;

        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value <= 0 ? 1 : value;
        }

        private int GameCount => GameHistory.Count;
        protected readonly List<GameHistory> GameHistory = new List<GameHistory>();
        
        
        public abstract void WinGame(Game? game, int gameIndex, bool isTrainingGame);
        public abstract void LoseGame(Game? game, int gameIndex,bool isTrainingGame);
        
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
