﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveToSurvive
{
    public partial class TrackSelectScreen : UserControl
    {
        public TrackSelectScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
