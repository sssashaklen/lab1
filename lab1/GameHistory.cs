namespace lab1
{
    public class GameHistory(string opponentName, string result, int rating, int gameIndex)
    {
        public string OpponentName { get; private set; } = opponentName;
        public string Result { get; private set; } = result;
        public int Rating { get; private set; } = rating;
        public int GameIndex { get; private set; } = gameIndex;
    }
}