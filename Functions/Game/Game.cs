namespace Game
{
    public class Game
    {
        static void Main(string[] args)
        {
            InputValidator inputValidatior = new InputValidatorImp();
            Logic guessTheCurrectNumberGame = new GuessTheCurrectNumber(inputValidatior);
            guessTheCurrectNumberGame.startGame();
        }
    }
}