namespace Game
{
    public class GuessTheCurrectNumber : Logic
    {
        public InputValidatior inputValidatior;
        public int target;

        public GuessTheCurrectNumber(InputValidatior inputValidatior)
        {
            this.inputValidatior = inputValidatior;
        }

        public void startGame()
        {
            Logic();
        }
        public void Logic()
        {
            this.target = new Random().Next(ApplicationConstants.One, ApplicationConstants.OneHunderdOne);
            var isGuessedNumberCorrect = false;
            Console.Write("Guess a number between 1 and 100: ");
            int.TryParse(Console.ReadLine(), out int gussedNumber);
            var guessCount = 0;
            while (!isGuessedNumberCorrect)
            {
                if (!inputValidatior.isValidInputBetweenRange(ApplicationConstants.One, ApplicationConstants.OneHunderdOne, gussedNumber))
                {
                    Console.Write("I wont count this one Please enter a number between 1 to 100 : ");
                    gussedNumber = int.Parse(Console.ReadLine());
                    continue;
                }
                else
                {
                    guessCount++;
                }
                if (gussedNumber < this.target)
                {
                    Console.Write("Too low. Guess again: ");
                    gussedNumber = int.Parse(Console.ReadLine());
                }
                else if (gussedNumber > this.target)
                {
                    Console.Write("Too High. Guess again: ");
                    gussedNumber = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("You guessed it in " + guessCount + " guesses!");
                    isGuessedNumberCorrect = true;
                }
            }
        }
    }
}