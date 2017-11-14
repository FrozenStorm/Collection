using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Collection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void B_Game_Engine_Click(object sender, EventArgs e)
        {
            OpenProgramm("Game-Engine.exe");
        }

        private void B_Moorhuhn_Click(object sender, EventArgs e)
        {
            OpenProgramm("Moorhuhn.exe");
        }

        private void B_Tron_2_Spieler_Click(object sender, EventArgs e)
        {
            OpenProgramm("Tron.exe");
        }

        private void B_Wild_durcheinander_Click(object sender, EventArgs e)
        {
            OpenProgramm("Wild durcheinander.exe");
        }

        private void B_3D_Sinus_Click(object sender, EventArgs e)
        {
            OpenProgramm("Series3D1.exe");
        }

        private void B_XNAtutorial_Click(object sender, EventArgs e)
        {
            OpenProgramm("XNAtutorial.exe");
        }

        private void B_Weltraum_Bildschirmschoner_Click(object sender, EventArgs e)
        {
            OpenProgramm("Gravitation.exe");
        }

        private void B_Wachstum_Click(object sender, EventArgs e)
        {
            OpenProgramm("Wachstum.exe");
        }
        private void B_Wator_Click(object sender, EventArgs e)
        {
            OpenProgramm("Wator.exe");
        }
        private void B_Maze_Click(object sender, EventArgs e)
        {
            OpenProgramm("Maze Generator.exe");
        }
        private void B_Conway_Click(object sender, EventArgs e)
        {
            OpenProgramm("Conways Spiel des Lebens.exe");
        }
        private void B_3D_Maze_Click(object sender, EventArgs e)
        {
            OpenProgramm("3D Maze Map.exe");
        }
        private void B_Tileset_Click(object sender, EventArgs e)
        {
            OpenProgramm("Tileset.exe");
        }
        private void B_Walking_Man_Click(object sender, EventArgs e)
        {
            OpenProgramm("Walking-Man.exe");
        }
        private void B_Ball_Click(object sender, EventArgs e)
        {
            OpenProgramm("Ball.exe");
        }
        private void B_Space_survive_Click(object sender, EventArgs e)
        {
            OpenProgramm("Space_survive.exe");
        }
        private void B_Primzahlen_Click(object sender, EventArgs e)
        {
            OpenProgramm("Primzahlen.exe");
        }
        private void B_3D_Erde_Click(object sender, EventArgs e)
        {
            OpenProgramm("3D-Erde.exe");
        }
        private void B_Ausbreitung_Click(object sender, EventArgs e)
        {
            OpenProgramm("Ausbreitung.exe");
        }
        private void B_Snake_Click(object sender, EventArgs e)
        {
            OpenProgramm("Snake.exe");
        }
        private void B_Stämme_Click(object sender, EventArgs e)
        {
            OpenProgramm("Stämme.exe");
        }
        private void OpenProgramm(string programmexe)
        {
            Process game = new Process();
            game.StartInfo.FileName = programmexe;
            this.Hide();
            game.Start();
            while (game.HasExited == false) ;
            this.Show();
        }
    }
}
