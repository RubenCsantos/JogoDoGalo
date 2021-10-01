using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JogoDoGalo
{
    public partial class MainWindow : Window
    {
        #region Global Variables
        // Holds the current results of cells in the current game
        private MarkType[] results;

        // True if Player1(User ;  X) plays, or false if Player2(CPU ; O)
        private bool whoPlay;

        // True if the game has ended, False if not
        private bool gameEnd = false;
        #endregion

        //Constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        //Starts a new game
        private void NewGame()
        {
            gameEnd = false;

            //Create a blank board
            results = new MarkType[9];

            for(int i=0; i<results.Length; i++)
            {
                results[i] = MarkType.Free;
            }

            //Make sure Player1 starts the game
            whoPlay = true;

            //Iterate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
        }

        //All functionalities of the click
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //if game end, start a new game
            if (gameEnd)
            {
                NewGame();
                return;
            }

            //Cast the button to a sender
            var button = (Button)sender;

            //Calculate Index of the grid
            int columnValue = Grid.GetColumn(button);
            int rowValue = Grid.GetRow(button);
            int index = columnValue + (rowValue * 3);

            //Send a message because column isn´t empty
            if(results[index] != MarkType.Free)
            {
                MessageBox.Show("This postion is already taked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Set the cell value based in who go play
            results[index] = whoPlay ? MarkType.Cross : MarkType.Circle;

            //Set X or O deppending on who plays
            button.Content = whoPlay ? "X" : "O";

            //Set the symbols colors
            button.Foreground = whoPlay ? Brushes.Blue : Brushes.Red;

            //change player
            if (whoPlay)
                whoPlay = false;
            else
                whoPlay = true;

            //Check who wins
            CheckBoxWinner();

        }

        //Check who is the winner
        private void CheckBoxWinner()
        {
            if(!results.Any(state => state == MarkType.Free))
            {
                //Game is over
                gameEnd = true;

                //Iterate every button on the grid and put the background Orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Yellow;
                });

                MessageBox.Show("Draw", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Row 1
            if(results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Row2
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Row 3
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Column 1
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Column 2
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Column 3
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Diagonal upper left to right
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Diagonal upper right to left
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
            {
                //Game Ended
                gameEnd = true;

                //Highlight the 3 in line
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.GreenYellow;

                if (whoPlay)
                    MessageBox.Show("Player 2 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Player 1 Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
