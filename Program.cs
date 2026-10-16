namespace NumberGuessing_Game
{
    internal class Program
    {
        private const int MinimumNumber = 1;
        private const int MaximumNumber = 100;

        private static void Main()
        {
            Console.Title = "Number Guessing Game";
            ShowWelcome();

            bool playAgain;
            do
            {
                PlayRound();
                playAgain = AskToPlayAgain();
                Console.WriteLine();
            }
            while (playAgain);

            Console.WriteLine("Thanks for playing. Goodbye!");
        }

        private static void ShowWelcome()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      NUMBER GUESSING GAME      ");
            Console.WriteLine("================================");
            Console.WriteLine($"Guess the secret number from {MinimumNumber} to {MaximumNumber}.");
            Console.WriteLine("I will tell you whether your guess is too high or too low.\n");
        }

        private static void PlayRound()
        {
            int maximumAttempts = ChooseDifficulty();
            int secretNumber = Random.Shared.Next(MinimumNumber, MaximumNumber + 1);
            int validAttempts = 0;
            bool hasWon = false;

            Console.WriteLine($"\nYou have {maximumAttempts} valid guesses. Good luck!\n");

            while (validAttempts < maximumAttempts)
            {
                Console.Write($"Guess {validAttempts + 1}/{maximumAttempts}: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Please enter a whole number. This does not use an attempt.\n");
                    continue;
                }

                if (guess < MinimumNumber || guess > MaximumNumber)
                {
                    Console.WriteLine($"Your number must be between {MinimumNumber} and {MaximumNumber}. This does not use an attempt.\n");
                    continue;
                }

                validAttempts++;

                if (guess == secretNumber)
                {
                    Console.WriteLine($"\nCorrect! You guessed the number in {validAttempts} valid attempt(s).\n");
                    hasWon = true;
                    break;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Too low. Try a higher number.\n");
                }
                else
                {
                    Console.WriteLine("Too high. Try a lower number.\n");
                }
            }

            if (!hasWon)
            {
                Console.WriteLine($"No attempts left. The secret number was {secretNumber}.\n");
            }
        }

        private static int ChooseDifficulty()
        {
            Console.WriteLine("Choose a difficulty:");
            Console.WriteLine("1. Easy   (10 attempts)");
            Console.WriteLine("2. Normal (7 attempts)");
            Console.WriteLine("3. Hard   (5 attempts)");

            while (true)
            {
                Console.Write("Enter 1, 2, or 3: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return 10;
                        case 2:
                            return 7;
                        case 3:
                            return 5;
                    }
                }

                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
            }
        }

        private static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.Write("Would you like to play again? (y/n): ");
                string? answer = Console.ReadLine()?.Trim();

                if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(answer, "n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(answer, "no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                Console.WriteLine("Please answer y or n.");
            }
        }
    }
}
