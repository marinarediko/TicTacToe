using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        bool xPlayerTurn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
            labelTurn.Text = "X Player Turn";
        }
        private void InitializeGrid()
        {
            Grid.BackColor = Color.LavenderBlush;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
            InitializeGrid();
            // xPlayerTurn = true;
            // if (xPlayerTurn)
            //     labelTurn.Text = "X Player Turn";
            // else
            //     labelTurn.Text = "O Player Turn"; 

        }


        private void InitializeCells()
        {
            string cellName;
            for (int i = 1; i < 10; i++)
            {
                cellName = "label" + i;
                Grid.Controls[cellName].Text = string.Empty;
                Grid.Controls[cellName].BackColor = Color.LavenderBlush;
            }
        }


        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "X" && label.Text != "O")
            {
                if (xPlayerTurn)
                {
                    label.Text = "X";
                    labelTurn.Text = "O Player Turn";
                }
                else
                {
                    label.Text = "O";
                    labelTurn.Text = "X Player Turn";
                }
                turnCount++;
                Check_The_Winner();
                Check_For_Draw();
                xPlayerTurn = !xPlayerTurn;
            }

        }

        private void Check_The_Winner()
        {
            if ((label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "") ||
                (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "") ||
                (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "") ||
                (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "") ||
                (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "") ||
                (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "") ||
                (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "") ||
                (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != ""))
            {
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
                {
                    label1.BackColor = label2.BackColor = label3.BackColor = Color.DeepPink;
                }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                label4.BackColor = label5.BackColor = label6.BackColor = Color.DeepPink;
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                label7.BackColor = label8.BackColor = label9.BackColor = Color.DeepPink;
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                label1.BackColor = label4.BackColor = label7.BackColor = Color.DeepPink;
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                label2.BackColor = label5.BackColor = label8.BackColor = Color.DeepPink;
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                label3.BackColor = label6.BackColor = label9.BackColor = Color.DeepPink;
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                label1.BackColor = label5.BackColor = label9.BackColor = Color.DeepPink;
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                label3.BackColor = label5.BackColor = label7.BackColor = Color.DeepPink;
            }

        }

        private void Check_For_Draw()
        {
            if (turnCount == 9)
            {
                MessageBox.Show("No Winner. DRAW");
                RestartGame();
            }
        }


        private void GameOver()
        {
            string winner;
            if (xPlayerTurn)
                winner = "X";
            else
                winner = "O";
            WinnerCellsChangeColor();
            MessageBox.Show("Congrats, " + winner);
            RestartGame();
        }

    }
}
