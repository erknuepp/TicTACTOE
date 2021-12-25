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
            gameOverStackLayout.IsVisible = true;
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
                game.HumanMoves(b);
            }
            if (game.IsWinner(buttons))
            {
                gameOverStackLayout.IsVisible = true;
            }

            game.ComputerMoves(buttons);
            if (game.IsWinner(buttons))
            {
                gameOverStackLayout.IsVisible = true;
            }
            
        }

        private void PlayAgain_Clicked(object sender, EventArgs e)
        {
            game.ResetGame(buttons);
            gameOverStackLayout.IsVisible = false;
        }
    }
}