namespace lab1
{
    public static class GameFactory
    {
        public static void CreateGames(int gameType, GameAccount? player1, GameAccount? player2, int numberOfGames)
        {
            if (player1 == null || player2 == null)
            {
                throw new ArgumentNullException("Players cannot be null");
            }
            
            string player1Name = player1.UserName ?? "Unknown Player 1";
            string player2Name = player2.UserName ?? "Unknown Player 2";

            Console.WriteLine("\nStarting games ...");
            for (int i = 0; i < numberOfGames; i++)
            {
                Game game = gameType switch
                {
                    1 => new BaseGame(player1Name, player2Name),
                    2 => new TrainingGame(player1Name, player2Name),
                    _ => throw new ArgumentException("Invalid game type.")
                };
                
                if (game is BaseGame or TrainingGame)
                {
                    
                    int gameIndex = game.GetNextGameIndex();
                    game.ImitationGame(player1, player2, game, gameIndex);
                }
                else
                {
                    throw new InvalidOperationException("Game type not supported for imitation.");
                }
            }
        }
    }
}