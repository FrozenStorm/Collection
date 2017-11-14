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
    partial class W_Game : Form
    {
        Manager Gamemananger;
        Save_and_Load SaL = new Save_and_Load();
        int myHeight;
        int myWidth;
        Objekt[,] Myobjektmaphintergrund;
        Effekt[,] Myobjektmapeffekt;
        Objekt[,] Myobjektmapvordergrund;

        public W_Game()
        {
            InitializeComponent();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W_Input my_W_Input = new W_Input();
            my_W_Input.Show();
        }
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W_Editor my_W_Editor = new W_Editor();
            my_W_Editor.Show();
        }
        public void loadmapformfile(Objekt[,] Maphintergrund, Effekt[,] Mapeffekt, Objekt[,] Mapvordergurnd, int Height, int Width)
        {
            try
            {
                Gamemananger.Endgame();
            }
            catch { }
            try
            {
                this.myHeight = Height;
                this.myWidth = Width;
                Myobjektmaphintergrund = new Objekt[myWidth, myHeight];
                Myobjektmapeffekt = new Effekt[myWidth, myHeight];
                Myobjektmapvordergrund = new Objekt[myWidth, myHeight];
                this.Myobjektmaphintergrund = Maphintergrund;
                this.Myobjektmapeffekt = Mapeffekt;
                this.Myobjektmapvordergrund = Mapvordergurnd;
                Gamemananger = new Manager(P_Spielfeld);
                Gamemananger.Loadmap(Myobjektmaphintergrund, Myobjektmapeffekt, Myobjektmapvordergrund, myHeight, myWidth);
            }
            catch
            {
                MessageBox.Show("Laden nicht möglich (loadmapformfile)");
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaL.Load(this);
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Gamemananger.Endgame();
            }
            catch { }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W_Hilfe my_W_Hilfe = new W_Hilfe();
            my_W_Hilfe.Show();
        }
    }
}
