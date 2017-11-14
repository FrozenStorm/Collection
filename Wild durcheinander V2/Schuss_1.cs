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
    class Schuss_1 : Panel
    {
        protected int Location_X;
        protected int Location_Y;
        protected int P_Hintergrund_X;
        protected int P_Hintergrund_Y;
        const int PanelSize = 10;
        static List<Schuss_1> mylist1 = new List<Schuss_1>();
        private double mynumber;

        private double xmaus;
        private double ymaus;
        private double xneu;
        private double yneu;
        private double xschuss;
        private double yschuss;
        private double winkelalt;
        private double wendewinkel;
        private double winkelneu;
        private double winkelzwischen;
        private double geschwindikeit;
        private bool plusminus;             //1=plus
        private double sektor;
        public Schuss_1(int Height, int Width, int X, int Y, int pos_x, int pos_y, int winkel, int geschwindikeitstart, List<Schuss_1> other)
        {
            mylist1 = other;
            mynumber = mylist1.Count();
            winkelalt = winkelneu = 0;
            geschwindikeit = geschwindikeitstart;
            wendewinkel = winkel;
            this.P_Hintergrund_X = Height;
            this.P_Hintergrund_Y = Width;
            this.Location_X = X;
            this.Location_Y = Y;
            this.Size = new System.Drawing.Size(PanelSize, PanelSize);
            this.BackColor = Color.Green;
            this.TabIndex = 1;
            this.Location = new Point(pos_x, pos_y);
        }
        public void Tick()
        {
            xmaus = MousePosition.X - Location_X;
            ymaus = P_Hintergrund_Y - (MousePosition.Y - Location_Y - 80);
            xschuss = this.Location.X;
            yschuss = P_Hintergrund_Y - this.Location.Y;
            xneu = yneu = winkelneu = 0;
            if (xmaus >= xschuss && ymaus >= yschuss) winkelneu = (Math.Atan(((ymaus - yschuss) / (xmaus - xschuss))) / (2 * Math.PI) * 360);
            if (xmaus < xschuss && ymaus >= yschuss) winkelneu = 180 + (Math.Atan(((ymaus - yschuss) / (xmaus - xschuss))) / (2 * Math.PI) * 360);
            if (xmaus < xschuss && ymaus < yschuss) winkelneu = 180 + (Math.Atan(((ymaus - yschuss) / (xmaus - xschuss))) / (2 * Math.PI) * 360);
            if (xmaus >= xschuss && ymaus < yschuss) winkelneu = 360 + (Math.Atan(((ymaus - yschuss) / (xmaus - xschuss))) / (2 * Math.PI) * 360);
            if (((winkelneu - winkelalt) <= wendewinkel) && ((winkelneu - winkelalt) >= -wendewinkel) || (((360 - winkelalt) + winkelneu <= 10) && ((360 - winkelalt) + winkelneu >= 0)) || (((360 - winkelneu) + winkelalt <= 10) && ((360 - winkelneu) + winkelalt >= 0)))
            {
                //Winkel kleiner 10
            }
            else
            {
                if ((winkelneu - winkelalt) > 180)
                {
                    plusminus = false;
                }
                else
                {
                    plusminus = true;
                }
                if ((winkelneu - winkelalt) < 0)
                {
                    if ((winkelneu - winkelalt) < -180)
                    {
                        plusminus = true;
                    }
                    else
                    {
                        plusminus = false;
                    }
                }
                if (plusminus == true)
                {
                    if ((winkelalt + wendewinkel) > 360)
                    {
                        winkelneu = winkelalt + wendewinkel - 360;
                    }
                    else
                    {
                        winkelneu = winkelalt + wendewinkel;
                    }
                }
                else
                {
                    if ((winkelalt - wendewinkel) < 0)
                    {
                        winkelneu = winkelalt - wendewinkel + 360;
                    }
                    else
                    {
                        winkelneu = winkelalt - wendewinkel;
                    }
                }
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





            xmaus = MousePosition.X - Location_X;
            ymaus = MousePosition.Y - Location_Y - 80;
            xschuss = this.Location.X;
            yschuss = this.Location.Y;
            if ((xmaus >= xschuss) && (xmaus <= (xschuss + PanelSize)) && (ymaus >= yschuss) && (ymaus <= (yschuss + PanelSize)))
            {
                this.BackColor=Color.Red;
            }
        }
    }
}