﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            _3x3 smallField = new _3x3();
            smallField.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            game5x5 bigField = new game5x5();
            bigField.Show();
        }
    }
}
