using System;
using System.Collections.Generic;
using System.Linq;

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
            else
            {
                return;
            }
            var winMessage = game.IsWinner(buttons);
            if (winMessage != "") //TODO Test win message
            {
                ShowGameOver(winMessage);
                return;
            }
            game.ComputerMoves(buttons);
            winMessage = game.IsWinner(buttons);
            if (winMessage != "")
            {
                ShowGameOver(winMessage);
                return;
            }
        }

        private void ShowGameOver(string winMessage)
        {
            gameOverStackLayout.IsVisible = true;
            winMessageLabel.Text = winMessage;
            buttons.ForEach(x => x.IsEnabled = false);
        }

        private void PlayAgain_Clicked(object sender, EventArgs e)
        {
            buttons.ForEach(x => x.IsEnabled = true);
            game.ResetGame(buttons);
            gameOverStackLayout.IsVisible = false;
        }
    }
}