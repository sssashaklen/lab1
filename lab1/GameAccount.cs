namespace lab1
{
    public class GameAccount
    {
        private int _currentrating = 1;
        public string UserName { get; private set; }
        
        public int CurrentRating
        {
            get { return _currentrating; }
            set
            {
                if (value <= 0)
                {
                    _currentrating = 1;
                }
                else
                {
                    _currentrating = value;
                }
            }
        }
        public GameAccount(string userName)
        {
            UserName = userName;

        }
        public int GameCount => gameHistory.Count;

        private List<GameHistory> gameHistory = new List<GameHistory>();

        public void WinGame(string opponentName, int rating, int gameIndex) 
        {
            CurrentRating += rating;
            gameHistory.Add(new GameHistory(opponentName, "Win", rating, gameIndex)); 
        }

        public void LoseGame(string opponentName, int rating, int gameIndex) 
        {
            CurrentRating -= rating;
            gameHistory.Add(new GameHistory(opponentName, "Lose", rating, gameIndex)); 
        }

      

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
    }
}
