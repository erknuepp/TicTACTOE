namespace TicTACTOE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public bool IsWinner(List<Button> buttons)
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++)
            {
                List<Button> buttonsToCheck = new List<Button>
                {
                    buttons[Winners[i, 0]],
                    buttons[Winners[i, 1]],
                    buttons[Winners[i, 2]]
                };

                if (buttonsToCheck.Any(x => x.Text == ""))
                {
                    continue;
                }                    

                if (buttonsToCheck.Select(x => x.Text).Distinct().Count() == 1)
                {
                    buttonsToCheck.ForEach(x => x.BackgroundColor = Color.AliceBlue);
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
            //Get rid of playertype all together and change this logic
            b.Text = "X";
            player = player == PlayerType.Human ? PlayerType.AI : PlayerType.Human;

            //TODO remove button from list? Make two lists? all_buttons, available_buttons
        }

        public void ComputerMoves(List<Button> buttons)
        {
            buttons.Where(x => x.Text == "").OrderBy(x => Guid.NewGuid()).FirstOrDefault().Text = "O";
        }

        public void ResetGame(List<Button> buttons)
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