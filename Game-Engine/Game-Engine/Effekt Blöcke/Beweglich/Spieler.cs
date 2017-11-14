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
    class Spieler:Effekt
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

        public Spieler(int x,int y)
        {
            this.punktegewinn = 0;
            this.altesObjekt = new DernichtEffekt(x, y);
            this.attack = 1;
            this.life = 0;
            this.transparent = false;
            this.bild = new Bitmap(Properties.Resources.mario2);
            this.classnumber = "Spieler";
            this.Walkable = false;
            this.position_x = x;
            this.position_y = y;
        }


        public void Do_Effekt(Effekt[,] Mapeffekt, int Height, int Width, Input Myinput,int newdurchlauf)
        {
            if (altesObjekt.Classnumber == "Final_Destination")
            {
                this.bild = new Bitmap(Properties.Resources.star);
            }
            if (this.life > 0)
            {
                if (durchlauf != newdurchlauf)
                {
                    durchlauf = newdurchlauf;
                    if (Myinput.KB_Right_state == true)
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
                    if (Myinput.KB_Left_state == true)
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
                    if (Myinput.KB_Up_state == true)
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
                    if (Myinput.KB_Down_state == true)
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
                }
            }
            else
            {
                Mapeffekt[position_x, position_y] = altesObjekt;
                int x;
                int y;
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        if (Mapeffekt[x, y].Classnumber == "Spawnpoint")
                        {
                            position_x = x;
                            position_y = y;
                        }
                    }
                }
                altesObjekt = Mapeffekt[position_x, position_y];
                Mapeffekt[position_x, position_y] = this;
                this.life = 5;
                this.punktegewinn = 0;
            }
        }
    }
}
