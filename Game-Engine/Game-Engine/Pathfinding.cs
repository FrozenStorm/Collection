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
    class Pathfinding
    {
        List<Point> Pathpoints = new List<Point>();
        private volatile bool searching = false;
        Effekt[,] Mapeffekt;
        KI_Nr6 KI;
        public Pathfinding(KI_Nr6 KI, Effekt[,] Mapeffekt)
        {
            this.KI = KI;
            this.Mapeffekt = Mapeffekt;
        }
        public void startsearching()
        {
            searching = true;
            this.Pathpoints.Clear();
            while (searching)
            {
                if (pathfinding(Mapeffekt, KI, "Coin") == true)
                {
                    KI.found = false;
                    KI.richtung = "";
                    KI.nextstep = Pathpoints.LastIndexOf(Pathpoints.Last<Point>());
                    KI.Pathpoints = this.Pathpoints;
                }
                else
                {
                    if (pathfinding(Mapeffekt, KI, "Final_Destination") == true)
                    {
                        KI.found = false;
                        KI.richtung = "";
                        KI.nextstep = Pathpoints.LastIndexOf(Pathpoints.Last<Point>());
                        KI.Pathpoints = this.Pathpoints;
                    }
                }
            }
        }
        public void stopsearching()
        {
            searching = false;
        }
        private bool pathfinding(Effekt[,] Mapeffekt, Effekt Beginn, String Finish)
        {
            int x;
            int y;
            int z = 0;
            int lastindex = 0;
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
                    if (Mapeffekt[x, y].Classnumber == Finish)
                    {
                        foundway = true;
                    }
                    else
                    {
                        try
                        {
                            if ((Mapeffekt[x + 1, y].Attack <= 0) && (Mapeffekt[x + 1, y].Walkable == true) && (knotenschonvorhanden(myKnoten, x + 1, y, lastindex) == false))
                            {
                                myKnoten.Add(new Knoten(z, x + 1, y));
                                lastindex++;
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x - 1, y].Attack <= 0) && (Mapeffekt[x - 1, y].Walkable == true) && (knotenschonvorhanden(myKnoten, x - 1, y, lastindex) == false))
                            {
                                myKnoten.Add(new Knoten(z, x - 1, y));
                                lastindex++;
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x, y + 1].Attack <= 0) && (Mapeffekt[x, y + 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x, y + 1, lastindex) == false))
                            {
                                myKnoten.Add(new Knoten(z, x, y + 1));
                                lastindex++;
                            }
                        }
                        catch { }
                        try
                        {
                            if ((Mapeffekt[x, y - 1].Attack <= 0) && (Mapeffekt[x, y - 1].Walkable == true) && (knotenschonvorhanden(myKnoten, x, y - 1, lastindex) == false))
                            {
                                myKnoten.Add(new Knoten(z, x, y - 1));
                                lastindex++;
                            }
                        }
                        catch { }
                        if (z < lastindex) z++;
                        else return false;
                    }
                }
            }
            catch { }


            while (z > 0)
            {
                Pathpoints.Add(new Point(myKnoten[z].Now_x, myKnoten[z].Now_y));
                z = myKnoten[z].From_z;
            }
            return true;
        }
        private bool knotenschonvorhanden(List<Knoten> myKnoten, int x, int y, int lastindex)
        {
            for (; lastindex >= 0; lastindex--)
            {
                if ((myKnoten[lastindex].Now_x == x) && (myKnoten[lastindex].Now_y == y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
