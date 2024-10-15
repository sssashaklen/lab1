namespace lab1
{
    public abstract class Game
    { 
        protected GameAccount? Player1 { get; }
        protected GameAccount? Player2 { get; }
        protected static int GlobalGameIndex = 0;
       
        protected Game(GameAccount? player1, GameAccount? player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        protected  static int GetNextGameIndex()
        {
            return ++GlobalGameIndex;
        }
        public abstract void ImitationGame(GameAccount? player1, GameAccount? player2, int rating,bool isTrainingGame);
    }
}