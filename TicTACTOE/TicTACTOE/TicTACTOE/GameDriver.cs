namespace TicTACTOE
{
    using Xamarin.Forms;

    internal class GameDriver
    {
        private PlayerType player = PlayerType.Human;

        private readonly int[,] Winners = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

        public bool CheckWinner(Button[] buttons)
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++)
            {
                Button b1 = buttons[Winners[i, 0]];
                Button b2 = buttons[Winners[i, 1]];
                Button b3 = buttons[Winners[i, 2]];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                {
                    continue;
                }                    

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackgroundColor = b2.BackgroundColor = b3.BackgroundColor = Color.Aqua;
                    gameOver = true;
                    break;
                }
            }

            bool isTie = true;
            if (!gameOver)
            {
                foreach (Button b in buttons)
                {
                    if (b.Text == "")
                    {
                        isTie = false;
                        break;
                    }
                }
                if (isTie)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }

        public void SetButton(Button b)
        {
            if (b.Text == "")
            {
                b.Text = player == PlayerType.Human ? "X" : "O";
                player = player == PlayerType.Human ? PlayerType.AI : PlayerType.Human;
            }
        }
        public void ResetGame(Button[] buttons)
        {
            player = PlayerType.Human;
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.BackgroundColor = Color.Gray;
            }
        }
    }
}