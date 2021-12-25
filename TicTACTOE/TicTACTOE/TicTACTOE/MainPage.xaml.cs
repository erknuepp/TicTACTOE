using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TicTACTOE
{
    public partial class MainPage : ContentPage
    {
        private List<Button> buttons = new List<Button>();
        private GameDriver game = new GameDriver();
        public MainPage()
        {
            InitializeComponent();

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "")
            {
                game.SetButton(b);
            }
            if (game.IsWinner(buttons))
            {
                gameOverStackLayout.IsVisible = true;
            }
            else
            {
                game.ComputerMoves(buttons);
            }
        }

        private void PlayAgain_Clicked(Object sender, EventArgs e)
        {
            game.ResetGame(buttons);
            gameOverStackLayout.IsVisible = false;
        }
    }
}