namespace lab1;

public class BaseGame(GameAccount? player1, GameAccount? player2) : Game(player1, player2)
{
    public override void ImitationGame(GameAccount? player1, GameAccount? player2, int rating,bool isTrainingGame)
    {
        
        int result = new Random().Next(0, 2);
                    
        int gameIndex = GetNextGameIndex(); 
        
        if (result == 0)
        {
            player1?.WinGame(player2?.UserName, rating, gameIndex,isTrainingGame); 
            player2?.LoseGame(player1?.UserName, rating, gameIndex,isTrainingGame); 
        }
        else
        {
            player2?.WinGame(player1?.UserName, rating, gameIndex,isTrainingGame); 
            player1?.LoseGame(player2?.UserName, rating, gameIndex,isTrainingGame); 
        }
    }
}