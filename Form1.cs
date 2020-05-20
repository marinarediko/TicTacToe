﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }
        private void InitializeGrid()
        {
            Grid.BackColor = Color.LavenderBlush;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Text = "X";
        }
    }
}
