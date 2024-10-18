namespace lab1
{
    public abstract class Game(string player1Name, string player2Name)
    {
        private static int _globalGameIndex;

        public int GetNextGameIndex()
        {
            return ++_globalGameIndex;
        }

        protected internal abstract void ImitationGame(GameAccount player1, GameAccount player2,Game game,int gameIndex);
        public int GetRating(GameAccount player)
        {
            return player.CurrentRating;
        }
        public string GetOpponentName(GameAccount player)
        {
            return player.UserName == player1Name ? player2Name : player1Name;
        }

    }
}