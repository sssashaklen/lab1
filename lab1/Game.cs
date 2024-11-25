namespace lab1
{
    public abstract class Game(string player1Name, string player2Name)
    {
        private static int _globalGameIndex;

        public static int GetNextGameIndex()
        {
            return ++_globalGameIndex;
        }

        protected internal abstract int ImitationGame(GameAccount player1, GameAccount player2);
        
    }
}