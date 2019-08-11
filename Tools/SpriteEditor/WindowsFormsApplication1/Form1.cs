using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Bitmap bmpZoom;

        public byte[, , ,] spritepixel;
        public byte[, , ,] SpeccyPaletteF;   //foreground
        public byte[, , ,] SpeccyPaletteB;   //Background
        public byte[, , ,] SpeccyPaletteL;   //Lightness
        AkuSpriteEditor.CompCPC CpcSpriteCompiler;
        AkuSpriteEditor.CompZX ZxSpriteCompiler;
        public byte[, ,] Bak_spritepixel;
        public byte[, ,] Bak_SpeccyPaletteF;   //foreground
        public byte[, ,] Bak_SpeccyPaletteB;   //Background
        public byte[, ,] Bak_SpeccyPaletteL;   //Lightness
        int NextBackup = -1;
        int MinBackup = 0;
        int CurrentBackup = -1;
        public Label[] ColorSelector;
        public Label[,] SpeccySelector;
        public Label[] C64Selector;
        public Label SpeccySample;
        public PictureBoxWithInterpolationMode PicZoom;
        public byte colorLeft = 15;
        public byte colorRight = 0;
        public byte SpeccyColorFore = 7;
        public byte SpeccyColorBack = 0;
        public byte SpeccyColorBright = 0;
        public byte C64Color1 = 0;
        public byte C64Color2 = 0;
        public byte C64Color3 = 0;
        public byte AppleColor = 0;
        public Label AppleSelector;
        public int CurrentSprite = 0;
        public int CurrentBank = 0;
        public int LastBank = 0;
        public Int16[] Spr_Wid;
        public Int16[] Spr_Hei;
        public Int16[] Spr_MinX;
        public Int16[] Spr_MinY;
        public Int16[] Spr_Xoff;
        public Int16[] Spr_Yoff;
        public int BankCount = 8;
        public int UndoBuffers = 10;
        public int[] Spr_Mempos;
        public byte[] Spr_MemposReset;
        public byte[] Spr_FixedSize;
        public int SpriteCount;
        public bool RespondToDrag = false;
        //public int LastSetPixelX, LastSetPixelY; // Used for checking mouse movement
        public Color[] Speccypalettedark = { Color.Black, Color.DarkBlue, Color.DarkRed, Color.DarkMagenta, Color.Green, Color.DarkCyan, Color.YellowGreen, Color.DarkGray, Color.DarkGray, Color.LightGray };
        public Color[] Speccypalette = { Color.Black, Color.Blue, Color.Red, Color.Magenta, Color.Lime, Color.Cyan, Color.Yellow, Color.White, Color.DarkGray, Color.LightGray };

        public Color[] C64palette = { Color.Black, Color.White,
                                           Color.FromArgb(136,0,0),Color.FromArgb(170,255,255),
                                           Color.FromArgb(204,68,204),Color.FromArgb(0,204,85),
                                           Color.FromArgb(0,0,170),Color.FromArgb(238,238,119),

                                           Color.FromArgb(221,136,85),Color.FromArgb(102,68,0),
                                           Color.FromArgb(255,119,119),Color.FromArgb(51,51,51),
                                           Color.FromArgb(119,119,119),Color.FromArgb(170,255,102),
                                           Color.FromArgb(0,136,255),Color.FromArgb(187,187,187),
                                           };

        public Color[] NESpalette = { 
                                           Color.FromArgb(173,173,173),Color.FromArgb(21,95,217),
                                           Color.FromArgb(66,64,255),Color.FromArgb(117,39,254),
                                           Color.FromArgb(160,26,204),Color.FromArgb(183,30,123),
                                           Color.FromArgb(181,49,32),Color.FromArgb(153,78,0),

                                           Color.FromArgb(107,109,0),Color.FromArgb(56,135,0),
                                           Color.FromArgb(13,147,0),Color.FromArgb(0,143,50),
                                           Color.FromArgb(0,124,141),Color.FromArgb(0,0,0),
                                           Color.FromArgb(0,0,0),Color.FromArgb(0,0,0),
                                      
                                           };
        public Color[] MSXpalette = { 
                                           Color.FromArgb(0,0,0),Color.FromArgb(0,0,0),
                                           Color.FromArgb(33,200,66),Color.FromArgb(94,220,120),
                                           Color.FromArgb(84,85,237),Color.FromArgb(124,118,252),
                                           Color.FromArgb(212,82,77),Color.FromArgb(66,235,245),

                                           Color.FromArgb(252,85,84),Color.FromArgb(255,121,120),
                                           Color.FromArgb(212,193,84),Color.FromArgb(230,206,128),
                                           Color.FromArgb(33,176,59),Color.FromArgb(201,91,186),
                                           Color.FromArgb(204,204,204),Color.FromArgb(255,255,255),
                                      
                                           };
        public int backuptimer = 0;
        public int maxSpriteSize = 256;
        public string lastfilename = "";
        public string CurrentTool = "";
        public void InitMaxSpriteSize()
        {
            spritepixel = null;
            SpeccyPaletteF = null;
            SpeccyPaletteB = null;
            SpeccyPaletteL = null;

            Bak_spritepixel = null;
            Bak_SpeccyPaletteF = null;
            Bak_SpeccyPaletteB = null;
            Bak_SpeccyPaletteL = null;
            bmpZoom = null;

            bmpZoom = new Bitmap(maxSpriteSize + 1, maxSpriteSize + 1);

            spritepixel = new byte[BankCount, 64, maxSpriteSize, maxSpriteSize];
            SpeccyPaletteF = new byte[BankCount, 64, maxSpriteSize / 8, maxSpriteSize / 8];
            SpeccyPaletteB = new byte[BankCount, 64, maxSpriteSize / 8, maxSpriteSize / 8];
            SpeccyPaletteL = new byte[BankCount, 64, maxSpriteSize / 8, maxSpriteSize / 8];
            ClearSprites();
            Bak_spritepixel = new byte[UndoBuffers, maxSpriteSize, maxSpriteSize];
            Bak_SpeccyPaletteF = new byte[UndoBuffers, maxSpriteSize / 8, maxSpriteSize / 8];
            Bak_SpeccyPaletteB = new byte[UndoBuffers, maxSpriteSize / 8, maxSpriteSize / 8];
            Bak_SpeccyPaletteL = new byte[UndoBuffers, maxSpriteSize / 8, maxSpriteSize / 8];

        }
        /************************************************************************************************************************************************/

        public Form1()
        {
            InitializeComponent();
            InitMaxSpriteSize();


            Spr_Wid = new Int16[64];
            Spr_Hei = new Int16[64];
            Spr_MinX = new Int16[64];
            Spr_MinY = new Int16[64];
            Spr_MemposReset = new byte[64];
            Spr_FixedSize = new byte[64];
            Spr_Mempos = new int[64];
            Spr_Xoff = new Int16[64];
            Spr_Yoff = new Int16[64];
            ColorSelector = new Label[19];
            SpeccySelector = new Label[11, 2];
            C64Selector = new Label[19];


            PicZoom = new PictureBoxWithInterpolationMode();
            PicZoom.Padding = new Padding(0, 0, 0, 0);
            PicZoom.Top = 0;
            PicZoom.Left = 0;
            PicZoom.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            PicZoom.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            PicZoom.MouseMove += new MouseEventHandler(PicZoom_Drag);
            PicZoom.MouseDown += new MouseEventHandler(PicZoom_Down);
            PicZoom.MouseUp += new MouseEventHandler(PicZoom_Up);

            panel1.Controls.Add(PicZoom);
            PicZoom.Image = bmpZoom;
            picPreview.Image = bmpZoom;
            PicZoom.SizeMode = PictureBoxSizeMode.Zoom;

            for (int i = 0; i <= 63; i++)
            {
                lstSprites.Items.Add(VbX.Right("00" + i.ToString(), 2) + " ");
            }
            lstSprites.SelectedIndex = 0;
            for (int i = 0; i < 19; i++)
            {



                ColorSelector[i] = new Label();
                ColorSelector[i].BorderStyle = BorderStyle.FixedSingle;
                if (i < 16)
                {
                    ColorSelector[i].BackColor = Color.FromArgb(255, i * 16, i * 16, i * 16);
                }
                ColorSelector[i].Name = "Colorselector_" + i.ToString();
                if (i == 16) ColorSelector[i].BackColor = Color.FromArgb(255, 255, 0, 255);
                if (i == 17) ColorSelector[i].BackColor = Color.FromArgb(255, 255, 255, 255);
                if (i == 18) ColorSelector[i].BackColor = Color.FromArgb(255, 0, 0, 0);
                if (i < 16) ColorSelector[i].Text = VbX.Hex(i);
                ColorSelector[i].Width = 32;
                ColorSelector[i].Height = 40;
                ColorSelector[i].Top = 4 + menuStrip1.Height;
                ColorSelector[i].Left = i * 32;
                if (i >= 17) ColorSelector[i].Left += 12;
                ColorSelector[i].MouseDown += new MouseEventHandler(ColorSelector_MouseDown);
                this.Controls.Add(ColorSelector[i]);
            }
            for (int i = 0; i <= 10; i++)
            {

                Label sp = new Label();
                sp.BorderStyle = BorderStyle.FixedSingle;

                sp.Name = "SpeccyBack_" + i.ToString();

                if (i == 8) { sp.Name = "SpeccyDark"; sp.Text = "0"; }
                if (i == 9) { sp.Name = "SpeccyLight"; sp.Text = "64"; }
                if (i < 10)
                {
                    sp.BackColor = Speccypalette[i];
                }



                sp.Width = 32;
                sp.Height = 24;
                sp.Top = 0;

                if (i >= 8)
                {
                    sp.Top += 12;
                }
                else
                {
                    sp.Text = VbX.CStr(i * 8);
                }
                sp.Left = i * 32;// +ColorSelector[18].Left;
                //sp.Left += 32 + 16;
                sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                pnlZXPalette.Controls.Add(sp);
                SpeccySelector[i, 0] = sp;
                if (i < 8)
                {
                    sp = new Label();
                    sp.BorderStyle = BorderStyle.FixedSingle;

                    sp.Text = VbX.CStr(i);
                    sp.BackColor = Speccypalette[i];

                    sp.Name = "SpeccyFore_" + i.ToString();

                    sp.Width = 32;
                    sp.Height = 24;
                    sp.Top = 24;
                    sp.Left = i * 32;// +ColorSelector[18].Left;
                    // sp.Left += 32 + 16;
                    sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                    pnlZXPalette.Controls.Add(sp);
                    SpeccySelector[i, 1] = sp;
                }
            }
            for (int i = 0; i <= 10; i++)
            {

                Label sp = new Label();
                sp.BorderStyle = BorderStyle.FixedSingle;

                sp.Name = "C64Back_" + (i + 8).ToString();

                if (i == 8) { sp.Name = "C64C1"; sp.Text = "C1"; C64Color1 = 1; sp.BackColor = C64palette[1]; }
                if (i == 9) { sp.Name = "C64C2"; sp.Text = "C2"; C64Color2 = 2; sp.BackColor = C64palette[2]; }
                if (i == 10) { sp.Name = "C64C3"; sp.Text = "C3"; C64Color1 = 3; sp.BackColor = C64palette[3]; }
                if (i < 8)
                {
                    sp.BackColor = C64palette[i + 8];
                }

                sp.Width = 32;
                sp.Height = 24;
                sp.Top = 24;

                if (i >= 8)
                {
                    sp.Top -= 12;
                }
                else
                {
                    sp.Text = VbX.CStr(i);
                }
                sp.Left = i * 32;// +ColorSelector[18].Left;
                //sp.Left += 32 + 16;

                //pnlC64pal.Controls.Add(sp);
                // SpeccySelector[i, 0] = sp;

                sp.MouseDown += new MouseEventHandler(C64Selector_MouseDown);
                pnlC64pal.Controls.Add(sp);
                C64Selector[i + 8] = sp;
                if (i < 8)
                {
                    sp = new Label();
                    sp.BorderStyle = BorderStyle.FixedSingle;

                    sp.Text = VbX.CStr(i + 8);
                    sp.BackColor = C64palette[i];

                    sp.Name = "C64Fore_" + (i).ToString();

                    sp.Width = 32;
                    sp.Height = 24;
                    sp.Top = 0;
                    sp.Left = i * 32;// +ColorSelector[18].Left;
                    // sp.Left += 32 + 16;
                    sp.MouseDown += new MouseEventHandler(C64Selector_MouseDown);
                    pnlC64pal.Controls.Add(sp);
                    C64Selector[i] = sp;
                }

            }

            for (int i = 0; i <= 2; i++)
            {

                Label sp = new Label();
                sp.BorderStyle = BorderStyle.FixedSingle;

                sp.Name = "APLBack_" + i.ToString();
                sp.Font = bigfont.Font;
                if (i == 0 || i == 2)
                {
                    sp.BackColor = Color.FromArgb(255, 0, 255);
                    sp.ForeColor = Color.FromArgb(0, 255, 0);


                }
                if (i == 1)
                {
                    sp.BackColor = Color.FromArgb(0, 175, 255);
                    sp.ForeColor = Color.FromArgb(255, 80, 0);
                }


                sp.Width = 32;
                sp.Height = 24;
                sp.Top = 12;
                sp.Left = i * 32;
                if (i < 2)
                {
                    sp.Text = VbX.CStr(i);
                }
                else { sp.Text = "S"; sp.Left += 16; AppleSelector = sp; }
                sp.Left = i * 32;// +ColorSelector[18].Left;
                //sp.Left += 32 + 16;
                sp.MouseDown += new MouseEventHandler(AppleSelector_MouseDown);
                pnlApplePal.Controls.Add(sp);

                // SpeccySelector[i, 0] = sp;


            }
            for (int i = 0; i <= 7; i++)
            {

                Label sp = new Label();
                sp.BorderStyle = BorderStyle.FixedSingle;

                sp.Name = "NESBack_" + i.ToString();

                if (i == 8) { sp.Name = "NESDark"; sp.Text = "0"; }
                if (i == 9) { sp.Name = "NESLight"; sp.Text = "64"; }
                if (i < 10)
                {
                    sp.BackColor = NESpalette[i];
                }



                sp.Width = 32;
                sp.Height = 24;
                sp.Top = 0;

                if (i >= 8)
                {
                    sp.Top += 12;
                }
                else
                {
                    sp.Text = VbX.CStr(i);
                }
                sp.Left = i * 32;// +ColorSelector[18].Left;
                //sp.Left += 32 + 16;
                sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                pnlNESpal.Controls.Add(sp);
                // SpeccySelector[i, 0] = sp;
                if (i < 8)
                {
                    sp = new Label();
                    sp.BorderStyle = BorderStyle.FixedSingle;

                    sp.Text = VbX.CStr(i + 8);
                    sp.BackColor = NESpalette[i + 8];

                    sp.Name = "NESFore_" + i.ToString();

                    sp.Width = 32;
                    sp.Height = 24;
                    sp.Top = 24;
                    sp.Left = i * 32;// +ColorSelector[18].Left;
                    // sp.Left += 32 + 16;
                    sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                    pnlNESpal.Controls.Add(sp);
                    // SpeccySelector[i, 1] = sp;
                }
            }
            for (int i = 0; i <= 7; i++)
            {

                Label sp = new Label();
                sp.BorderStyle = BorderStyle.FixedSingle;

                sp.Name = "MSXBack_" + i.ToString();

                if (i == 8) { sp.Name = "MSXDark"; sp.Text = "0"; }
                if (i == 9) { sp.Name = "MSXLight"; sp.Text = "64"; }
                if (i < 10)
                {
                    sp.BackColor = MSXpalette[i];
                }



                sp.Width = 32;
                sp.Height = 24;
                sp.Top = 0;

                if (i >= 8)
                {
                    sp.Top += 12;
                }
                else
                {
                    sp.Text = VbX.CStr(i);
                }
                sp.Left = i * 32;// +ColorSelector[18].Left;
                //sp.Left += 32 + 16;
                sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                pnlMSXpal.Controls.Add(sp);
                // SpeccySelector[i, 0] = sp;
                if (i < 8)
                {
                    sp = new Label();
                    sp.BorderStyle = BorderStyle.FixedSingle;

                    sp.Text = VbX.CStr(i + 8);
                    sp.BackColor = MSXpalette[i + 8];

                    sp.Name = "MSXFore_" + i.ToString();

                    sp.Width = 32;
                    sp.Height = 24;
                    sp.Top = 24;
                    sp.Left = i * 32;// +ColorSelector[18].Left;
                    // sp.Left += 32 + 16;
                    sp.MouseDown += new MouseEventHandler(SpeccySelector_MouseDown);
                    pnlMSXpal.Controls.Add(sp);
                    // SpeccySelector[i, 1] = sp;
                }
            }
            pnlMSXpal.Location = pnlZXPalette.Location;
            pnlNESpal.Location = pnlZXPalette.Location;
            pnlC64pal.Location = pnlZXPalette.Location;
            pnlApplePal.Location = pnlZXPalette.Location;
            SpeccySampleUpdate();

            btnToolPixelPaint_Click(null, null);
            btnRefresh_Click(null, null);
            trkzoom.Value = 4;
            doscale(trkzoom.Value);



            string recentfile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "") + "\\AkuSprite.recent";
            if (VbX.exists(recentfile))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(recentfile);
                recent1.Text = sr.ReadLine();
                recent2.Text = sr.ReadLine();
                recent3.Text = sr.ReadLine();
                recent4.Text = sr.ReadLine();
                recent5.Text = sr.ReadLine();
                recent6.Text = sr.ReadLine();
                recent7.Text = sr.ReadLine();
                recent8.Text = sr.ReadLine();
                recent9.Text = sr.ReadLine();
                recent10.Text = sr.ReadLine();
                sr.Close();
            }
        }

        /************************************************************************************************************************************************/

        private void doscale(int scale)
        {
            //PicZoom.zoom = scale;
            PicZoom.Width = maxSpriteSize * scale;
            PicZoom.Height = maxSpriteSize * scale;
        }
        /************************************************************************************************************************************************/
        private void ResetBackupTimer()
        {
            backuptimer = 0;
            tmrBackup.Enabled = true;
            btnUndo.Text = "Undo?";

        }
        /************************************************************************************************************************************************/
        private void RepaintArea(int x, int y)
        {

            int xx = x / 8;
            int yy = y / 8;
            xx = xx * 8;
            yy = yy * 8;
            for (int ax = xx; ax < xx + 8; ax++)
            {
                for (int ay = yy; ay < yy + 8; ay++)
                {
                    RepaintPixel(ax, ay);
                }
            }


        }
        /************************************************************************************************************************************************/

        private byte GetDisplayNum(int cb, int cs, int x, int y)
        {
            byte pen = spritepixel[cb, cs, x, y];
            if (rdoSpecDither.Checked)
            {


                int r = ColorSelector[pen].BackColor.R;
                int g = ColorSelector[pen].BackColor.G;
                int b = ColorSelector[pen].BackColor.B;



                g = (r + g + b + g + g);
                g = g / 5;
                if (pen == 0) g = 0;
                if (g < 4) return 0;

                if (g > 256 - 80) return 4;
                if (g < 48) return checkerize(x, y, 0, 4, 2);
                if (g > 256 - 160) return checkerize(x, y, 4, 0, 2);
                return checkerize(x, y, 4, 0, 1);
            }

            if (rdoCPCdither.Checked)
            {

                int r = ColorSelector[pen].BackColor.R;
                int g = ColorSelector[pen].BackColor.G;
                int b = ColorSelector[pen].BackColor.B;



                g = (r + g + b + g + g);



                if (cbo4colorDither.Text == "Alternate")
                {
                    g = (g + 100) / 5;

                    if (pen == 0) g = 0;
                    if (g < 32) return 0;
                    if (g > 150) return 3;
                    g = g / 32;

                }
                else
                {

                    g = g / 5;

                    if (pen == 0) g = 0;
                    if (g < 4) return 0;
                    if (g > 248) return 3;
                    g = g / 32;
                }




                byte col1 = 0;
                byte col2 = 0;

                if (g / 3 == 0) { col1 = 0; col2 = 1; }
                if (g / 3 == 1) { col1 = 1; col2 = 2; }
                if (g / 3 == 2) { col1 = 2; col2 = 3; }

                if (g % 3 == 0) { return checkerize(x, y, col1, col2, 2); }
                if (g % 3 == 1) { return checkerize(x, y, col1, col2, 1); }
                if (g % 3 == 2) { return checkerize(x, y, col2, col1, 2); }

            }

            if (RdoTIquarter.Checked)
            {
                x = x * 2;
                y = y * 2;
                if (x > 255) return 0;
                if (y > 255) return 0;
            }
            if (rdoVic20MultiColor.Checked)
            {
                x = x / 2;
                x = x * 2;

                int pena = spritepixel[cb, cs, x, y];
                int penb = spritepixel[cb, cs, x + 1, y];
                if (pena > 0) pena = 2;
                if (penb > 0) penb = 1;
                pen = (byte)(pena + penb);

            }
            if (rdoDisplayCPC0.Checked || rdoC64_4Color.Checked || rdoAppleColor.Checked || rdoHalfWidthFourColor.Checked)
            {
                x = x / 2;
                x = x * 2;

                pen = spritepixel[cb, cs, x, y];
                byte penb = spritepixel[cb, cs, x + 1, y];


                if (pen == 0) pen = penb;
            }

            if ((rdoCPCpairs.Checked || rdoHalfWidthFourColor.Checked) && pen < 16)
            {
                int p = pen;
                if (p > 3)
                {
                    p = (p - 4) % 2 + 1;
                }
                pen = ((byte)p);
            }
            if (rdoDisplayCPC.Checked && pen < 16)
            {
                int p = pen;
                if (p > 3) p = p % 3 + 1;
                pen = ((byte)p);
            }
            if ((rdoDisplaySpeccy.Checked || RdoTIquarter.Checked) && pen > 0 && pen < 16)
            {

                pen = 1;
            }
            return pen;

        }
        /************************************************************************************************************************************************/
        private Color GetDisplayRGB(int cb, int cs, int x, int y)
        {


            if (cb < 0 || cb > 16) return Color.Black;

            byte pen = GetDisplayNum(cb, cs, x, y);




            int r = ColorSelector[pen].BackColor.R;
            int g = ColorSelector[pen].BackColor.G;
            int b = ColorSelector[pen].BackColor.B;

            if (rdoSpecDither.Checked)
            {
                if (pen == 0) { return Color.FromArgb(0, 0, 0); }
                return Color.FromArgb(255, 255, 255);
            }

            if (rdoCPCdither.Checked)
            {
                if (pen == 0) { return Color.FromArgb(0, 0, 0); }
                if (pen == 1) { return Color.FromArgb(96, 0, 96); }
                if (pen == 2) { return Color.FromArgb(0, 255, 255); }
                if (pen == 3) { return Color.FromArgb(255, 255, 255); }


            }
            if (rdoAppleColor.Checked)
            {
                pen = (byte)(pen % 4);
                if (pen == 0) { return Color.Black; }
                if (SpeccyPaletteF[CurrentBank, CurrentSprite, x / 7, y / 8] == 0)
                {
                    if (pen == 1) { return Color.FromArgb(255, 0, 255); }
                    if (pen == 2) { return Color.FromArgb(0, 255, 0); }
                }
                else
                {
                    if (pen == 1) { return Color.FromArgb(0, 175, 255); }
                    if (pen == 2) { return Color.FromArgb(255, 80, 0); }
                }
                if (pen == 3) { return Color.FromArgb(255, 255, 255); }

            }

            if (rdoC64_4Color.Checked)
            {
                pen = (byte)(pen % 4);
                if (pen == 0) { return ColorSelector[0].BackColor; }
                if (pen == 1) { return C64palette[SpeccyPaletteF[CurrentBank, CurrentSprite, x / 8, y / 8]]; }
                if (pen == 2) { return C64palette[SpeccyPaletteB[CurrentBank, CurrentSprite, x / 8, y / 8]]; }
                if (pen == 3) { return C64palette[SpeccyPaletteL[CurrentBank, CurrentSprite, x / 8, y / 8]]; }

            }
            if ((rdoDisplaySpeccy.Checked || RdoTIquarter.Checked) && pen < 16) // apply the spectrum effect!
            {
                if (ChkBackgroundTestDots.Checked && (x % 4) == 0 && (y % 4) == 0)
                {
                    pen = 1;
                }

                int specb = SpeccyPaletteB[CurrentBank, CurrentSprite, x / 8, y / 8];
                int specf = SpeccyPaletteF[CurrentBank, CurrentSprite, x / 8, y / 8];
                if (SpeccyPaletteL[CurrentBank, CurrentSprite, x / 8, y / 8] == 0)
                {
                    if (pen == 0)
                    {
                        r = Speccypalettedark[specb].R;
                        g = Speccypalettedark[specb].G;
                        b = Speccypalettedark[specb].B;
                    }
                    else
                    {
                        r = Speccypalettedark[specf].R;
                        g = Speccypalettedark[specf].G;
                        b = Speccypalettedark[specf].B;
                    }
                }
                else
                {
                    if (pen == 0)
                    {
                        r = Speccypalette[specb].R;
                        g = Speccypalette[specb].G;
                        b = Speccypalette[specb].B;
                    }
                    else
                    {
                        r = Speccypalette[specf].R;
                        g = Speccypalette[specf].G;
                        b = Speccypalette[specf].B;
                    }
                }

            } // End of spectrum palette tweaks

            return Color.FromArgb(r, g, b);
        }
        /************************************************************************************************************************************************/
        private void RepaintPixel(int x, int y)
        {

            int gridcol1 = 56 / 2;
            int gridcol2 = 64 / 2;
            int gridcol3 = 80 / 2;
            if (chkStrongGrid.Checked)
            {
                gridcol1 = 56;
                gridcol2 = 64;
                gridcol3 = 80;

            }

            Color mycolor = GetDisplayRGB(CurrentBank, CurrentSprite, x, y);

            int r = mycolor.R;
            int g = mycolor.G;
            int b = mycolor.B;

            if (rdoFrameNext.Checked)
            {
                Color mycolor2 = GetDisplayRGB(CurrentBank + 1, CurrentSprite, x, y);
                r = (int)(((float)r) * .7 + mycolor2.R * .3);
                g = (int)(((float)g) * .7 + mycolor2.G * .3);
                b = (int)(((float)b) * .7 + mycolor2.B * .3);
            }


            if (rdoFrameLast.Checked)
            {
                Color mycolor2 = GetDisplayRGB(CurrentBank - 1, CurrentSprite, x, y);
                r = (int)(((float)r) * .7 + mycolor2.R * .3);
                g = (int)(((float)g) * .7 + mycolor2.G * .3);
                b = (int)(((float)b) * .7 + mycolor2.B * .3);
            }



            int rx = 0;
            int gx = 0;
            int bx = 0;




            if (!rdoGuideNone.Checked)
            {
                if (rdoC64Sprite.Checked)
                {
                    if (((x / 8) % 2) == 0) rx = gridcol2;
                    if (((y / 7) % 2) == 0)
                    {
                        if (rx == gridcol2) rx = 0; else rx = gridcol2;
                    }
                }
                if (rdoGuide4_8_32.Checked || rdoGuide4_8_24.Checked)
                {
                    if (((x / 8) % 2) == 0) rx = gridcol2;
                    if (((y / 8) % 2) == 0)
                    {
                        if (rx == gridcol2) rx = 0; else rx = gridcol2;
                    }
                }
                if (rdoGuide7_14_28.Checked)
                {

                    if (((x / 7) % 2) == 0) rx = gridcol2;
                    if (((y / 7) % 2) == 0)
                    {
                        if (rx == gridcol2) rx = 0; else rx = gridcol2;
                    }

                    if (((x / 28) % 2) == 0) gx = gridcol1;
                    if (((y / 28) % 2) == 0)
                    {
                        if (gx == 0) gx = gridcol1; else gx = 0;
                    }
                    if (((x / 7) % 2) == 0) bx = gridcol3;
                }
                if (rdoC64Sprite.Checked)
                {
                    if (((x / 24) % 2) == 0) gx = gridcol1;
                    if (((y / 21) % 2) == 0)
                    {
                        if (gx == 0) gx = gridcol1; else gx = 0;
                    }
                    if (((x / 4) % 2) == 0) bx = gridcol3;
                }
                if (rdoGuide4_8_24.Checked)
                {
                    if (((x / 24) % 2) == 0) gx = gridcol1;
                    if (((y / 24) % 2) == 0)
                    {
                        if (gx == 0) gx = gridcol1; else gx = 0;
                    }
                    if (((x / 4) % 2) == 0) bx = gridcol3;
                }

                if (rdoGuide4_8_32.Checked)
                {
                    if (((x / 32) % 2) == 0) gx = gridcol1;
                    if (((y / 32) % 2) == 0)
                    {
                        if (gx == 0) gx = gridcol1; else gx = 0;
                    }
                    if (((x / 4) % 2) == 0) bx = gridcol3;
                }



            }



            r = (int)(((double)r) * 1) + rx;
            g = (int)(((double)g) * 1) + gx;
            b = (int)(((double)b) * 1) + bx;



            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            bmpZoom.SetPixel(x + 1, y + 1, Color.FromArgb(255, r, g, b));
        }

        /************************************************************************************************************************************************/

        private byte checkerize(int x, int y, byte col1, byte col2, int pattern)
        {
            int c = 1;
            if (pattern == 1)
            {
                if (x % 2 == 1) c = 1 - c;
                if (y % 2 == 1) c = 1 - c;
            }
            if (pattern == 2)
            {
                if (x % 2 == y % 4 && y % 2 == 1) c = 1 - c;
            }
            if (pattern == 3)
            {
                if (x % 2 == 1) c = 1 - c;
                if (y % 2 == 1) c = 1 - c;
                c = 1 - c;
            }
            if (c == 1) return col1; else return col2;

        }
        /************************************************************************************************************************************************/
        private void PicZoom_Up(object sender, EventArgs e)
        {
            RespondToDrag = false;
        }
        private void PicZoom_Down(object sender, EventArgs e)
        {
            RespondToDrag = true;
            PicZoom_Drag(sender, e);
        }
        private void PicZoom_Drag(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            tabControl1.Focus();

            if (RespondToDrag == false) return;
            int chkr = 0;
            if (cboCheckMode.Text == "1/3") chkr = 1;
            if (cboCheckMode.Text == "2/3") chkr = 2;
            if (cboCheckMode.Text == "3/3") chkr = 3;

            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                float scale = trkzoom.Value;
                float halfscale = scale / 2;
                float fx = (mouseEventArgs.X - halfscale) * maxSpriteSize;
                float fy = (mouseEventArgs.Y - halfscale) * maxSpriteSize;
                fx = fx / ((maxSpriteSize - 1) * scale);
                fy = fy / ((maxSpriteSize - 1) * scale);

                int x = (int)fx;//((mouseEventArgs.X - halfscale)) / scale;
                int y = (int)fy;//((mouseEventArgs.Y - halfscale)) / scale;


                //  VbX.MsgBox(mouseEventArgs.X.ToString());
                if (x > (maxSpriteSize - 1)) x = (maxSpriteSize - 1);
                if (y > (maxSpriteSize - 1)) y = (maxSpriteSize - 1);


                //x=x-1;
                //y=y-1;
                if (x < 0 || y < 0 || x > (maxSpriteSize - 1) || y > (maxSpriteSize - 1)) return;

                if (mouseEventArgs.Button == MouseButtons.Middle || mouseEventArgs.Button == MouseButtons.XButton1)
                {
                    colorLeft = spritepixel[CurrentBank, CurrentSprite, x, y];
                    ColorSelector[17].BackColor = ColorSelector[colorLeft].BackColor;
                    return;
                }
                if (mouseEventArgs.Button == MouseButtons.XButton2)
                {
                    colorRight = spritepixel[CurrentBank, CurrentSprite, x, y];
                    ColorSelector[18].BackColor = ColorSelector[colorRight].BackColor;
                    return;
                }

                //if (LastSetPixelX == x && LastSetPixelY == y)
                //{                    return;                }



                ///////// Do color swap
                if (CurrentTool == "colorswap")
                {



                    int minsprite = CurrentSprite;
                    int maxsprite = CurrentSprite;
                    int sx = 0; int sy = 0; int dx = maxSpriteSize; int dy = maxSpriteSize;
                    if (cboColorConvertMode.Text == "AllSprites")
                    { minsprite = 0; maxsprite = 63; }
                    if (cboColorConvertMode.Text == "Block")
                    {
                        sx = x / 8; sx *= 8;
                        sy = y / 8; sy *= 8;
                        dx = sx + 8;
                        dy = sy + 8;
                    }
                    int fromcol = spritepixel[CurrentBank, CurrentSprite, x, y];
                    int colmode = -1;


                    if (mouseEventArgs.Button == MouseButtons.Left) colmode = 1;
                    if (mouseEventArgs.Button == MouseButtons.Right) colmode = 2;
                    if (colmode < 0) return;

                    chkr = 0;
                    if (cboFillCheck.Text == "1/3") chkr = 1;
                    if (cboFillCheck.Text == "2/3") chkr = 2;
                    if (cboFillCheck.Text == "3/3") chkr = 3;
                    // To avoid problems with swaping colors to check patterns, we first swap to temp color 255, then swap that to the destination colors
                    DoColorSwap(minsprite, maxsprite, sx, sy, dx, dy, fromcol, colmode, 255, 255, 0);
                    DoColorSwap(minsprite, maxsprite, sx, sy, dx, dy, 255, colmode, colorLeft, colorRight, chkr);
                    //LastSetPixelX = x;
                    //LastSetPixelY = y;
                    btnRefresh_Click(sender, e);
                    ForceBackup();
                    return;

                }    ///////// Do color swap



                if (mouseEventArgs.Button == MouseButtons.Left)
                {

                    float rx = (mouseEventArgs.X - halfscale) * maxSpriteSize;
                    float ry = (mouseEventArgs.Y - halfscale) * maxSpriteSize;
                    rx = rx / ((maxSpriteSize - 1) * scale) - x;
                    ry = ry / ((maxSpriteSize - 1) * scale) - y;
                    if ((ry < .20 || ry > .80 || rx < .20 || rx > .80) && scale >= 3)
                    {   // didn't hit center
                        //  VbX.MsgBox(rx.ToString() + " " + ry.ToString());
                        return;
                    }

                    ResetBackupTimer();
                    if (CurrentTool != "zxpaint" || cboZxPaintMode.Text != "Colors")
                    {
                        spritepixel[CurrentBank, CurrentSprite, x, y] = checkerize(x, y, colorLeft, colorRight, chkr);
                    }


                    if (CurrentTool != "zxpaint" || cboZxPaintMode.Text != "PixelMap")
                    {
                        if (pnlZXPalette.Visible)
                        {

                            SpeccyPaletteF[CurrentBank, CurrentSprite, x / 8, y / 8] = SpeccyColorFore;
                            SpeccyPaletteB[CurrentBank, CurrentSprite, x / 8, y / 8] = SpeccyColorBack;
                            SpeccyPaletteL[CurrentBank, CurrentSprite, x / 8, y / 8] = SpeccyColorBright;
                        }
                        if (pnlC64pal.Visible)
                        {
                            SpeccyPaletteF[CurrentBank, CurrentSprite, x / 8, y / 8] = C64Color1;
                            SpeccyPaletteB[CurrentBank, CurrentSprite, x / 8, y / 8] = C64Color2;
                            SpeccyPaletteL[CurrentBank, CurrentSprite, x / 8, y / 8] = C64Color3;
                        }
                        if (pnlApplePal.Visible)
                        {
                            SpeccyPaletteF[CurrentBank, CurrentSprite, x / 7, y / 8] = AppleColor;

                        }
                    }
                    //LastSetPixelX = x;
                    //LastSetPixelY = y;
                    RepaintArea(x, y);

                    //bmpZoom.SetPixel(x,y,Color.FromArgb(255, 255, 255, 0));
                    PicZoom.Image = bmpZoom;
                    picPreview.Image = bmpZoom;
                }
                if (mouseEventArgs.Button == MouseButtons.Right)
                {
                    ResetBackupTimer();
                    spritepixel[CurrentBank, CurrentSprite, x, y] = checkerize(x, y, colorRight, colorLeft, chkr); ;
                    RepaintArea(x, y);

                    //   bmpZoom.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    PicZoom.Image = bmpZoom;
                    picPreview.Image = bmpZoom;
                }


            }
        }
        /************************************************************************************************************************************************/

        private void DoColorSwap(int minsprite, int maxsprite, int sx, int sy, int dx, int dy, int fromcol, int colmode, byte colLeft, byte colRight, int chkr)
        {

            for (int cs = minsprite; cs <= maxsprite; cs++)
            {
                for (int x = sx; x < dx; x++)
                {
                    for (int y = sy; y < dy; y++)
                    {
                        if (spritepixel[CurrentBank, cs, x, y] == fromcol)
                        {
                            if (colmode == 1)
                                spritepixel[CurrentBank, cs, x, y] = checkerize(x, y, colLeft, colRight, chkr);
                            else
                                spritepixel[CurrentBank, cs, x, y] = checkerize(x, y, colRight, colLeft, chkr);
                        }
                    }
                }
            }
        }
        /************************************************************************************************************************************************/

        private void AppleSelector_MouseDown(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            byte i = (byte)VbX.CInt(ss.GetItem(((Label)sender).Name, "_", 1));

            if (i < 2)
            {
                AppleColor = i;
                AppleSelector.BackColor = ((Label)sender).BackColor;
                AppleSelector.ForeColor = ((Label)sender).ForeColor;
            }

        }
        /************************************************************************************************************************************************/

        private void SpeccySelector_MouseDown(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            byte i = (byte)VbX.CInt(ss.GetItem(((Label)sender).Name, "_", 1));
            String cmd = ss.GetItem(((Label)sender).Name, "_", 0);

            if (i == 10)
            {
                i = SpeccyColorBack;
                SpeccyColorBack = SpeccyColorFore;
                SpeccyColorFore = i;
                SpeccySampleUpdate();
                return;
            }


            switch (cmd)
            {
                case "SpeccyBack":
                    SpeccyColorBack = i;
                    break;
                case "SpeccyFore":
                    SpeccyColorFore = i;
                    break;
                case "SpeccyDark":
                    SpeccyColorBright = 0;
                    break;
                case "SpeccyLight":
                    SpeccyColorBright = 1;
                    break;

            }

            SpeccySampleUpdate();

        }

        /************************************************************************************************************************************************/

        private void C64Selector_MouseDown(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            byte i = (byte)VbX.CInt(ss.GetItem(((Label)sender).Name, "_", 1));
            String cmd = ss.GetItem(((Label)sender).Name, "_", 0);



            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                C64Selector[16].BackColor = C64Selector[i].BackColor;
                C64Color1 = i;
            }
            if (mouseEventArgs.Button == MouseButtons.Middle)
            {
                C64Selector[17].BackColor = C64Selector[i].BackColor;
                C64Color2 = i;
            }
            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                C64Selector[18].BackColor = C64Selector[i].BackColor;
                C64Color3 = i;
            }


        }

        /************************************************************************************************************************************************/

        private void SpeccySampleUpdate()
        {
            Label sample = SpeccySelector[10, 0];
            if (SpeccyColorBright == 0)
            {
                sample.BackColor = Speccypalettedark[SpeccyColorBack];
                sample.ForeColor = Speccypalettedark[SpeccyColorFore];
            }
            if (SpeccyColorBright == 1)
            {
                sample.BackColor = Speccypalette[SpeccyColorBack];
                sample.ForeColor = Speccypalette[SpeccyColorFore];
            }

            sample.Text = "ABC";
            sample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        /************************************************************************************************************************************************/

        private void ColorSelector_MouseDown(object sender, EventArgs e)
        {
            byte i = (byte)VbX.CInt(ss.GetItem(((Label)sender).Name, "_", 1));
            if (VbX.Right(btnSetPal.Text, 1) == "?")
            { //redefine this color
                ColorDialog colorDlg = new ColorDialog();

                colorDlg.FullOpen = true;
                colorDlg.Color = ColorSelector[i].BackColor;
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    ColorSelector[i].BackColor = colorDlg.Color;
                }
                btnRefresh_Click(sender, e);
                return;
            }
            if (VbX.Right(btnSetPal.Text, 1) == "#")
            { //redefine this color

                string NewCol = VbX.InputBox("Select a color from -GRB", "Enter a color def in -GRB format (0-F)", "0");

                if (NewCol.Length == 4)
                {

                    ColorSelector[i].BackColor = Color.FromArgb(VbX.HexToInt(NewCol.Substring(2, 1)) * 16, VbX.HexToInt(NewCol.Substring(1, 1)) * 16, VbX.HexToInt(NewCol.Substring(3, 1)) * 16);
                }
                btnRefresh_Click(sender, e);
                return;
            }




            var mouseEventArgs = e as MouseEventArgs;

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                colorRight = i;
                ColorSelector[18].BackColor = ColorSelector[i].BackColor;
            }
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                colorLeft = i;
                ColorSelector[17].BackColor = ColorSelector[i].BackColor;
            }

        }
        /************************************************************************************************************************************************/

        private void trkzoom_Scroll(object sender, EventArgs e)
        {
            doscale(trkzoom.Value);
        }
        /************************************************************************************************************************************************/
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstSprites.SelectedIndex = CurrentSprite;

            for (int x = 0; x < maxSpriteSize; x++)
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    RepaintPixel(x, y);

                }
            PicZoom.Image = bmpZoom;
            picPreview.Image = bmpZoom;
            SpriteStats(CurrentSprite);
            lblSpriteInfo.Text = "(" + Spr_MinX[CurrentSprite].ToString() + "," + Spr_MinY[CurrentSprite].ToString() + ") - (" + Spr_Wid[CurrentSprite].ToString() + "," + Spr_Hei[CurrentSprite].ToString() + ")";
            int vpos = 0;
            for (int i = 0; i < CurrentSprite; i++)
            {
                vpos += Spr_Hei[i];
            }
            lblSpriteInfo.Text += "   Vpos:" + VbX.CStr(vpos);

            lblSpriteInfo.Text += VbX.Chr(13) + VbX.Chr(10) + "Sprites:" + SpriteCount.ToString();

            lblMaxSpritesByOffset.Text = VbX.CStr(VbX.Val(txtSpriteDataOffSet.Text) / 6);
            this.Text = "AkuSprite Editor -  Sprite:" + CurrentSprite.ToString() + "  Bank:" + CurrentBank.ToString() + " - File: [" + lastfilename + "]";

        }
        /************************************************************************************************************************************************/

        private void SpriteStats(int i)
        {
            if (Spr_FixedSize[i] > 0)
            {
                if ((i + 1) > SpriteCount) SpriteCount = i + 1;
                return;
            }
            Spr_Wid[i] = 0;
            Spr_Hei[i] = 0;
            Spr_MinX[i] = (Int16)maxSpriteSize;
            Spr_MinY[i] = (Int16)maxSpriteSize;
            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    // RepaintPixel(x, y);
                    if (spritepixel[CurrentBank, i, x, y] != 0)
                    {
                        if (x >= Spr_Wid[i]) Spr_Wid[i] = (Int16)(x + 1);
                        if (y >= Spr_Hei[i]) Spr_Hei[i] = (Int16)(y + 1);
                        if (x < Spr_MinX[i]) Spr_MinX[i] = (Int16)x;
                        if (y < Spr_MinY[i]) Spr_MinY[i] = (Int16)y;
                        if ((i + 1) > SpriteCount) SpriteCount = i + 1;
                    }

                }
            }

        }

        /************************************************************************************************************************************************/
        private void lstSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CurrentSprite = VbX.Val(ss.GetItem(lstSprites.Text, " ", 0));
            //if (this.Visible==true)            btnRefresh_Click(sender, e);
            //ForceBackup();
            ChangeCurrentSprite();
        }
        /************************************************************************************************************************************************/

        private void btnSetPal_Click(object sender, EventArgs e)
        {
            if (VbX.Right(btnSetPal.Text, 1) == "?")
            {
                btnSetPal.Text = "SetPal #";
                btnSetPal.BackColor = Color.LightGreen;
            }
            else if (VbX.Right(btnSetPal.Text, 1) == "#")
            {
                btnSetPal.Text = "SetPal  ";
                btnSetPal.BackColor = SystemColors.ButtonFace;
            }
            else
            {
                btnSetPal.Text = "SetPal ?";
                btnSetPal.BackColor = Color.LightBlue;
            }
        }
        /************************************************************************************************************************************************/
        private void rdoDisplayMSX_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void rdoDisplayCPC_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void rdoDisplaySpeccy_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void Togglebutton(Button b)
        {
            if (b.Text.Substring(0, 1) == "[")
            {
                b.Text = b.Text.Replace("[", "").Replace("]", "");
            }
            else
            {
                b.Text = "[" + b.Text + "]";
            }
        }
        /************************************************************************************************************************************************/
        private void ForceBackup()
        {
            backuptimer = 99999;
            tmrBackup.Enabled = true;
            btnUndo.Text = "Undo (F)";
        }
        /************************************************************************************************************************************************/
        private void tmrBackup_Tick(object sender, EventArgs e)
        {

            backuptimer += 100;
            if (backuptimer > 1000)
            {
                backuptimer = 0;

                btnUndo.Text = "Undo ";
                tmrBackup.Enabled = false;

                CurrentBackup = CurrentBackup + 1;
                if (CurrentBackup >= UndoBuffers)
                {
                    CurrentBackup = 0;
                    MinBackup = -1;
                }
                MakeBackup(CurrentBackup);

                NextBackup = CurrentBackup;
            }
        }
        /************************************************************************************************************************************************/
        private void MakeBackup(int i)
        {

            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    Bak_spritepixel[i, x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }


            }
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    Bak_SpeccyPaletteF[i, x, y] = SpeccyPaletteF[CurrentBank, CurrentSprite, x, y];
                    Bak_SpeccyPaletteB[i, x, y] = SpeccyPaletteB[CurrentBank, CurrentSprite, x, y];
                    Bak_SpeccyPaletteL[i, x, y] = SpeccyPaletteL[CurrentBank, CurrentSprite, x, y];
                }
            }
        }
        /************************************************************************************************************************************************/
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (MinBackup == CurrentBackup) return;
            int cb = CurrentBackup;
            CurrentBackup -= 1;
            if (CurrentBackup < 0) CurrentBackup = UndoBuffers - 1;
            if (CurrentBackup == NextBackup)
            {
                CurrentBackup = cb;
                return;
            }
            RestoreBackup(CurrentBackup);
        }
        /************************************************************************************************************************************************/

        private void RestoreBackup(int i)
        {

            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = Bak_spritepixel[i, x, y];
                }

            }
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = Bak_SpeccyPaletteF[i, x, y];
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = Bak_SpeccyPaletteB[i, x, y];
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = Bak_SpeccyPaletteL[i, x, y];
                }
            }
            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (CurrentBackup == NextBackup) return;
            CurrentBackup += 1;
            if (CurrentBackup > 9) CurrentBackup = 0;
            RestoreBackup(CurrentBackup);
        }
        /************************************************************************************************************************************************/
        private void btnLastSprite_Click(object sender, EventArgs e)
        {
            SaveSpriteDetails(-1);
            if (lstSprites.SelectedIndex == 0) return;
            lstSprites.SelectedIndex = lstSprites.SelectedIndex - 1;
            // CurrentSprite = VbX.Val(ss.GetItem(lstSprites.Text, " ", 0));
            //if (this.Visible == true) btnRefresh_Click(sender, e);
            //ResetBackup();
            //  ChangeCurrentSprite();
        }
        /************************************************************************************************************************************************/
        private void ResetBackup()
        {
            MinBackup = 0;
            NextBackup = -1;
            CurrentBackup = -1;
            ForceBackup();
        }
        /************************************************************************************************************************************************/
        private void btnNextSprite_Click(object sender, EventArgs e)
        {
            SaveSpriteDetails(-1);
            // if (lstSprites.SelectedIndex == 0) return;
            lstSprites.SelectedIndex = lstSprites.SelectedIndex + 1;
            //  ChangeCurrentSprite();
        }
        /************************************************************************************************************************************************/
        private void ChangeCurrentSprite()
        {
            CurrentSprite = VbX.Val(ss.GetItem(lstSprites.Text, " ", 0));
            if (Spr_MemposReset[CurrentSprite] == 0) chkAligned.Checked = false; else chkAligned.Checked = true;
            if (Spr_FixedSize[CurrentSprite] == 0) chkFixedSize.Checked = false; else chkFixedSize.Checked = true;
            txtSpriteSettings.Text = Spr_Xoff[CurrentSprite].ToString();
            if (this.Visible == true) btnRefresh_Click(null, null);
            ResetBackup();
            if (CurrentBank > LastBank) LastBank = CurrentBank;


        }
        /************************************************************************************************************************************************/

        private void SaveSpriteDetails(int s)
        {

            if (s == -1) s = lstSprites.SelectedIndex;
            string spritedescr = s.ToString() + " ";
            spritedescr += Spr_Wid[s].ToString() + "x";
            spritedescr += Spr_Hei[s].ToString() + "   ";
            spritedescr += Spr_MinX[s].ToString() + "/";
            spritedescr += Spr_MinY[s].ToString();
            spritedescr += Spr_Hei[s].ToString() + "   ";
            spritedescr += Spr_Xoff[s].ToString() + "/";
            spritedescr += Spr_Yoff[s].ToString();
            lstSprites.Items[s] = spritedescr;


        }
        /************************************************************************************************************************************************/

        private void ClearSprites()
        {
            txtSpriteDataOffSet.Text = "&180";

            for (int b = 0; b < BankCount; b++)
            {
                for (int s = 0; s < 64; s++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        for (int y = 0; y < 32; y++)
                        {
                            SpeccyPaletteF[b, s, x, y] = 7;
                            SpeccyPaletteB[b, s, x, y] = 0;
                            SpeccyPaletteL[b, s, x, y] = 1;
                        }
                    }

                    for (int x = 0; x < 255; x++)
                    {
                        for (int y = 0; y < 255; y++)
                        {
                            spritepixel[b, s, x, y] = 0;

                        }
                    }
                }
            }
        }
        /************************************************************************************************************************************************/

        private void ClearSpritesCurrentBank()
        {
            int b = CurrentBank;
            for (int s = 0; s < 64; s++)
            {
                for (int x = 0; x < 32; x++)
                {
                    for (int y = 0; y < 32; y++)
                    {
                        SpeccyPaletteF[b, s, x, y] = 7;
                        SpeccyPaletteB[b, s, x, y] = 0;
                        SpeccyPaletteL[b, s, x, y] = 1;
                    }
                }

                for (int x = 0; x < 255; x++)
                {
                    for (int y = 0; y < 255; y++)
                    {
                        spritepixel[b, s, x, y] = 0;

                    }
                }
            }

        }


        /************************************************************************************************************************************************/


        private void loadSpectrumScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Speccy Screen (*.scr)|*.scr";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            ClearSprites();
            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            System.IO.BinaryReader BR = new System.IO.BinaryReader(ST);
            byte b = 0;
            if (chkHasDosHeader.Checked)
            {
                for (int i = 0; i < 128; i++)
                {
                    //skip header
                    b = BR.ReadByte();
                }
            }
            int yy = 0;
            int x = 0;

            for (int by = 0; by < (256 * 192) / 8; by++)
            {
                int y1 = yy % 8 * 8;
                int y2 = (yy % 64) / 8;
                int y3 = (yy / 64) * 64;
                int y = y1 + y2 + y3;

                b = BR.ReadByte();
                int b1 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(0, 1));
                int b2 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(1, 1));
                int b3 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(2, 1));
                int b4 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(3, 1));
                int b5 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(4, 1));
                int b6 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(5, 1));
                int b7 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(6, 1));
                int b8 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(7, 1));
                spritepixel[CurrentBank, CurrentSprite, x + 0, y] = (byte)b1;
                spritepixel[CurrentBank, CurrentSprite, x + 1, y] = (byte)b2;
                spritepixel[CurrentBank, CurrentSprite, x + 2, y] = (byte)b3;
                spritepixel[CurrentBank, CurrentSprite, x + 3, y] = (byte)b4;
                spritepixel[CurrentBank, CurrentSprite, x + 4, y] = (byte)b5;
                spritepixel[CurrentBank, CurrentSprite, x + 5, y] = (byte)b6;
                spritepixel[CurrentBank, CurrentSprite, x + 6, y] = (byte)b7;
                spritepixel[CurrentBank, CurrentSprite, x + 7, y] = (byte)b8;
                x = x + 8;
                if (x == 256) { x = 0; yy++; }
            }
            for (int y2 = 0; y2 < 24; y2++)
            {
                for (int x2 = 0; x2 < 32; x2++)
                {
                    b = BR.ReadByte();
                    int b1 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(1, 1));
                    int b2 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(2, 3));
                    int b3 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(5, 3));

                    SpeccyPaletteB[CurrentBank, CurrentSprite, x2, y2] = (byte)b2;
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x2, y2] = (byte)b3;
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x2, y2] = (byte)b1;

                }
            }

            BR.Close();
            VbX.MsgBox("Loaded");
            rdoDisplaySpeccy.Checked = true;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveSpectrumBinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "ZXS Binary Sprite (*.SPR)|*.SPR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            SaveSpectrum(fd.FileName, true);
        }

        /************************************************************************************************************************************************/

        private void saveMSXASMPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveASMPaletteToolStripMenuItem_Click(sender, e);

            /*
             string nl = VbX.Chr(13) + VbX.Chr(10);
             StringBuilder SR = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {

                SR.Append("defb ");
                SR.Append("%0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.R).Substring(0, 3));
                SR.Append("0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.B).Substring(0, 3));
                SR.Append(",%00000" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.G).Substring(0, 3));
                SR.Append(";" + VbX.CStr(i) + "  -RRR-BBB,-----GGG");
                SR.Append(nl);
            }
            Clipboard.SetText(SR.ToString());
            VbX.MsgBox("Copied to Clipboard");
             
            tabControl1.SelectedTab = tabControl1.TabPages[0];
             */
        }

        /************************************************************************************************************************************************/

        private void saveMSXBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MSX Binary Sprite (*.SPR)|*.SPR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            byte b = 0;
            int bytepos = 0;
            int thisspritebytepos = firstspritepos;

            for (int s = 0; s < SpriteCount; s++)
            {
                BW.Write((Byte)Spr_Hei[s]);
                BW.Write((Byte)((Spr_Wid[s] + 1) / 2));
                BW.Write((Byte)Spr_Yoff[s]);
                BW.Write((Byte)Spr_Xoff[s]);

                UInt16 mp = (UInt16)(thisspritebytepos);
                thisspritebytepos = thisspritebytepos + ((Spr_Hei[s] - Spr_MinY[s]) * ((Spr_Wid[s] + 1) / 2));
                BW.Write(mp);
                bytepos += 6;
            }
            while (bytepos < firstspritepos)
            {
                bytepos++;
                BW.Write((Byte)(0));
            }




            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {
                for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y++)
                {
                    for (int x = 0; x < Spr_Wid[spritenum]; x += 2)
                    {
                        int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                        int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];



                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;


                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);



                        //int b1 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(0, 1) + VbX.Dec2Bin8Bit(b).Substring(4, 1));
                        //int b3 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(1, 1) + VbX.Dec2Bin8Bit(b).Substring(5, 1));
                        //int b2 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(2, 1) + VbX.Dec2Bin8Bit(b).Substring(6, 1));
                        //int b4 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(3, 1) + VbX.Dec2Bin8Bit(b).Substring(7, 1));

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));



                    }
                }


            }

            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/


        private void pasteZXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string response = VbX.InputBox("Replace Sprite", "Replace Sprite", "yes/no");
            if (response != "*yes*") return;


            Bitmap clipbit = (Bitmap)Clipboard.GetImage();
            if (clipbit == null) return;
            for (int x = 0; x < maxSpriteSize; x += 8)
            {
                for (int y = 0; y < maxSpriteSize; y += 8)
                {
                    string[] ccol = new string[maxSpriteSize];
                    int[] cct = new int[maxSpriteSize];
                    int bestcolnum = 0;
                    string bestcol = "";
                    int bestcolnum2 = 0;
                    string bestcol2 = "";
                    for (int xx = x; xx < x + 8; xx++)
                    {
                        for (int yy = y; yy < y + 8; yy++)
                        {
                            Color c = Color.Black;

                            if (y < clipbit.Height && x < clipbit.Width)
                            {
                                c = clipbit.GetPixel(xx, yy);
                            }

                            int r = c.R / 16;
                            int g = c.G / 16;
                            int b = c.B / 16;
                            string thiscol = VbX.Hex(r) + VbX.Hex(g) + VbX.Hex(b);
                            for (int i = 0; i < maxSpriteSize; i++)
                            {
                                if (ccol[i] == thiscol)
                                {
                                    cct[i]++;
                                    if (cct[i] > bestcolnum)
                                    {
                                        bestcol = thiscol;
                                        bestcolnum = cct[i];
                                    }
                                    else if (cct[i] > bestcolnum2)
                                    {
                                        bestcol2 = thiscol;
                                        bestcolnum2 = cct[i];

                                    }
                                }
                                if (ccol[i] == "" || ccol[i] == null)
                                {
                                    cct[i]++;
                                    ccol[i] = thiscol;
                                    if (cct[i] > bestcolnum)
                                    {
                                        bestcol = thiscol;
                                        bestcolnum = cct[i];
                                    }

                                }
                                i = 1024;
                            }
                        }
                    }
                    // VbX.MsgBox(bestcol + "  " + bestcolnum);
                    byte c1 = 1;
                    byte c0 = 0;
                    if (((VbX.Val("&0" + bestcol) < VbX.Val("&0" + bestcol2))) || bestcol == "000")
                    {

                        c1 = 0;
                        c0 = 1;
                    }


                    SpeccyPaletteB[CurrentBank, CurrentSprite, x / 8, y / 8] = 0;
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x / 8, y / 8] = 7;


                    for (int xx = x; xx < x + 8; xx++)
                    {
                        for (int yy = y; yy < y + 8; yy++)
                        {
                            Color c = Color.Black;

                            if (y < clipbit.Height && x < clipbit.Width)
                            {
                                c = clipbit.GetPixel(xx, yy);
                            }

                            int r = c.R / 16;
                            int g = c.G / 16;
                            int b = c.B / 16;
                            string thiscol = VbX.Hex(r) + VbX.Hex(g) + VbX.Hex(b);
                            if (bestcol == thiscol)
                            {
                                spritepixel[CurrentBank, CurrentSprite, xx, yy] = c1;
                            }
                            else
                            {
                                spritepixel[CurrentBank, CurrentSprite, xx, yy] = c0;
                            }

                        }

                    }

                }
            }
            rdoDisplaySpeccy.Checked = true;
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void copyPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clipboard.SetImage(bmpZoom);
            Bitmap clipbit = new Bitmap(maxSpriteSize, maxSpriteSize);
            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    clipbit.SetPixel(x, y, bmpZoom.GetPixel(x + 1, y + 1));
                }
            }

            Clipboard.SetImage(clipbit);
        }
        /************************************************************************************************************************************************/
        private void canvasSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string newxy = VbX.InputBox("New size? (X,Y)", "New size (X,Y)", VbX.CStr(Spr_Wid[CurrentSprite]) + "," + VbX.CStr(Spr_Hei[CurrentSprite]));
            int mx = (byte)VbX.CInt(ss.GetItem(newxy, ",", 0));
            int my = (byte)VbX.CInt(ss.GetItem(newxy, ",", 1));

            if (my == 0 || mx == 0) return;
            for (int y = my; y < maxSpriteSize; y++)
            {
                for (int x = 0; x < maxSpriteSize; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = 0;
                }
            }


            for (int y = 0; y < maxSpriteSize; y++)
            {
                for (int x = mx; x < maxSpriteSize; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = 0;
                }
            }
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void loadCPCBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Cpc Plus Binary Sprite (*.PLS)|*.PLS";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            ClearSprites();
            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            System.IO.BinaryReader BR = new System.IO.BinaryReader(ST);
            byte b = 0;
            if (chkHasDosHeader.Checked)
            {
                for (int i = 0; i < 128; i++)
                {
                    //skip header
                    b = BR.ReadByte();
                }
            }
            for (int s = 0; s < 16; s++)
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 15; x += 2)
                    {
                        if (ST.Position < ST.Length)
                        {
                            b = BR.ReadByte();
                            int b2 = b / 16;
                            int b1 = b % 16;
                            spritepixel[CurrentBank, s, x, y] = (byte)b1;
                            spritepixel[CurrentBank, s, x + 1, y] = (byte)b2;
                        }
                    }
                }
            }

            BR.Close();
            ST.Close();
            VbX.MsgBox("Loaded");
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void loadCPCBinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "CPC Binary Sprite (*.*)|*.*";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            ClearSpritesCurrentBank();
            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            System.IO.BinaryReader BR = new System.IO.BinaryReader(ST);
            byte b = 0;
            int firstspritepos = 0;
            int fileoffset = 0;
            int spritenum = 0;
            if (chkHasDosHeader.Checked)
            {
                fileoffset = 128;
                for (int i = 0; i < 128; i++)
                {
                    //skip header
                    b = BR.ReadByte();
                }
            }

            while (firstspritepos == 0 || (firstspritepos) >= ((ST.Position - fileoffset) + 6))
            {
                b = BR.ReadByte();
                Spr_Hei[spritenum] = (byte)b;

                b = BR.ReadByte();
                Spr_Wid[spritenum] = (byte)(b * 4);


                b = BR.ReadByte();
                Spr_Yoff[spritenum] = (byte)b;
                b = BR.ReadByte();
                Spr_Xoff[spritenum] = (byte)b;


                b = BR.ReadByte();
                int Mempos = (int)b;
                b = BR.ReadByte();
                Mempos += ((int)b * 256);
                Spr_Mempos[spritenum] = Mempos;

                if (spritenum < 63) spritenum++;

                if (firstspritepos == 0) firstspritepos = Mempos;
            }

            while ((ST.Position - fileoffset) > ST.Position)
            {
                b = BR.ReadByte();
            }

            int spritecount = spritenum;

            while (Spr_Mempos[spritecount] > ST.Length - fileoffset)
            {
                spritecount--;
            }

            for (spritenum = 0; spritenum < spritecount; spritenum++)
            {
                //VbX.MsgBox((ST.Position - fileoffset).ToString() + " " + Spr_Mempos[spritenum].ToString());
                if ((ST.Position - fileoffset) == Spr_Mempos[spritenum])
                {
                    Spr_MemposReset[spritenum] = 0;
                }
                else
                {
                    Spr_MemposReset[spritenum] = 1;
                    while ((Spr_Mempos[spritenum]) > (ST.Position - fileoffset) && (ST.Length > ST.Position))
                    {
                        b = BR.ReadByte();
                    }


                }
                for (int y = Spr_Yoff[spritenum]; y < Spr_Hei[spritenum] + Spr_Yoff[spritenum]; y++)
                {
                    for (int x = 0; x < Spr_Wid[spritenum]; x += 4)
                    {
                        try
                        {
                            b = BR.ReadByte();
                        }
                        catch (Exception ee)
                        {
                            b = 0;
                        }

                        int b1 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(4, 1) + VbX.Dec2Bin8Bit(b).Substring(0, 1));
                        int b2 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(5, 1) + VbX.Dec2Bin8Bit(b).Substring(1, 1));
                        int b3 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(6, 1) + VbX.Dec2Bin8Bit(b).Substring(2, 1));
                        int b4 = VbX.Bin2Dec(VbX.Dec2Bin8Bit(b).Substring(7, 1) + VbX.Dec2Bin8Bit(b).Substring(3, 1));

                        int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));

                        if ((transpcol == 5 && b1 == 0 && b2 == 1 && b3 == 2 && b4 == 3) || (transpcol == 4 && b1 == 3 && b2 == 2 && b3 == 1 && b4 == 0))
                        {
                            b1 = 16;
                            b2 = 16;
                            b3 = 16;
                            b4 = 16;
                        }


                        spritepixel[CurrentBank, spritenum, x, y] = (byte)b1;
                        spritepixel[CurrentBank, spritenum, x + 1, y] = (byte)b2;
                        spritepixel[CurrentBank, spritenum, x + 2, y] = (byte)b3;
                        spritepixel[CurrentBank, spritenum, x + 3, y] = (byte)b4;



                        /*

                        int sp1 = spritepixel[CurrentBank,spritenum, x, y];
                        int sp2 = spritepixel[CurrentBank,spritenum, x + 1, y];
                        int sp3 = spritepixel[CurrentBank,spritenum, x + 2, y];
                        int sp4 = spritepixel[CurrentBank,spritenum, x + 3, y];
                        string tbyte = "";
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 1);

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                        VbX.MsgBox(VbX.Dec2Bin8Bit(b) + "=" + tbyte);
                        */
                    }
                }

            }

            BR.Close();
            ST.Close();
            VbX.MsgBox("Loaded");

            txtSpriteDataOffSet.Text = "&" + VbX.Hex(firstspritepos);
            ForceBackup();
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveCPCBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CPC Binary Sprite (*.SPR)|*.SPR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }
            //VbX.MsgBox(SpriteCount.ToString());
            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            byte b = 0;
            int bytepos = 0;
            int thisspritebytepos = firstspritepos;

            for (int s = 0; s < SpriteCount; s++)
            {
                BW.Write((Byte)(Spr_Hei[s] - Spr_MinY[s]));
                BW.Write((Byte)((Spr_Wid[s] + 3) / 4));
                BW.Write((Byte)Spr_MinY[s]); // BW.Write((Byte)Spr_Yoff[s]);
                BW.Write((Byte)Spr_Xoff[s]);

                if (Spr_MemposReset[s] != 0 && thisspritebytepos % 256 != 0)
                {
                    thisspritebytepos = thisspritebytepos / 256;
                    thisspritebytepos++;
                    thisspritebytepos = thisspritebytepos * 256;
                }

                UInt16 mp = (UInt16)(thisspritebytepos);
                thisspritebytepos = thisspritebytepos + ((Spr_Hei[s] - Spr_MinY[s]) * ((Spr_Wid[s] + 3) / 4));
                BW.Write(mp);
                bytepos += 6;
            }
            while (bytepos < firstspritepos)
            {
                bytepos++;
                BW.Write((Byte)(0));
            }


            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {
                if (Spr_MemposReset[spritenum] != 0)
                {
                    while (ST.Position % 256 != 0)
                    {
                        BW.Write((Byte)(0));
                        //   VbX.MsgBox(ST.Position.ToString());
                    }
                }
                if (rdoDisplayCPC0.Checked)
                {
                    CPC_SaveRAW_16Color(BW, spritenum, 1);
                }
                else
                {
                    CPC_SaveRAW_4Color(BW, spritenum, false, 1);
                }

            }

            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveRAWBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCPCRawBmp_Click(sender, e);
        }
        private void SaveCPCRawBmp_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            if (rdoDisplayCPC0.Checked)
            {
                CPC_SaveRAW_16Color(BW, CurrentSprite, 1);
            }
            else
            {
                CPC_SaveRAW_4Color(BW, CurrentSprite, false, 1);
            }

            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void CPC_SaveRAW_16Color(System.IO.BinaryWriter BW, int spritenum, int Ystep)
        {
            for (int yy = 0; yy < Ystep; yy++)
            {

                for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += Ystep)
                {

                    for (int x = 0; x < Spr_Wid[spritenum]; x += 4)
                    {

                        int sp1 = spritepixel[CurrentBank, spritenum, x, y + yy];
                        int sp2 = spritepixel[CurrentBank, spritenum, x + 2, y + yy];


                        if (sp2 == 16 && sp1 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 3;
                                sp2 = 2;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;


                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);




                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }
                }

                if (Ystep == 8)
                {
                    for (int i = 0; i < 48; i++)
                    {
                        BW.Write((Byte)(0));
                    }
                }
            }

        }

        /************************************************************************************************************************************************/

        private void CPC_SaveRAW_4Color(System.IO.BinaryWriter BW, int spritenum, bool ZigZag, int Ystep)
        {
            for (int yy = 0; yy < Ystep; yy++)
            {
                for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += Ystep)
                {

                    for (int rx = 0; rx < Spr_Wid[spritenum]; rx += 4)
                    {
                        int x = rx;
                        if (ZigZag && y % 2 == 1)
                        {
                            x = (Spr_Wid[spritenum] - x) - 4;
                        }


                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);


                        if (sp4 == 16 && sp3 == 16 && sp2 == 16 && sp1 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                                sp3 = 2;
                                sp4 = 3;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 3;
                                sp2 = 2;
                                sp3 = 1;
                                sp4 = 0;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        if (sp3 == 16) sp3 = 0;
                        if (sp4 == 16) sp4 = 0;


                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 1);

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }
                }
                if (Ystep == 8 && yy < 7
                    )
                {
                    for (int i = 0; i < 48; i++)
                    {
                        BW.Write((Byte)(0));
                    }
                }
            }

        }

        /************************************************************************************************************************************************/


        private void saveSpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Text Sprite Data (*.txt)|*.txt";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            dosave(fd.FileName);

        }
        private void dosave(String filename)
        {
            if (filename.Length == 0) return;

            if (System.IO.File.Exists(filename + ".old"))
            {
                System.IO.File.Delete(filename + ".old");

            }

            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Copy(filename, filename + ".old");

            }


            lastfilename = filename;
            reSaveSpritesToolStripMenuItem.Enabled = true;

            string nl = VbX.Chr(13) + VbX.Chr(10);
            System.IO.StreamWriter SR = new System.IO.StreamWriter(filename, false, Encoding.ASCII);

            SR.Write("FileVersion,1" + nl);
            SR.Write("Sprites,64" + nl);

            SR.Write("SpriteSize," + maxSpriteSize.ToString() + nl);

            for (int i = 0; i <= 16; i++)
            {
                SR.Write("Colorselector," + i.ToString());
                SR.Write("," + ColorSelector[i].BackColor.R.ToString());
                SR.Write("," + ColorSelector[i].BackColor.G.ToString());
                SR.Write("," + ColorSelector[i].BackColor.B.ToString());
                SR.Write(nl);
            }

            int OldBank = CurrentBank;
            for (CurrentBank = 0; CurrentBank <= LastBank; CurrentBank++)
            {
                SpriteCount = 0;
                for (int s = 0; s < 64; s++)
                {

                    SpriteStats(s);         // update all our info on the sprites
                }

                //  VbX.MsgBox(CurrentBank.ToString() + " " + SpriteCount.ToString());
                if (SpriteCount > 0)
                {
                    SR.Write("spritebank," + CurrentBank.ToString() + nl);


                    SR.Write("SpriteStart" + nl);
                    for (int s = 0; s < SpriteCount; s++)
                    {

                        SR.Write("SpriteBitmapBlock," + s.ToString() + "," + Spr_Hei[s].ToString() + "," + Spr_Wid[s].ToString() + nl);
                        for (int y = 0; y < Spr_Hei[s]; y++)
                        {
                            for (int x = 0; x < Spr_Wid[s]; x++)
                            {
                                if (x > 0) SR.Write(",");
                                SR.Write(spritepixel[CurrentBank, s, x, y].ToString());
                            }
                            SR.Write(VbX.Chr(13) + VbX.Chr(10));
                        }
                        SR.Write("SpriteSpeccyBlock," + s.ToString() + "," + ((Spr_Hei[s] + 7) / 8).ToString() + "," + ((Spr_Wid[s] + 7) / 8).ToString() + nl);
                        for (int y = 0; y < (Spr_Hei[s] + 7) / 8; y++)
                        {
                            for (int x = 0; x < (Spr_Wid[s] + 7) / 8; x++)
                            {
                                if (x > 0) SR.Write(",");
                                SR.Write(SpeccyPaletteF[CurrentBank, s, x, y].ToString() + ",");
                                SR.Write(SpeccyPaletteB[CurrentBank, s, x, y].ToString() + ",");
                                SR.Write(SpeccyPaletteL[CurrentBank, s, x, y].ToString());
                            }
                            SR.Write(VbX.Chr(13) + VbX.Chr(10));
                        }
                        SR.Write("SpriteAttribs," + s.ToString() + "," + (Spr_Xoff[s]).ToString() + "," + Spr_FixedSize[s].ToString() + "," + Spr_MemposReset[s].ToString() + nl);
                    }
                }
            }
            CurrentBank = OldBank;
            //        public byte[,,] spritepixel;
            //public byte[, ,] SpeccyPaletteF;   //foreground
            //public byte[, ,] SpeccyPaletteB;   //Background
            //public byte[, ,] SpeccyPaletteL;   //Lightness
            SR.Write("SpriteDataOffSet," + txtSpriteDataOffSet.Text + nl);
            SR.Write("SpriteNotes,Start" + nl);
            SR.Write(txtNotes.Text + nl);
            SR.Write("SpriteNotes,End" + nl);


            SR.Write("eof" + nl);
            SR.Close();
            //VbX.MsgBox("Save Complete");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

        }

        /************************************************************************************************************************************************/

        private void savePaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Text Palette Data (*.txt)|*.txt";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            string nl = VbX.Chr(13) + VbX.Chr(10);
            System.IO.StreamWriter SR = new System.IO.StreamWriter(fd.FileName, false, Encoding.ASCII);

            SR.Write("FileVersion,1" + nl);
            SR.Write("Sprites,0" + nl);

            for (int i = 0; i < 16; i++)
            {
                SR.Write("Colorselector," + i.ToString());
                SR.Write("," + ColorSelector[i].BackColor.R.ToString());
                SR.Write("," + ColorSelector[i].BackColor.G.ToString());
                SR.Write("," + ColorSelector[i].BackColor.B.ToString());
                SR.Write(nl);
                SR.Write(nl);
                SR.Write(nl);
            }
            SR.Close();
        }

        /************************************************************************************************************************************************/

        private void DoLoadFile(string File, bool loadpixels, bool loadbackground, bool loadpalette, bool loadsettings)
        {

            if (loadpixels && loadbackground && loadpalette & loadsettings)
            {
                lastfilename = File;
                this.Text = "AkuSprite Editor [" + File + "]";
            }



            reSaveSpritesToolStripMenuItem.Enabled = true;

            int spriteresetdone = 0;

            System.IO.StreamReader SR = new System.IO.StreamReader(File);
            int s = 0;

            string lin2 = "";    // read dummy line
            lin2 = SR.ReadLine();       // read dummy line
            while (ss.GetItem(lin2, ",", 0).ToLower() != "eof" && !SR.EndOfStream)
            {

                string command = ss.GetItem(lin2, ",", 0).ToLower();
                int sprite = VbX.CInt(ss.GetItem(lin2, ",", 1).ToLower());
                if (command == "colorselector" && loadpalette)
                {
                    ColorSelector[sprite].BackColor = Color.FromArgb(VbX.CInt(ss.GetItem(lin2, ",", 2).ToLower()), VbX.CInt(ss.GetItem(lin2, ",", 3).ToLower()), VbX.CInt(ss.GetItem(lin2, ",", 4).ToLower()));

                }


                if (lin2.ToLower().Trim() == "spritenotes,start")
                {
                    //VbX.MsgBox("notes");
                    lin2 = SR.ReadLine();
                    txtNotes.Text = "";
                    while (lin2.ToLower().Trim() != "spritenotes,end")
                    {
                        txtNotes.Text = txtNotes.Text + lin2 + VbX.Chr(13) + VbX.Chr(10);
                        lin2 = SR.ReadLine();
                    }




                }
                if (command == "spritebitmapblock" && loadpixels)
                {

                    if (spriteresetdone == 0)
                    {
                        ClearSprites();
                        CurrentSprite = 0;
                        spriteresetdone = 1;
                    }
                    int maxy = VbX.CInt(ss.GetItem(lin2, ",", 2).ToLower());
                    int maxx = VbX.CInt(ss.GetItem(lin2, ",", 3).ToLower());
                    Spr_Hei[sprite] = (Int16)maxy;
                    Spr_Wid[sprite] = (Int16)maxx;

                    for (int y = 0; y < maxy; y++)
                    {
                        string lin = SR.ReadLine();
                        for (int x = 0; x < maxSpriteSize; x++)
                        {
                            spritepixel[CurrentBank, sprite, x, y] = (byte)VbX.CInt(ss.GetItem(lin, ",", x));
                        }
                    }

                }
                if (command == "spriteattribs" && loadsettings)
                {
                    s = VbX.CInt(ss.GetItem(lin2, ",", 1).ToLower());
                    Spr_Xoff[s] = (Int16)VbX.CInt(ss.GetItem(lin2, ",", 2).ToLower());
                    Spr_FixedSize[s] = (byte)VbX.CInt(ss.GetItem(lin2, ",", 3).ToLower());
                    Spr_MemposReset[s] = (byte)VbX.CInt(ss.GetItem(lin2, ",", 4).ToLower());
                    if (Spr_FixedSize[s] != 0)
                    {
                        Spr_MinX[s] = 0;
                        Spr_MinY[s] = 0;
                    }

                }
                if (command == "spritedataoffset" && loadsettings)
                {
                    txtSpriteDataOffSet.Text = ss.GetItem(lin2, ",", 1).ToLower();
                }
                if (command == "spritebank")
                {
                    CurrentBank = VbX.CInt(ss.GetItem(lin2, ",", 1));
                    if (CurrentBank > LastBank) LastBank = CurrentBank;
                }
                if (command == "spritesize" && loadsettings)
                {
                    maxSpriteSize =
                        VbX.CInt(ss.GetItem(lin2, ",", 1));
                    InitMaxSpriteSize();
                }
                if (command == "spritespeccyblock" && loadbackground)
                {
                    int maxy = VbX.CInt(ss.GetItem(lin2, ",", 2).ToLower());
                    int maxx = VbX.CInt(ss.GetItem(lin2, ",", 3).ToLower());
                    sprite = VbX.CInt(ss.GetItem(lin2, ",", 1).ToLower());
                    for (int y = 0; y < maxy; y++)
                    {
                        string lin = SR.ReadLine();
                        for (int x = 0; x < 32; x++)
                        {

                            SpeccyPaletteF[CurrentBank, sprite, x, y] = (byte)VbX.CInt(ss.GetItem(lin, ",", x * 3 + 0));
                            SpeccyPaletteB[CurrentBank, sprite, x, y] = (byte)VbX.CInt(ss.GetItem(lin, ",", x * 3 + 1));
                            SpeccyPaletteL[CurrentBank, sprite, x, y] = (byte)VbX.CInt(ss.GetItem(lin, ",", x * 3 + 2));

                            //SR.Write(SpeccyPaletteF[CurrentBank,s, x, y].ToString() + ",");
                            //SR.Write(SpeccyPaletteB[CurrentBank,s, x, y].ToString() + ",");
                            //SR.Write(SpeccyPaletteL[CurrentBank,s, x, y].ToString());
                        }
                    }

                }
                lin2 = SR.ReadLine();       // read dummy line
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            // VbX.MsgBox("Load Complete");

            //        public byte[,,] spritepixel;
            //public byte[, ,] SpeccyPaletteF;   //foreground
            //public byte[, ,] SpeccyPaletteB;   //Background
            //public byte[, ,] SpeccyPaletteL;   //Lightness
            SR.Close();
            CurrentBank = 0;
            for (int i = 0; i < 64; i++)
            {

                SpriteStats(i);         // update all our info on the sprites
                SaveSpriteDetails(i);
            }
            ForceBackup();
            btnRefresh_Click(null, null);

        }

        /************************************************************************************************************************************************/

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoLoad(true, true, true, true);


        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap clipbit = new Bitmap(maxSpriteSize, maxSpriteSize + 12);
            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    Color mycolor = GetDisplayRGB(CurrentBank, CurrentSprite, x, y);
                    clipbit.SetPixel(x, y, mycolor);
                }
            }


            for (int col = 0; col <= 16; col++)
            {
                for (int cx = 0; cx < 12; cx++)
                {
                    for (int cy = 0; cy < 12; cy++)
                    {
                        clipbit.SetPixel(col * 12 + cx, maxSpriteSize + cy, ColorSelector[col].BackColor);
                    }
                }
            }

            Clipboard.SetImage(clipbit);
        }

        /************************************************************************************************************************************************/

        private void pasteToClipToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap clipbit = (Bitmap)Clipboard.GetImage();
            if (clipbit == null) return;
            string response = VbX.InputBox("Replace Sprite", "Replace Sprite", "yes/no");
            if (response != "*yes*") return;


            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    Color c = Color.Black;

                    if (y < clipbit.Height && x < clipbit.Width)
                    {
                        c = clipbit.GetPixel(x, y);
                    }


                    int currentpixel = 0;
                    int bestpixel = 255 * 255 * 255;

                    for (int i = 0; i <= 16; i++)
                    {
                        int thisdiff = Math.Abs(ColorSelector[i].BackColor.R - c.R) + Math.Abs(ColorSelector[i].BackColor.G - c.G) + Math.Abs(ColorSelector[i].BackColor.B - c.B);

                        if (thisdiff < bestpixel)
                        {
                            bestpixel = thisdiff;
                            currentpixel = i;
                        }

                    }
                    spritepixel[CurrentBank, CurrentSprite, x, y] = (byte)currentpixel;
                }
            }
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void DoLoad(bool loadpixels, bool loadbackground, bool loadpalette, bool loadsettings)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text Sprite Data (*.txt)|*.txt";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            string File = fd.FileName;
            DoLoadFile(File, loadpixels, loadbackground, loadpalette, loadsettings);
            recent10.Text = recent9.Text;
            recent9.Text = recent8.Text;
            recent8.Text = recent7.Text;
            recent7.Text = recent6.Text;
            recent6.Text = recent5.Text;
            recent5.Text = recent4.Text;
            recent4.Text = recent3.Text;
            recent3.Text = recent2.Text;
            recent2.Text = recent1.Text;
            recent1.Text = File;

        }

        /************************************************************************************************************************************************/

        private void fourColor2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {

                    byte i = spritepixel[CurrentBank, CurrentSprite, x, y];
                    switch (i)
                    {
                        case 1:
                            i = checkerize(x, y, 3, 0, 1);
                            break;
                        case 2:
                            i = checkerize(x, y, 3, 0, 2);
                            break;
                    }

                    spritepixel[CurrentBank, CurrentSprite, x, y] = i;

                }
            }
        }

        /************************************************************************************************************************************************/

        private void invertZXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string response = VbX.InputBox("Replace Sprite", "Replace Sprite", "yes/no");
            if (response != "*yes*") return;


            Bitmap clipbit = (Bitmap)Clipboard.GetImage();
            if (clipbit == null) return;
            for (int x = 0; x < maxSpriteSize; x++)
            {
                for (int y = 0; y < maxSpriteSize; y++)
                {
                    Color c = Color.Black;

                    if (y < clipbit.Height && x < clipbit.Width)
                    {
                        c = clipbit.GetPixel(x, y);
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        if (ColorSelector[i].BackColor.R == c.R && ColorSelector[i].BackColor.G == c.G && ColorSelector[i].BackColor.B == c.B)
                        {
                            spritepixel[CurrentBank, CurrentSprite, x, y] = (byte)i;
                        }
                    }
                }
            }
            btnRefresh_Click(sender, e);

        }
        /************************************************************************************************************************************************/
        private void chkStrongGrid_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveSpectrumScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "ZXS Binary Sprite (*.SCR)|*.SCR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }



            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            byte b = 0;
            int bytepos = 0;
            int thisspritebytepos = firstspritepos;

            int spritenum = CurrentSprite;

            int yy = 0;
            int x = 0;


            for (int by = 0; by < (256 * 192) / 8; by++)
            {
                int y1 = yy % 8 * 8;
                int y2 = (yy % 64) / 8;
                int y3 = (yy / 64) * 64;
                int y = y1 + y2 + y3;

                int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];
                int sp3 = spritepixel[CurrentBank, spritenum, x + 2, y];
                int sp4 = spritepixel[CurrentBank, spritenum, x + 3, y];
                int sp5 = spritepixel[CurrentBank, spritenum, x + 4, y];
                int sp6 = spritepixel[CurrentBank, spritenum, x + 5, y];
                int sp7 = spritepixel[CurrentBank, spritenum, x + 6, y];
                int sp8 = spritepixel[CurrentBank, spritenum, x + 7, y];

                string tbyte = "";

                tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);


                BW.Write((Byte)VbX.Bin2Dec(tbyte));
                x = x + 8;
                if (x == 256) { x = 0; yy++; }
            }
            for (int y = 0; y < (192 / 8); y++)
            {
                for (x = 0; x < (256 / 8); x++)
                {
                    string tbyte = "0"; //flashing is bad -mkay!
                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteL[CurrentBank, spritenum, x, y]).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteB[CurrentBank, spritenum, x, y]).Substring(5, 3);
                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteF[CurrentBank, spritenum, x, y]).Substring(5, 3);
                    BW.Write((Byte)VbX.Bin2Dec(tbyte));

                }
            }


            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void rLEASMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DoCPCRLE("cpc");
        }
        private void DoCPCRLE(string mode)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder Header = new StringBuilder();

            for (int c = 0; c < SpriteCount; c++)
            {

                int w = Spr_Wid[c] / 4;
                string Filen = "Sprite" + VbX.CStr(c);

                Header.Append("     call Sprite0_Setup" + VbX.nl());
                Header.Append("     call RLE_Draw" + VbX.nl());
                Header.Append("     di" + VbX.nl());
                Header.Append("     halt" + VbX.nl());
                if (mode == "ent")
                {
                    Header.Append("     read \"\\SrcENT\\Akuyou_ENT_RLE.asm\"" + VbX.nl());

                }
                else
                {
                    Header.Append("     read \"\\SrcCPC\\Akuyou_CPC_RLE.asm\"" + VbX.nl());
                }
                Header.Append("     jp " + Filen + "_Setup" + VbX.nl());
                result.Append(Filen + "_Setup:" + VbX.nl());

                result.Append("     ld hl," + Filen + "_Start-1" + VbX.nl());
                result.Append("     ld de," + Filen + "_End-1" + VbX.nl());
                result.Append("     ld b,0   ;Y-Start" + VbX.nl());
                result.Append("     ld ixh," + VbX.CStr(w) + "	;Width" + VbX.nl());
                result.Append("     ld IXL," + VbX.CStr(40 - (w / 2)) + "+" + VbX.CStr(w) + "-1	;X-Righthandside" + VbX.nl());
                result.Append("     ret" + VbX.nl());


                AkuSpriteEditor.RLEBinaryCPC nr = new AkuSpriteEditor.RLEBinaryCPC();
                result.Append(Filen + "_Start:" + VbX.nl());
                nr.width = Spr_Wid[c];
                nr.height = Spr_Hei[c];
                nr.spritepixel = new short[maxSpriteSize, maxSpriteSize];
                for (int y = 0; y < nr.height; y++)
                {
                    for (int x = 0; x < nr.width; x++)
                    {
                        nr.spritepixel[x, y] = GetDisplayNum(CurrentBank, c, x, y);
                    }
                }
                nr.NewRLE();

                result.Append("     db ");
                for (int i = 0; i < nr.RleDataPos; i++)
                {
                    if (i > 0)
                    {
                        if (i % 16 == 0)
                        {
                            result.Append(VbX.nl() + "      db ");
                        }
                        else
                        {
                            result.Append(",");
                        }
                    }
                    result.Append("&" + VbX.Hex(nr.RleData[i]));
                }
                result.Append(VbX.nl() + Filen + "_End:" + VbX.nl() + VbX.nl());
            }
            Clipboard.SetText(Header.ToString() + VbX.nl() + VbX.nl() + result.ToString());
            VbX.MsgBox("Copied to Clipboard");

        }

        /************************************************************************************************************************************************/

        private void rLEASMCOLORToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StringBuilder Header = new StringBuilder();

            StringBuilder result = new StringBuilder();
            for (int c = 0; c < SpriteCount; c++)
            {
                AkuSpriteEditor.RLEBinaryZX nr = new AkuSpriteEditor.RLEBinaryZX();

                int w = Spr_Wid[c] / 8;
                string Filen = "Sprite" + VbX.CStr(c);

                Header.Append("     ld de," + Filen + "_jumpblock" + VbX.nl());
                Header.Append("     call Rle_FromPointers" + VbX.nl());

                Header.Append("     halt" + VbX.nl());
                Header.Append("     read \"\\SrcZX\\Akuyou_Spectrum_RLE.asm\"" + VbX.nl());
                Header.Append("     jp " + Filen + "_Setup" + VbX.nl());
                Header.Append("callHL:" + VbX.nl());
                Header.Append("     push hl" + VbX.nl());
                Header.Append("     ret" + VbX.nl());

                Header.Append(Filen + "_jumpblock:	" + VbX.nl());



                Header.Append("     jp " + Filen + "_Setup" + VbX.nl());
                result.Append(Filen + "_Setup:" + VbX.nl());

                result.Append("     ld hl," + Filen + "_Start-1" + VbX.nl());
                result.Append("     ld de," + Filen + "_End-1" + VbX.nl());
                result.Append("     ld b,0*8   ;Y-Start" + VbX.nl());
                result.Append("     ld ixh," + VbX.CStr(w) + "	;Width" + VbX.nl());
                result.Append("     ld IXL," + VbX.CStr(16 - (w / 2)) + "+" + VbX.CStr(w - 1) + "	;X-Righthandside" + VbX.nl());
                result.Append("     ret" + VbX.nl());
                result.Append(Filen + "_Start:" + VbX.nl());






                nr.width = Spr_Wid[c];
                nr.height = Spr_Hei[c];
                nr.spritepixel = new short[maxSpriteSize, maxSpriteSize];
                for (int y = 0; y < nr.height; y++)
                {
                    for (int x = 0; x < nr.width; x++)
                    {
                        nr.spritepixel[x, y] = spritepixel[CurrentBank, c, x, y];
                    }
                }

                nr.NewRLE();
                // VbX.MsgBox(nr.RleDataPos.ToString());
                result.Append("     db ");
                for (int i = 0; i < nr.RleDataPos; i++)
                {
                    if (i > 0)
                    {
                        if (i % 16 == 0)
                        {
                            result.Append(VbX.nl() + "     db ");
                        }
                        else
                        {
                            result.Append(",");
                        }
                    }
                    result.Append("&" + VbX.Hex(nr.RleData[i]));
                }
                result.Append(VbX.nl() + Filen + "_End:" + VbX.nl() + VbX.nl());






















                w = Spr_Wid[c] / 8;

                Header.Append("     jp " + Filen + "Color_Setup" + VbX.nl());
                result.Append(Filen + "Color_Setup:" + VbX.nl());

                result.Append("     ld hl," + Filen + "Color_Start-1" + VbX.nl());
                result.Append("     ld de," + Filen + "Color_End-1" + VbX.nl());
                result.Append("     ld b,0*8   ;Y-Start" + VbX.nl());
                result.Append("     ld ixh," + VbX.CStr(w) + "	;Width" + VbX.nl());
                result.Append("     ld IXL," + VbX.CStr(16 - (w / 2)) + "+" + VbX.CStr(w - 1) + "	;X-Righthandside" + VbX.nl());
                result.Append("     ret" + VbX.nl());
                nr = new AkuSpriteEditor.RLEBinaryZX();
                result.Append(Filen + "Color_Start:" + VbX.nl());
                nr.spritepixel = new short[4 * 8, 1024];
                int xx = 4 * 8 - 8;
                int yy = 0;
                for (int y = 0; y < (Spr_Hei[c] / 8); y++)
                {
                    for (int x = (Spr_Wid[c] / 8) - 1; x >= 0; x--)
                    {

                        string tbyte = "0"; //flashing is bad -mkay!
                        tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteL[CurrentBank, c, x, y]).Substring(7, 1);

                        tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteB[CurrentBank, c, x, y]).Substring(5, 3);
                        tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteF[CurrentBank, c, x, y]).Substring(5, 3);

                        nr.spritepixel[xx + 7, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(7, 1));
                        nr.spritepixel[xx + 6, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(6, 1));
                        nr.spritepixel[xx + 5, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(5, 1));
                        nr.spritepixel[xx + 4, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(4, 1));

                        nr.spritepixel[xx + 3, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(3, 1));
                        nr.spritepixel[xx + 2, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(2, 1));
                        nr.spritepixel[xx + 1, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(1, 1));
                        nr.spritepixel[xx + 0, yy] = (byte)VbX.Bin2Dec(tbyte.Substring(0, 1));
                        xx -= 8;
                        if (xx < 0) { yy++; xx = 4 * 8 - 8; }

                    }
                }

                nr.width = 4 * 8;
                nr.height = yy;
                nr.NewRLE();

                result.Append("     db ");
                for (int i = 0; i < nr.RleDataPos; i++)
                {
                    if (i > 0)
                    {
                        if (i % 16 == 0)
                        {
                            result.Append(VbX.nl() + "      db ");
                        }
                        else
                        {
                            result.Append(",");
                        }
                    }
                    result.Append("&" + VbX.Hex(nr.RleData[i]));
                }
                result.Append(VbX.nl() + Filen + "Color_End:" + VbX.nl() + VbX.nl());
            }
            Clipboard.SetText(Header.ToString() + VbX.nl() + VbX.nl() + result.ToString());
            VbX.MsgBox("Copied to Clipboard!");
        }

        /************************************************************************************************************************************************/

        private void saveMSXBitmapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MSX Bitmap Screen/Sprite (*.SCR)|*.SCR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;





            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            int spritenum = CurrentSprite;



            BW.Write((Byte)(0));         // First byte = format: 0= no palette 1 = palette
            BW.Write((UInt16)(Spr_Wid[spritenum]));         // Width
            BW.Write((UInt16)(Spr_Hei[spritenum]));         // Height

            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y++)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 2)
                {
                    int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                    int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];

                    if (sp1 == 16) sp1 = 0;
                    if (sp2 == 16) sp2 = 0;
                    string tbyte = "";
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                }
            }

            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveMSXBitmapWithPaletteToolStripMenuItem1_Click(object sender, EventArgs e)
        {



            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MSX Bitmap Screen/Sprite (*.SCR)|*.SCR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;





            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            int spritenum = CurrentSprite;



            BW.Write((Byte)(1));         // First byte = format: 0= no palette 1 = palette
            BW.Write((UInt16)(Spr_Wid[spritenum]));         // Width
            BW.Write((UInt16)(Spr_Hei[spritenum]));         // Height





            for (int i = 0; i < 16; i++)
            {
                string tbyte = "";
                tbyte = "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.R).Substring(0, 3) + "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.B).Substring(0, 3);
                BW.Write((Byte)VbX.Bin2Dec(tbyte));
                tbyte = "00000" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.G).Substring(0, 3);
                BW.Write((Byte)VbX.Bin2Dec(tbyte));

            }




            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y++)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 2)
                {
                    int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                    int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];

                    if (sp1 == 16) sp1 = 0;
                    if (sp2 == 16) sp2 = 0;
                    string tbyte = "";
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                }
            }

            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveMSXBitmapSpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMSXSprites(false);

        }

        private void SaveMSXSprites(bool rle)
        {
            {

                Bitmap clipbit = new Bitmap(256, 1024);
                UInt16[,] tilearray = new UInt16[256, 1024];



                for (int x = 0; x < 256; x++)
                {
                    for (int y = 0; y < 1024; y++)
                    {
                        tilearray[x, y] = 256;
                    }

                }
                int CurrentX = 0;
                int CurrentY = 0;
                int CurrentYHeight = 0;
                int TotalYHeight = 0;

                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "MSX Binary Sprite (*.MAP)|*.MAP";
                DialogResult dr = fd.ShowDialog();
                if (dr != DialogResult.OK) return;


                int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
                for (int s = 0; s < 64; s++)
                {
                    SpriteStats(s);         // update all our info on the sprites
                }





                System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
                byte b = 0;
                int bytepos = 0;
                int thisspritebytepos = firstspritepos;

                for (int s = 0; s < SpriteCount; s++)
                {

                    /*
     ;db H		1
     ;db W		2
     ;db Yoff	3
     ;db Woff	4
     ;DW MyLMMM_SX	6
     ;DW MyLMMM_SY	8
     ;db MyLMMM_NX	9
     ;db MyLMMM_NY	10
                     *           Bitmap clipbit = new Bitmap(256, 1024);
                int CurrentX = 0;
                int CurrentY = 0;
                int CurrentYHeight = 0;
    */

                    int ThisActualHeight = Spr_Hei[s] - Spr_MinY[s];

                    BW.Write((Byte)(ThisActualHeight));
                    BW.Write((Byte)((Spr_Wid[s] + 1) / 2));
                    BW.Write((Byte)Spr_MinY[s]);
                    BW.Write((Byte)Spr_Xoff[s]);

                    // byte mp = (byte)(thisspritebytepos);
                    //thisspritebytepos = thisspritebytepos + ((Spr_Hei[s] - Spr_MinY[s]) * ((Spr_Wid[s] + 1) / 2));
                    //BW.Write(mp);

                    //bytepos += 6;


                    /*
                     Simple Scan
                    if (CurrentX + Spr_Wid[s]>=256){
                        CurrentX=0;
                        CurrentY+= CurrentYHeight;
                        CurrentYHeight = 0;
                    }
                    */
                    bool OutputThisOne = true;
                    if (Spr_Wid[s] < 1 || ThisActualHeight < 1) OutputThisOne = false;

                    if (OutputThisOne)
                    {
                        for (int sy = 0; sy < 1024; sy++)
                        {
                            for (int sx = 0; sx < 256 - (Spr_Wid[s] - 1); sx += 2)
                            {
                                if (tilearray[sx, sy] == 256)
                                {
                                    bool valid = true;
                                    for (int zx = 0; zx < Spr_Wid[s]; zx++)
                                    {
                                        for (int zy = 0; zy < Spr_Hei[s]; zy++)
                                        {
                                            if (tilearray[sx + zx, sy + zy] < 256)
                                            {
                                                valid = false;
                                                zy = 1024; zx = 1024;
                                            }
                                        }
                                    }
                                    if (valid == true)
                                    {
                                        CurrentX = sx;
                                        CurrentY = sy;
                                        sy = 1024;
                                        sx = 1024;
                                    }
                                }
                            }
                        }

                        if (Spr_Hei[s] - Spr_MinY[s] > CurrentYHeight) CurrentYHeight = ThisActualHeight;
                        for (int y = Spr_MinY[s]; y < Spr_Hei[s]; y++)
                        {
                            int y2 = y - Spr_MinY[s];
                            for (int x = 0; x < Spr_Wid[s]; x++)
                            {
                                int c = spritepixel[CurrentBank, s, x, y];
                                if (c == 16) c = 0;

                                clipbit.SetPixel(x + CurrentX, y2 + CurrentY, ColorSelector[c].BackColor);
                                tilearray[x + CurrentX, y2 + CurrentY] = (UInt16)c;
                            }
                        }

                    }
                    UInt16 bw = 0;
                    bw = (UInt16)CurrentX;
                    BW.Write(bw);
                    bw = (UInt16)CurrentY;
                    BW.Write(bw);
                    b = (Byte)Spr_Wid[s];
                    BW.Write(b);
                    b = (Byte)(ThisActualHeight);
                    BW.Write(b);
                    /*
                      ;db H		1
                    ;db W		2
                    ;db Yoff	3
                    ;db Woff	4
                    ;DW MyLMMM_SX	6
                    ;DW MyLMMM_SY	8
                    ;db MyLMMM_NX	9
                    ;db MyLMMM_NY	10
                 
                     */


                    CurrentX = CurrentX + Spr_Wid[s];
                    if (CurrentY + ThisActualHeight > TotalYHeight) TotalYHeight = CurrentY + ThisActualHeight;
                }


                BW.Close();
                ST.Close();



                if (rle == false)
                {
                    string fname2 = fd.FileName.Replace(".MAP", ".SCR");
                    ST = new System.IO.FileStream(fname2, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    BW = new System.IO.BinaryWriter(ST);

                    BW.Write((Byte)(0));         // First byte = format: 0= no palette 1 = palette
                    BW.Write((UInt16)(256));         // Width
                    BW.Write((UInt16)(TotalYHeight));         // Height


                    /*
                    for (int i = 0; i < 16; i++)
                    {
                        string tbyte = "";
                        tbyte = "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.R).Substring(0, 3) + "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.B).Substring(0, 3);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        tbyte = "00000" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.G).Substring(0, 3);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));

                    }
                    */



                    for (int y = 0; y <= TotalYHeight; y++)
                    {
                        for (int x = 0; x < 256; x += 2)
                        {
                            int sp1 = tilearray[x, y];
                            int sp2 = tilearray[x + 1, y];

                            if (sp1 >= 16) sp1 = 0;
                            if (sp2 >= 16) sp2 = 0;
                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);

                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }
                    }


                    BW.Close();
                    ST.Close();
                }
                else
                {
                    // rle
                    string fname2 = fd.FileName.Replace(".MAP", ".RLE");
                    ST = new System.IO.FileStream(fname2, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                    BW = new System.IO.BinaryWriter(ST);
                    int spritenum = CurrentSprite;

                    BW.Write((Byte)(0));         // First byte = format: 0= no palette 1 = palette
                    BW.Write((UInt16)(256));         // Width
                    BW.Write((UInt16)(TotalYHeight));         // Height



                    AkuSpriteEditor.RLEBinaryMSX nr = new AkuSpriteEditor.RLEBinaryMSX();

                    nr.width = 256;
                    nr.height = TotalYHeight;
                    nr.spritepixel = new short[256, TotalYHeight];
                    for (int y = 0; y < nr.height; y++)
                    {
                        for (int x = 0; x < nr.width; x++)
                        {
                            nr.spritepixel[x, y] = (byte)tilearray[x, y];
                        }
                    }
                    nr.NewRLE();

                    for (int i = 0; i < nr.RleDataPos; i++)
                    {
                        BW.Write((Byte)(nr.RleData[i]));         // First byte = format: 0= no palette 1 = palette
                    }

                    BW.Close();
                    ST.Close();


                }
                //VbX.MsgBox("Saved");
                tabControl1.SelectedTab = tabControl1.TabPages[0];

                btnRefresh_Click(null, null);

                Clipboard.SetImage(clipbit);

            }

        }

        /************************************************************************************************************************************************/


        private void buildRLEASMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AkuSpriteEditor.RLEBinaryMSX nr = new AkuSpriteEditor.RLEBinaryMSX();

            nr.width = Spr_Wid[CurrentSprite];
            nr.height = Spr_Hei[CurrentSprite];
            nr.spritepixel = new short[256, 256];
            for (int y = 0; y < nr.height; y++)
            {
                for (int x = 0; x < nr.width; x++)
                {
                    nr.spritepixel[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }
            }
            nr.NewRLE();
            VbX.MsgBox(nr.RleDataPos.ToString());
            StringBuilder result = new StringBuilder();
            result.Append("     db ");
            for (int i = 0; i < nr.RleDataPos; i++)
            {
                if (i > 0)
                {
                    if (i % 16 == 0)
                    {
                        result.Append(VbX.nl() + "      db ");
                    }
                    else
                    {
                        result.Append(",");
                    }
                }
                result.Append("&" + VbX.Hex(nr.RleData[i]));
            }


            string loader = "";
            loader = loader + "		ld hl,RleFile" + VbX.nl();
            loader = loader + "		ld de,RleFile_End" + VbX.nl();
            loader = loader + "		ld bc,RleFile_End-RleFile" + VbX.nl();
            loader = loader + "		ld ix,0" + VbX.nl();
            loader = loader + "		ld iy,0" + VbX.nl();
            loader = loader + "		call VDP_RLEProcessorFromMemory	" + VbX.nl();
            loader = loader + "		di" + VbX.nl();
            loader = loader + "		halt" + VbX.nl();
            loader = loader + "RleFile:	 " + VbX.nl();
            loader = loader + "		db 0;nopalette" + VbX.nl();
            loader = loader + "     dw " + nr.width.ToString() + "," + nr.height.ToString() + VbX.nl();
            loader = loader + result.ToString() + VbX.nl();
            loader = loader + "RleFile_End:" + VbX.nl();
            loader = loader + "		include \"Z:\\SrcMSX\\Akuyou_MSX_RLE.asm\"" + VbX.nl();
            loader = loader + "LoadDiscSectorSpecialMSX:;Dummy Label - should never run" + VbX.nl();
            loader = loader + "		halt	" + VbX.nl();

            Clipboard.SetText(loader);
            VbX.MsgBox("Copied to Clipboard");
        }

        /***********************************************************************************************************************************************/
        private void saveMSXRLEPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MSX RLE Screen/Sprite (*.RLE)|*.RLE";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            saveMSXRLE(fd.FileName, true);
            //System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            //System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            //int spritenum = CurrentSprite;

            //BW.Write((Byte)(1));         // First byte = format: 0= no palette 1 = palette
            //BW.Write((UInt16)(Spr_Wid[spritenum]));         // Width
            //BW.Write((UInt16)(Spr_Hei[spritenum]));         // Height

            //for (int i = 0; i < 16; i++)
            //{
            //    string tbyte = "";
            //    tbyte = VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.R).Substring(0, 3) + "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.B).Substring(0, 3) + "0";
            //    BW.Write((Byte)VbX.Bin2Dec(tbyte));
            //    tbyte = "0000" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.G).Substring(0, 3) + "0";
            //    BW.Write((Byte)VbX.Bin2Dec(tbyte));

            //}

            //AkuSpriteEditor.RLEBinaryMSX nr = new AkuSpriteEditor.RLEBinaryMSX();

            //nr.width = Spr_Wid[CurrentSprite];
            //nr.height = Spr_Hei[CurrentSprite];
            //nr.spritepixel = new byte[256, 256];
            //for (int y = 0; y < nr.height; y++)
            //{
            //    for (int x = 0; x < nr.width; x++)
            //    {
            //        nr.spritepixel[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
            //    }
            //}
            //nr.NewRLE();
            //VbX.MsgBox(nr.RleDataPos.ToString());

            //for (int i = 0; i < nr.RleDataPos; i++)
            //{
            //    BW.Write((Byte)(nr.RleData[i]));         // First byte = format: 0= no palette 1 = palette
            //}

            //BW.Close();
            //ST.Close();


            //btnRefresh_Click(sender, e);
        }
        /***********************************************************************************************************************************************/
        private void saveMSXRLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MSX RLE Screen/Sprite (*.RLE)|*.RLE";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            saveMSXRLE(fd.FileName, false);
        }
        /************************************************************************************************************************************************/
        private void saveMSXRLE(string Filename, bool withpalette)
        {

            System.IO.Stream ST = new System.IO.FileStream(Filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            int spritenum = CurrentSprite;
            if (!withpalette)
            {
                BW.Write((Byte)(0));         // First byte = format: 0= no palette 1 = palette
            }
            else
            {
                BW.Write((Byte)(1));         // First byte = format: 0= no palette 1 = palette
            }
            BW.Write((UInt16)(Spr_Wid[spritenum]));         // Width
            BW.Write((UInt16)(Spr_Hei[spritenum]));         // Height
            if (withpalette)
            {

                for (int i = 0; i < 16; i++)
                {
                    string tbyte = "";
                    tbyte = VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.R).Substring(0, 3) + "0" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.B).Substring(0, 3) + "0";
                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    tbyte = "0000" + VbX.Dec2Bin8Bit(ColorSelector[i].BackColor.G).Substring(0, 3) + "0";
                    BW.Write((Byte)VbX.Bin2Dec(tbyte));

                }
            }
            AkuSpriteEditor.RLEBinaryMSX nr = new AkuSpriteEditor.RLEBinaryMSX();

            nr.width = Spr_Wid[CurrentSprite];
            nr.height = Spr_Hei[CurrentSprite];
            nr.spritepixel = new short[256, 256];
            for (int y = 0; y < nr.height; y++)
            {
                for (int x = 0; x < nr.width; x++)
                {
                    nr.spritepixel[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }
            }
            nr.NewRLE();
            VbX.MsgBox(nr.RleDataPos.ToString());

            for (int i = 0; i < nr.RleDataPos; i++)
            {
                BW.Write((Byte)(nr.RleData[i]));         // First byte = format: 0= no palette 1 = palette
            }

            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            string loader = "";
            loader = loader + "		ld hl,RleFile" + VbX.nl();
            loader = loader + "		ld de,RleFile_End" + VbX.nl();
            loader = loader + "		ld bc,RleFile_End-RleFile" + VbX.nl();
            loader = loader + "		ld ix,0" + VbX.nl();
            loader = loader + "		ld iy,0" + VbX.nl();
            loader = loader + "		call VDP_RLEProcessorFromMemory	" + VbX.nl();
            loader = loader + "		di" + VbX.nl();
            loader = loader + "		halt" + VbX.nl();
            loader = loader + "RleFile:	 " + VbX.nl();
            loader = loader + "		incbin \"c:\\RleFile.rle\"" + VbX.nl();
            loader = loader + "RleFile_End:" + VbX.nl();
            loader = loader + "		include \"Z:\\SrcMSX\\Akuyou_MSX_RLE.asm\"" + VbX.nl();
            loader = loader + "LoadDiscSectorSpecialMSX:;Dummy Label - should never run" + VbX.nl();
            loader = loader + "		halt	" + VbX.nl();
            Clipboard.SetText(loader);
            VbX.MsgBox("Saved, and sample loader in clipboard.");
            btnRefresh_Click(null, null);

        }
        /***********************************************************************************************************************************************/
        private void addOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CpcSpriteCompiler != null)
            {
                // CpcSpriteCompiler.globals_LastFrame = null;
                CpcSpriteCompiler.clearPrevioushistory();
            }
            CpcSpriteConvaddOneDiffToolStripMenuItem_Click(sender, e);

        }

        private void addOneToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ZxSpriteCompiler == null)
            {
                ZxSpriteCompiler = new AkuSpriteEditor.CompZX();
                ZxSpriteCompiler.Doreset();
            }
            ZxSpriteCompiler.txtFilename_Text = "ClipImage";
            Bitmap clipbit = new Bitmap(256, 192);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 192; y++)
                {
                    int a = spritepixel[CurrentBank, CurrentSprite, x, y];
                    if (a > 1) a = 1;
                    ZxSpriteCompiler.globals_PixelMap[x, y] = a;


                    clipbit.SetPixel(x, y, ColorSelector[spritepixel[CurrentBank, CurrentSprite, x, y]].BackColor);
                }
            }







            for (int y = 0; y < 192 / 8; y++)
            {
                for (int x = 0; x < 256 / 8; x++)
                {
                    string tbyte = "0"; //flashing is bad -mkay!
                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteL[CurrentBank, CurrentSprite, x, y]).Substring(7, 1);

                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteB[CurrentBank, CurrentSprite, x, y]).Substring(5, 3);
                    tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteF[CurrentBank, CurrentSprite, x, y]).Substring(5, 3);

                    ZxSpriteCompiler.globals_Colormap[(y * 32) + x] = VbX.Bin2Dec(tbyte);

                }
            }
            ZxSpriteCompiler.globals_ColormapSize = 32 * 24;

            Clipboard.SetImage(clipbit);
            ZxSpriteCompiler.button1_Click(null, null);
            string s = ZxSpriteCompiler.textBox1_Text;
            Clipboard.SetText(s);
            VbX.MsgBox("Saved to clipboard!");
        }
        /************************************************************************************************************************************************/
        private void duplicateFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dupefrom = VbX.InputBox("?", "Copy Ftom which sprite?", CurrentSprite.ToString());
            if (dupefrom.Length == 0) return;
            int df = VbX.CInt(dupefrom);

            Spr_Wid[CurrentSprite] = Spr_Wid[df];
            Spr_Hei[CurrentSprite] = Spr_Hei[df];
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = spritepixel[CurrentBank, df, x, y];
                }
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = SpeccyPaletteF[CurrentBank, df, x, y];
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = SpeccyPaletteB[CurrentBank, df, x, y];
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = SpeccyPaletteL[CurrentBank, df, x, y];
                }
            }

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void flipXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] ptemp = new byte[256, 256];
            byte[,] ptempF = new byte[32, 32];
            byte[,] ptempB = new byte[32, 32];
            byte[,] ptempL = new byte[32, 32];

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    ptemp[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    ptempF[x, y] = SpeccyPaletteF[CurrentBank, CurrentSprite, x, y];
                    ptempB[x, y] = SpeccyPaletteB[CurrentBank, CurrentSprite, x, y];
                    ptempL[x, y] = SpeccyPaletteL[CurrentBank, CurrentSprite, x, y];
                }
            }

            int w = Spr_Wid[CurrentSprite] - 1;
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x <= w; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = ptemp[w - x, y];
                }
            }
            w = (Spr_Wid[CurrentSprite] / 8) - 1;
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x <= w; x++)
                {

                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = ptempF[w - x, y];
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = ptempB[w - x, y];
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = ptempL[w - x, y];
                }
            }

            btnRefresh_Click(sender, e);

        }
        /************************************************************************************************************************************************/
        private void flipYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] ptemp = new byte[256, 256];
            byte[,] ptempF = new byte[32, 32];
            byte[,] ptempB = new byte[32, 32];
            byte[,] ptempL = new byte[32, 32];

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    ptemp[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    ptempF[x, y] = SpeccyPaletteF[CurrentBank, CurrentSprite, x, y];
                    ptempB[x, y] = SpeccyPaletteB[CurrentBank, CurrentSprite, x, y];
                    ptempL[x, y] = SpeccyPaletteL[CurrentBank, CurrentSprite, x, y];
                }
            }

            int h = Spr_Hei[CurrentSprite] - 1;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x, y] = ptemp[x, h - y];
                }
            }
            h = (Spr_Hei[CurrentSprite] / 8) - 1;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < 32; x++)
                {

                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = ptempF[x, h - y];
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = ptempB[x, h - y];
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = ptempL[x, h - y];
                }
            }

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void mSX16ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoDisplayMSX.Checked = true;
        }
        /************************************************************************************************************************************************/
        private void cPC4ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoDisplayCPC.Checked = true;

        }
        /************************************************************************************************************************************************/
        private void zX2ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoDisplaySpeccy.Checked = true;
        }
        /************************************************************************************************************************************************/
        private void highVisToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkStrongGrid.Checked = !chkStrongGrid.Checked;
        }
        /************************************************************************************************************************************************/
        private void reSaveSpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosave(lastfilename);
        }

        /************************************************************************************************************************************************/

        private void chkAligned_CheckedChanged(object sender, EventArgs e)
        {
            Spr_MemposReset[CurrentSprite] = 0;
            if (chkAligned.Checked) Spr_MemposReset[CurrentSprite] = 1;
        }
        /************************************************************************************************************************************************/
        private void txtSpriteSettings_TextChanged(object sender, EventArgs e)
        {
            Spr_Xoff[CurrentSprite] = (byte)VbX.CInt(txtSpriteSettings.Text);
        }
        /************************************************************************************************************************************************/
        private void btnLastBank_Click(object sender, EventArgs e)
        {
            if (CurrentBank > 0) CurrentBank = CurrentBank - 1;
            for (int s = 0; s < 64; s++)
            {

                SpriteStats(s);         // update all our info on the sprites
                SaveSpriteDetails(s);
            }
            ChangeCurrentSprite();
        }
        /************************************************************************************************************************************************/
        private void btnNextBank_Click(object sender, EventArgs e)
        {
            if (CurrentBank < 16) CurrentBank = CurrentBank + 1;

            for (int s = 0; s < 64; s++)
            {

                SpriteStats(s);         // update all our info on the sprites
                SaveSpriteDetails(s);
            }

            ChangeCurrentSprite();
        }
        /************************************************************************************************************************************************/
        private void duplicateOffsetFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dupefrom = VbX.InputBox("?", "Copy From which sprite?", CurrentSprite.ToString());
            string offset = VbX.InputBox("?", "X,Y offset", "0,0");
            if (dupefrom.Length == 0) return;
            int df = VbX.CInt(dupefrom);

            Spr_Wid[CurrentSprite] = Spr_Wid[df];
            Spr_Hei[CurrentSprite] = Spr_Hei[df];
            int xoff = VbX.CInt(ss.GetItem(offset, 0));
            int yoff = VbX.CInt(ss.GetItem(offset, 1));
            for (int y = 0; y < 256 - yoff; y++)
            {
                for (int x = 0; x < 256 - xoff; x++)
                {
                    spritepixel[CurrentBank, CurrentSprite, x + xoff, y + yoff] = spritepixel[CurrentBank, df, x, y];
                }
            }
            xoff = xoff / 8;
            yoff = yoff / 8;
            for (int y = 0; y < 32 - yoff; y++)
            {
                for (int x = 0; x < 32 - xoff; x++)
                {
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x + xoff, y + yoff] = SpeccyPaletteF[CurrentBank, df, x, y];
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x + xoff, y + yoff] = SpeccyPaletteB[CurrentBank, df, x, y];
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x + xoff, y + yoff] = SpeccyPaletteL[CurrentBank, df, x, y];
                }
            }

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveMSXRLESpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMSXSprites(true);
        }
        /************************************************************************************************************************************************/

        private void rdoGuideNone_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void tabEditor_Click(object sender, EventArgs e)
        {

        }
        /************************************************************************************************************************************************/
        private void yInterlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = Spr_Hei[CurrentSprite] * 2; y > 0; y--)
            {
                for (int x = 0; x < Spr_Wid[CurrentSprite]; x++)
                {
                    if (y % 2 == 0)
                    {
                        spritepixel[CurrentBank, CurrentSprite, x, y] = 0;
                    }
                    else
                    {
                        spritepixel[CurrentBank, CurrentSprite, x, y] = spritepixel[CurrentBank, CurrentSprite, x, y / 2];
                    }

                }
            }
            Spr_Hei[CurrentSprite] *= 2;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void label3_Click(object sender, EventArgs e)
        {

        }
        /************************************************************************************************************************************************/
        private void setAllAttribsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newval = VbX.CInt(VbX.InputBox("Set all", "128=Pset,64=DoubleHeight", "-1"));
            if (newval < 0) return;
            txtSpriteSettings.Text = newval.ToString();
            for (int s = 0; s < 63; s++)
            {
                Spr_Xoff[s] = (byte)newval;
            }
        }
        /************************************************************************************************************************************************/
        private void saveSpectrumTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "ZXS Binary Tiles (*.TSP)|*.TSP";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            SaveSpectrum(fd.FileName, false);
        }
        /************************************************************************************************************************************************/
        private void SaveSpectrum(string filename, bool SaveColors)
        {

            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }






            System.IO.Stream ST = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            byte b = 0;
            int bytepos = 0;
            int thisspritebytepos = firstspritepos;

            for (int s = 0; s < SpriteCount; s++)
            {
                BW.Write((Byte)(Spr_Hei[s] - Spr_MinY[s]));
                BW.Write((Byte)((Spr_Wid[s] + 7) / 8));
                BW.Write((Byte)Spr_MinY[s]);
                BW.Write((Byte)Spr_Xoff[s]);

                if (Spr_MemposReset[s] != 0 && thisspritebytepos % 256 != 0)
                {
                    thisspritebytepos = thisspritebytepos / 256;
                    thisspritebytepos++;
                    thisspritebytepos = thisspritebytepos * 256;
                }


                UInt16 mp = (UInt16)(thisspritebytepos);
                int thisspritesize = ((Spr_Hei[s] - Spr_MinY[s]) * ((Spr_Wid[s] + 7) / 8));

                if (SaveColors == true)
                {
                    thisspritesize += ((Spr_Hei[s] + 7) / 8) * ((Spr_Wid[s] + 7) / 8);//- (((Spr_MinY[s]) + 7) / 8))
                }
                if (thisspritesize < 0)
                {
                    VbX.MsgBox("You have a negative sprite size");
                    thisspritesize = 0;
                }
                thisspritebytepos = thisspritebytepos + thisspritesize;
                BW.Write(mp);
                bytepos += 6;
            }
            while (bytepos < firstspritepos)
            {
                bytepos++;
                BW.Write((Byte)(0));
            }




            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {

                if (Spr_MemposReset[spritenum] != 0)
                {
                    while (ST.Position % 256 != 0)
                    {
                        BW.Write((Byte)(0));
                        //   VbX.MsgBox(ST.Position.ToString());
                    }
                }

                for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y++)
                {
                    for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                    {
                        int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                        int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];
                        int sp3 = spritepixel[CurrentBank, spritenum, x + 2, y];
                        int sp4 = spritepixel[CurrentBank, spritenum, x + 3, y];
                        int sp5 = spritepixel[CurrentBank, spritenum, x + 4, y];
                        int sp6 = spritepixel[CurrentBank, spritenum, x + 5, y];
                        int sp7 = spritepixel[CurrentBank, spritenum, x + 6, y];
                        int sp8 = spritepixel[CurrentBank, spritenum, x + 7, y];


                        if (sp4 == 16 && sp3 == 16 && sp2 == 16 && sp1 == 16 && sp5 == 16 && sp6 == 16 && sp7 == 16 && sp8 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                                sp3 = 0;
                                sp4 = 1;
                                sp5 = 0;
                                sp6 = 1;
                                sp7 = 0;
                                sp8 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 1;
                                sp2 = 0;
                                sp3 = 1;
                                sp4 = 0;
                                sp5 = 1;
                                sp6 = 0;
                                sp7 = 1;
                                sp8 = 0;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        if (sp3 == 16) sp3 = 0;
                        if (sp4 == 16) sp4 = 0;
                        if (sp5 == 16) sp5 = 0;
                        if (sp6 == 16) sp6 = 0;
                        if (sp7 == 16) sp7 = 0;
                        if (sp8 == 16) sp8 = 0;

                        if (sp1 > 1) sp1 = 1;
                        if (sp2 > 1) sp2 = 1;
                        if (sp3 > 1) sp3 = 1;
                        if (sp4 > 1) sp4 = 1;
                        if (sp5 > 1) sp5 = 1;
                        if (sp6 > 1) sp6 = 1;
                        if (sp7 > 1) sp7 = 1;
                        if (sp8 > 1) sp8 = 1;

                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);





                        BW.Write((Byte)VbX.Bin2Dec(tbyte));



                    }

                }

                if (SaveColors)
                {
                    for (int y = 0; y < ((Spr_Hei[spritenum] + 7) / 8); y++)//((Spr_MinY[spritenum] + 7) / 8)
                    {
                        for (int x = 0; x < ((Spr_Wid[spritenum] + 7) / 8); x++)
                        {
                            string tbyte = "0"; //flashing is bad -mkay!
                            tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteL[CurrentBank, spritenum, x, y]).Substring(7, 1);
                            tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteB[CurrentBank, spritenum, x, y]).Substring(5, 3);
                            tbyte += VbX.Dec2Bin8Bit(SpeccyPaletteF[CurrentBank, spritenum, x, y]).Substring(5, 3);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));

                        }
                    }
                }
            }

            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(null, null);

        }
        /************************************************************************************************************************************************/
        private void chkFixedSize_MouseUp(object sender, MouseEventArgs e)
        {
            Spr_FixedSize[CurrentSprite] = 0;
            if (chkFixedSize.Checked)
            {
                SpriteStats(CurrentSprite);
                Spr_FixedSize[CurrentSprite] = 1;
                Spr_MinX[CurrentSprite] = 0;
                Spr_MinY[CurrentSprite] = 0;


                string newxy = VbX.InputBox("New size? (X,Y)", "New size (X,Y)", VbX.CStr(Spr_Wid[CurrentSprite]) + "," + VbX.CStr(Spr_Hei[CurrentSprite]));
                Spr_Wid[CurrentSprite] = (byte)VbX.CInt(ss.GetItem(newxy, ",", 0));
                Spr_Hei[CurrentSprite] = (byte)VbX.CInt(ss.GetItem(newxy, ",", 1));

            }
        }
        /************************************************************************************************************************************************/
        private void pixelShiftUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pixmove = VbX.CInt(VbX.InputBox("Move Size", "Move Size", "4"));
            if (pixmove == 0) return;

            for (int y = 0; y <= Spr_Hei[CurrentSprite] - 1; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    byte a = 0;
                    if (y + pixmove < 256)
                    {
                        a = spritepixel[CurrentBank, CurrentSprite, x, y + pixmove];
                    }
                    spritepixel[CurrentBank, CurrentSprite, x, y] = a;
                }
            }

            for (int y = 0; y < Spr_Hei[CurrentSprite] / 8; y++)
            {
                for (int x = 0; x <= Spr_Wid[CurrentSprite] / 8; x++)
                {
                    byte f = 7;
                    byte b = 0;
                    byte l = 0;
                    if (y - pixmove / 8 >= 0)
                    {
                        f = SpeccyPaletteF[CurrentBank, CurrentSprite, x, y + pixmove / 8];
                        b = SpeccyPaletteB[CurrentBank, CurrentSprite, x, y + pixmove / 8];
                        l = SpeccyPaletteL[CurrentBank, CurrentSprite, x, y + pixmove / 8];
                    }
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = f;
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = b;
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = l;
                }

            }
            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void pixelShiftDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pixmove = VbX.CInt(VbX.InputBox("Move Size", "Move Size", "4"));
            if (pixmove == 0) return;

            Spr_Hei[CurrentSprite] += (byte)pixmove;
            for (int y = Spr_Hei[CurrentSprite] - 1; y >= 0; y--)
            {
                for (int x = 0; x < Spr_Wid[CurrentSprite]; x++)
                {
                    byte a = 0;
                    if (y - pixmove >= 0)
                    {
                        a = spritepixel[CurrentBank, CurrentSprite, x, y - pixmove];
                    }
                    spritepixel[CurrentBank, CurrentSprite, x, y] = a;
                }
            }
            for (int y = Spr_Hei[CurrentSprite] / 8; y >= 0; y--)
            {
                for (int x = 0; x <= Spr_Wid[CurrentSprite] / 8; x++)
                {
                    byte f = 7;
                    byte b = 0;
                    byte l = 0;
                    if (y - pixmove / 8 >= 0)
                    {
                        f = SpeccyPaletteF[CurrentBank, CurrentSprite, x, y - pixmove / 8];
                        b = SpeccyPaletteB[CurrentBank, CurrentSprite, x, y - pixmove / 8];
                        l = SpeccyPaletteL[CurrentBank, CurrentSprite, x, y - pixmove / 8];
                    }
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = f;
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = b;
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = l;
                }

            }
            btnRefresh_Click(null, null);
        }

        /************************************************************************************************************************************************/
        private void pixelShiftRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pixmove = VbX.CInt(VbX.InputBox("Move Size", "Move Size", "4"));
            if (pixmove == 0) return;

            Spr_Wid[CurrentSprite] += (byte)pixmove;
            for (int y = 0; y < Spr_Hei[CurrentSprite]; y++)
            {

                for (int x = Spr_Wid[CurrentSprite] - 1; x >= 0; x--)
                {
                    byte a = 0;
                    if (x - pixmove >= 0)
                    {
                        a = spritepixel[CurrentBank, CurrentSprite, x - pixmove, y];
                    }
                    spritepixel[CurrentBank, CurrentSprite, x, y] = a;
                }

            }
            for (int y = 0; y < Spr_Hei[CurrentSprite] / 8; y++)
            {

                for (int x = Spr_Wid[CurrentSprite] / 8; x >= 0; x--)
                {
                    byte f = 7;
                    byte b = 0;
                    byte l = 0;
                    if (x - pixmove / 8 >= 0)
                    {
                        f = SpeccyPaletteF[CurrentBank, CurrentSprite, x - pixmove / 8, y];
                        b = SpeccyPaletteB[CurrentBank, CurrentSprite, x - pixmove / 8, y];
                        l = SpeccyPaletteL[CurrentBank, CurrentSprite, x - pixmove / 8, y];
                    }
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = f;
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = b;
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = l;
                }

            }

            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void pxShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pixmove = VbX.CInt(VbX.InputBox("Move Size", "Move Size", "2"));
            if (pixmove == 0) return;


            for (int y = 0; y < 256; y++)
            {

                for (int x = 0; x <= Spr_Wid[CurrentSprite] - 1; x++)
                {
                    byte a = 0;
                    if (x + pixmove < 256)
                    {
                        a = spritepixel[CurrentBank, CurrentSprite, x + pixmove, y];
                    }
                    spritepixel[CurrentBank, CurrentSprite, x, y] = a;
                }

            }
            for (int y = 0; y < Spr_Hei[CurrentSprite] / 8; y++)
            {

                for (int x = 0; x <= Spr_Wid[CurrentSprite] / 8; x++)
                {
                    byte f = 7;
                    byte b = 0;
                    byte l = 0;
                    if (x - pixmove / 8 >= 0)
                    {
                        f = SpeccyPaletteF[CurrentBank, CurrentSprite, x + pixmove / 8, y];
                        b = SpeccyPaletteB[CurrentBank, CurrentSprite, x + pixmove / 8, y];
                        l = SpeccyPaletteL[CurrentBank, CurrentSprite, x + pixmove / 8, y];
                    }
                    SpeccyPaletteF[CurrentBank, CurrentSprite, x, y] = f;
                    SpeccyPaletteB[CurrentBank, CurrentSprite, x, y] = b;
                    SpeccyPaletteL[CurrentBank, CurrentSprite, x, y] = l;
                }

            }
            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void blackBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = Spr_Wid[CurrentSprite] - 1;
            int h = Spr_Hei[CurrentSprite] - 1;
            for (int y = 0; y <= h; y++)
            {
                for (int x = 0; x <= w; x++)
                {
                    if (spritepixel[CurrentBank, CurrentSprite, x, y] > 1)
                    {
                        for (int xx = -1; xx <= 1; xx++)
                        {
                            for (int yy = -1; yy <= 1; yy++)
                            {
                                int px = x + xx;
                                int py = y + yy;
                                if (px >= 0 && py >= 0 && px <= w && py <= h)
                                {
                                    if (spritepixel[CurrentBank, CurrentSprite, px, py] == 0)
                                    {
                                        spritepixel[CurrentBank, CurrentSprite, px, py] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            btnRefresh_Click(null, null);
        }

        /************************************************************************************************************************************************/

        private void saveASMPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog fd = new SaveFileDialog();
            //fd.Filter = "MSX Palette ASM Code (*.txt)|*.txt";
            //DialogResult dr = fd.ShowDialog();
            //if (dr != DialogResult.OK) return;

            string nl = VbX.Chr(13) + VbX.Chr(10);
            //System.IO.StreamWriter SR = new System.IO.StreamWriter(fd.FileName, false, Encoding.ASCII);
            StringBuilder SR = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {
                SR.Append("defw &0");
                SR.Append(VbX.Hex(ColorSelector[i].BackColor.G / 16));
                SR.Append(VbX.Hex(ColorSelector[i].BackColor.R / 16));
                SR.Append(VbX.Hex(ColorSelector[i].BackColor.B / 16));

                SR.Append(";" + VbX.CStr(i) + "  -GRB");
                SR.Append(nl);
            }

            // SR.Close();
            Clipboard.SetText(SR.ToString());
            VbX.MsgBox("Copied to Clipboard");
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        /************************************************************************************************************************************************/
        private void rdoFrameNext_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoFrameLast_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/
        private void overlayLastFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rdoFrameLast.Checked) rdoFrameNone.Checked = true; else rdoFrameLast.Checked = true;
            btnRefresh_Click(sender, e);

        }
        /************************************************************************************************************************************************/
        private void overlayNextFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rdoFrameNext.Checked) rdoFrameNone.Checked = true; else rdoFrameNext.Checked = true;
            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/
        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab != tabEditor) return;

            if (e.KeyCode == Keys.Down && CurrentBank > 0) { btnLastBank_Click(null, null); e.SuppressKeyPress = true; return; }
            if (e.KeyCode == Keys.Up && CurrentBank < 15) { btnNextBank_Click(null, null); e.SuppressKeyPress = true; return; }
            if (e.KeyCode == Keys.Left && CurrentSprite > 0) { btnLastSprite_Click(null, null); e.SuppressKeyPress = true; return; }
            if (e.KeyCode == Keys.Right && CurrentSprite < 63) { btnNextSprite_Click(null, null); e.SuppressKeyPress = true; return; }
            if (e.Modifiers == (Keys.Shift | Keys.Control) && e.KeyCode == Keys.Z) { btnRedo_Click(null, null); return; }
            if (e.Modifiers == (Keys.Control) && e.KeyCode == Keys.Z) { btnUndo_Click(null, null); return; }
            if (e.KeyCode == Keys.F5) btnRefresh_Click(null, null);
            if (e.KeyCode == Keys.Add && trkzoom.Value < 32) { trkzoom.Value++; doscale(trkzoom.Value); }
            if (e.KeyCode == Keys.Subtract && trkzoom.Value > 0) { trkzoom.Value--; doscale(trkzoom.Value); }

            if (e.Modifiers == (Keys.Control) && e.KeyCode == Keys.C) { copyToClipboardToolStripMenuItem_Click(null, null); return; }
            if (e.Modifiers == (Keys.Shift | Keys.Control) && e.KeyCode == Keys.C) { copyPreviewToolStripMenuItem_Click(null, null); return; }
            if (e.Modifiers == (Keys.Control) && e.KeyCode == Keys.V) { pasteToClipToolStripMenuItem_Click(null, null); return; }

        }
        /************************************************************************************************************************************************/
        private void makeTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newxy = VbX.InputBox("New size? (X,Y)", "New size (X,Y)", VbX.CStr(Spr_Wid[CurrentSprite]) + "," + VbX.CStr(Spr_Hei[CurrentSprite]));
            int mx = (byte)VbX.CInt(ss.GetItem(newxy, ",", 0));
            int my = (byte)VbX.CInt(ss.GetItem(newxy, ",", 1));

            for (int x = 0; x < mx; x++)
            {
                for (int y = 0; y < my; y++)
                {
                    int x2 = x % Spr_Wid[CurrentSprite];
                    int y2 = y % Spr_Hei[CurrentSprite];

                    spritepixel[CurrentBank, CurrentSprite, x, y] = spritepixel[CurrentBank, CurrentSprite, x2, y2];

                }
            }

            Spr_Wid[CurrentSprite] = (byte)mx;
            Spr_Hei[CurrentSprite] = (byte)my;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void tileShiftXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pixmove = VbX.CInt(VbX.InputBox("Move Size", "Move Size", "4"));
            if (pixmove == 0) return;

            byte[,] Sbak = new byte[256, 256];

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    Sbak[x, y] = spritepixel[CurrentBank, CurrentSprite, x, y];
                }
            }

            for (int y = 0; y < 256; y++)
            {

                for (int x = Spr_Wid[CurrentSprite] - 1; x >= 0; x--)
                {

                    int x2 = x + pixmove;
                    if (x2 >= 256) x2 -= 256;

                    spritepixel[CurrentBank, CurrentSprite, x, y] = Sbak[x2, y];
                }

            }
            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void blackBorderTightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = Spr_Wid[CurrentSprite] - 1;
            int h = Spr_Hei[CurrentSprite] - 1;
            for (int y = 0; y <= h; y++)
            {
                for (int x = 0; x <= w; x++)
                {
                    if (spritepixel[CurrentBank, CurrentSprite, x, y] > 1)
                    {
                        for (int xx = -1; xx <= 1; xx++)
                        {
                            for (int yy = 0; yy <= 0; yy++)
                            {
                                int px = x + xx;
                                int py = y + yy;
                                if (px >= 0 && py >= 0 && px <= w && py <= h)
                                {
                                    if (spritepixel[CurrentBank, CurrentSprite, px, py] == 0)
                                    {
                                        spritepixel[CurrentBank, CurrentSprite, px, py] = 1;
                                    }
                                }
                            }
                        }
                        for (int xx = 0; xx <= 0; xx++)
                        {
                            for (int yy = -1; yy <= 1; yy++)
                            {
                                int px = x + xx;
                                int py = y + yy;
                                if (px >= 0 && py >= 0 && px <= w && py <= h)
                                {
                                    if (spritepixel[CurrentBank, CurrentSprite, px, py] == 0)
                                    {
                                        spritepixel[CurrentBank, CurrentSprite, px, py] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            btnRefresh_Click(null, null);
        }
        /************************************************************************************************************************************************/
        private void PaletteTint_Click(object sender, EventArgs e)
        {
            string ncol = VbX.InputBox("New COLOR (R,G,B)", "New COLOR (R,G,B)", "255,255,255");
            string ntint = VbX.InputBox("New Tint (0-1)", "New Tint (0-1)", ".1");
            int rr = (byte)VbX.CInt(ss.GetItem(ncol, ",", 0));
            int gg = (byte)VbX.CInt(ss.GetItem(ncol, ",", 1));
            int bb = (byte)VbX.CInt(ss.GetItem(ncol, ",", 2));
            Double aa = Double.Parse(ntint);

            Double a2 = 1 - aa;
            for (int c = 0; c < 16; c++)
            {
                int r2 = (int)((ColorSelector[c].BackColor.R * a2) + (rr * aa));
                int g2 = (int)((ColorSelector[c].BackColor.G * a2) + (gg * aa));
                int b2 = (int)((ColorSelector[c].BackColor.B * a2) + (bb * aa));

                ColorSelector[c].BackColor = Color.FromArgb(255, r2, g2, b2);



            }

        }
        /************************************************************************************************************************************************/
        private void saveSpectrumFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "ZXS Binary Sprite (*.FNT)|*.FNT";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            saveSpectrumFont(BW);
            BW.Close();


        }
        /************************************************************************************************************************************************/
        private void halfSizeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {

                    int sp1 = spritepixel[CurrentBank, spritenum, x, y] + spritepixel[CurrentBank, spritenum, x + 1, y];
                    int sp3 = spritepixel[CurrentBank, spritenum, x + 2, y] + spritepixel[CurrentBank, spritenum, x + 3, y];
                    int sp5 = spritepixel[CurrentBank, spritenum, x + 4, y] + spritepixel[CurrentBank, spritenum, x + 5, y];
                    int sp7 = spritepixel[CurrentBank, spritenum, x + 6, y] + spritepixel[CurrentBank, spritenum, x + 7, y];
                    if (sp1 > 1) sp1 = 1;
                    if (sp3 > 1) sp3 = 1;
                    if (sp5 > 1) sp5 = 1;
                    if (sp7 > 1) sp7 = 1;
                    spritepixel[CurrentBank, spritenum, x, y] = (byte)(sp1);
                    spritepixel[CurrentBank, spritenum, x + 1, y] = (byte)(sp3);
                    spritepixel[CurrentBank, spritenum, x + 2, y] = (byte)(sp5);
                    spritepixel[CurrentBank, spritenum, x + 3, y] = (byte)(sp7);
                    spritepixel[CurrentBank, spritenum, x + 4, y] = 0;
                    spritepixel[CurrentBank, spritenum, x + 5, y] = 0;
                    spritepixel[CurrentBank, spritenum, x + 6, y] = 0;
                    spritepixel[CurrentBank, spritenum, x + 7, y] = 0;


                }
            }

        }
        /************************************************************************************************************************************************/
        private void saveCPCBinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CPC Binary Sprite (*.PLS)|*.PLS";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }





            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            byte b = 0;

            for (int s = 0; s < 16; s++)
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 15; x += 2)
                    {



                        // ; int b2 = b / 16;
                        // ; int b1 = b % 16;
                        // ; spritepixel[CurrentBank, s, x, y] = (byte)b1;
                        // ; spritepixel[CurrentBank, s, x + 1, y] = (byte)b2;

                        int b2 = spritepixel[CurrentBank, s, x, y];
                        int b1 = spritepixel[CurrentBank, s, x + 1, y] * 16;
                        b = (byte)(b2 + b1);
                        BW.Write((Byte)b);

                    }
                }
            }

            BW.Close();
            ST.Close();
            VbX.MsgBox("Save");
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdospr512_CheckedChanged(object sender, EventArgs e)
        {
            if (rdospr512.Checked)
            {
                maxSpriteSize = 512;
                InitMaxSpriteSize();
            }
            doscale(trkzoom.Value);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdospr256_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdospr512.Checked)
            {
                maxSpriteSize = 256;
                InitMaxSpriteSize();
            }
            doscale(trkzoom.Value);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    int yy = 0;
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);
                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + yy);
                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);
                    int sp8 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + yy);


                    if (sp4 == 16 && sp3 == 16 && sp2 == 16 && sp1 == 16 && sp5 == 16 && sp6 == 16 && sp7 == 16 && sp8 == 16)
                    {
                        int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                        if (transpcol == 5)
                        {
                            sp1 = 0;
                            sp2 = 1;
                            sp3 = 0;
                            sp4 = 1;
                            sp5 = 0;
                            sp6 = 1;
                            sp7 = 0;
                            sp8 = 1;
                        }
                        if (transpcol == 4)
                        {
                            sp1 = 1;
                            sp2 = 0;
                            sp3 = 1;
                            sp4 = 0;
                            sp5 = 1;
                            sp6 = 0;
                            sp7 = 1;
                            sp8 = 0;
                        }
                    }
                    if (sp1 == 16) sp1 = 0;
                    if (sp2 == 16) sp2 = 0;
                    if (sp3 == 16) sp3 = 0;
                    if (sp4 == 16) sp4 = 0;
                    if (sp5 == 16) sp5 = 0;
                    if (sp6 == 16) sp6 = 0;
                    if (sp7 == 16) sp7 = 0;
                    if (sp8 == 16) sp8 = 0;

                    if (sp1 > 1) sp1 = 1;
                    if (sp2 > 1) sp2 = 1;
                    if (sp3 > 1) sp3 = 1;
                    if (sp4 > 1) sp4 = 1;
                    if (sp5 > 1) sp5 = 1;
                    if (sp6 > 1) sp6 = 1;
                    if (sp7 > 1) sp7 = 1;
                    if (sp8 > 1) sp8 = 1;

                    string tbyte = "";

                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));


                }

            }
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void MSX_SaveRAW_16Color(System.IO.BinaryWriter BW, int spritenum)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y++)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 2)
                {
                    int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                    int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];


                    if (sp2 == 16 && sp1 == 16)
                    {
                        int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                        if (transpcol == 5)
                        {
                            sp1 = 0;
                            sp2 = 1;
                        }
                        if (transpcol == 4)
                        {
                            sp1 = 3;
                            sp2 = 2;
                        }
                    }
                    if (sp1 == 16) sp1 = 0;
                    if (sp2 == 16) sp2 = 0;


                    string tbyte = "";

                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    //tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);




                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                }
            }


        }
        /************************************************************************************************************************************************/
        private void saveRAWBitmapToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            MSX_SaveRAW_16Color(BW, CurrentSprite);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // SAM uses same screen format as MSX
            saveRAWBitmapToolStripMenuItem3_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //Spectrum and TI-83 use the same bitmap format!
            saveRawBitmapToolStripMenuItem1_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveCPCZigTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CPC Binary Sprite (*.SPR)|*.SPR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            int thisspritebytepos = firstspritepos;




            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {
                if (Spr_MemposReset[spritenum] != 0)
                {
                    while (ST.Position % 256 != 0)
                    {
                        BW.Write((Byte)(0));
                        //   VbX.MsgBox(ST.Position.ToString());
                    }
                }
                if (rdoDisplayCPC0.Checked)
                {
                    CPC_SaveRAW_16Color(BW, spritenum, 1);
                }
                else
                {
                    CPC_SaveRAW_4Color(BW, spritenum, true, 1);
                }

            }

            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_Planar(BW, CurrentSprite, 4);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        void SaveRAW_Planar(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int y2 = 0; y2 < 8; y2++)
                    {

                        int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                        int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                        int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                        int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);

                        /*
                        if ( sp2 == 16 && sp1 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 3;
                                sp2 = 2;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        */



                        for (int p = 7; p > 7 - planes; p--)
                        {
                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }

                    }//y2
                }//x
            }//y

        }

        /************************************************************************************************************************************************/
        void SaveRAW_PlanarPCE(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int p2 = 2; p2 >= 0; p2 -= 2)
                    {
                        for (int y2 = 0; y2 < 8; y2++)
                        {

                            int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                            int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                            int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                            int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);


                            string tbyte = "";
                            int p = 5 + p2;

                            tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                            p = 4 + p2;

                            tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));


                        }//y2
                    }//p2
                }//x
            }//y

        }

        /************************************************************************************************************************************************/

        void SaveRAW_PlanarSNS(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int p2 = 2; p2 >= 0; p2 -= 2)

                    //   for (int p2 =0 ; p2 <= 2; p2 += 2)
                    {
                        for (int y2 = 0; y2 < 8; y2++)
                        {

                            int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                            int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                            int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                            int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);


                            string tbyte = "";
                            int p = 4 + p2;

                            tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                            p = 5 + p2;

                            tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));


                        }//y2
                    }//p2
                }//x
            }//y

        }

        /************************************************************************************************************************************************/

        void SaveRAW_PlanarNES(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int p2 = 0; p2 <= 1; p2 += 1)
                    {
                        for (int y2 = 0; y2 < 8; y2++)
                        {

                            int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                            int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                            int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                            int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);


                            string tbyte = "";
                            int p = 7 - p2;

                            tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));



                        }//y2
                    }//p2
                }//x
            }//y

        }

        /************************************************************************************************************************************************/

        void SaveRAW_PlanarAMI(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    int y2 = 0;

                    int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);



                    for (int p = 7; p > 7 - planes; p--)
                    {
                        string tbyte = "";
                        tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }

                }//x
            }//y

        }

        void SaveRAW_PlanarCLX(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int p = 7; p > 7 - planes; p--)
                {
                    for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                    {
                        int y2 = 0;

                        int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                        int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                        int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                        int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);




                        string tbyte = "";
                        tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }//x

                }//p
            }//y

        }

        void SaveRAW_PlanarCLX8(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y2 = Spr_MinY[spritenum]; y2 < Spr_Hei[spritenum]; y2 += 8)
            {

                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int p = 7; p > 7 - planes; p--)
                    {

                        for (int y = 0; y < 8; y += 1)
                        {


                            int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                            int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                            int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                            int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);




                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }//x

                    }//p
                }//y
            }
        }
        /************************************************************************************************************************************************/


        void SaveRAW_PlanarAST(System.IO.BinaryWriter BW, int spritenum, int planes)
        {
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 16)
                {
                    //  for (int y2 = 0; y2 < 8; y2++)
                    // {
                    int y2 = 0;

                    int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);

                    int sp8 = GetDisplayNum(CurrentBank, spritenum, x + 8, y + y2);
                    int sp9 = GetDisplayNum(CurrentBank, spritenum, x + 9, y + y2);
                    int spA = GetDisplayNum(CurrentBank, spritenum, x + 10, y + y2);
                    int spB = GetDisplayNum(CurrentBank, spritenum, x + 11, y + y2);
                    int spC = GetDisplayNum(CurrentBank, spritenum, x + 12, y + y2);
                    int spD = GetDisplayNum(CurrentBank, spritenum, x + 13, y + y2);
                    int spE = GetDisplayNum(CurrentBank, spritenum, x + 14, y + y2);
                    int spF = GetDisplayNum(CurrentBank, spritenum, x + 15, y + y2);


                    for (int p = 7; p > 7 - planes; p--)
                    {
                        string tbyte = "";
                        tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        tbyte = "";
                        tbyte += VbX.Dec2Bin8Bit(sp8).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp9).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spA).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spB).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spC).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spD).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spE).Substring(p, 1);
                        tbyte += VbX.Dec2Bin8Bit(spF).Substring(p, 1);
                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }

                    //  }//y2
                }//x
            }//y

        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_Planar(BW, CurrentSprite, 2);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveRLEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StringBuilder result = new StringBuilder();
            StringBuilder Header = new StringBuilder();

            for (int c = 0; c < SpriteCount; c++)
            {

                int w = Spr_Wid[c] / 2;
                string Filen = "Sprite" + VbX.CStr(c);
                Header.Append("jp " + Filen + "_Setup" + VbX.nl());
                result.Append(Filen + "_Setup:" + VbX.nl());

                result.Append("ld hl," + Filen + "_Start-1" + VbX.nl());
                result.Append("ld de," + Filen + "_End-1" + VbX.nl());
                result.Append("ld b,0   ;Y-Start" + VbX.nl());
                result.Append("ld ixh," + VbX.CStr(w) + "	;Width" + VbX.nl());
                result.Append("ld IXL," + VbX.CStr(64 - (w / 2)) + "+" + VbX.CStr(w) + "-1	;X-Righthandside" + VbX.nl());
                result.Append("ret" + VbX.nl());


                AkuSpriteEditor.RLEBinarySAM nr = new AkuSpriteEditor.RLEBinarySAM();
                result.Append(Filen + "_Start:" + VbX.nl());
                nr.width = Spr_Wid[c];
                nr.height = Spr_Hei[c];
                nr.spritepixel = new short[maxSpriteSize, maxSpriteSize];
                for (int y = 0; y < nr.height; y++)
                {
                    for (int x = 0; x < nr.width; x++)
                    {
                        nr.spritepixel[x, y] = spritepixel[CurrentBank, c, x, y];
                    }
                }
                nr.NewRLE();

                result.Append("db ");
                for (int i = 0; i < nr.RleDataPos; i++)
                {
                    if (i > 0)
                    {
                        if (i % 16 == 0)
                        {
                            result.Append(VbX.nl() + "db ");
                        }
                        else
                        {
                            result.Append(",");
                        }
                    }
                    result.Append("&" + VbX.Hex(nr.RleData[i]));
                }
                result.Append(VbX.nl() + Filen + "_End:" + VbX.nl() + VbX.nl());
            }
            Clipboard.SetText(Header.ToString() + VbX.nl() + VbX.nl() + result.ToString());
            VbX.MsgBox("Copied to Clipboard");
        }

        /************************************************************************************************************************************************/

        private void saveRAWMSX1BitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_Planar(BW, CurrentSprite, 1);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);

        }

        /************************************************************************************************************************************************/

        private void saveRawVdpTileBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            int spritenum = CurrentSprite;

            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int y2 = 0; y2 < 8; y2++)
                    {
                        for (int xx = 0; xx < 8; xx += 2)
                        {

                            int sp1 = GetDisplayNum(CurrentBank, spritenum, xx + x, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, xx + x + 1, y + y2);

                            if (sp1 == 16) sp1 = 0;
                            if (sp2 == 16) sp2 = 0;
                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);

                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }
                    }//y2
                }//x
            }//y


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);


        }

        /************************************************************************************************************************************************/

        private void rdoCPCdither_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoSpecDither_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveCPCSCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CPC Binary Screen (*.SCR)|*.SCR";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            byte b = 0;
            int bytepos = 0;
            int thisspritebytepos = firstspritepos;


            int spritenum = CurrentSprite;
            // for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {

                if (rdoDisplayCPC0.Checked)
                {
                    CPC_SaveRAW_16Color(BW, spritenum, 8);
                }
                else
                {
                    CPC_SaveRAW_4Color(BW, spritenum, false, 8);
                }

            }

            BW.Close();
            ST.Close();
            //VbX.MsgBox("Saved");
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/

        private void saveFIXFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "FIX Font Bitmap (*.FIX)|*.FIX";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            int spritenum = CurrentSprite;

            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {

                    for (int cc = 0; cc < 8; cc += 2)
                    {
                        for (int y2 = 0; y2 < 8; y2++)
                        {
                            int xx = 0;
                            if (cc == 0) xx = 4;
                            if (cc == 2) xx = 6;
                            if (cc == 4) xx = 0;
                            if (cc == 6) xx = 2;


                            int sp1 = GetDisplayNum(CurrentBank, spritenum, xx + x + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, xx + x, y + y2);

                            if (sp1 == 16) sp1 = 0;
                            if (sp2 == 16) sp2 = 0;
                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);

                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }
                    }//y2
                }//x
            }//y


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void CpcSpriteCompilerClear_Click(object sender, EventArgs e)
        {
            if (CpcSpriteCompiler == null)
            {
                CpcSpriteCompiler = new AkuSpriteEditor.CompCPC();

            }
            CpcSpriteCompiler.textBox1_Text = "";
            CpcSpriteCompiler.Doreset();
        }
        /************************************************************************************************************************************************/
        private void CpcSpriteConvaddOneDiffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (CpcSpriteCompiler == null)
            {
                CpcSpriteCompiler = new AkuSpriteEditor.CompCPC();
                CpcSpriteCompiler.Doreset();
            }
            CpcSpriteCompiler.txtFilename_Text = "ClipImage" + CurrentSprite.ToString() + "_";
            Bitmap clipbit = new Bitmap(Spr_Wid[CurrentSprite], Spr_Hei[CurrentSprite]);
            for (int x = 0; x < Spr_Wid[CurrentSprite]; x++)
            {
                for (int y = 0; y < Spr_Hei[CurrentSprite]; y++)
                {
                    int a = spritepixel[CurrentBank, CurrentSprite, x, y];
                    if (a > 4) a = 4;
                    CpcSpriteCompiler.globals_PixelMap[x, y] = a;


                    clipbit.SetPixel(x, y, ColorSelector[spritepixel[CurrentBank, CurrentSprite, x, y]].BackColor);
                }
            }

            Clipboard.SetImage(clipbit);
            CpcSpriteCompiler.button1_Click(null, null);
            string s = CpcSpriteCompiler.textBox1_Text;
            Clipboard.SetText(s);
            VbX.MsgBox("Saved to clipboard!");
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarAST(BW, CurrentSprite, 4);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/


        private void saveRawBitmapToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarAMI(BW, CurrentSprite, 4);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            MSX_SaveRAW_16Color(BW, CurrentSprite);

            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/

        private void ResetButtons()
        {


            tabSpriteTools.TabPages.Remove(tabPixelPaint);
            tabSpriteTools.TabPages.Remove(tabZXPaint);
            tabSpriteTools.TabPages.Remove(tabColorSwap);

            btnToolPixelPaint.BackColor = SystemColors.ButtonFace;
            btnZXpaint2.BackColor = SystemColors.ButtonFace;
            btnColorSwap2.BackColor = SystemColors.ButtonFace;
            CurrentTool = "";
        }
        /************************************************************************************************************************************************/
        private void btnToolPixelPaint_Click(object sender, EventArgs e)
        {

            ResetButtons();
            tabSpriteTools.TabPages.Add(tabPixelPaint);
            tabPixelPaint.Show();
            btnToolPixelPaint.BackColor = SystemColors.ButtonShadow;
            CurrentTool = "pixelpaint";
            tabSpriteTools.SelectedTab = tabPixelPaint;
        }
        /************************************************************************************************************************************************/
        private void cboCheckMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)(0);
        }
        /************************************************************************************************************************************************/
        private void btnZXpaint2_Click(object sender, EventArgs e)
        {
            ResetButtons();
            tabSpriteTools.TabPages.Add(tabZXPaint);
            tabZXPaint.Show();
            btnZXpaint2.BackColor = SystemColors.ButtonShadow;
            CurrentTool = "zxpaint";
            tabSpriteTools.SelectedTab = tabZXPaint;
        }
        /************************************************************************************************************************************************/
        private void btnColorSwap_Click_1(object sender, EventArgs e)
        {
            ResetButtons();
            tabSpriteTools.TabPages.Add(tabColorSwap);
            tabZXPaint.Show();
            btnColorSwap2.BackColor = SystemColors.ButtonShadow;
            CurrentTool = "colorswap";
            tabSpriteTools.SelectedTab = tabColorSwap;
        }
        /************************************************************************************************************************************************/
        private void BtnAltPal_Click(object sender, EventArgs e)
        {

            pnlC64pal.Visible = false;
            pnlZXPalette.Visible = false;
            pnlNESpal.Visible = false;
            pnlMSXpal.Visible = false;
            rdoDisplayMSX.Checked = true;
            pnlApplePal.Visible = false;
            if (BtnAltPal.Text == "AltPal:  ")
            {
                rdoDisplaySpeccy.Checked = true;
                BtnAltPal.Text = "AltPal: ZX";
                pnlZXPalette.Visible = true;

            }
            else if (BtnAltPal.Text == "AltPal: ZX")
            {
                BtnAltPal.Text = "AltPal: C64";
                pnlC64pal.Visible = true;
                rdoC64_4Color.Checked = true;

            }

            else if (BtnAltPal.Text == "AltPal: C64")
            {
                BtnAltPal.Text = "AltPal: NES";
                pnlNESpal.Visible = true;

            }
            else if (BtnAltPal.Text == "AltPal: NES")
            {

                BtnAltPal.Text = "AltPal: MSX";
                pnlMSXpal.Visible = true;
            }
            else if (BtnAltPal.Text == "AltPal: MSX")
            {

                BtnAltPal.Text = "AltPal: APL";
                pnlApplePal.Visible = true;
                rdoAppleColor.Checked = true;
            }

            else
            {

                BtnAltPal.Text = "AltPal:  ";

            }

        }
        /************************************************************************************************************************************************/

        private void cPC16ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoDisplayCPC0.Checked = true;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoDisplayCPC0_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void colorpairsCPCENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoCPCpairs.Checked = true;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void colorditheredCPCENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoCPCdither.Checked = true;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void colorditheredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoSpecDither.Checked = true;
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void cbo4colorDither_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void applyViewColorConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int yy = 0; yy < Spr_Hei[CurrentSprite]; yy++)
            {
                for (int xx = 0; xx < Spr_Wid[CurrentSprite]; xx++)
                {
                    spritepixel[CurrentBank, CurrentSprite, xx, yy] = GetDisplayNum(CurrentBank, CurrentSprite, xx, yy);
                }
            }
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rLEASMToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DoCPCRLE("ent");
        }
        /************************************************************************************************************************************************/
        private void saveRawBitmapToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // Genesis uses SMS Exporter
            saveRawBitmapToolStripMenuItem5_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoGuide6_12_24_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoGuide4_8_32_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void rdoGuide4_8_24_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void loadPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoLoad(false, false, true, false);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void loadPixelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoLoad(true, false, false, false);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/
        private void importBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoLoad(false, true, false, false);
            btnRefresh_Click(sender, e);
        }
        /************************************************************************************************************************************************/

        private void saveRawBitmap2ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 7)
                {
                    int yy = 0;
                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + yy);
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);
                    // int sp8 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + yy);

                    if (sp1 > 1) sp1 = 1;
                    if (sp2 > 1) sp2 = 1;
                    if (sp3 > 1) sp3 = 1;
                    if (sp4 > 1) sp4 = 1;
                    if (sp5 > 1) sp5 = 1;
                    if (sp6 > 1) sp6 = 1;
                    if (sp7 > 1) sp7 = 1;
                    //if (sp8 > 1) sp8 = 1;

                    string tbyte = "";
                    tbyte += "0";
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                    // tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));


                }

            }
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmap4ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {

                for (int x = 0; x < Spr_Wid[spritenum]; x += 14)
                {
                    int yy = 0;
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);
                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 8, y + yy);
                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 10, y + yy);
                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 12, y + yy);



                    string tbyte = "";
                    int colorbit = SpeccyPaletteF[CurrentBank, CurrentSprite, x / 7, y / 8];
                    if (colorbit > 1) colorbit = 1;
                    tbyte += colorbit.ToString();
                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 2);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    colorbit = SpeccyPaletteF[CurrentBank, CurrentSprite, (x + 7) / 7, y / 8];
                    if (colorbit > 1) colorbit = 1;
                    tbyte = colorbit.ToString();
                    tbyte += VbX.Dec2Bin8Bit(sp7).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp6).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp5).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 1);



                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                }

            }
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmap2ColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveRawBitmapToolStripMenuItem1_Click(sender, e);
        }
        /************************************************************************************************************************************************/

        private void saveRawBitmap4ColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
            {

                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    int yy = 0;
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);

                    string tbyte = "";
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 2);
                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 2);

                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                }

            }
            BW.Close();
        }
        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            saveRAWBitmapToolStripMenuItem3_Click(sender, e);   //Lynx uses same format as MSX

        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem12_Click(object sender, EventArgs e)         // BBC 4 Color
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 4)
                {
                    for (int yy = 0; yy < 8; yy += 1)
                    {
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);


                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 1);

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }

                }

            }
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmap4ColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // C64 4 color
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int yy = 0; yy < 8; yy += 1)
                    {
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);


                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 2);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 2);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 2);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 2);

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }

                }

            }
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            // PC Engine Raw

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarPCE(BW, CurrentSprite, 4);


            BW.Close();
            ST.Close();

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            // Nes Raw Bitmap

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarNES(BW, CurrentSprite, 2);


            BW.Close();
            ST.Close();

            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            // Snes Raw Bitmap
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarSNS(BW, CurrentSprite, 4);


            BW.Close();
            ST.Close();

            btnRefresh_Click(sender, e);

        }

        /************************************************************************************************************************************************/

        private void saveRawBitmapToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            saveSpectrumFont(BW);
            BW.Close();
        }

        /************************************************************************************************************************************************/

        private void saveSpectrumFont(System.IO.BinaryWriter BW)
        {

            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int yy = 0; yy < 8; yy++)
                    {
                        int sp1 = spritepixel[CurrentBank, spritenum, x, y + yy];
                        int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y + yy];
                        int sp3 = spritepixel[CurrentBank, spritenum, x + 2, y + yy];
                        int sp4 = spritepixel[CurrentBank, spritenum, x + 3, y + yy];
                        int sp5 = spritepixel[CurrentBank, spritenum, x + 4, y + yy];
                        int sp6 = spritepixel[CurrentBank, spritenum, x + 5, y + yy];
                        int sp7 = spritepixel[CurrentBank, spritenum, x + 6, y + yy];
                        int sp8 = spritepixel[CurrentBank, spritenum, x + 7, y + yy];


                        if (sp4 == 16 && sp3 == 16 && sp2 == 16 && sp1 == 16 && sp5 == 16 && sp6 == 16 && sp7 == 16 && sp8 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                                sp3 = 0;
                                sp4 = 1;
                                sp5 = 0;
                                sp6 = 1;
                                sp7 = 0;
                                sp8 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 1;
                                sp2 = 0;
                                sp3 = 1;
                                sp4 = 0;
                                sp5 = 1;
                                sp6 = 0;
                                sp7 = 1;
                                sp8 = 0;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        if (sp3 == 16) sp3 = 0;
                        if (sp4 == 16) sp4 = 0;
                        if (sp5 == 16) sp5 = 0;
                        if (sp6 == 16) sp6 = 0;
                        if (sp7 == 16) sp7 = 0;
                        if (sp8 == 16) sp8 = 0;

                        if (sp1 > 1) sp1 = 1;
                        if (sp2 > 1) sp2 = 1;
                        if (sp3 > 1) sp3 = 1;
                        if (sp4 > 1) sp4 = 1;
                        if (sp5 > 1) sp5 = 1;
                        if (sp6 > 1) sp6 = 1;
                        if (sp7 > 1) sp7 = 1;
                        if (sp8 > 1) sp8 = 1;

                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);





                        BW.Write((Byte)VbX.Bin2Dec(tbyte));

                    }

                }

            }
        }

        /************************************************************************************************************************************************/

        private void saveBMPMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {

                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "BMP Map (*.PNG)|*.PNG";
                DialogResult dr = fd.ShowDialog();
                if (dr != DialogResult.OK) return;
                string filename = fd.FileName;


                if (VbX.InStr(VbX.LCase(filename), "bank") > 0)
                {
                    filename = VbX.Left(filename, VbX.Len(filename) - 10);
                }
                else if (VbX.InStr(VbX.LCase(filename), "map") > 0)
                {
                    filename = VbX.Left(filename, VbX.Len(filename) - 8);
                }
                else
                {
                    filename = VbX.Left(filename, VbX.Len(filename) - 4);
                }


                int tilemapwidth = 768;
                int spacing = 48;
                Bitmap colormap = new Bitmap(tilemapwidth, 1024);


                UInt16[,] tilearray = new UInt16[tilemapwidth, 1024];



                for (int x = 0; x < tilemapwidth; x++) //Checkerboard background
                {
                    for (int y = 0; y < 1024; y++)
                    {
                        tilearray[x, y] = 256;
                        if (VbX.CInt(x / 8) % 2 == VbX.CInt(y / 8) % 2)
                        {
                            colormap.SetPixel(x, y, Color.FromArgb(20, 20, 20));
                        }
                        else
                        {
                            colormap.SetPixel(x, y, Color.FromArgb(40, 40, 40));
                        }

                    }

                }
                int CurrentX = 0;
                int CurrentY = 0;

                int[] SprPosX = new int[64];
                int[] SprPosY = new int[64];

                int CurrentYHeight = 0;
                int TotalYHeight = 0;



                int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
                for (int s = 0; s < 64; s++)
                {
                    Spr_Wid[s] = 0;
                    Spr_Hei[s] = 0;
                    Spr_MinX[s] = (Int16)maxSpriteSize;
                    Spr_MinY[s] = (Int16)maxSpriteSize;
                    if (Spr_FixedSize[s] > 0)
                    {
                        if ((s + 1) > SpriteCount) SpriteCount = s + 1;

                    }


                    for (int cb = 0; cb < BankCount; cb++)
                    {

                        //SpriteStats(s);         // update all our info on the sprites



                        for (int x = 0; x < maxSpriteSize; x++)
                        {
                            for (int y = 0; y < maxSpriteSize; y++)
                            {
                                // RepaintPixel(x, y);
                                if (spritepixel[cb, s, x, y] != 0)
                                {
                                    if (x >= Spr_Wid[s]) Spr_Wid[s] = (Int16)(x + 1);
                                    if (y >= Spr_Hei[s]) Spr_Hei[s] = (Int16)(y + 1);
                                    if (x < Spr_MinX[s]) Spr_MinX[s] = (Int16)x;
                                    if (y < Spr_MinY[s]) Spr_MinY[s] = (Int16)y;
                                    if ((s + 1) > SpriteCount) SpriteCount = s + 1;
                                }

                            }
                        }

                    }
                    // VbX.MsgBox(Spr_MinY[s].ToString());
                }



                byte b = 0;
                int bytepos = 0;
                int thisspritebytepos = firstspritepos;

                for (int s = 0; s < SpriteCount; s++)
                {


                    int ThisActualHeight = Spr_Hei[s];


                    bool OutputThisOne = true;
                    if (Spr_Wid[s] < 1 || ThisActualHeight < 1) OutputThisOne = false;

                    if (OutputThisOne)
                    {
                        for (int sy = 0; sy < 1024; sy += spacing) //Find a position for the new sprite
                        {
                            for (int sx = 0; sx < tilemapwidth - (Spr_Wid[s] - 1); sx += spacing)
                            {
                                if (tilearray[sx, sy] == 256)
                                {
                                    bool valid = true;
                                    for (int zx = 0; zx < Spr_Wid[s]; zx++)
                                    {
                                        for (int zy = 0; zy < Spr_Hei[s]; zy++)
                                        {
                                            if (tilearray[sx + zx, sy + zy] < 256)
                                            {
                                                valid = false;
                                                zy = 1024; zx = 1024;
                                            }
                                        }
                                    }
                                    if (valid == true)
                                    {
                                        CurrentX = sx;
                                        CurrentY = sy;
                                        sy = 1024;
                                        sx = 1024;
                                    }
                                }
                            }
                        }

                        if (Spr_Hei[s] > CurrentYHeight) CurrentYHeight = ThisActualHeight;
                        int sr = (s + 1) % 4;
                        int sg = ((s + 1) / 4) % 4;
                        int sb = ((s + 1) / 16) % 4;
                        //VbX.MsgBox(sr.ToString() + " " + sg.ToString() + " " + sb.ToString() + " ");
                        sr = (sr * 84);
                        sg = (sg * 84);
                        sb = (sb * 84);
                        SprPosX[s] = CurrentX;
                        SprPosY[s] = CurrentY;

                        for (int y = 0; y < Spr_Hei[s]; y++)
                        {
                            int y2 = y - 0;
                            for (int x = 0; x < Spr_Wid[s]; x++)
                            {
                                int c = spritepixel[CurrentBank, s, x, y];
                                //if (c == 16) c = 0;

                                //clipbit.SetPixel(x + CurrentX, y2 + CurrentY, ColorSelector[c].BackColor);

                                colormap.SetPixel(x + CurrentX, y2 + CurrentY, Color.FromArgb(sr, sg, sb));
                                tilearray[x + CurrentX, y2 + CurrentY] = (UInt16)c;
                            }
                        }
                    }

                    CurrentX = CurrentX + Spr_Wid[s];
                    if (CurrentY + ThisActualHeight > TotalYHeight) TotalYHeight = CurrentY + ThisActualHeight;
                }


                for (int col = 0; col < 64; col++)
                {
                    int sr = (col + 1) % 4;
                    int sg = ((col + 1) / 4) % 4;
                    int sb = ((col + 1) / 16) % 4;
                    //VbX.MsgBox(sr.ToString() + " " + sg.ToString() + " " + sb.ToString() + " ");
                    sr = (sr * 84);
                    sg = (sg * 84);
                    sb = (sb * 84);
                    for (int cx = 0; cx < 10; cx++)
                    {
                        for (int cy = 0; cy < 12; cy++)
                        {
                            colormap.SetPixel(col * 10 + cx, 1012 + cy, Color.FromArgb(sr, sg, sb));
                        }
                    }
                }
                colormap.Save(filename + "_Map.png");


                for (int Bnum = 0; Bnum < BankCount; Bnum++)
                {
                    CurrentBank = Bnum;

                    for (int x = 0; x < tilemapwidth; x++) //Checkerboard background
                    {
                        for (int y = 0; y < 1024; y++)
                        {
                            tilearray[x, y] = 256;
                            if (VbX.CInt(x / 8) % 2 == VbX.CInt(y / 8) % 2)
                            {
                                colormap.SetPixel(x, y, Color.FromArgb(20, 20, 20));
                            }
                            else
                            {
                                colormap.SetPixel(x, y, Color.FromArgb(40, 40, 40));
                            }

                        }

                    }
                    for (int s = 0; s < SpriteCount; s++)
                    {


                        for (int y = 0; y < Spr_Hei[s]; y++)
                        {
                            int y2 = y - 0;
                            for (int x = 0; x < Spr_Wid[s]; x++)
                            {
                                int c = spritepixel[Bnum, s, x, y];
                                // if (c == 16) c = 0;

                                colormap.SetPixel(x + SprPosX[s], y2 + SprPosY[s], ColorSelector[c].BackColor);

                                // colormap.SetPixel(x + CurrentX, y2 + CurrentY, Color.FromArgb(sr, sg, sb));
                                //tilearray[x + CurrentX, y2 + CurrentY] = (UInt16)c;
                            }
                        }
                    }

                    for (int col = 0; col <= 16; col++)
                    {
                        for (int cx = 0; cx < 12; cx++)
                        {
                            for (int cy = 0; cy < 12; cy++)
                            {
                                colormap.SetPixel(col * 12 + cx, 1000 + cy, ColorSelector[col].BackColor);
                            }
                        }
                    }



                    colormap.Save(filename + "_Bank" + Bnum.ToString() + ".png");
                }

                CurrentBank = 0;
                //Clipboard.SetImage(colormap);

            }
        }

        /************************************************************************************************************************************************/

        private void loadBMPMaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "BMP Map (*.png)|*.png";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;
            string filename = fd.FileName;
            if (VbX.InStr(VbX.LCase(filename), "bank") > 0)
            {
                filename = VbX.Left(filename, VbX.Len(filename) - 10);
            }
            else if (VbX.InStr(VbX.LCase(filename), "map") > 0)
            {
                filename = VbX.Left(filename, VbX.Len(filename) - 8);
            }
            else
            {
                filename = VbX.Left(filename, VbX.Len(filename) - 4);
            }




            Bitmap colormap = new Bitmap(filename + "_Map.png");
            int[] MinX = new int[64];
            int[] MinY = new int[64];

            int[] MaxX = new int[64];
            int[] MaxY = new int[64];
            for (int i = 0; i < 64; i++)
            {
                MaxX[i] = 0;
                MaxY[i] = 0;
                MinX[i] = 10000;
                MinY[i] = 10000;
            }

            for (int x = 0; x < colormap.Width; x++)
            {
                for (int y = 0; y < colormap.Height - 24; y++)
                {
                    Color c = colormap.GetPixel(x, y);
                    int sr = c.R / 84;
                    int sg = c.G / 84;
                    int sb = c.B / 84;
                    int spritenum = sb * 16 + sg * 4 + sr;
                    if (spritenum > 0)
                    {
                        spritenum--;
                        if (x > MaxX[spritenum]) MaxX[spritenum] = x;
                        if (y > MaxY[spritenum]) MaxY[spritenum] = y;

                        if (x < MinX[spritenum]) MinX[spritenum] = x;
                        if (y < MinY[spritenum]) MinY[spritenum] = y;

                    }

                }

            }
            for (int i = 0; i < 64; i++)
            {

                if (MinX[i] == 10000) { MinX[i] = 0; MaxX[i] = -1; };
                if (MinY[i] == 10000) { MinY[i] = 0; MaxY[i] = -1; };

            }
            colormap.Dispose();
            for (int b = 0; b < BankCount; b++)
            {
                colormap = new Bitmap(filename + "_Bank" + b.ToString() + ".png");
                if (b == 0)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        ColorSelector[i].BackColor = colormap.GetPixel(i * 12, 1000);
                    }
                }
                for (int i = 0; i < 64; i++)
                {
                    if (b == 1)
                    {
                        if (MinX[i] > 0)
                        {
                            Spr_MinX[i] = 0;
                            Spr_MinY[i] = 0;
                            Spr_Wid[i] = (short)(MaxX[i] - MinX[i] + 1);
                            Spr_Hei[i] = (short)(MaxY[i] - MinY[i] + 1);
                            Spr_FixedSize[i] = 1;
                        }
                    }
                    for (int x = MinX[i]; x <= MaxX[i]; x++)
                    {
                        for (int y = MinY[i]; y <= MaxY[i]; y++)
                        {
                            Color c = colormap.GetPixel(x, y);
                            int cnum = 0;
                            for (int co = 0; co <= 16; co++)
                            {
                                if (c == ColorSelector[co].BackColor) cnum = co;
                            }
                            spritepixel[b, i, x - MinX[i], y - MinY[i]] = (byte)cnum;
                        }

                    }
                }
                colormap.Dispose();
            }
            for (int s = 0; s < 64; s++)
            {

                SpriteStats(s);         // update all our info on the sprites
                SaveSpriteDetails(s);
            }


            btnRefresh_Click(sender, e);
        }

        /************************************************************************************************************************************************/

        private void abToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VbX.MsgBox("AkuSprite Editor V1.00" + VbX.Chr(13) + VbX.Chr(10) + "please see http://www.chibiakumas.com for usage info");
        }


        private void recent1_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Text == "") return;
            string Response = VbX.InputBox("Reload Sprites?", "Reload Sprites?", "yes/no");
            if (Response != "*yes*") return;
            DoLoadFile(((ToolStripMenuItem)sender).Text, true, true, true, true);
        }

        private void recent2_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent3_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent4_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent5_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent6_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent7_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent8_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent9_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void recent10_Click(object sender, EventArgs e)
        { recent1_Click(sender, e); }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Response = VbX.InputBox("Exit Akusprite?", "Exit Akusprite?", "yes/no");
            if (Response != "*yes*") { e.Cancel = true; return; }


            string recentfile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "") + "\\AkuSprite.recent";

            System.IO.StreamWriter sw = new System.IO.StreamWriter(recentfile);
            sw.WriteLine(recent1.Text);
            sw.WriteLine(recent2.Text);
            sw.WriteLine(recent3.Text);
            sw.WriteLine(recent4.Text);
            sw.WriteLine(recent5.Text);
            sw.WriteLine(recent6.Text);
            sw.WriteLine(recent7.Text);
            sw.WriteLine(recent8.Text);
            sw.WriteLine(recent9.Text);
            sw.WriteLine(recent10.Text);
            sw.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void saveBinarySpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMSXBinaryToolStripMenuItem_Click(sender, e);
        }

        private void savePCESpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            int planes = 4;
            int spritenum = CurrentSprite;
            for (int p = 7; p > 7 - planes; p--)
            {
                for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 1)
                {
                    for (int x = 0; x < Spr_Wid[spritenum]; x += 16)
                    {
                        int y2 = 0;
                        for (int x2 = 8; x2 >= 0; x2 -= 8)
                        {

                            int sp0 = GetDisplayNum(CurrentBank, spritenum, x + x2, y + y2);
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 1, y + y2);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 2, y + y2);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 3, y + y2);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 4, y + y2);
                            int sp5 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 5, y + y2);
                            int sp6 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 6, y + y2);
                            int sp7 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 7, y + y2);

                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }
                    }//x
                }//y




            }

            BW.Close();
        }

        private void saveSprite2ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "C64 Sprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);



            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {
                for (int y = 0; y < 21; y += 1)
                {
                    for (int x = 0; x < 24; x += 8)
                    {
                        int yy = 0;
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);
                        int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                        int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + yy);
                        int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);
                        int sp8 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + yy);


                        if (sp4 == 16 && sp3 == 16 && sp2 == 16 && sp1 == 16 && sp5 == 16 && sp6 == 16 && sp7 == 16 && sp8 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                                sp3 = 0;
                                sp4 = 1;
                                sp5 = 0;
                                sp6 = 1;
                                sp7 = 0;
                                sp8 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 1;
                                sp2 = 0;
                                sp3 = 1;
                                sp4 = 0;
                                sp5 = 1;
                                sp6 = 0;
                                sp7 = 1;
                                sp8 = 0;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        if (sp3 == 16) sp3 = 0;
                        if (sp4 == 16) sp4 = 0;
                        if (sp5 == 16) sp5 = 0;
                        if (sp6 == 16) sp6 = 0;
                        if (sp7 == 16) sp7 = 0;
                        if (sp8 == 16) sp8 = 0;

                        if (sp1 > 1) sp1 = 1;
                        if (sp2 > 1) sp2 = 1;
                        if (sp3 > 1) sp3 = 1;
                        if (sp4 > 1) sp4 = 1;
                        if (sp5 > 1) sp5 = 1;
                        if (sp6 > 1) sp6 = 1;
                        if (sp7 > 1) sp7 = 1;
                        if (sp8 > 1) sp8 = 1;

                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));


                    }

                }
            }
            BW.Write((Byte)(0)); // spacer (each sprite must be 64 bytes
            BW.Close();
        }

        private void saveSprite4ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // C64 4 color
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "C64 4-color sprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            for (int spritenum = 0; spritenum < SpriteCount; spritenum++)
            {
                for (int y = 0; y < 21; y += 1)
                {
                    for (int x = 0; x < 24; x += 8)
                    {
                        int yy = 0;
                        {
                            int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                            int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                            int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                            int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);


                            string tbyte = "";

                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 2);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 2);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 2);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(6, 2);

                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }

                    }

                }
                BW.Write((Byte)(0)); // spacer (each sprite must be 64 bytes
            }
            BW.Close();
        }

        private void saveRawBitmap2ColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // C64 4 color
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Raw Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = CurrentSprite;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 8)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int yy = 0; yy < 8; yy += 1)
                    {
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x, y + yy);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + yy);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + yy);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + yy);
                        int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + yy);
                        int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + yy);
                        int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + yy);
                        int sp8 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + yy);

                        string tbyte = "";

                        tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp4).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp5).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp6).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp7).Substring(7, 1);
                        tbyte += VbX.Dec2Bin8Bit(sp8).Substring(7, 1);

                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    }

                }

            }
            BW.Close();
        }

        private void saveRAWMSX1Raw16x16SpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);


            int spritenum = 0;
            int planes = 1;
            for (int y = Spr_MinY[spritenum]; y < Spr_Hei[spritenum]; y += 16)
            {
                for (int x = 0; x < Spr_Wid[spritenum]; x += 8)
                {
                    for (int y2 = 0; y2 < 16; y2++)
                    {

                        int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                        int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                        int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                        int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);
                        int sp4 = GetDisplayNum(CurrentBank, spritenum, x + 4, y + y2);
                        int sp5 = GetDisplayNum(CurrentBank, spritenum, x + 5, y + y2);
                        int sp6 = GetDisplayNum(CurrentBank, spritenum, x + 6, y + y2);
                        int sp7 = GetDisplayNum(CurrentBank, spritenum, x + 7, y + y2);

                        /*
                        if ( sp2 == 16 && sp1 == 16)
                        {
                            int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                            if (transpcol == 5)
                            {
                                sp1 = 0;
                                sp2 = 1;
                            }
                            if (transpcol == 4)
                            {
                                sp1 = 3;
                                sp2 = 2;
                            }
                        }
                        if (sp1 == 16) sp1 = 0;
                        if (sp2 == 16) sp2 = 0;
                        */



                        for (int p = 7; p > 7 - planes; p--)
                        {
                            string tbyte = "";
                            tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                            tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                            BW.Write((Byte)VbX.Bin2Dec(tbyte));
                        }

                    }//y2
                }//x
            }//y


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }
        private void CreateRawLynxBitmap(System.IO.BinaryWriter BW, int CurrentSprite, int bitdepth, bool RLE)
        {
            int spritenum = CurrentSprite;
            string tbyte = "";
            for (int y = 0; y < Spr_Hei[spritenum]; y++)
            {
                tbyte = "";
                for (int x = 0; x < Spr_Wid[spritenum]; x += 2)
                {
                    int sp1 = spritepixel[CurrentBank, spritenum, x, y];
                    int sp2 = spritepixel[CurrentBank, spritenum, x + 1, y];


                    if (sp2 == 16 && sp1 == 16)
                    {
                        int transpcol = VbX.Bin2Dec(VbX.Right(VbX.Dec2Bin8Bit(Spr_Xoff[spritenum]), 3));
                        if (transpcol == 5)
                        {
                            sp1 = 0;
                            sp2 = 1;
                        }
                        if (transpcol == 4)
                        {
                            sp1 = 3;
                            sp2 = 2;
                        }
                    }
                    if (sp1 == 16) sp1 = 0;
                    if (sp2 == 16) sp2 = 0;




                    if (bitdepth >= 4) tbyte += VbX.Dec2Bin8Bit(sp1).Substring(4, 1);
                    if (bitdepth >= 3) tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                    if (bitdepth >= 2) tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);

                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    // tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    //tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    if (bitdepth >= 4) tbyte += VbX.Dec2Bin8Bit(sp2).Substring(4, 1);
                    if (bitdepth >= 3) tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    if (bitdepth >= 2) tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);





                }

                if (RLE)
                {
                    string tbyte2 = tbyte;
                    tbyte = "";
                    string lastchunk = "";
                    string LinearChunk = "";
                    int LinearCount = 0;
                    int RleCount = 0;
                    for (int b = 0; b < tbyte2.Length; b += bitdepth)
                    {
                        string chunk = tbyte2.Substring(b, bitdepth);



                        if (lastchunk == "")
                        {


                        }
                        else
                        {
                            if (RleCount == 15 || ((b == tbyte2.Length - bitdepth && lastchunk == chunk) || (lastchunk != chunk && RleCount > 0)))
                            {
                                if (b == tbyte2.Length - bitdepth && RleCount <= 14 && lastchunk == chunk)
                                {
                                    RleCount++;
                                    chunk = "";
                                }

                                tbyte += "0";
                                tbyte += VbX.Dec2Bin8Bit(RleCount).Substring(4, 4) + lastchunk;
                                // VbX.MsgBox(VbX.Dec2Bin8Bit(RleCount).Substring(4, 4) + lastchunk);
                                RleCount = 0;
                                lastchunk = "";
                            }
                            else if (lastchunk != chunk && RleCount == 0)
                            {

                                LinearChunk += lastchunk;
                                LinearCount++;
                                if (LinearCount > 15)
                                {
                                    tbyte += "1";
                                    tbyte += "1111" + LinearChunk.Substring(0, 16 * bitdepth);
                                    LinearChunk = "";
                                    lastchunk = "";
                                    LinearCount = 0;
                                }

                            }
                            else// rle match
                            {
                                if (LinearCount > 0)
                                {

                                    tbyte += "1";
                                    tbyte += VbX.Dec2Bin8Bit((LinearChunk.Length / bitdepth) - 1).Substring(4, 4) + LinearChunk;
                                    LinearChunk = "";
                                    LinearCount = 0;
                                }
                                RleCount++;
                            }
                        }


                        lastchunk = chunk;
                    }
                    if (lastchunk != "")
                    {
                        LinearChunk += lastchunk;
                        LinearCount++;
                        tbyte += "1";
                        tbyte += VbX.Dec2Bin8Bit((LinearChunk.Length / bitdepth) - 1).Substring(4, 4) + LinearChunk;
                        LinearChunk = "";
                        LinearCount = 0;
                    }
                }
                //VbX.MsgBox(tbyte);
                if (tbyte.Length % 8 > 0)
                {
                    while (tbyte.Length % 8 > 0)
                    {
                        tbyte += "0";
                    }
                }
                else
                {
                    tbyte += "00000000";
                }

                BW.Write((Byte)((tbyte.Length / 8) + 1));
                for (int c = 0; c < tbyte.Length; c += 8)
                {
                    string bchunk = tbyte.Substring(c, 8);
                    BW.Write((Byte)VbX.Bin2Dec(bchunk));
                }

                tbyte = "";
            }
            BW.Write((Byte)0);
        }

        private void save16colorLinearSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 4, false);
            BW.Close();
        }

        private void save8colorLinearSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 3, false);
            BW.Close();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 2, false);
            BW.Close();
        }

        private void sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 1, false);
            BW.Close();
        }

        private void save16ColorRLESpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 4, true);
            BW.Close();
        }

        private void save8ColorRLESpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 3, true);
            BW.Close();
        }

        private void save2ColorRLESpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 1, true);
            BW.Close();
        }

        private void save4ColorRLESpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Lynx Literalsprite (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            CreateRawLynxBitmap(BW, CurrentSprite, 2, true);
            BW.Close();
        }

        private void saveRawBitmapToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            // Camputers Lynx

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarCLX(BW, CurrentSprite, 3);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        private void saveRaw8x8TileBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Camputers Lynx 8tile

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarCLX8(BW, CurrentSprite, 3);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }

        private void raw8colorBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Sinclair QL

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            int spritenum = CurrentSprite;

            for (int y2 = Spr_MinY[spritenum]; y2 < Spr_Hei[spritenum]; y2 += 1)
            {

                for (int x = 0; x < Spr_Wid[spritenum]; x += 4)
                {

                    int y = 0;


                    int sp0 = GetDisplayNum(CurrentBank, spritenum, x, y + y2);
                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x + 1, y + y2);
                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + 2, y + y2);
                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + 3, y + y2);




                    string tbyte = "";

                    tbyte += VbX.Dec2Bin8Bit(sp0).Substring(5, 1);
                    tbyte += "0";
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(5, 1);
                    tbyte += "0";
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(5, 1);
                    tbyte += "0";
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(5, 1);
                    tbyte += "0";
                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    
                    tbyte = "";
                    tbyte += VbX.Dec2Bin8Bit(sp0).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp0).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(7, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(6, 1);
                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(7, 1);
                    BW.Write((Byte)VbX.Bin2Dec(tbyte));
                    
                    
                }
            }



            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);

        }

        private void saveSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Neo Geo Sprite
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "NeoGeo Sprite (*.c1)|*.c1";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);
            System.IO.Stream ST2 = new System.IO.FileStream(fd.FileName.Replace(".c1",".c2"), System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW2 = new System.IO.BinaryWriter(ST2);
            long bytecount=0;
            int planes = 4;
            for (int spritenum=0;spritenum<SpriteCount;spritenum++){

                    for (int x = 0; x < Spr_Wid[spritenum]; x += 16)
                    {

                        for (int y2 = 0; y2 < Spr_Hei[spritenum]; y2 += 16)
                        {
                        for (int x2 = 8; x2 >= 0; x2 -= 8)
                        {
                            for (int y = 0; y < 16; y += 1)
                            {
                                for (int p = 7; p > 7 - planes; p--)
                                {
                                    


                                    int sp0 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 7, y + y2);
                                    int sp1 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 6, y + y2);
                                    int sp2 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 5, y + y2);
                                    int sp3 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 4, y + y2);
                                    int sp4 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 3, y + y2);
                                    int sp5 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 2, y + y2);
                                    int sp6 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 1, y + y2);
                                    int sp7 = GetDisplayNum(CurrentBank, spritenum, x + x2 + 0, y + y2);

                                    string tbyte = "";
                                    tbyte += VbX.Dec2Bin8Bit(sp0).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp1).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp2).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp3).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp4).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp5).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp6).Substring(p, 1);
                                    tbyte += VbX.Dec2Bin8Bit(sp7).Substring(p, 1);
                                    if (p >= 6)
                                    {
                                        bytecount++;
                                        BW.Write((Byte)VbX.Bin2Dec(tbyte));
                                    }
                                    else
                                    {
                                        BW2.Write((Byte)VbX.Bin2Dec(tbyte));
                                    }
                                }
                            }//x
                        }//y

                    }//p
                }

            }//s
            long targetcount = VbX.Val(txtFixedFileSize.Text);
            while (bytecount < targetcount) {
                bytecount++;
                BW2.Write((Byte)0);
                BW.Write((Byte)0);
            }


            BW.Close();
            BW2.Close();
        }

        private void raw4colorBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 4 Color QL bitmap
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "RAW Bitmap (*.RAW)|*.RAW";
            DialogResult dr = fd.ShowDialog();
            if (dr != DialogResult.OK) return;


            int firstspritepos = VbX.Val(txtSpriteDataOffSet.Text);
            for (int s = 0; s < 64; s++)
            {
                SpriteStats(s);         // update all our info on the sprites
            }

            System.IO.Stream ST = new System.IO.FileStream(fd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            System.IO.BinaryWriter BW = new System.IO.BinaryWriter(ST);

            SaveRAW_PlanarAMI(BW, CurrentSprite, 2);


            BW.Close();
            ST.Close();
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            btnRefresh_Click(sender, e);
        }


    }

}

