namespace Game
{
    public class InputValidatorImp : InputValidatior
    {
        /// <summary>
        /// Return true if input is in range of fromNumber to toNumber, otherwise false.
        /// </summary>
        /// <param name="fromNumber"></param>
        /// <param name="toNumber"></param>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        public bool isValidInputBetweenRange(int fromNumber, int toNumber, int input)
        {
            var result = false;
            if (fromNumber <= input && input < toNumber)
            {
                result = true;
            }
            return result;
        }
    }
}