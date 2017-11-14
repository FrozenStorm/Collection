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
    public partial class Moorhuhn : Form
    {
        Random myRandom = new Random();
        Random myRandom_2 = new Random();
        int runter,vor,runter_2,vor_2,schongeholt,MouseX,MouseY = 0;
        int vorschub=3;
        int vorschub_verzögerung=0;
        int schwirikeitsgrad=4;
        public Moorhuhn()
        {
            InitializeComponent();
        }
        private void P_Hintergrund_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true && timer2.Enabled == true)
            {
                L_Punkte.Text = (int.Parse(L_Punkte.Text) - 10).ToString();
                if (vorschub_verzögerung == schwirikeitsgrad)
                {
                    if (vorschub != 1)
                        vorschub -= 1;
                    vorschub_verzögerung = 0;
                }
                else
                {
                    ++vorschub_verzögerung;
                }
            }
            P_Verfolger.Visible = true;
        }
        private void Huhn1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true && timer2.Enabled == true && timer3.Enabled == true)
            {
                L_Punkte.Text = (int.Parse(L_Punkte.Text) + 10).ToString();
                runter = 20;
                vor = vorschub;
                if (vorschub_verzögerung == schwirikeitsgrad)
                {
                    ++vorschub;
                    vorschub_verzögerung = 0;
                }
                else
                {
                    ++vorschub_verzögerung;
                }
            }
        }

        private void Huhn2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true && timer2.Enabled == true && timer3.Enabled == true)
            {
                L_Punkte.Text = (int.Parse(L_Punkte.Text) + 10).ToString();
                runter_2 = 20;
                vor_2 = vorschub;
                if (vorschub_verzögerung == schwirikeitsgrad)
                {
                    ++vorschub;
                    vorschub_verzögerung = 0;
                }
                else
                {
                    ++vorschub_verzögerung;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (P_Huhn_1.Location.Y >= P_Hintergrund.Size.Height)
            {
                P_Huhn_1.Location = new Point(-P_Huhn_1.Size.Width, myRandom.Next(0,(P_Hintergrund.Size.Height - P_Huhn_1.Size.Height)));
                runter = 0;
                vor = 0;
            }
            if (P_Huhn_1.Location.X >= P_Hintergrund.Size.Width)
            {
                P_Huhn_1.Location = new Point(-P_Huhn_1.Size.Width, myRandom.Next(0,(P_Hintergrund.Size.Height - P_Huhn_1.Size.Height)));
                L_Leben.Text = (int.Parse(L_Leben.Text) - 1).ToString();
                if (vorschub != 1)
                    vorschub -= 1;
            }
            if (int.Parse(L_Leben.Text) == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("Verloren");
            }
            if (int.Parse(L_Punkte.Text) == 500 && schongeholt==0)
            {
                P_Huhn_Leben.Visible = true;
                schongeholt = 1;
            }
            P_Huhn_1.Location = new Point(P_Huhn_1.Location.X + vorschub - vor, P_Huhn_1.Location.Y + runter);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (P_Huhn_2.Location.Y >= P_Hintergrund.Size.Height)
            {
                P_Huhn_2.Location = new Point(P_Hintergrund.Size.Width, myRandom_2.Next(0,(P_Hintergrund.Size.Height - P_Huhn_2.Size.Height)));
                runter_2 = 0;
                vor_2 = 0;
            }
            if (P_Huhn_2.Location.X <= -P_Huhn_2.Size.Width)
            {
                P_Huhn_2.Location = new Point(P_Hintergrund.Size.Width, myRandom_2.Next(0, (P_Hintergrund.Size.Height - P_Huhn_2.Size.Height)));
                L_Leben.Text = (int.Parse(L_Leben.Text) - 1).ToString();
                if (vorschub != 1)
                    vorschub -= 1;
            }
            if (int.Parse(L_Leben.Text) == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("Verloren");
            }
            if (int.Parse(L_Punkte.Text) % 500 <= 9 && schongeholt == 0 && int.Parse(L_Punkte.Text) >= 10)
            {
                P_Huhn_Leben.Visible = true;
                schongeholt = 1;
            }
            P_Huhn_2.Location = new Point(P_Huhn_2.Location.X - vorschub + vor_2, P_Huhn_2.Location.Y + runter_2);
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schongeholt = 0;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            L_Punkte.Text = "0";
            L_Leben.Text = "3";
            vorschub = 3;
        }

        
        private void CheatBox_TextChanged(object sender, EventArgs e)
        {
            if (CheatBox.Text == "Teewords")
            {
                L_Punkte.Text = "99990";
            }
            if (CheatBox.Text == "Minecraft")
            {
                L_Leben.Text = "99990";
            }
            if (CheatBox.Text == "LOL")
            {
                vorschub = 1;
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false && timer2.Enabled == false)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
            }
        }
        

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.Show();
        }

        private void P_Huhn_Leben_Click(object sender, EventArgs e)
        {
            L_Leben.Text = (int.Parse(L_Leben.Text) + 1).ToString();
            P_Huhn_Leben.Visible = false;
        }

        private void optionenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Optionen Optionen = new Optionen();
            Optionen.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (0 < MousePosition.X - Location.X - P_Verfolger.Location.X - P_Hintergrund.Location.X - P_Verfolger.Size.Width/2)
                MouseX = 1;
            else
                MouseX = -1;
            if (0 < MousePosition.Y - Location.Y - P_Verfolger.Location.Y - P_Hintergrund.Location.Y - P_Verfolger.Size.Height)
                MouseY = 1;
            else
                MouseY = -1;
            P_Verfolger.Location = new Point(P_Verfolger.Location.X + MouseX, P_Verfolger.Location.Y + MouseY);
        }

        private void P_Verfolger_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true && timer2.Enabled == true && timer3.Enabled == true)
            {
                P_Verfolger.Visible = false;
                L_Punkte.Text = (int.Parse(L_Punkte.Text) + 1).ToString();
            }
        }   
    }
}
