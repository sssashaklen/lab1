namespace lab1
{
    public class BaseGame(string player1Name, string player2Name) : Game(player1Name, player2Name)

    {
        protected internal override void ImitationGame(GameAccount? player1, GameAccount? player2, Game? game, int gameIndex)
        {
            bool isTrainingGame = false;
            int result = new Random().Next(0, 2); 
            
            if (result == 0)
            {
                player1?.WinGame(game,gameIndex,isTrainingGame);
                player2?.LoseGame(game,gameIndex,isTrainingGame);
            }
            else
            {

                player2?.WinGame(game,gameIndex,isTrainingGame);
                player1?.LoseGame(game,gameIndex,isTrainingGame);
            }
        }
    }
}