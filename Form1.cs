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
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
            xPlayerTurn = false;
            InitializeGrid();
            
             if (!xPlayerTurn)
                 labelTurn.Text = "X Player Turn";
             else
                 labelTurn.Text = "O Player Turn"; 

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

       
        private void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
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
                    PlaySound("ClickSound");
                }
                else
                {
                    label.Text = "O";
                    labelTurn.Text = "X Player Turn";
                    PlaySound("ClickSound2");
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
                ChangeCellsColors(label1, label2, label3, Color.DeepPink);
            }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                ChangeCellsColors(label4, label5, label6, Color.DeepPink);
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                ChangeCellsColors(label7, label8, label9, Color.DeepPink);
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                ChangeCellsColors(label1, label4, label7, Color.DeepPink);
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                ChangeCellsColors(label2, label5, label8, Color.DeepPink);
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                ChangeCellsColors(label3, label6, label9, Color.DeepPink);
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                ChangeCellsColors(label1, label5, label9, Color.DeepPink);
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                ChangeCellsColors(label3, label5, label7, Color.DeepPink);
            }

        }

        private void ChangeCellsColors(Label labelOne, Label labelTwo, Label labelThree, Color color)
        {
            labelOne.BackColor = color;
            labelTwo.BackColor = color;
            labelThree.BackColor = color;
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
            PlaySound("WinnerSound");
            MessageBox.Show("Congrats, " + winner);
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
            RestartGame();
        }

    }
}
