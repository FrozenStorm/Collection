using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game_Engine
{
    partial class W_Editor : Form
    {
        Grafik mygrafik;
        Input myinput= new Input();
        Save_and_Load SaL = new Save_and_Load();
        Objekt[,] Myobjektmaphintergrund;
        Effekt[,] Myobjektmapeffekt;
        Objekt[,] Myobjektmapvordergrund;
        int schrittweite = 32; //Felder grösse 
        int myHeight; // Höhe von Spielfeld Array
        int myWidth; // Breite von Spielfeld Array
        int Mousposition_X; //Mausposition auf Panel in array koordinaten schrittweite wird beachtet
        int Mousposition_Y;
        int Showposition_X;// Anzeigeposition ( Wie Spieler)
        int Showposition_Y;
        int Felder_X; // Anzahl sichtbarer Felder in x Richtung
        int Felder_Y; // Anzahl sichtbarer Felder in y Richtung
        public W_Editor()
        {
            InitializeComponent();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            try
            {
                Showposition_X=0;
                Showposition_Y=0;
                myHeight=Convert.ToInt16(TB_Grösse_X.Text);
                myWidth=Convert.ToInt16(TB_Grösse_Y.Text);
                Myobjektmaphintergrund = new Objekt[myWidth, myHeight];
                Myobjektmapeffekt = new Effekt[myWidth, myHeight];
                Myobjektmapvordergrund = new Objekt[myWidth, myHeight];
                mygrafik = new Grafik(P_Spielfeld, myHeight, myWidth);
                for (x = 0; x < myWidth; x++)
                {
                    for (y = 0; y < myHeight; y++)
                    {
                        Myobjektmaphintergrund[x, y] = new DasnichtObjekt(x,y);
                        Myobjektmapeffekt[x, y] = new DernichtEffekt(x, y);
                        Myobjektmapvordergrund[x, y] = new DasnichtObjekt(x, y);
                    }
                }
                timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Falsche Grösse");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myinput.Update();
            this.Felder_X = P_Spielfeld.Size.Width / schrittweite;
            this.Felder_Y = P_Spielfeld.Size.Height / schrittweite;
            this.Mousposition_X = (((myinput.M_Position_X - this.Location.X - 5) / schrittweite) - (Felder_X / 2)) + this.Showposition_X;
            this.Mousposition_Y = (((myinput.M_Position_Y - this.Location.Y - 54) / schrittweite) - (Felder_Y / 2)) + this.Showposition_Y;
            label1.Text = this.Showposition_X.ToString();
            label2.Text = this.Showposition_Y.ToString();
            if(myinput.KB_Left_state==true && Showposition_X>0)
            {
                Showposition_X-=1;
            }
            if (myinput.KB_Right_state == true && Showposition_X < (myHeight-1))
            {
                Showposition_X+=1;
            }
            if (myinput.KB_Up_state == true && Showposition_Y > 0)
            {
                Showposition_Y-=1;
            }
            if (myinput.KB_Down_state == true && Showposition_Y < (myWidth - 1))
            {
                Showposition_Y+=1;
            }
            if (myinput.KB_Control_state == true)
            {
                CB_Layer.Enabled = true;
                CB_Objekt.Enabled = true;
                CB_ShowallLayers.Enabled = true;
            }
            else
            {
                CB_Layer.Enabled = false;
                CB_Objekt.Enabled = false;
                CB_ShowallLayers.Enabled = false;
            }
            if ((myinput.M_Left_state == true) && (myinput.KB_Control_state == false))
            {
                try
                {
                    switch (CB_Objekt.Text)
                    {
                        case "Spieler":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Spieler(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr1":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr1(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr2":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr2(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr3":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr3(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr4":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr4(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr5":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr5(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "KI_Nr6":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new KI_Nr6(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Blockade":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Blockade(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Lava":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Lava(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "OneUp":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new OneUp(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Coin":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Coin(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Spawnpoint":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Spawnpoint(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Final_Destination":
                            switch (CB_Layer.Text)
                            {
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new Final_Destination(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Grün":
                            switch (CB_Layer.Text)
                            {
                                case "0":
                                    Myobjektmaphintergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Grün(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "2":
                                    Myobjektmapvordergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Grün(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Blau":
                            switch (CB_Layer.Text)
                            {
                                case "0":
                                    Myobjektmaphintergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Blau(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "2":
                                    Myobjektmapvordergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Blau(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Stein":
                            switch (CB_Layer.Text)
                            {
                                case "0":
                                    Myobjektmaphintergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Stein(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "2":
                                    Myobjektmapvordergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Stein(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Schwarz":
                            switch (CB_Layer.Text)
                            {
                                case "0":
                                    Myobjektmaphintergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Schwarz(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "2":
                                    Myobjektmapvordergrund[this.Mousposition_X, this.Mousposition_Y] = new Block_Schwarz(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;

                        case "Löschen":
                            switch (CB_Layer.Text)
                            {
                                case "0":
                                    Myobjektmaphintergrund[this.Mousposition_X, this.Mousposition_Y] = new DasnichtObjekt(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "1":
                                    Myobjektmapeffekt[this.Mousposition_X, this.Mousposition_Y] = new DernichtEffekt(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                                case "2":
                                    Myobjektmapvordergrund[this.Mousposition_X, this.Mousposition_Y] = new DasnichtObjekt(this.Mousposition_X, this.Mousposition_Y);
                                    break;
                            }
                            break;
                    }
                }
                catch { }
            }
            if (CB_ShowallLayers.Checked == true)
            {
                mygrafik.Updatescreen(Myobjektmaphintergrund, Myobjektmapeffekt, Myobjektmapvordergrund, Showposition_X, Showposition_Y);
            }
            else
            {

                switch (CB_Layer.Text)
                {
                    case "0":
                        mygrafik.Updatehindergrund(Myobjektmaphintergrund, Showposition_X, Showposition_Y);
                        break;
                    case "1":
                        mygrafik.Updateeffekt(Myobjektmapeffekt, Showposition_X, Showposition_Y);
                        break;
                    case "2":
                        mygrafik.Updatevordergrund(Myobjektmapvordergrund, Showposition_X, Showposition_Y);
                        break;
                    default:
                        mygrafik.Updatescreen(Myobjektmaphintergrund, Myobjektmapeffekt, Myobjektmapvordergrund, Showposition_X, Showposition_Y);
                        break;
                }
            }
        }

        private void speicherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaL.Save(Myobjektmaphintergrund, Myobjektmapeffekt, Myobjektmapvordergrund, myHeight, myWidth);
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaL.Load(this);
        }
        public void loadmapformfile(Objekt[,] Maphintergrund, Effekt[,] Mapeffekt, Objekt[,] Mapvordergurnd, int Height, int Width)
        {
            try
            {
                Showposition_X = 0;
                Showposition_Y = 0;
                this.myHeight = Height;
                this.myWidth = Width;
                Myobjektmaphintergrund = new Objekt[myWidth, myHeight];
                Myobjektmapeffekt = new Effekt[myWidth, myHeight];
                Myobjektmapvordergrund = new Objekt[myWidth, myHeight];
                mygrafik = new Grafik(P_Spielfeld, myHeight, myWidth);
                this.Myobjektmaphintergrund = Maphintergrund;
                this.Myobjektmapeffekt = Mapeffekt;
                this.Myobjektmapvordergrund = Mapvordergurnd;
                timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Laden nicht möglich");
            }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W_Hilfe my_W_Hilfe = new W_Hilfe();
            my_W_Hilfe.Show();
        }
    }
}
