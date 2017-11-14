using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moorhuhn
{
    public partial class Optionen : Form
    {
        private int[] Schwirikeitsgrad = new int[] { 4, 3, 2, 1 };

        public Optionen()
        {
            InitializeComponent();
            CB_Schwirikeitsgrad.SelectedIndex = 1;
        }

        
    }
}
