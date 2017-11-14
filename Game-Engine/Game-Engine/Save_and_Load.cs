using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Game_Engine
{
    class Save_and_Load
    {
        public Save_and_Load()
        {
        }
        public void Save(Objekt[,] Maphintergrund, Effekt[,] Mapeffekt, Objekt[,] Mapvordergurnd, int Height, int Width)
        {
            int x;
            int y;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "bla.txt";
            saveFileDialog1.ShowDialog();
            FileStream fi;
            fi = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fi);
            sw.WriteLine(Height.ToString());
            sw.WriteLine(Width.ToString());
            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < Height; y++)
                {
                    sw.WriteLine(Maphintergrund[x, y].Classnumber.ToString());
                }
            }
            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < Height; y++)
                {
                    sw.WriteLine(Mapeffekt[x, y].Classnumber.ToString());
                }
            }
            for (x = 0; x < Width; x++)
            {
                for (y = 0; y < Height; y++)
                {
                    sw.WriteLine(Mapvordergurnd[x, y].Classnumber.ToString());
                }
            }
            sw.Close();
            fi.Close();
        }
        public void Load(W_Game window) 
        {
            Objekt[,] Maphintergrund;
            Effekt[,] Mapeffekt;
            Objekt[,] Mapvordergurnd;
            int Height;
            int Width;
            int x;
            int y;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            FileStream fi;
            try
            {
                fi = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fi);
                Height = Convert.ToInt16(sr.ReadLine());
                Width = Convert.ToInt16(sr.ReadLine());
                Maphintergrund = new Objekt[Width, Height];
                Mapeffekt = new Effekt[Width, Height];
                Mapvordergurnd = new Objekt[Width, Height];
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DasnichtObjekt":
                                Maphintergrund[x, y] = new DasnichtObjekt(x, y);
                                break;
                            case "Block_Blau":
                                Maphintergrund[x, y] = new Block_Blau(x, y);
                                break;
                            case "Block_Grün":
                                Maphintergrund[x, y] = new Block_Grün(x, y);
                                break;
                            case "Block_Schwarz":
                                Maphintergrund[x, y] = new Block_Schwarz(x, y);
                                break;
                            case "Block_Stein":
                                Maphintergrund[x, y] = new Block_Stein(x, y);
                                break;
                            default:
                                Maphintergrund[x, y] = new DasnichtObjekt(x, y);
                                break;
                        }
                    }
                }
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DernichtEffekt":
                                Mapeffekt[x, y] = new DernichtEffekt(x, y);
                                break;
                            case "Blockade":
                                Mapeffekt[x, y] = new Blockade(x, y);
                                break;
                            case "Lava":
                                Mapeffekt[x, y] = new Lava(x, y);
                                break;
                            case "Coin":
                                Mapeffekt[x, y] = new Coin(x, y);
                                break;
                            case "OneUp":
                                Mapeffekt[x, y] = new OneUp(x, y);
                                break;
                            case "Spawnpoint":
                                Mapeffekt[x, y] = new Spawnpoint(x, y);
                                break;
                            case "KI_Nr1":
                                Mapeffekt[x, y] = new KI_Nr1(x, y);
                                break;
                            case "KI_Nr2":
                                Mapeffekt[x, y] = new KI_Nr2(x, y);
                                break;
                            case "KI_Nr3":
                                Mapeffekt[x, y] = new KI_Nr3(x, y);
                                break;
                            case "KI_Nr4":
                                Mapeffekt[x, y] = new KI_Nr4(x, y);
                                break;
                            case "KI_Nr5":
                                Mapeffekt[x, y] = new KI_Nr5(x, y);
                                break;
                            case "KI_Nr6":
                                Mapeffekt[x, y] = new KI_Nr6(x, y);
                                break;
                            case "Final_Destination":
                                Mapeffekt[x, y] = new Final_Destination(x, y);
                                break;
                            case "Spieler":
                                Mapeffekt[x, y] = new Spieler(x, y);
                                break;
                            default:
                                Mapeffekt[x, y] = new DernichtEffekt(x, y);
                                break;
                        }
                    }
                }
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DasnichtObjekt":
                                Mapvordergurnd[x, y] = new DasnichtObjekt(x, y);
                                break;
                            case "Block_Blau":
                                Mapvordergurnd[x, y] = new Block_Blau(x, y);
                                break;
                            case "Block_Grün":
                                Mapvordergurnd[x, y] = new Block_Grün(x, y);
                                break;
                            case "Block_Schwarz":
                                Mapvordergurnd[x, y] = new Block_Schwarz(x, y);
                                break;
                            case "Block_Stein":
                                Mapvordergurnd[x, y] = new Block_Stein(x, y);
                                break;
                            default:
                                Mapvordergurnd[x, y] = new DasnichtObjekt(x, y);
                                break;
                        }
                    }
                }
                window.loadmapformfile(Maphintergrund, Mapeffekt, Mapvordergurnd, Height, Width);
                sr.Close();
                fi.Close();  
            }
            catch 
            {
                MessageBox.Show("Laden nicht möglich (load)");
            }
        }
        public void Load(W_Editor window)
        {
            Objekt[,] Maphintergrund;
            Effekt[,] Mapeffekt;
            Objekt[,] Mapvordergurnd;
            int Height;
            int Width;
            int x;
            int y;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            FileStream fi;
            try
            {
                fi = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fi);
                Height = Convert.ToInt16(sr.ReadLine());
                Width = Convert.ToInt16(sr.ReadLine());
                Maphintergrund = new Objekt[Width, Height];
                Mapeffekt = new Effekt[Width, Height];
                Mapvordergurnd = new Objekt[Width, Height];
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DasnichtObjekt":
                                Maphintergrund[x, y] = new DasnichtObjekt(x, y);
                                break;
                            case "Block_Blau":
                                Maphintergrund[x, y] = new Block_Blau(x, y);
                                break;
                            case "Block_Grün":
                                Maphintergrund[x, y] = new Block_Grün(x, y);
                                break;
                            case "Block_Schwarz":
                                Maphintergrund[x, y] = new Block_Schwarz(x, y);
                                break;
                            case "Block_Stein":
                                Maphintergrund[x, y] = new Block_Stein(x, y);
                                break;
                            default:
                                Maphintergrund[x, y] = new DasnichtObjekt(x, y);
                                break;
                        }
                    }
                }
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DernichtEffekt":
                                Mapeffekt[x, y] = new DernichtEffekt(x, y);
                                break;
                            case "Blockade":
                                Mapeffekt[x, y] = new Blockade(x, y);
                                break;
                            case "Lava":
                                Mapeffekt[x, y] = new Lava(x, y);
                                break;
                            case "Coin":
                                Mapeffekt[x, y] = new Coin(x, y);
                                break;
                            case "OneUp":
                                Mapeffekt[x, y] = new OneUp(x, y);
                                break;
                            case "Spawnpoint":
                                Mapeffekt[x, y] = new Spawnpoint(x, y);
                                break;
                            case "KI_Nr1":
                                Mapeffekt[x, y] = new KI_Nr1(x, y);
                                break;
                            case "KI_Nr2":
                                Mapeffekt[x, y] = new KI_Nr2(x, y);
                                break;
                            case "KI_Nr3":
                                Mapeffekt[x, y] = new KI_Nr3(x, y);
                                break;
                            case "KI_Nr4":
                                Mapeffekt[x, y] = new KI_Nr4(x, y);
                                break;
                            case "KI_Nr5":
                                Mapeffekt[x, y] = new KI_Nr5(x, y);
                                break;
                            case "KI_Nr6":
                                Mapeffekt[x, y] = new KI_Nr6(x, y);
                                break;
                            case "Final_Destination":
                                Mapeffekt[x, y] = new Final_Destination(x, y);
                                break;
                            case "Spieler":
                                Mapeffekt[x, y] = new Spieler(x, y);
                                break;
                            default:
                                Mapeffekt[x, y] = new DernichtEffekt(x, y);
                                break;
                        }
                    }
                }
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        switch (sr.ReadLine())
                        {
                            case "DasnichtObjekt":
                                Mapvordergurnd[x, y] = new DasnichtObjekt(x, y);
                                break;
                            case "Block_Blau":
                                Mapvordergurnd[x, y] = new Block_Blau(x, y);
                                break;
                            case "Block_Grün":
                                Mapvordergurnd[x, y] = new Block_Grün(x, y);
                                break;
                            case "Block_Schwarz":
                                Mapvordergurnd[x, y] = new Block_Schwarz(x, y);
                                break;
                            case "Block_Stein":
                                Mapvordergurnd[x, y] = new Block_Stein(x, y);
                                break;
                            default:
                                Mapvordergurnd[x, y] = new DasnichtObjekt(x, y);
                                break;
                        }
                    }
                }
                window.loadmapformfile(Maphintergrund, Mapeffekt, Mapvordergurnd, Height, Width);
                sr.Close();
                fi.Close();  
            }
            catch 
            {
                MessageBox.Show("Laden nicht möglich (load)");
            }
        }
    }
}
