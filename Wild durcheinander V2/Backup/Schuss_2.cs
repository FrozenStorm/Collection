using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace WindowsFormsApplication1
{
    class Schuss_2 : Panel
    {
        protected int P_Hintergrund_Y;
        protected int P_Hintergrund_X;
        private int PanelSize = 10;
        static List<Schuss_2> mylist2 = new List<Schuss_2>();
        private double mynumber;

        private double xneu;
        private double yneu;
        private double xschuss;
        private double yschuss;
        static double startwinkel;
        private double winkelalt;
        private double winkelneu;
        private double winkelzwischen;
        private double geschwindikeit;
        private double sektor;
        public Schuss_2(int Height, int Width, int pos_x, int pos_y, int geschwindikeitstart, int grösse, List<Schuss_2> other)
        {
            mylist2 = other;
            mynumber = mylist2.Count();
            startwinkel = startwinkel + 22;
            if (startwinkel >= 360) startwinkel = startwinkel - 360;
            winkelalt = winkelneu = startwinkel;
            
            geschwindikeit = geschwindikeitstart;
            PanelSize = grösse;
            this.P_Hintergrund_Y = Height;
            this.P_Hintergrund_X = Width;
            this.Size = new System.Drawing.Size(PanelSize, PanelSize);
            this.BackColor = Color.Green;
            this.TabIndex = 1;
            this.Location = new Point(pos_x, pos_y);
            
        }
        public void Tick()
        {
            xschuss = this.Location.X;
            yschuss = P_Hintergrund_X - this.Location.Y;
            if ((this.Location.X <= 0) && (winkelalt>90) && (winkelalt<270))
            {
                winkelneu = winkelalt - 180;
                if (winkelneu >= 0) winkelneu = 360 - winkelneu;
                else winkelneu = 0 - winkelneu;
            }
            if ((this.Location.X + this.Size.Width >= P_Hintergrund_X) && (((winkelalt>=0) && (winkelalt<90)) || ((winkelalt>270) && (winkelalt<=360))))
            {
                winkelneu = winkelalt + 180;
                if (winkelneu > 360) winkelneu = winkelneu - 360;
                winkelneu = 180 - (winkelneu - 180);
            }
            if ((this.Location.Y <= 0) && (winkelalt>0) && (winkelalt<180))
            {
                winkelneu = winkelalt + 180;
                winkelneu = 270 - (winkelneu - 270);
            }
            if ((this.Location.Y + this.Size.Height >= P_Hintergrund_Y) && (winkelalt>180) && (winkelalt<360))
            {
                winkelneu = winkelalt - 180;
                winkelneu = 90 - (winkelneu - 90);
            }
            if ((winkelneu <= 90) && (winkelneu > 0)) sektor = 1; //oben rechts
            if ((winkelneu <= 180) && (winkelneu > 90)) sektor = 2; //oben links
            if ((winkelneu <= 270) && (winkelneu > 180)) sektor = 3; //unten links
            if ((winkelneu <= 360) && (winkelneu > 270)) sektor = 4; //unten rechts
            winkelzwischen = winkelneu * (2 * Math.PI) / 360;
            if (sektor == 1)
            {
                if (winkelzwischen >= 90) winkelzwischen = 89;
                if (winkelzwischen <= 0) winkelzwischen = 1;
                xneu = geschwindikeit / Math.Tan(winkelzwischen);
                yneu = geschwindikeit * Math.Tan(winkelzwischen);
                if (xneu < 0) xneu = 0;
                if (xneu > geschwindikeit) xneu = geschwindikeit;
                if (yneu < 0) yneu = 0;
                if (yneu > geschwindikeit) yneu = geschwindikeit;
            }
            if (sektor == 2)
            {
                winkelzwischen = winkelzwischen - (Math.PI / 2);
                if (winkelzwischen >= 90) winkelzwischen = 89;
                if (winkelzwischen <= 0) winkelzwischen = 1;
                xneu = -geschwindikeit * Math.Tan(winkelzwischen);
                yneu = geschwindikeit / Math.Tan(winkelzwischen);
                if (xneu < -geschwindikeit) xneu = -geschwindikeit;
                if (xneu > 0) xneu = 0;
                if (yneu < 0) yneu = 0;
                if (yneu > geschwindikeit) yneu = geschwindikeit;
            }
            if (sektor == 3)
            {
                winkelzwischen = winkelzwischen - Math.PI;
                if (winkelzwischen >= 90) winkelzwischen = 89;
                if (winkelzwischen <= 0) winkelzwischen = 1;
                xneu = -geschwindikeit / Math.Tan(winkelzwischen);
                yneu = -geschwindikeit * Math.Tan(winkelzwischen);
                if (xneu < -geschwindikeit) xneu = -geschwindikeit;
                if (xneu > 0) xneu = 0;
                if (yneu < -geschwindikeit) yneu = -geschwindikeit;
                if (yneu > 0) yneu = 0;
            }
            if (sektor == 4)
            {
                winkelzwischen = winkelzwischen - (Math.PI * 1.5);
                if (winkelzwischen >= 90) winkelzwischen = 89;
                if (winkelzwischen <= 0) winkelzwischen = 1;
                xneu = geschwindikeit * Math.Tan(winkelzwischen);
                yneu = -geschwindikeit / Math.Tan(winkelzwischen);
                if (xneu < 0) xneu = 0;
                if (xneu > geschwindikeit) xneu = geschwindikeit;
                if (yneu < -geschwindikeit) yneu = -geschwindikeit;
                if (yneu > 0) yneu = 0;
            }
            winkelalt = winkelneu;
            this.Location = new Point(this.Location.X + (int)xneu, this.Location.Y - (int)yneu);
            /*
            foreach (Schuss_2 n in mylist2)
            {
                if ((this.Location.X >= n.Location.X) && (this.Location.Y >= n.Location.Y) && (this.Location.X <= (n.Location.X + n.Size.Width)) && (this.Location.Y <= (n.Location.Y + n.Size.Height)))
                {
                    if (this != n && this.Visible==true && n.Visible==true)
                    {
                        this.Hide();
                        n.Hide();
                    }
                }
                if (((this.Location.X + this.Size.Width) >= n.Location.X) && (this.Location.Y >= n.Location.Y) && ((this.Location.X + this.Size.Width) <= (n.Location.X + n.Size.Width)) && (this.Location.Y <= (n.Location.Y + n.Size.Height)))
                {
                    if (this != n && this.Visible == true && n.Visible == true)
                    {
                        this.Hide();
                        n.Hide();
                    }
                }
            }
             */
            foreach (Schuss_2 n in mylist2)
            {
                if ((this.Location.X >= n.Location.X) && (this.Location.Y >= n.Location.Y) && (this.Location.X <= (n.Location.X + n.Size.Width)) && (this.Location.Y <= (n.Location.Y + n.Size.Height)))
                {
                    if (this != n)
                    {
                        this.winkelneu = (this.winkelalt + n.winkelalt)/2;
                        if (this.winkelalt < this.winkelneu)
                        {
                            this.winkelneu = this.winkelalt + 180 + this.winkelneu;
                        }
                        else
                        {
                            if (this.winkelalt > this.winkelneu)
                            {
                                this.winkelneu = this.winkelalt - 180 - this.winkelneu;
                            }
                        }
                        if (this.winkelneu > 360) this.winkelneu = this.winkelneu - 360;
                        if (this.winkelneu < 0) this.winkelneu = 360 - this.winkelneu;
                        this.winkelalt = this.winkelneu;

                        n.winkelneu = (n.winkelalt + n.winkelalt) / 2;
                        if (n.winkelalt < n.winkelneu)
                        {
                            n.winkelneu = n.winkelalt + 180 + n.winkelneu;
                        }
                        else
                        {
                            if (n.winkelalt > n.winkelneu)
                            {
                                n.winkelneu = n.winkelalt - 180 - n.winkelneu;
                            }
                        }
                        if (n.winkelneu > 360) n.winkelneu = n.winkelneu - 360;
                        if (n.winkelneu < 0) n.winkelneu = 360 - n.winkelneu;
                        n.winkelalt = n.winkelneu;
                    }
                }
                if (((this.Location.X + this.Size.Width) >= n.Location.X) && (this.Location.Y >= n.Location.Y) && ((this.Location.X + this.Size.Width) <= (n.Location.X + n.Size.Width)) && (this.Location.Y <= (n.Location.Y + n.Size.Height)))
                {
                    if (this != n)
                    {
                        this.winkelneu = (this.winkelalt + n.winkelalt) / 2;
                        if (this.winkelalt < this.winkelneu)
                        {
                            this.winkelneu = this.winkelalt + 180 + this.winkelneu;
                        }
                        else
                        {
                            if (this.winkelalt > this.winkelneu)
                            {
                                this.winkelneu = this.winkelalt - 180 - this.winkelneu;
                            }
                        }
                        if (this.winkelneu > 360) this.winkelneu = this.winkelneu - 360;
                        if (this.winkelneu < 0) this.winkelneu = 360 - this.winkelneu;
                        this.winkelalt = this.winkelneu;

                        n.winkelneu = (n.winkelalt + n.winkelalt) / 2;
                        if (n.winkelalt < n.winkelneu)
                        {
                            n.winkelneu = n.winkelalt + 180 + n.winkelneu;
                        }
                        else
                        {
                            if (n.winkelalt > n.winkelneu)
                            {
                                n.winkelneu = n.winkelalt - 180 - n.winkelneu;
                            }
                        }
                        if (n.winkelneu > 360) n.winkelneu = n.winkelneu - 360;
                        if (n.winkelneu < 0) n.winkelneu = 360 - n.winkelneu;
                        n.winkelalt = n.winkelneu;
                    }
                }
            }
        
        
        }
    }
}