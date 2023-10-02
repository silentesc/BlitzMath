using System;

namespace BlitzMath
{
    internal class Game
    {
        private readonly char[] symbols = new char[] { '+', '-', '*' };

        private string calculation;
        private int result;

        public Game(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.BASIC: GenerateBasicCalculation(); break;
                case Difficulty.EASY: GenerateEasyCalculation(); break;
                case Difficulty.NORMAL: GenerateNormalCalculation(); break;
                case Difficulty.HARD: GenerateHardCalculation(); break;
            }
        }

        /*
         * Check if input equals result
         * Returns:
         *  true if correct
         *  false if incorrect
         */
        public bool CheckInput(int input)
        {
            return input == result;
        }

        /*
         * Basic calculation
         * Examples:
         * 5 + 7
         * 8 - 9
         * 5 * 3
         */
        private void GenerateBasicCalculation()
        {
            // random.Next(1, 10) generates number between 1 - 9
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int symbol;

            symbol = random.Next(0, 3);
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);

            // Generate calculation string
            calculation = string.Format("{0}{1}{2}", firstNumber, symbols[symbol], secondNumber);

            // Calculate result
            switch (symbol)
            {
                case 0: result = firstNumber + secondNumber; break;
                case 1: result = firstNumber - secondNumber; break;
                case 2: result = firstNumber * secondNumber; break;
            }
        }

        /*
         * Easy calculation
         * Examples:
         * 12 + 83
         * 15 - 7
         * 8 * 4
         */
        private void GenerateEasyCalculation()
        {
            // random.Next(1, 10) generates number between 1 - 9
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int symbol;

            symbol = random.Next(0, 3);
            // Multiplication only with 1 digit numbers
            if (symbol == 2)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
            }
            else
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 100);
            }

            // Generate calculation string
            calculation = string.Format("{0}{1}{2}", firstNumber, symbols[symbol], secondNumber);

            // Calculate result
            switch (symbol)
            {
                case 0: result = firstNumber + secondNumber; break;
                case 1: result = firstNumber - secondNumber; break;
                case 2: result = firstNumber * secondNumber; break;
            }
        }

        /*
         * Normal calculation
         * Examples:
         * 132 + 318
         * 713 - 359
         * 12 * 8
         */
        private void GenerateNormalCalculation()
        {
            // random.Next(1, 10) would generate number between 1 - 9
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int symbol;

            symbol = random.Next(0, 3);
            // Multiplication only with 2 digits
            if (symbol == 2)
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 10);
            }
            else
            {
                firstNumber = random.Next(1, 1000);
                secondNumber = random.Next(1, 1000);
            }

            // Generate calculation string
            calculation = string.Format("{0}{1}{2}", firstNumber, symbols[symbol], secondNumber);

            // Calculate result
            switch (symbol)
            {
                case 0: result = firstNumber + secondNumber; break;
                case 1: result = firstNumber - secondNumber; break;
                case 2: result = firstNumber * secondNumber; break;
            }
        }

        /*
         * Hard calculation
         * Examples:
         * 7 * 15 + 29
         * 7 * 15 - 29
         */
        private void GenerateHardCalculation()
        {
            // random.Next(1, 10) would generate number between 1 - 9
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            int firstSymbol = 2;
            int secondSymbol;

            secondSymbol = random.Next(0, 2);
            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 20);
            thirdNumber = random.Next(1, 100);

            // Generate calculation string
            calculation = string.Format("{0}{1}{2}{3}{4}", firstNumber, symbols[firstSymbol], secondNumber, symbols[secondSymbol], thirdNumber);

            // Calculate result
            if (firstSymbol == 0)
            {
                switch (secondSymbol)
                {
                    case 0: result = firstNumber + secondNumber + thirdNumber; break;
                    case 1: result = firstNumber + secondNumber - thirdNumber; break;
                    case 2: result = firstNumber + secondNumber * thirdNumber; break;
                }
            }
            else if (firstSymbol == 1)
            {
                switch (secondSymbol)
                {
                    case 0: result = firstNumber - secondNumber + thirdNumber; break;
                    case 1: result = firstNumber - secondNumber - thirdNumber; break;
                    case 2: result = firstNumber - secondNumber * thirdNumber; break;
                }
            }
            else if (firstSymbol == 2)
            {
                switch (secondSymbol)
                {
                    case 0: result = firstNumber * secondNumber + thirdNumber; break;
                    case 1: result = firstNumber * secondNumber - thirdNumber; break;
                    case 2: result = firstNumber * secondNumber * thirdNumber; break;
                }
            }
        }

        public string GetCalculation()
        {
            return calculation;
        }
    }
}
