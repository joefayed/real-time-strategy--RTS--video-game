using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Big_game
{
    public class vehickles
    {
        public Bitmap tank;
        public int posx, posy, health;
    }
    public class weaponfactory
    {
        public Rectangle temp, post;
        public int startwf, intx, inty, health;
    }
    public class defencetower
    {
        public Rectangle temp, post;
        public int startdt, intx, inty, health;
    }
    public class guntower
    {
        public Rectangle temp, post;
        public int startgt, intx, inty, startmove = 0, health;
    }
    public class barrackes
    {
        public Rectangle temp, post;
        public int startba, intx, inty, health;
    }
    public class powerPlant
    {
        public Rectangle temp, post;
        public int startpb, intx, inty, health;
    }
    public class refinery
    {
        public Rectangle temp, post;
        public int startpb, intx, inty, health;
    }
    public class sideicons
    {
        public Rectangle temp, post;
        public int startsi, intx, inty;
    }
    public class laser
    {
        public int posxs, posys, posxe, posye;
    }
    public class menu
    {
        public Bitmap im;
    }
    public class scores
    {
        public string sc;
        public int start;
    }
    
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Random r = new Random();
        List<powerPlant> pbl = new List<powerPlant>();
        List<sideicons> sic = new List<sideicons>();
        List<refinery> refi = new List<refinery>();
        List<barrackes> bar = new List<barrackes>();
        List<defencetower> dft = new List<defencetower>();
        List<guntower> gt = new List<guntower>();
        List<weaponfactory> wfa = new List<weaponfactory>();
        List<vehickles> tank1 = new List<vehickles>();
        List<laser> lase = new List<laser>();
        List<laser> lase2 = new List<laser>();
        List<menu> men=new List<menu>();
        List<scores> sco = new List<scores>();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        Bitmap bg, map, sidebar, pbg, pby, pbr, pblant, sidebaricons, refinery, barrackes, defencetower, guntower, guntowermove, weaponfactory, masknuke, maskion, sell, enemybase, back, credits, music, mon, moff;
        int mapx = 0, mapy = 0, dx = 0, dy = 0, inity = 270, nmc = 1, imc = 1, v = -1, score = 0, money = 200, enemyhealth = 400, plusmin = 100, current = 0, cs = 0,super=0;
        //flags
        //fi= Flag Sidebar Icon\ pi= power indicator\fab= flag to allow build\nf=nuke flag\ifl= ion flag\ftm= flag tank move\fs= flag sell\ptf= power tower flag\
        int fi = -1, pi = 1, fab = 0, nf = 0, ifl = 0, ftm = 0, fs = 0, ptf = 0, scene = 0;
        int counttick = 0;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//Mouse.cur");
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown;
            t.Interval = 5;
            t.Tick += t_Tick;
            t.Start();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                fs = 1;
            }
            if (e.KeyCode==Keys.B)
            {
                fs = 0;
            }
            if (e.KeyCode == Keys.Escape && scene == 1)
            {
                scene = 12;
                current = 7;
            }
            else if (e.KeyCode == Keys.Escape && scene != 1)
            {
                scene = 0;
                current = 0;
            }
        }

        void whichicon(int x, int y)
        {
            for (int i=0;i<sic.Count;i++)
            {
                if (x >= sic[i].intx && y >= sic[i].inty && x <= sic[i].intx + 75 && y <= sic[i].inty + 102)
                {
                    fi = i;
                    break;
                }
            }
        }

        void Checkexistance(int x,int y)
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                if (x - mapx >= pbl[i].intx - 50 && y - mapy >= pbl[i].inty - 50 && x - mapx <= pbl[i].intx + 50 && y - mapy <= pbl[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
            for (int i = 0; i < refi.Count; i++)
            {
                if (x - mapx >= refi[i].intx - 50 && y - mapy >= refi[i].inty - 50 && x - mapx <= refi[i].intx + 50 && y - mapy <= refi[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
            for (int i = 0; i < bar.Count; i++)
            {
                if (x - mapx >= bar[i].intx - 50 && y - mapy >= bar[i].inty - 50 && x - mapx <= bar[i].intx + 50 && y - mapy <= bar[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
            for (int i = 0; i < dft.Count; i++)
            {
                if (x - mapx >= dft[i].intx - 50 && y - mapy >= dft[i].inty - 50 && x - mapx <= dft[i].intx + 50 && y - mapy <= dft[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
            for (int i = 0; i < gt.Count; i++)
            {
                if (x - mapx >= gt[i].intx - 50 && y - mapy >= gt[i].inty - 50 && x - mapx <= gt[i].intx + 50 && y - mapy <= gt[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
            for (int i = 0; i < wfa.Count; i++)
            {
                if (x - mapx >= wfa[i].intx - 50 && y - mapy >= wfa[i].inty - 50 && x - mapx <= wfa[i].intx + 50 && y - mapy <= wfa[i].inty + 50)
                {
                    fab = 1;
                    break;
                }
            }
        }

        void Checkexistance2(int x, int y)
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                if (x - mapx >= pbl[i].intx - 50 && y - mapy >= pbl[i].inty - 50 && x - mapx <= pbl[i].intx + 50 && y - mapy <= pbl[i].inty + 50)
                {
                    pbl.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
            for (int i = 0; i < refi.Count; i++)
            {
                if (x - mapx >= refi[i].intx - 50 && y - mapy >= refi[i].inty - 50 && x - mapx <= refi[i].intx + 50 && y - mapy <= refi[i].inty + 50)
                {
                    refi.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
            for (int i = 0; i < bar.Count; i++)
            {
                if (x - mapx >= bar[i].intx - 50 && y - mapy >= bar[i].inty - 50 && x - mapx <= bar[i].intx + 50 && y - mapy <= bar[i].inty + 50)
                {
                    bar.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
            for (int i = 0; i < dft.Count; i++)
            {
                if (x - mapx >= dft[i].intx - 50 && y - mapy >= dft[i].inty - 50 && x - mapx <= dft[i].intx + 50 && y - mapy <= dft[i].inty + 50)
                {
                    dft.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
            for (int i = 0; i < gt.Count; i++)
            {
                if (x - mapx >= gt[i].intx - 50 && y - mapy >= gt[i].inty - 50 && x - mapx <= gt[i].intx + 50 && y - mapy <= gt[i].inty + 50)
                {
                    gt.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
            for (int i = 0; i < wfa.Count; i++)
            {
                if (x - mapx >= wfa[i].intx - 50 && y - mapy >= wfa[i].inty - 50 && x - mapx <= wfa[i].intx + 50 && y - mapy <= wfa[i].inty + 50)
                {
                    wfa.RemoveAt(i);
                    money += 5;
                    break;
                }
            }
        }

        void building(int x,int y)
        {
            //powerplant
            if (fi == 0)
            {
                if (money >= 10)
                {
                    money -= 10;
                    powerPlant pnn = new powerPlant();
                    pnn.startpb = 238;
                    pnn.temp = new Rectangle(pnn.startpb, 0, 50, 50);
                    pnn.post = new Rectangle(x, y, 50, 50);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    pbl.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
            //barrackes
            else if (fi == 1)
            {
                if (money >= 5)
                {
                    money -= 5;
                    barrackes pnn = new barrackes();
                    pnn.startba = 0;
                    pnn.temp = new Rectangle(pnn.startba, 0, 47, 50);
                    pnn.post = new Rectangle(x, y, 50, 50);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    bar.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
            //defence tower
            else if (fi == 2)
            {
                if (money >= 15)
                {
                    money -= 15;
                    defencetower pnn = new defencetower();
                    pnn.startdt = 0;
                    pnn.temp = new Rectangle(pnn.startdt, 0, 24, 30);
                    pnn.post = new Rectangle(x, y, 50, 50);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    dft.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
            //refinery
            else if (fi == 5)
            {
                if (money >= 20)
                {
                    money -= 20;
                    refinery pnn = new refinery();
                    pnn.startpb = 0;
                    pnn.temp = new Rectangle(pnn.startpb, 0, 73, 70);
                    pnn.post = new Rectangle(x, y, 100, 100);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    refi.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
            //gun tower
            else if (fi == 6)
            {
                if (money >= 25)
                {
                    money -= 25;
                    guntower pnn = new guntower();
                    pnn.startgt = 0;
                    pnn.temp = new Rectangle(pnn.startgt, 0, 24, 30);
                    pnn.post = new Rectangle(x, y, 50, 50);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    gt.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
            //weaponfactory
            else if (fi == 7)
            {
                if (money >= 15)
                {
                    money -= 15;
                    weaponfactory pnn = new weaponfactory();
                    pnn.startwf = 0;
                    pnn.temp = new Rectangle(pnn.startwf, 0, 71, 70);
                    pnn.post = new Rectangle(x, y, 50, 50);
                    pnn.intx = x - mapx;
                    pnn.inty = y - mapy;
                    pnn.health = 50;
                    wfa.Add(pnn);
                }
                else
                {
                    MessageBox.Show("you don't have enough money");
                }
            }
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (scene==0)
            {
                if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 200 && e.Y <= 280)
                {
                    scene = 1;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 340 && e.Y <= 420)
                {
                    scene = 2;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 420 && e.Y <= 500)
                {
                    scene = 3;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 500 && e.Y <= 580)
                {
                    scene = 4;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 580 && e.Y <= 660)
                {
                    this.Close();
                }
            }
            if (scene==12)
            {
                if (e.X >= 896 && e.Y >= 473 && e.X <= 990 && e.Y <= 495)
                {
                    scene = 1;
                }
                if (e.X >= 870 && e.Y >= 522 && e.X <= 1020 && e.Y <= 544)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"D://Cs//CS 232//Assignments//Big game//Sources//Scores.txt", true))
                    {
                        file.WriteLine(score.ToString());
                    }
                    scene = 0;
                    current = 0;
                }
            }

            if (scene == 1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (fi > -1 && fs == 0)
                    {
                        Checkexistance(e.X, e.Y);
                        if (fab == 0)
                        {
                            if (fi==3||fi==4)
                            {
                                if (e.X >= 4000 + mapx && e.X <= 4000 + mapx +400&& e.Y >= 450 + mapy && e.Y <= 450 + mapy + 300)
                                {
                                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"D://Cs//CS 232//Assignments//Big game//Sources//Scores.txt", true))
                    {
                        file.WriteLine(score.ToString());
                    }
                                    MessageBox.Show("you won");
                                    scene = 1;
                                    current = 1;
                                }
                            }
                            if (fi != 6 && fi != 2)
                            {
                                building(e.X, e.Y);
                            }
                            else if ((fi == 6 || fi == 2) && ptf == 1)
                            {
                                building(e.X, e.Y);
                            }
                            else
                            {
                                MessageBox.Show("you don't have enough power");
                            }
                        }
                        else
                        {
                            fab = 0;
                            MessageBox.Show("you cannot build here");
                        }
                    }
                    else if (fs == 1)
                    {
                        Checkexistance2(e.X, e.Y);
                    }
                }
                else
                {
                    whichicon(e.X, e.Y);
                }
            }
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (scene == 0)
            {
                if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width-140 && e.Y >= 200 && e.Y <= 280)
                {
                    current = 1;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 260 && e.Y <= 340)
                {
                    current = 2;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 340 && e.Y <= 420)
                {
                    current = 3;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 420 && e.Y <= 500)
                {
                    current = 4;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 500 && e.Y <= 580)
                {
                    current = 5;
                }
                else if (e.X >= this.ClientSize.Width - 650 && e.X <= this.ClientSize.Width - 140 && e.Y >= 580 && e.Y <= 660)
                {
                    current = 6;
                }
                else
                {
                    current = 0;
                }
            }
            dx = e.X;
            dy = e.Y;
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawbuffer(e.Graphics);
        }

        void Createvehickle()
        {
            v = r.Next(200, 700);
            vehickles pnn = new vehickles();
            pnn.tank = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//tank1.bmp");
            pnn.tank.MakeTransparent(Color.White);
            pnn.posx = 4000 - mapx;
            pnn.posy = v - mapy;
            pnn.health = 50;
            tank1.Add(pnn);
        }

        void tabkmove()
        {
            for (int i = 0; i < tank1.Count; i++)
            {
                for (int k = 0; k < pbl.Count; k++)
                {
                    if (((tank1[i].posx >= pbl[k].intx + 55 && tank1[i].posx <= pbl[k].intx + 70) || (tank1[i].posx + 50 >= pbl[k].intx + 55 && tank1[i].posx + 50 <= pbl[k].intx + 70))
                     && ((tank1[i].posy >= pbl[k].inty && tank1[i].posy <= pbl[k].inty + 55) || (tank1[i].posy + 50 >= pbl[k].inty && tank1[i].posy + 50 <= pbl[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                for (int k = 0; k < refi.Count; k++)
                {
                    if (((tank1[i].posx >= refi[k].intx + 55 && tank1[i].posx <= refi[k].intx + 70) || (tank1[i].posx + 50 >= refi[k].intx + 55 && tank1[i].posx + 50 <= refi[k].intx + 70))
                    && ((tank1[i].posy >= refi[k].inty && tank1[i].posy <= refi[k].inty + 55) || (tank1[i].posy + 50 >= refi[k].inty && tank1[i].posy + 50 <= refi[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                for (int k = 0; k < bar.Count; k++)
                {
                    if (((tank1[i].posx >= bar[k].intx + 55 && tank1[i].posx <= bar[k].intx + 70) || (tank1[i].posx + 50 >= bar[k].intx + 55 && tank1[i].posx + 50 <= bar[k].intx + 70))
                    && ((tank1[i].posy >= bar[k].inty && tank1[i].posy <= bar[k].inty + 55) || (tank1[i].posy + 50 >= bar[k].inty && tank1[i].posy + 50 <= bar[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                for (int k = 0; k < dft.Count; k++)
                {
                    if (((tank1[i].posx >= dft[k].intx + 55 && tank1[i].posx <= dft[k].intx + 70) || (tank1[i].posx + 50 >= dft[k].intx + 55 && tank1[i].posx + 50 <= dft[k].intx + 70))
                    && ((tank1[i].posy >= dft[k].inty && tank1[i].posy <= dft[k].inty + 55) || (tank1[i].posy + 50 >= dft[k].inty && tank1[i].posy + 50 <= dft[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                for (int k = 0; k < gt.Count; k++)
                {
                    if (((tank1[i].posx >= gt[k].intx + 55 && tank1[i].posx <= gt[k].intx + 70) || (tank1[i].posx + 50 >= gt[k].intx + 55 && tank1[i].posx + 50 <= gt[k].intx + 70))
                    && ((tank1[i].posy >= gt[k].inty && tank1[i].posy <= gt[k].inty + 55) || (tank1[i].posy + 50 >= gt[k].inty && tank1[i].posy + 50 <= gt[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                for (int k = 0; k < wfa.Count; k++)
                {
                    if (((tank1[i].posx >= wfa[k].intx + 55 && tank1[i].posx <= wfa[k].intx + 70) || (tank1[i].posx + 50 >= wfa[k].intx + 55 && tank1[i].posx + 50 <= wfa[k].intx + 70))
                    && ((tank1[i].posy >= wfa[k].inty && tank1[i].posy <= wfa[k].inty + 55) || (tank1[i].posy + 50 >= wfa[k].inty && tank1[i].posy + 50 <= wfa[k].inty + 55)))
                    {
                        ftm = 1;
                        break;
                    }
                }
                if (ftm == 1)
                {
                    tank1[i].posy -= 50;
                    tank1[i].tank = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//tank1right.bmp");
                    tank1[i].tank.MakeTransparent(Color.White);
                    ftm = 0;
                }
                else
                {
                    tank1[i].tank = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//tank1.bmp");
                    tank1[i].tank.MakeTransparent(Color.White);
                }

                tank1[i].posx -= 5;
            }
        }

        void nukesuperweapontimer()
        {
            if (nf == 0)
            {
                if (nmc == 4)
                {
                    nf = 1;
                }
                else
                {
                    masknuke = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Mask" + nmc + ".bmp");
                }
                if (nmc < 4)
                {
                    nmc++;
                }
                masknuke.MakeTransparent(Color.Black);
            }
        }

        void ionsupeerweapontimer()
        {
            if (ifl == 0)
            {
                if (imc == 4)
                {
                    ifl = 1;
                }
                else
                {
                    maskion = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Mask" + imc + ".bmp");
                }
                if (imc < 4)
                {
                    imc++;
                }
                maskion.MakeTransparent(Color.Black);
            }
        }

        void construction()
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                if (pbl[i].startpb < 900)
                    pbl[i].startpb += 48;
                pbl[i].temp = new Rectangle(pbl[i].startpb, 0, 50, 50);
            }
            for (int i = 0; i < refi.Count; i++)
            {
                if (refi[i].startpb < 2000)
                    refi[i].startpb += 72;
                refi[i].temp = new Rectangle(refi[i].startpb, 0, 73, 70);
            }
            for (int i = 0; i < bar.Count; i++)
            {
                if (bar[i].startba < 1500)
                    bar[i].startba += 48;
                bar[i].temp = new Rectangle(bar[i].startba, 0, 47, 50);
            }
            for (int i = 0; i < dft.Count; i++)
            {
                if (dft[i].startdt < 275)
                    dft[i].startdt += 24;
                dft[i].temp = new Rectangle(dft[i].startdt, 0, 24, 30);
            }
            for (int i = 0; i < gt.Count; i++)
            {
                if (gt[i].startgt < 375)
                {
                    gt[i].startgt += 24;
                    gt[i].temp = new Rectangle(gt[i].startgt, 0, 24, 30);
                }
                else
                {
                    if (gt[i].startmove < 1000)
                    {
                        gt[i].startmove += 24;
                    }
                    else
                    {
                        gt[i].startmove = 0;
                    }
                    gt[i].temp = new Rectangle(gt[i].startmove, 0, 24, 30);
                }
            }
            for (int i = 0; i < wfa.Count; i++)
            {
                if (wfa[i].startwf < 1100)
                    wfa[i].startwf += 72;
                wfa[i].temp = new Rectangle(wfa[i].startwf, 0, 72, 70);
            }
        }

        void cursor_scrolling()
        {
            if (dx >= this.ClientSize.Width - 20 && mapx > -3585)
            {
                mapx -= 15;
                this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//right.cur");
            }
            else if (dx <= 10 && mapx < 0)
            {
                mapx += 15;
                this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//left.cur");
            }
            else if (dy >= this.ClientSize.Height - 50 && mapy > -1005)
            {
                mapy -= 15;
                this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//down.cur");
            }
            else if (dy <= 10 && mapy < 0)
            {
                mapy += 15;
                this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//SCCScroll6.cur");
            }
            else
            {
                this.Cursor = new Cursor("D://Cs//CS 232//Assignments//Big game//Sources//Mouse.cur");
            }
        }

        void checkradis()
        {
            for (int k=0;k<gt.Count;k++)
            {
                for (int i=0;i<tank1.Count;i++)
                {
                    if (((tank1[i].posx >= gt[k].intx + 55 && tank1[i].posx <= gt[k].intx + 180) || (tank1[i].posx + 50 >= gt[k].intx + 55 && tank1[i].posx + 50 <= gt[k].intx + 180))
                    && ((tank1[i].posy >= gt[k].inty+30 && tank1[i].posy <= gt[k].inty + 180) || (tank1[i].posy + 50 >= gt[k].inty-30 && tank1[i].posy + 50 <= gt[k].inty + 180)))
                    {
                        tank1[i].health -= 3;
                        laser pnn = new laser();
                        pnn.posxs = gt[k].post.X;
                        pnn.posys = gt[k].post.Y;
                        pnn.posxe = tank1[i].posx;
                        pnn.posye = tank1[i].posy;
                        lase.Add(pnn);
                    }
                }
            }
            for (int k = 0; k < dft.Count; k++)
            {
                for (int i = 0; i < tank1.Count; i++)
                {
                    if (((tank1[i].posx >= dft[k].intx + 55 && tank1[i].posx <= dft[k].intx + 180) || (tank1[i].posx + 50 >= dft[k].intx + 55 && tank1[i].posx + 50 <= dft[k].intx + 180))
                    && ((tank1[i].posy >= dft[k].inty + 30 && tank1[i].posy <= dft[k].inty + 180) || (tank1[i].posy + 50 >= dft[k].inty - 30 && tank1[i].posy + 50 <= dft[k].inty + 180)))
                    {
                        tank1[i].health--;
                        laser pnn = new laser();
                        pnn.posxs = dft[k].post.X;
                        pnn.posys = dft[k].post.Y;
                        pnn.posxe = tank1[i].posx;
                        pnn.posye = tank1[i].posy;
                        lase2.Add(pnn);
                    }
                }
            }
        }

        void checkhealth()
        {
            for (int i=0;i<tank1.Count;i++)
            {
                if (tank1[i].health<=0)
                {
                    score += 10;
                    tank1.RemoveAt(i);
                }
            }
        }

        void attack()
        {
            for (int i=0;i<tank1.Count;i++)
            {
                for (int k=0;k<pbl.Count;k++)
                {
                    if (((tank1[i].posx >= pbl[k].intx + 55 && tank1[i].posx <= pbl[k].intx + 180) || (tank1[i].posx + 50 >= pbl[k].intx + 55 && tank1[i].posx + 50 <= pbl[k].intx + 180))
                    && ((tank1[i].posy >= pbl[k].inty + 30 && tank1[i].posy <= pbl[k].inty + 180) || (tank1[i].posy + 50 >= pbl[k].inty - 30 && tank1[i].posy + 50 <= pbl[k].inty + 180)))
                    {
                        pbl[k].health-=1;
                    }
                }
                for (int k = 0; k < refi.Count; k++)
                {
                    if (((tank1[i].posx >= refi[k].intx + 55 && tank1[i].posx <= refi[k].intx + 180) || (tank1[i].posx + 50 >= refi[k].intx + 55 && tank1[i].posx + 50 <= refi[k].intx + 180))
                    && ((tank1[i].posy >= refi[k].inty + 30 && tank1[i].posy <= refi[k].inty + 180) || (tank1[i].posy + 50 >= refi[k].inty - 30 && tank1[i].posy + 50 <= refi[k].inty + 180)))
                    {
                        refi[k].health -= 1;
                    }
                }
                for (int k = 0; k < bar.Count; k++)
                {
                    if (((tank1[i].posx >= bar[k].intx + 55 && tank1[i].posx <= bar[k].intx + 180) || (tank1[i].posx + 50 >= bar[k].intx + 55 && tank1[i].posx + 50 <= bar[k].intx + 180))
                    && ((tank1[i].posy >= bar[k].inty + 30 && tank1[i].posy <= bar[k].inty + 180) || (tank1[i].posy + 50 >= bar[k].inty - 30 && tank1[i].posy + 50 <= bar[k].inty + 180)))
                    {
                        bar[k].health -= 1;
                    }
                }
                for (int k = 0; k < dft.Count; k++)
                {
                    if (((tank1[i].posx >= dft[k].intx + 55 && tank1[i].posx <= dft[k].intx + 180) || (tank1[i].posx + 50 >= dft[k].intx + 55 && tank1[i].posx + 50 <= dft[k].intx + 180))
                    && ((tank1[i].posy >= dft[k].inty + 30 && tank1[i].posy <= dft[k].inty + 180) || (tank1[i].posy + 50 >= dft[k].inty - 30 && tank1[i].posy + 50 <= dft[k].inty + 180)))
                    {
                        dft[k].health -= 1;
                    }
                }
                for (int k = 0; k < gt.Count; k++)
                {
                    if (((tank1[i].posx >= gt[k].intx + 55 && tank1[i].posx <= gt[k].intx + 180) || (tank1[i].posx + 50 >= gt[k].intx + 55 && tank1[i].posx + 50 <= gt[k].intx + 180))
                    && ((tank1[i].posy >= gt[k].inty + 30 && tank1[i].posy <= gt[k].inty + 180) || (tank1[i].posy + 50 >= gt[k].inty - 30 && tank1[i].posy + 50 <= gt[k].inty + 180)))
                    {
                        gt[k].health -= 1;
                    }
                }
                for (int k = 0; k < wfa.Count; k++)
                {
                    if (((tank1[i].posx >= wfa[k].intx + 55 && tank1[i].posx <= wfa[k].intx + 180) || (tank1[i].posx + 50 >= wfa[k].intx + 55 && tank1[i].posx + 50 <= wfa[k].intx + 180))
                    && ((tank1[i].posy >= wfa[k].inty + 30 && tank1[i].posy <= wfa[k].inty + 180) || (tank1[i].posy + 50 >= wfa[k].inty - 30 && tank1[i].posy + 50 <= wfa[k].inty + 180)))
                    {
                        wfa[k].health -= 1;
                    }
                }
            }
        }

        void checkbuildingshealth()
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                if (pbl[i].health<=0)
                {
                    pbl.RemoveAt(i);
                }
            }
            for (int i = 0; i < refi.Count; i++)
            {
                if (refi[i].health <= 0)
                {
                    refi.RemoveAt(i);
                }
            }
            for (int i = 0; i < bar.Count; i++)
            {
                if (bar[i].health <= 0)
                {
                    bar.RemoveAt(i);
                }
            }
            for (int i = 0; i < dft.Count; i++)
            {
                if (dft[i].health <= 0)
                {
                    dft.RemoveAt(i);
                }
            }
            for (int i = 0; i < gt.Count; i++)
            {
                if (gt[i].health <= 0)
                {
                    gt.RemoveAt(i);
                }
            }
            for (int i = 0; i < wfa.Count; i++)
            {
                if (wfa[i].health <= 0)
                {
                    wfa.RemoveAt(i);
                }
            }
        }

        void checkpower()
        {
            if (pbl.Count > 9 && ((dft.Count + gt.Count) - pbl.Count) <= 3)
            {
                pi = 3;
                ptf = 1;
            }
            else if (pbl.Count > 5 && ((dft.Count + gt.Count) - pbl.Count) <= 3)
            {
                pi = 2;
                ptf = 1;
            }
            else
            {
                pi = 1;
                ptf = 0;
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (scene==4)
            {
                cs -= 5;
            }
            if (scene==2)
            {
                for (int i=0;i<sco.Count;i++)
                {
                    sco[i].start += 5;
                }
            }
            if (scene == 1)
            {
                if (counttick % 100 == 0)
                {
                    Createvehickle();
                }
                if (counttick % 700 == 0)
                {
                    nukesuperweapontimer();
                }
                attack();
                tabkmove();
                if (counttick % 1000 == 0)
                {
                    ionsupeerweapontimer();
                }
                if (counttick % 5 == 0)
                {
                    construction();
                }
                if (counttick % 200 == 0 && refi.Count > 0)
                {
                    money += 10 * refi.Count;
                }
                checkbuildingshealth();
                checkhealth();
                checkradis();
                cursor_scrolling();
                checkpower();
                for (int i=0;i<tank1.Count;i++)
                {
                    if (tank1[i].posx<=0)
                    {
                        using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"D://Cs//CS 232//Assignments//Big game//Sources//Scores.txt", true))
                        {
                            file.WriteLine(score.ToString());
                        }
                        MessageBox.Show("You Lost");
                        scene = 0;
                        current = 0;
                    }
                }
            }
            counttick++;
            drawbuffer(this.CreateGraphics());
        }

        void Sidebarcreate()
        {
            for (int i = 0; i < 8; i++)
            {
                sideicons pnn = new sideicons();
                pnn.startsi = i * 63;
                pnn.temp = new Rectangle(pnn.startsi, 0, 60, 50);
                if (i % 2 == 0)
                {
                    inity += plusmin + 5;
                    pnn.intx = this.ClientSize.Width - 175;
                }
                else
                {
                    pnn.intx = this.ClientSize.Width - 175 + 90;
                }
                pnn.inty = inity;
                pnn.post = new Rectangle(pnn.intx, pnn.inty, 75, 102);
                sic.Add(pnn);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            music = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Music.bmp");
            mon = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Ong.bmp");
            moff = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Off.bmp");
            music.MakeTransparent(Color.White);
            mon.MakeTransparent(Color.White);
            moff.MakeTransparent(Color.White);
            cs = this.ClientSize.Height;
            player.SoundLocation = "D://Cs//CS 232//Assignments//Big game//Sources//Background.wav";
            player.Play();
            bg = new Bitmap(ClientSize.Width, ClientSize.Height);
            map = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Map.bmp");
            sidebar = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//sidebar.bmp");
            pbg = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//power_bar_green.bmp");
            pby = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//power_bar_orange.bmp");
            pbr = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//power_bar_red.bmp");
            pblant = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//power-plant-sprite-sheet.bmp");
            pblant.MakeTransparent(Color.Black);
            sidebaricons = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//icons-sprite-sheet.bmp");
            refinery = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//refinery-sprite-sheet.bmp");
            refinery.MakeTransparent(Color.White);
            barrackes = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//barracks-sprite-sheet.bmp");
            barrackes.MakeTransparent(Color.White);
            defencetower = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//guard-tower-sprite-sheet.bmp");
            defencetower.MakeTransparent(Color.White);
            guntower = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//gun-turret-sprite-sheet.bmp");
            guntower.MakeTransparent(Color.White);
            guntowermove = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//gun-turret-sprite-sheet move.bmp");
            guntowermove.MakeTransparent(Color.White);
            weaponfactory = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//weapons-factory-sprite-sheet.bmp");
            weaponfactory.MakeTransparent(Color.White);
            masknuke = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Mask0.bmp");
            maskion = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Mask0.bmp");
            sell = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//sell1.bmp");
            enemybase = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//EnemyBase.bmp");
            enemybase.MakeTransparent(Color.White);
            back = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Back.bmp");
            credits = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//Credits.bmp");
            credits.MakeTransparent(Color.White);
            for (int i=0;i<8;i++)
            {
                menu pnn=new menu();
                pnn.im = new Bitmap("D://Cs//CS 232//Assignments//Big game//Sources//menu" + i + ".bmp");
                men.Add(pnn);
            }
            string line = "";
            StreamReader st = new StreamReader("D://Cs//CS 232//Assignments//Big game//Sources//Scores.txt");
            while ((line = st.ReadLine()) != null)
            {
                string token = line;
                scores pnn = new scores();
                pnn.sc = token;
                pnn.start = 0;
                sco.Add(pnn);
            }
            st.Close();
            Sidebarcreate();
        }

        void drawbuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(bg);
            drawscene(g2);
            g.DrawImage(bg, 0, 0);
        }
        void drawscene(Graphics g)
        {
            g.Clear(Color.Black);
            if (scene == 0)
            {
                g.DrawImage(men[current].im, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }
            if (scene == 1)
            {
                g.DrawImage(map, mapx, mapy);
                for (int i = 0; i < pbl.Count; i++)
                {
                    pbl[i].post = new Rectangle(pbl[i].intx + mapx, pbl[i].inty + mapy, 50, 50);
                    g.DrawImage(pblant, pbl[i].post, pbl[i].temp, GraphicsUnit.Pixel);
                    g.FillRectangle(Brushes.DarkGreen, pbl[i].post.X, pbl[i].post.Y, pbl[i].health, 3);
                }
                for (int i = 0; i < refi.Count; i++)
                {
                    refi[i].post = new Rectangle(refi[i].intx + mapx, refi[i].inty + mapy, 70, 70);
                    g.DrawImage(refinery, refi[i].post, refi[i].temp, GraphicsUnit.Pixel);
                    g.FillRectangle(Brushes.DarkGreen, refi[i].post.X, refi[i].post.Y, refi[i].health, 3);
                }
                for (int i = 0; i < bar.Count; i++)
                {
                    bar[i].post = new Rectangle(bar[i].intx + mapx, bar[i].inty + mapy, 50, 50);
                    g.DrawImage(barrackes, bar[i].post, bar[i].temp, GraphicsUnit.Pixel);
                    g.FillRectangle(Brushes.DarkGreen, bar[i].post.X, bar[i].post.Y, bar[i].health, 3);
                }
                for (int i = 0; i < dft.Count; i++)
                {
                    dft[i].post = new Rectangle(dft[i].intx + mapx, dft[i].inty + mapy, 50, 50);
                    g.DrawImage(defencetower, dft[i].post, dft[i].temp, GraphicsUnit.Pixel);
                    g.FillRectangle(Brushes.DarkGreen, dft[i].post.X, dft[i].post.Y, dft[i].health, 3);
                }
                for (int i = 0; i < gt.Count; i++)
                {
                    gt[i].post = new Rectangle(gt[i].intx + mapx, gt[i].inty + mapy, 50, 50);
                    if (gt[i].startgt < 375)
                    {
                        g.DrawImage(guntower, gt[i].post, gt[i].temp, GraphicsUnit.Pixel);
                        g.FillRectangle(Brushes.DarkGreen, gt[i].post.X, gt[i].post.Y, gt[i].health, 3);
                    }
                    else
                    {
                        g.DrawImage(guntowermove, gt[i].post, gt[i].temp, GraphicsUnit.Pixel);
                        g.FillRectangle(Brushes.DarkGreen, gt[i].post.X, gt[i].post.Y, gt[i].health, 3);
                    }
                }
                for (int i = 0; i < wfa.Count; i++)
                {
                    wfa[i].post = new Rectangle(wfa[i].intx + mapx, wfa[i].inty + mapy, 50, 50);
                    g.DrawImage(weaponfactory, wfa[i].post, wfa[i].temp, GraphicsUnit.Pixel);
                    g.FillRectangle(Brushes.DarkGreen, wfa[i].post.X, wfa[i].post.Y, wfa[i].health, 3);
                }
                for (int i = 0; i < tank1.Count; i++)
                {
                    g.DrawImage(tank1[i].tank, tank1[i].posx + mapx, tank1[i].posy, 50, 50);
                    g.FillRectangle(Brushes.Red, tank1[i].posx + mapx, tank1[i].posy, tank1[i].health, 3);
                }
                for (int i = 0; i < lase.Count; i++)
                {
                    g.DrawLine(Pens.Blue, lase[i].posxs, lase[i].posys, lase[i].posxe + mapx, lase[i].posye + mapy);
                }
                for (int i = 0; i < lase.Count; i++)
                {
                    lase.RemoveAt(i);
                }
                for (int i = 0; i < lase2.Count; i++)
                {
                    g.DrawLine(Pens.Yellow, lase2[i].posxs, lase2[i].posys, lase2[i].posxe + mapx, lase2[i].posye + mapy);
                }
                for (int i = 0; i < lase2.Count; i++)
                {
                    lase2.RemoveAt(i);
                }
                //enemybase
                //------------------------------------------------------------------------------------------
                g.DrawImage(enemybase, 4000 + mapx, 450 + mapy, 400, 300);
                g.FillRectangle(Brushes.DarkRed, 4000 + mapx, 450 + mapy, enemyhealth, 3);
                //------------------------------------------------------------------------------------------
                //Lazm tb2a a5er wa7da
                //-------------------------------------------------------------------------------------
                g.DrawImage(sidebar, this.ClientSize.Width - 200, 0, 200, this.ClientSize.Height);
                if (pi == 1)
                {
                    g.DrawImage(pbr, this.ClientSize.Width - 200, 750, 20, this.ClientSize.Height - 750);
                }
                if (pi == 2)
                {
                    g.DrawImage(pby, this.ClientSize.Width - 200, 550, 20, 200);
                    g.DrawImage(pbr, this.ClientSize.Width - 200, 750, 20, this.ClientSize.Height - 750);
                }
                if (pi == 3)
                {
                    g.DrawImage(pbg, this.ClientSize.Width - 200, 340, 20, 210);
                    g.DrawImage(pby, this.ClientSize.Width - 200, 550, 20, 200);
                    g.DrawImage(pbr, this.ClientSize.Width - 200, 750, 20, this.ClientSize.Height - 750);
                }
                //icons
                for (int i = 0; i < sic.Count; i++)
                {
                    g.DrawImage(sidebaricons, sic[i].post, sic[i].temp, GraphicsUnit.Pixel);
                    Font drawFont = new Font("Arial", 15);
                    SolidBrush drawBrush = new SolidBrush(Color.Brown);
                    PointF drawPoint = new PointF(sic[i].post.X, sic[i].post.Y);
                    if (i == 0)
                    {
                        g.DrawString("10$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 1)
                    {
                        g.DrawString("5$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 2)
                    {
                        g.DrawString("15$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 5)
                    {
                        g.DrawString("20$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 6)
                    {
                        g.DrawString("25$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 7)
                    {
                        g.DrawString("15$", drawFont, drawBrush, drawPoint);
                    }
                    if (i == 3 && ifl == 0)
                    {
                        g.DrawImage(maskion, sic[i].post.X, sic[i].post.Y, 75, 102);
                    }
                    if (i == 4 && nf == 0)
                    {
                        g.DrawImage(masknuke, sic[i].post.X, sic[i].post.Y, 75, 102);
                    }
                }
                if (fs == 1)
                {
                    g.DrawImage(sell, this.ClientSize.Width - 130, 305, 60, 30);
                }
                //----------------------------------------------------------------------------------------
                Font drawFont2 = new Font("Arial", 15);
                SolidBrush drawBrush2 = new SolidBrush(Color.Yellow);
                PointF drawPoint2 = new PointF(20.0F, 10.0F);
                g.DrawString("Money=" + money.ToString() + "$", drawFont2, drawBrush2, drawPoint2);
                drawFont2 = new Font("Arial", 15);
                drawBrush2 = new SolidBrush(Color.Yellow);
                drawPoint2 = new PointF(20.0F, 30.0F);
                g.DrawString("Score=" + score.ToString(), drawFont2, drawBrush2, drawPoint2);
            }
            if (scene == 2)
            {
                g.DrawImage(back, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
                for (int i = 0; i < sco.Count; i++)
                {
                    Font drawFont2 = new Font("Arial", 50);
                    SolidBrush drawBrush2 = new SolidBrush(Color.MediumVioletRed);
                    PointF drawPoint2 = new PointF(i*800.0F, sco[i].start);
                    g.DrawString("Score"+(i+1).ToString()+": "+sco[i].sc, drawFont2, drawBrush2, drawPoint2);
                }
            }
            if (scene==4)
            {
                g.DrawImage(credits, 0, cs, this.ClientSize.Width, this.ClientSize.Height);
            }
            if (scene==3)
            {
                g.DrawImage(back, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
                g.DrawImage(music, 200, 200, 100, 60);
                g.DrawImage(mon, 300, 200, 100, 60);
                g.DrawImage(moff, 400, 200, 100, 60);
            }
            if (scene==12)
            {
                g.DrawImage(men[current].im, 700, 340);
            }
        }
    }
}
