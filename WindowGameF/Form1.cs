using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BoardF;

namespace WindowGameF
{
    public partial class FormGame15 : Form
    {
        const int size = 4;
        Game game;

        public FormGame15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void b00_Click(object sender, EventArgs e)
        {
            //Если игра пройдена, то плашки не реагируют на клики
            //****
            if (game.Solved())
                return;
            //****
            Button button = (Button)sender; //b00
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PressAt(x, y);
            ShowButtons();
            //Поздравление с окончанием игры
            if (game.Solved())
                labelMoves.Text = "Game finished in " + game.moves + " moves";
        }

        private void labelMoves_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            game.Start(1000 + DateTime.Now.DayOfYear);
            ShowButtons();
        }

        //Скрываем кнопки
        void HideButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(0, x, y);
            labelMoves.Text = "Welcome to Game F";
        }

        //Отображаем кнопки
        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(game.GetDigitAt(x,y), x, y);
            labelMoves.Text = game.moves + " moves";
        }

        void ShowDigitAt (int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y];
            button.Text = DecToHex(digit); //digit.ToString()
            button.Visible = digit > 0;
        }

        //десятиричную систему счисление переводим в шестнадцатеричную
        //10=А, 11=В и т.д. Можно вернуть стандартную версию отображения
        string DecToHex (int digit)
        {
            if (digit == 0) return "";
            if (digit < 10) return digit.ToString();
            return ((char)('A' + digit - 10)).ToString();
        }
    }
}
