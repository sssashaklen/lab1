namespace lab1
{
    public abstract class Game
    {
        private static int _globalGameIndex;
        private readonly string _player1Name;
        private readonly string _player2Name;
        protected Game(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }
        public int GetNextGameIndex()
        {
            return ++_globalGameIndex;
        }

        protected internal abstract void ImitationGame(GameAccount? player1, GameAccount? player2,Game? game,int gameIndex);
        public int GetRating(GameAccount player)
        {
            return player.CurrentRating;
        }
        public string GetOpponentName(GameAccount player)
        {
            return player.UserName == _player1Name ? _player2Name : _player1Name;
        }

    }
}