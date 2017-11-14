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
    class DernichtEffekt : Effekt
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
        public DernichtEffekt(int x,int y)
        {
            this.punktegewinn = 0;
            this.life = 1;
            this.attack = 0;
            this.transparent = true;
            this.classnumber = "DernichtEffekt";
            this.bild = new Bitmap(Properties.Resources.Transparent);
            this.Walkable = true;
            this.position_x = x;
            this.position_y = y;
        }
        public void Do_Effekt(Effekt[,] Mapeffekt, int Height, int Width, Input Myinput, int newdurchlauf)
        {
        }
    }
}
