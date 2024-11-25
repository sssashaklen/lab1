namespace lab1
{
    public class PremiumGameAccount(string userName,int id) : GameAccount(userName, id)
    {
        public override void WinGame(int rating)
        { 
            CurrentRating += (rating *2);
            
        }
        
        public override void LoseGame(int rating)
        {

        }
    }
}