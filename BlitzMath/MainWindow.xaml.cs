using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BlitzMath
{
    public partial class MainWindow : Window
    {
        Difficulty currentDifficulty;
        Game game;
        int statsCorrect = 0;
        int statsIncorrect = 0;

        public MainWindow()
        {
            InitializeComponent();

            NormalButton.IsEnabled = false;
            NormalButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.NORMAL;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();

            Input.Focus();
        }

        private void ResetDifficultyButtons()
        {
            EasyButton.IsEnabled = true;
            NormalButton.IsEnabled = true;
            HardButton.IsEnabled = true;

            EasyButton.BorderThickness = new Thickness(0);
            NormalButton.BorderThickness = new Thickness(0);
            HardButton.BorderThickness = new Thickness(0);
        }

        private void ResetStats()
        {
            statsCorrect = 0;
            statsIncorrect = 0;
            StatsCorrect.Content = statsCorrect.ToString();
            StatsIncorrect.Content = statsIncorrect.ToString();
        }

        private void CheckInput()
        {
            if (!int.TryParse(Input.Text, out int inputNum)) return;

            // Game has been won
            if (game.CheckInput(inputNum))
            {
                Input.Background = Brushes.Green;
                NextButton.Focus();
                statsCorrect++;
                StatsCorrect.Content = statsCorrect.ToString();
            }
            // Game has been lost
            else
            {
                Input.Background = Brushes.Red;
                NextButton.Focus();
                statsIncorrect++;
                StatsIncorrect.Content = statsIncorrect.ToString();
            }
        }

        private void Button_Click_Easy(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            ResetStats();
            EasyButton.IsEnabled = false;
            EasyButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.EASY;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();
            
            Input.Focus();
        }

        private void Button_Click_Normal(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            ResetStats();
            NormalButton.IsEnabled = false;
            NormalButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.NORMAL;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();

            Input.Focus();
        }

        private void Button_Click_Hard(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            ResetStats();
            HardButton.IsEnabled = false;
            HardButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.HARD;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();

            Input.Focus();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            CheckInput();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();

            Input.Text = "";
            Input.Focus();
            Input.Background = Brushes.Transparent;
        }
    }
}
