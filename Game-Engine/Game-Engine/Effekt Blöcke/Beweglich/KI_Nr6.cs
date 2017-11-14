using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
/* Optimiertes laufen ein nicht schritt nach neuberechnung weniger
 * Umgeht alle Felder die Schaden
 * Funktioniert
 * 
*/
namespace Game_Engine
{
    class KI_Nr6 : Effekt
    {
        private Bitmap bild;
        public Bitmap Bild
        {
            get
            {
                return bild;
            }
            set
            {
                bild = value;
            }
        }
        private string classnumber;
        public string Classnumber
        {
            get
            {
                return classnumber;
            }
            set
            {
                classnumber = value;
            }

        }
        private int position_x;
        public int Position_X
        {
            get
            {
                return position_x;
            }
            set
            {
                position_x = value;
            }

        }
        private int position_y;
        public int Position_Y
        {
            get
            {
                return position_y;
            }
            set
            {
                position_y = value;
            }

        }
        private bool walkable;
        public bool Walkable
        {
            get
            {
                return walkable;
            }
            set
            {
                walkable = value;
            }
        }
        private int durchlauf;
        public int Durchlauf
        {
            get
            {
                return durchlauf;
            }
            set
            {
                durchlauf = value;
            }
        }
        private int life;
        public int Life
        {
            get
            {
                return life;
            }
            set
            {
                life = value;
            }
        }
        private int attack;
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        }
        private bool transparent;
        public bool Transparent
        {
            get
            {
                return transparent;
            }
            set
            {
                transparent = value;
            }
        }
        private int punktegewinn;
        public int Punktegewinn
        {
            get
            {
                return punktegewinn;
            }
            set
            {
                punktegewinn = value;
            }
        }

        Effekt altesObjekt;
        Pathfinding workerObject;
        Thread workerThread;
        public string richtung;
        public bool found;
        public int nextstep = 0;
        public List<Point> Pathpoints = new List<Point>();
        public KI_Nr6(int x, int y)
        {
            this.punktegewinn = 0;
            this.altesObjekt = new DernichtEffekt(x, y);
            this.attack = 1;
            this.life = 1;
            this.transparent = false;
            this.bild = new Bitmap(Properties.Resources.Dragon);
            this.classnumber = "KI_Nr6";
            this.Walkable = false;
            this.position_x = x;
            this.position_y = y;
            this.found = true;
        }


        public void Do_Effekt(Effekt[,] Mapeffekt, int Height, int Width, Input Myinput, int newdurchlauf)
        {
            if (workerThread == null)
            {
                workerObject = new Pathfinding(this,Mapeffekt);
                workerThread = new Thread(new ThreadStart(workerObject.startsearching));
                workerThread.Start();
            }
            richtung = "";
            if (durchlauf != newdurchlauf)
            {
                //Thread.Sleep(1);
                durchlauf = newdurchlauf;
                if (found == false)
                {
                    if (Pathpoints[nextstep].X > this.position_x) richtung = "Right";
                    if (Pathpoints[nextstep].X < this.position_x) richtung = "Left";
                    if (Pathpoints[nextstep].Y > this.position_y) richtung = "Down";
                    if (Pathpoints[nextstep].Y < this.position_y) richtung = "Up";
                    if (nextstep <= 0) found = true;
                    nextstep--;
                }
                if (richtung == "Right")
                {
                    if (position_x + 1 < Width)
                    {
                        if ((Mapeffekt[position_x + 1, position_y].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x += 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                }
                if (richtung == "Left")
                {
                    if (position_x > 0)
                    {
                        if ((Mapeffekt[position_x - 1, position_y].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x -= 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                }
                if (richtung == "Up")
                {
                    if (position_y > 0)
                    {
                        if ((Mapeffekt[position_x, position_y - 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_y -= 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                }
                if (richtung == "Down")
                {
                    if (position_y + 1 < Height)
                    {
                        if ((Mapeffekt[position_x, position_y + 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_y += 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                }
            }
        }
    }
}

