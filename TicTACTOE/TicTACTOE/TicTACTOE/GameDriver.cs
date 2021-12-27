namespace TicTACTOE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xamarin.Forms;

    internal class GameDriver
    {
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
            for (int key = 0; key < 8; key++)
            {
                List<Button> buttonsToCheck = new List<Button>
                {
                    buttons[Winners[key, 0]],
                    buttons[Winners[key, 1]],
                    buttons[Winners[key, 2]]
                };

                if (buttonsToCheck.Any(x => x.Text == ""))
                {
                    continue; //to next loop interation
                }

                //
                if (buttonsToCheck.Select(x => x.Text).Distinct().Count() == 1)
                {
                    buttonsToCheck.ForEach(x => x.BackgroundColor = Color.AliceBlue);
                    gameOver = true;
                    break; //out of for loop
                }
            }

            if (!gameOver)
            {
                bool isTie = true;
                foreach (Button b in buttons)
                {
                    if (b.Text == "")
                    {
                        isTie = false;
                        break; //out of foreach loop
                    }
                }
                if (isTie)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }

        public void HumanMoves(Button b)
        {
            b.Text = "X";
        }

        public void ComputerMoves(List<Button> buttons)
        {
            /*
            TODO AI
            Look at all available buttons
            Look at all available blocks
            choose best block
            */
            try
            {
                var openButtons = buttons.Where(x => x.Text == ""); //.OrderBy(x => Guid.NewGuid()).First().Text = "O";
                foreach (Button b in openButtons)
                {
                    //if the row, column of possible diagonal contains 2 X's, then perform a block
                    //get the 2 or 3 Winners items and check if any have 2 X's
                    for (int key = 0; key < 8; key++)
                    {
                        List<Button> buttonsToCheck = new List<Button>
                        {
                            buttons[Winners[key, 0]],
                            buttons[Winners[key, 1]],
                            buttons[Winners[key, 2]]
                        };
                        if (buttonsToCheck.Contains(b))
                        {
                            if(buttonsToCheck.Where(x => x.Text == "X").Count() == 2)
                            {
                                buttonsToCheck.Single(x => x.Text == "").Text = "O";
                                return;
                            }
                        }
                    }
                }
                buttons.Where(x => x.Text == "").OrderBy(x => Guid.NewGuid()).First().Text = "O";
            }
            catch (Exception e)
            {
                //TODO what to do?

            }
        }

        public void ResetGame(List<Button> buttons)
        {
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.BackgroundColor = Color.Gray;
            }
        }
    }
}