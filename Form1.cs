namespace Morpion
{
   public partial class Form1 : Form
{
        CellState[,] board = new CellState[3, 3];
        private List<Move> moveHistory;
        private Player player1;
        private Player player2;
        private Player currentPlayer;
        private int player1Wins;
        private int player2Wins;

        public Form1()
    {
        InitializeComponent();
            moveHistory = new List<Move>();
            // D�finir les joueurs
            player1 = new Player("Player 1", CellState.X);
            player2 = new Player("Player 2", CellState.O);
            currentPlayer = player1;
            InitializeBoard();

        }

        void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Location = new Point(col * 50, row * 50);
                button.Click += ButtonClick;
                Controls.Add(button);
            }
        }
    }

    void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int row = button.Location.Y / 50;
        int col = button.Location.X / 50;
        if (board[row, col] == CellState.Empty)
        {
            board[row, col] = currentPlayer.Symbol;
            button.Text = currentPlayer.Symbol.ToString();
            moveHistory.Add(new Move(currentPlayer, row, col));
            if (HasWon(currentPlayer))
            {
                MessageBox.Show(currentPlayer.Name + " wins!");
                    // Afficher l'historique des victoires
                    ShowWinsHistory();
                    ResetBoard();
            }
            else if (IsBoardFull())
            {
                MessageBox.Show("Draw!");
                    // Afficher l'historique des victoires
                    ShowWinsHistory();
                    ResetBoard();
            }
            else
            {
                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
        }
    }

        private bool HasWon(Player player)
        {
            bool hasWon = false;

            // V�rifier les lignes
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player.Symbol &&
                    board[row, 1] == player.Symbol &&
                    board[row, 2] == player.Symbol)
                {
                    hasWon = true;
                    break;
                }
            }

            // V�rifier les colonnes
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player.Symbol &&
                    board[1, col] == player.Symbol &&
                    board[2, col] == player.Symbol)
                {
                    hasWon = true;
                    break;
                }
            }

            // V�rifier la diagonale principale
            if (board[0, 0] == player.Symbol &&
                board[1, 1] == player.Symbol &&
                board[2, 2] == player.Symbol)
            {
                hasWon = true;
            }

            // V�rifier la diagonale secondaire
            if (board[0, 2] == player.Symbol &&
                board[1, 1] == player.Symbol &&
                board[2, 0] == player.Symbol)
            {
                hasWon = true;
            }

            if (hasWon)
            {
                if (player == player1)
                {
                    player1Wins++;
                }
                else
                {
                    player2Wins++;
                }
            }

            return hasWon;
        }
        bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == CellState.Empty)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void ResetBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = CellState.Empty;
                Controls[row * 3 + col].Text = "";
            }
        }
        moveHistory.Clear();
    }
    
        private void ShowWinsHistory()
        {
            string message = "Player 1 wins: " + player1Wins + "\n"
                           + "Player 2 wins: " + player2Wins;

            MessageBox.Show(message, "Wins History");
        }
    }

}
