using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BlitzMath
{
    public partial class MainWindow : Window
    {
        Difficulty currentDifficulty;
        Game game;

        public MainWindow()
        {
            InitializeComponent();

            NormalButton.IsEnabled = false;
            NormalButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.NORMAL;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();
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

        private void Button_Click_Easy(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            EasyButton.IsEnabled = false;
            EasyButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.EASY;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();
        }

        private void Button_Click_Normal(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            NormalButton.IsEnabled = false;
            NormalButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.NORMAL;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();
        }

        private void Button_Click_Hard(object sender, RoutedEventArgs e)
        {
            ResetDifficultyButtons();
            HardButton.IsEnabled = false;
            HardButton.BorderThickness = new Thickness(1);

            currentDifficulty = Difficulty.HARD;
            game = new Game(currentDifficulty);
            Calculation.Content = game.GetCalculation();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            if (!int.TryParse(Input.Text, out int inputNum)) return;

            // Game has been won
            if (game.CheckInput(inputNum))
            {
                Input.Background = Brushes.Green;
                NextButton.Focus();
            }
            // Game has been lost
            else
            {
                Input.Background = Brushes.Red;
                NextButton.Focus();
            }
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
