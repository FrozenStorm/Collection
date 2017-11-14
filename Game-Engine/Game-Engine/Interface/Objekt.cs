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
    interface Objekt
    {
        int Position_X
        {
            get;
            set;
        }
        int Position_Y
        {
            get;
            set;
        }
        string Classnumber
        {
            get;
            set;
        }
        bool Transparent
        {
            get;
            set;
        }
        Bitmap Bild
        {
            get;
            set;
        }

    }
}
