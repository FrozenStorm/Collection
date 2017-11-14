using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* Kann diagonal laufen
 * Funktioniert
 * 
*/
namespace Game_Engine
{
    class KI_Nr3 : Effekt
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
        Effekt Finish;
        string richtung;
        bool found;
        int nextstep = 0;
        List<Point> Pathpoints = new List<Point>();
        public KI_Nr3(int x, int y)
        {
            this.punktegewinn = 0;
            this.altesObjekt = new DernichtEffekt(x, y);
            this.attack = 1;
            this.life = 1;
            this.transparent = false;
            this.bild = new Bitmap(Properties.Resources.Pikachu);
            this.classnumber = "KI_Nr3";
            this.Walkable = false;
            this.position_x = x;
            this.position_y = y;
            this.found = true;
        }


        public void Do_Effekt(Effekt[,] Mapeffekt, int Height, int Width, Input Myinput, int newdurchlauf)
        {
            richtung = "";
            if (durchlauf != newdurchlauf)
            {
                durchlauf = newdurchlauf;
                if (found == false)
                {
                    while ((richtung == "") && (nextstep >= 0))
                    {
                        if ((Pathpoints[nextstep].X > this.position_x) && (Pathpoints[nextstep].Y == this.position_y)) richtung = "Right";
                        if ((Pathpoints[nextstep].X < this.position_x) && (Pathpoints[nextstep].Y == this.position_y)) richtung = "Left";
                        if ((Pathpoints[nextstep].X == this.position_x) && (Pathpoints[nextstep].Y > this.position_y)) richtung = "Down";
                        if ((Pathpoints[nextstep].X == this.position_x) && (Pathpoints[nextstep].Y < this.position_y)) richtung = "Up";
                        if ((Pathpoints[nextstep].X > this.position_x) && (Pathpoints[nextstep].Y > this.position_y)) richtung = "Right-Down";
                        if ((Pathpoints[nextstep].X < this.position_x) && (Pathpoints[nextstep].Y > this.position_y)) richtung = "Left-Down";
                        if ((Pathpoints[nextstep].X > this.position_x) && (Pathpoints[nextstep].Y < this.position_y)) richtung = "Right-Up";
                        if ((Pathpoints[nextstep].X < this.position_x) && (Pathpoints[nextstep].Y < this.position_y)) richtung = "Left-Up";
                        nextstep--;
                    }
                    if (nextstep <= 0) found = true;
                }
                else
                {
                    Finish = findnearestfinish(Mapeffekt, Height, Width, this, "Coin");
                    if (Finish == null)
                    {
                        Finish = findnearestfinish(Mapeffekt, Height, Width, this, "Final_Destination");
                    }
                    if (Finish != null)
                    {
                        pathfinding(Mapeffekt, this, Finish);
                        found = false;
                        richtung = "";
                        nextstep = Pathpoints.LastIndexOf(Pathpoints.Last<Point>());
                    }
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
                    }
                }
                if (richtung == "Right-Up")
                {
                    if ((position_x + 1 < Width) && (position_y > 0))
                    {
                        if ((Mapeffekt[position_x + 1, position_y - 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x += 1;
                            this.position_y -= 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                    }
                }
                if (richtung == "Right-Down")
                {
                    if ((position_x + 1 < Width) && (position_y + 1 < Height))
                    {
                        if ((Mapeffekt[position_x + 1, position_y + 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x += 1;
                            this.position_y += 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                    }
                }
                if (richtung == "Left-Up")
                {
                    if ((position_x > 0) && (position_y > 0))
                    {
                        if ((Mapeffekt[position_x - 1, position_y - 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x -= 1;
                            this.position_y -= 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                    }
                }
                if (richtung == "Left-Down")
                {
                    if ((position_x > 0) && (position_y + 1 < Height))
                    {
                        if ((Mapeffekt[position_x - 1, position_y + 1].Walkable == true))
                        {
                            Mapeffekt[position_x, position_y] = altesObjekt;
                            this.position_x -= 1;
                            this.position_y += 1;
                            altesObjekt = Mapeffekt[position_x, position_y];
                            Mapeffekt[position_x, position_y] = this;
                            this.life = this.life - altesObjekt.Attack;
                            this.punktegewinn = this.punktegewinn + altesObjekt.Punktegewinn;
                            altesObjekt.Life = altesObjekt.Life - this.attack;
                        }
                    }
                }
            }
        }

        private bool pathfinding(Effekt[,] Mapeffekt, Effekt Beginn, Effekt Finish)
        {
            int x;
            int y;
            int z = 0;
            bool foundway = false;
            List<Knoten> myKnoten = new List<Knoten>();
            Pathpoints = new List<Point>();
            myKnoten.Add(new Knoten(z, Beginn.Position_X, Beginn.Position_Y));
            try
            {
                while (foundway == false)
                {
                    x = myKnoten[z].Now_x;
                    y = myKnoten[z].Now_y;
                    if (Mapeffekt[x, y] == Finish)
                    {
                        foundway = true;
                    }
                    else
                    {
                        try
                        {
                            if ((Mapeffekt[x + 1, y].Walkable == true) && (knotenschonvorhanden(myKnoten, x + 1, y) == false))
                            {
                                myKnoten.Add(new Knoten(z, x + 1, y));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x - 1, y].Walkable == true) && (knotenschonvorhanden(myKnoten, x - 1, y) == false))
                            {
                                myKnoten.Add(new Knoten(z, x - 1, y));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x, y + 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x, y + 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x, y + 1));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x, y - 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x, y - 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x, y - 1));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x + 1, y + 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x + 1, y + 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x + 1, y + 1));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x - 1, y + 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x - 1, y + 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x - 1, y + 1));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x + 1, y - 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x + 1, y - 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x + 1, y - 1));
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x - 1, y - 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x - 1, y - 1) == false))
                            {
                                myKnoten.Add(new Knoten(z, x - 1, y - 1));
                            }
                        }
                        catch { }
                        if (z < myKnoten.LastIndexOf(myKnoten.Last<Knoten>())) z++;
                        else return false;
                    }
                }
            }
            catch { }

            try
            {
                while (z > 0)
                {
                    Pathpoints.Add(new Point(myKnoten[z].Now_x, myKnoten[z].Now_y));
                    z = myKnoten[z].From_z;
                }
                Pathpoints.Add(new Point(myKnoten[z].Now_x, myKnoten[z].Now_y));

            }
            catch { }
            return true;
        }
        private bool knotenschonvorhanden(List<Knoten> myKnoten, int x, int y)
        {
            int z;
            for (z = myKnoten.LastIndexOf(myKnoten.Last<Knoten>()); z >= 0; z--)
            {
                if ((myKnoten[z].Now_x == x) && (myKnoten[z].Now_y == y))
                {
                    return true;
                }
            }
            return false;
        }
        private Effekt findnearestfinish(Effekt[,] Mapeffekt, int Height, int Width, Effekt Beginn, string SearchedOjekt)
        {
            int x;
            int y;
            List<Effekt> PosibleFinish = new List<Effekt>();
            int bestDistanz = 65000;
            Effekt bestOjket = null;
            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < Height; y++)
                {
                    if (Mapeffekt[x, y].Classnumber == SearchedOjekt)
                    {
                        if (pathfinding(Mapeffekt, Beginn, Mapeffekt[x, y]) == true)
                        {
                            if (Pathpoints.LastIndexOf(Pathpoints.Last<Point>()) < bestDistanz)
                            {
                                bestDistanz = Pathpoints.LastIndexOf(Pathpoints.Last<Point>());
                                bestOjket = Mapeffekt[x, y];
                            }
                        }
                    }
                }
            }
            return bestOjket;
        }
    }
}
