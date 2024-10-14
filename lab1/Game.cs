namespace lab1
{
    public class Game
    { 
        private static int globalGameIndex = 0;
        private static int GetNextGameIndex()
        {
            return ++globalGameIndex;
        }
        public static void ImitationGame(GameAccount player1, GameAccount player2, int rating)
        {
            int result = new Random().Next(0, 2);
            
            int gameIndex = GetNextGameIndex(); 

            if (result == 0)
            {
                player1.WinGame(player2.UserName, rating, gameIndex); 
                player2.LoseGame(player1.UserName, rating, gameIndex); 
            }
            else
            {
                player2.WinGame(player1.UserName, rating, gameIndex); 
                player1.LoseGame(player2.UserName, rating, gameIndex); 
            }
        }
    }
}