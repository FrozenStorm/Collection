using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Schuss_1> mylist1 = new List<Schuss_1>();
        List<Schuss_2> mylist2 = new List<Schuss_2>();
        public Form1()
        {
            InitializeComponent();
        }

        private void B_New_1_Click(object sender, EventArgs e)
        {
            mylist1.Add(new Schuss_1(Hintergrund_1.Size.Height, Hintergrund_1.Size.Width, this.Location.X, this.Location.Y, 0, 0, (int)n_winkel_1.Value, (int)n_geschwindikeit_1.Value, mylist1));
            this.Hintergrund_1.Controls.Add(mylist1.Last<Schuss_1>());
        }

        private void B_New_2_Click(object sender, EventArgs e)
        {
            mylist2.Add(new Schuss_2(Hintergrund_2.Size.Height, Hintergrund_2.Size.Width, (Hintergrund_2.Size.Width / 2), (Hintergrund_2.Size.Height / 2), (int)n_geschwindikeit_2.Value, (int)n_grösse.Value,mylist2));
            this.Hintergrund_2.Controls.Add(mylist2.Last<Schuss_2>());
        }

        private void neustartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Schuss_1 n in mylist1)
            {
                n.Hide();
            }
            foreach (Schuss_2 n in mylist2)
            {
                n.Hide();
            }
            mylist1.Clear();
            mylist2.Clear();
        }

        private void beendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Schuss_1 n in mylist1)
            {
                n.Tick();
            }
            foreach (Schuss_2 n in mylist2)
            {
                n.Tick();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wild drucheinander Version 2.1.0 von D.Zwygart");
        }

        private void n_Timer_ValueChanged(object sender, EventArgs e)
        {
            if(n_Timer.Value>0) timer1.Interval = (int)n_Timer.Value;
        }
    }
}
