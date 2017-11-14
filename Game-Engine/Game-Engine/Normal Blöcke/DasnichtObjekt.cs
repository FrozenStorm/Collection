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
    class DasnichtObjekt : Objekt
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
        public DasnichtObjekt(int x, int y)
        {
            this.transparent = true;
            this.classnumber = "DasnichtObjekt";
            this.bild = new Bitmap(Properties.Resources.Transparent);
            this.position_x = x;
            this.position_y = y;
        }
    }
}
