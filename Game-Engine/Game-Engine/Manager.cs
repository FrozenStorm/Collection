using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* Neue Bilder, neues Hilfefenster, Transparente png Bilder mit neuer Grafikausgabe
 * 
Host: ftp.supertoub.heliohost.org 
Port: 21 
Username: daniel@supertoub.heliohost.org 
Password: c#1992
*/
namespace Game_Engine
{
    class Manager
    {
        Panel Mymap;
        Timer Mytimer;
        Grafik Mygrafik;
        Input Myinput;
        Spieler Player;
        Graphics g;
        int durchlauf; //Welcherdruchlauf
        int Height; // Höhe von Spielfeld Array
        int Width; // Breite von Spielfeld Array
        Objekt[,] Myobjektmaphintergrund;
        Effekt[,] Myobjektmapeffekt;
        Objekt[,] Myobjektmapvordergrund;
        /* 
         * 3 Ebenen   1=Maphintergrund  2=Effekte  3=Vordergrund   
         *      
         * 1:   Objekt-Hintergrund
         * 2:   Ojekt-Effekte
         *      Wie die Figur,Gegener,Feuerschaden,Bockiertes-Feld (meist Transparenter hintergrund)
         * 3:   Objekt-Vordergrund
         *      Wie Baum,Haus(meist Transparenter hintergrund)
         * */

        public Manager(Panel Spielfeld)      //mode = flase=Editor =true=Spiel
        {
            this.Mymap = Spielfeld;
            g = Mymap.CreateGraphics();
            Myinput = new Input();
            this.Mytimer = new Timer();
            this.Mytimer.Enabled = false;
            this.Mytimer.Interval = 100;
            this.Mytimer.Tick += new EventHandler(Mytimer_Tick);
        }
        public bool Loadmap(Objekt[,] Newmaphintergrund, Effekt[,] Newmapeffekt, Objekt[,] Newmapvordergurnd, int newheight, int newwidth) //höhe breite von array
        {
            try
            {
                this.Myobjektmaphintergrund = Newmaphintergrund;
                this.Myobjektmapeffekt = Newmapeffekt;
                this.Myobjektmapvordergrund = Newmapvordergurnd;
                this.Height = newheight;
                this.Width = newheight;
                Mygrafik = new Grafik(this.Mymap, this.Height, this.Width);
                int x;
                int y;
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        if (Myobjektmapeffekt[x, y].Classnumber == "Spieler")
                        {
                            Player = (Spieler)Myobjektmapeffekt[x, y];
                        }
                    }
                }
                this.Mytimer.Enabled = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Endgame()
        {
            this.Mytimer.Enabled = false;
        }
        void Mytimer_Tick(object sender, EventArgs e)
        {
            Myinput.Update();
            durchlauf += 1;
            int x;
            int y;
            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < Height; y++)
                {
                    Myobjektmapeffekt[x, y].Do_Effekt(this.Myobjektmapeffekt, this.Height, this.Width, this.Myinput, durchlauf);
                }
            }
            Mygrafik.Updatescreen(this.Myobjektmaphintergrund, this.Myobjektmapeffekt, this.Myobjektmapvordergrund,Player.Position_X,Player.Position_Y);
            g.DrawString("Life:   "+Player.Life.ToString(), new Font(new FontFamily("Arial"), 10), new SolidBrush(Color.White), new PointF(20, 20));
            g.DrawString("Points: "+Player.Punktegewinn.ToString(), new Font(new FontFamily("Arial"), 10), new SolidBrush(Color.White), new PointF(20, 40));
        }
    }
}
