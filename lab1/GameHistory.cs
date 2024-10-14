namespace lab1
{
    public class GameHistory
    {
        public string OpponentName { get; private set; }
        public string Result { get; private set; }
        public int Rating { get; private set; }
        public int GameIndex { get; private set; }

        public GameHistory(string opponentName, string result, int rating, int gameIndex) 
        {
            OpponentName = opponentName;
            Result = result;
            Rating = rating;
            GameIndex = gameIndex; 
        }
    }
}