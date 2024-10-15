namespace lab1
{
    public class GameFactory
    {
        public static Game CreateGame(int gameType, GameAccount? player1, GameAccount? player2)
        {
            switch (gameType)
            {
                case 1:
                    return new BaseGame(player1, player2);
                case 2:
                    return new TrainingGame(player1, player2);
                default:
                    throw new ArgumentException("Invalid game type.");
            }
        }
    }
}
