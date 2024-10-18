namespace lab1
{
    public static class GameFactory
    {
        public static void CreateGames(int gameType, GameAccount player1, GameAccount player2, int numberOfGames)
        {
            string player1Name = player1.UserName;
            string player2Name = player2.UserName;

            Console.WriteLine("\nStarting games ...");
            for (int i = 0; i < numberOfGames; i++)
            {
                Game game = gameType switch
                {
                    1 => new BaseGame(player1Name, player2Name),
                    2 => new TrainingGame(player1Name, player2Name),
                    _ => throw new ArgumentException("Invalid game type.")
                };
                int gameIndex = game.GetNextGameIndex();
                game.ImitationGame(player1, player2, game, gameIndex);

            }
        }
    }
}