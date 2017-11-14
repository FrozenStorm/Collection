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
    interface Effekt:Objekt
    {
        void Do_Effekt(Effekt[,] Mapeffekt, int Height, int Width, Input Myinput, int newdurchlauf);
        bool Walkable
        {
            get;
            set;
        }
        int Durchlauf
        {
            get;
            set;
        }
        int Life
        {
            get;
            set;
        }
        int Attack
        {
            get;
            set;
        }
        int Punktegewinn
        {
            get;
            set;
        }
    }
}
