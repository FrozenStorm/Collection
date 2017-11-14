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
    class Grafik
    {
        Panel Mymap;
        private int Height; //Höhe des Array
        private int Width; //Breite des Array
        private int x = 0; //Position des Bildschirms oben linker Punkt
        private int y = 0; //position des Bildschirms oben linker Punkt
        private int schrittweite = 32; //Felder grösse 
        private int Felder_X; // Anzahl sichtbarer Felder in x Richtung
        private int Felder_Y; // Anzahl sichtbarer Felder in y Richtung
        Graphics g;
        public Grafik(Panel Spielfeld, int newheight, int newwidth) //höhe und breite des array
        {
            Mymap = Spielfeld;
            this.Height = newheight;
            this.Width = newwidth;
        }
        public void Updatescreen(Objekt[,] Maphintergrund, Effekt[,] Mapeffekt, Objekt[,] Mapvordergurnd, int Pos_X, int Pos_Y)
        {
            g = Mymap.CreateGraphics();
            int loopx;
            int loopy;
            this.Felder_X = Mymap.Size.Width / schrittweite;
            this.Felder_Y = Mymap.Size.Height / schrittweite;
            this.x = Pos_X - (Felder_X / 2);
            this.y = Pos_Y - (Felder_Y / 2);


            for (loopx = this.x; loopx < (this.x + Felder_X + 1); loopx++)
            {
                for (loopy = this.y; loopy < (this.y + Felder_Y + 1); loopy++)
                {
                    if (loopx >= 0 && loopx < this.Width && loopy >= 0 && loopy < this.Height)
                    {
                        if (Mapvordergurnd[loopx, loopy].Transparent == true)
                        {

                            if (Maphintergrund[loopx, loopy].Transparent == true)
                            {
                                g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                            }
                            else
                            {
                                g.DrawImage(Maphintergrund[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                            }
                            if (Mapeffekt[loopx, loopy].Transparent == true)
                            {
                            }
                            else
                            {
                                g.DrawImage(Mapeffekt[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                            }
                        }
                        else
                        {
                            g.DrawImage(Mapvordergurnd[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                        }
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                    }
                }
            }
        }
        public void Updatehindergrund(Objekt[,] Maphintergrund, int Pos_X, int Pos_Y)
        {
            g = Mymap.CreateGraphics();
            int loopx;
            int loopy;
            this.Felder_X = Mymap.Size.Width / schrittweite;
            this.Felder_Y = Mymap.Size.Height / schrittweite;
            this.x = Pos_X - (Felder_X / 2);
            this.y = Pos_Y - (Felder_Y / 2);


            for (loopx = this.x; loopx < (this.x + Felder_X + 1); loopx++)
            {
                for (loopy = this.y; loopy < (this.y + Felder_Y + 1); loopy++)
                {
                    if (loopx >= 0 && loopx < this.Width && loopy >= 0 && loopy < this.Height)
                    {
                        if (Maphintergrund[loopx, loopy].Transparent == true)
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                        }
                        else
                        {
                            g.DrawImage(Maphintergrund[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                        }
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                    }
                }
            }
        }
        public void Updateeffekt(Effekt[,] Mapeffekt, int Pos_X, int Pos_Y)
        {
            g = Mymap.CreateGraphics();
            int loopx;
            int loopy;
            this.Felder_X = Mymap.Size.Width / schrittweite;
            this.Felder_Y = Mymap.Size.Height / schrittweite;
            this.x = Pos_X - (Felder_X / 2);
            this.y = Pos_Y - (Felder_Y / 2);


            for (loopx = this.x; loopx < (this.x + Felder_X + 1); loopx++)
            {
                for (loopy = this.y; loopy < (this.y + Felder_Y + 1); loopy++)
                {
                    if (loopx >= 0 && loopx < this.Width && loopy >= 0 && loopy < this.Height)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                        g.DrawImage(Mapeffekt[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                    }
                }
            }
        }
        
        public void Updatevordergrund(Objekt[,] Mapvordergurnd, int Pos_X, int Pos_Y)
        {
            g = Mymap.CreateGraphics();
            int loopx;
            int loopy;
            this.Felder_X = Mymap.Size.Width / schrittweite;
            this.Felder_Y = Mymap.Size.Height / schrittweite;
            this.x = Pos_X - (Felder_X / 2);
            this.y = Pos_Y - (Felder_Y / 2);


            for (loopx = this.x; loopx < (this.x + Felder_X + 1); loopx++)
            {
                for (loopy = this.y; loopy < (this.y + Felder_Y + 1); loopy++)
                {
                    if (loopx >= 0 && loopx < this.Width && loopy >= 0 && loopy < this.Height)
                    {
                        if (Mapvordergurnd[loopx, loopy].Transparent == true)
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                        }
                        else
                        {
                            g.DrawImage(Mapvordergurnd[loopx, loopy].Bild, (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite));
                        }
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (loopx - this.x) * (schrittweite), (loopy - this.y) * (schrittweite), schrittweite, schrittweite);
                    }
                }
            }
        }
    }
}
