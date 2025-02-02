namespace Game
{
    public class Game
    {
        static void Main(string[] args)
        {
            InputValidatior inputValidatior = new InputValidatorImp();
            Logic guessTheCurrectNumberGame = new GuessTheCurrectNumber(inputValidatior);
            guessTheCurrectNumberGame.startGame();
        }
    }
}