namespace TicTACTOE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xamarin.Forms;

    internal class GameDriver
    {
        //A zero based field to hold the round number
        int round;

        public GameDriver() : this(0)
        {
        }

        public GameDriver(int round)
        {
            this.round = round;
        }

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

        public string IsWinner(List<Button> buttons)
        {
            string winMessage = "";
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

                //If all buttons have the same text
                if (buttonsToCheck.Select(x => x.Text).Distinct().Count() == 1)
                {
                    //Set color on winning row
                    buttonsToCheck.ForEach(x => x.BackgroundColor = Color.Green);
                    var openButtonsCount = buttons.Where(x => x.Text == "X").Count();

                    winMessage = openButtonsCount%2==0?$"Human Wins Round {round}!":$"AI Wins Round {round}!";
                    break; //out of for loop
                }
            }

            if (winMessage == "")
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
                    winMessage = $"Round {round} is a Cat game!";
                }
            }
            return winMessage;
        }

        public void HumanMoves(Button button)
        {
            button.Text = "X";
        }

        public void ComputerMoves(List<Button> buttons)
        {
            try
            {
                //Loop over the buttons that have not been taken
                var openButtons = buttons.Where(x => x.Text == "");
                foreach (Button b in openButtons)
                {
                    //For each winning combonation
                    for (int key = 0; key < 8; key++)
                    {
                        //Get combination to check
                        List<Button> buttonsToCheck = new List<Button>
                        {
                            buttons[Winners[key, 0]],
                            buttons[Winners[key, 1]],
                            buttons[Winners[key, 2]]
                        };
                        //If the button is in the combination to check
                        if (buttonsToCheck.Contains(b))
                        {
                            //And if the combonation to check has 2 Xs in it 
                            if(buttonsToCheck.Where(x => x.Text == "X").Count() == 2)
                            {
                                //Then perform the block and return
                                buttonsToCheck.Single(x => x.Text == "").Text = "O";
                                return;
                            }
                        }
                    }
                }
                //Otherwise just set a random button
                buttons.Where(x => x.Text == "").OrderBy(x => Guid.NewGuid()).First().Text = "O";
            }
            catch (Exception)
            {
                //TODO What should happen when the game ends and a null reference is thrown by AI?
            }
        }

        public void ResetGame(List<Button> buttons)
        {
            round++;
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.BackgroundColor = Color.Gray;
            }
        }
    }
}