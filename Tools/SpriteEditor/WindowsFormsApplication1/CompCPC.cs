using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AkuSpriteEditor
{
    class CompCPC
    {
        Color Color0_BackColor=Color.Black;
        Color Color1_BackColor=Color.Red;
        Color Color2_BackColor=Color.Green;
        Color Color3_BackColor=Color.Blue;
        Color ColorA_BackColor=Color.Magenta;



        //results go in here
        public string textBox1_Text = "";
        public string txtFilename_Text = "";
        public static string txtOrg_Text = "";
        public static string txtFilenameOld_Text = "";
        int globals_GlobalsDone=0;
        public static string txtBank_Text = "0";
        public static bool globals_DoRawBmp = false;
        public static string txtFrameDiff_Text = "1";
        public static Boolean globals_useRLE = false;
        public static System.Text.StringBuilder globals_globaldata = new System.Text.StringBuilder();
        public static string txtColorConv_Text = "";
        
        public static string cboNextLine_Text="";
        public static string txtBitBlockLength_Text="30";
        public static string txtDeCompression_Text="4";
        public static bool chkScaledownDither_Checked=false;
        public static bool chkcomressDEs_Checked = false;
        public static bool chkLooper_Checked = true;
        public static int[,] globals_LastPixelMap = new int[340, 256];
        public  System.Drawing.Bitmap globals_LastFrame = null;
        public static bool chkRst0_Checked=false;
        public static bool chkRst6_Checked = false;
        public static bool chkInterlace_Checked = false;
        public static Image pictureBox1_Image;
        public static string globals_initdata = VbX.Chr(13) + VbX.Chr(10) + "nolist" + VbX.Chr(13) + VbX.Chr(10) +
            "LD hl,&D5E1" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0030),hl" + VbX.Chr(13) + VbX.Chr(10) + "LD hl,&D5D5" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0032),hl" + VbX.Chr(13) + VbX.Chr(10) + "LD hl,&D5E9" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0034),hl" + VbX.Chr(13) + VbX.Chr(10);
        public static bool[] globals_MultiPushDeLast = new bool[41];
        public static int globals_MaxDePush = 5;
        public static bool[] globals_DePushUsed = new bool[41];
        public static bool[] globals_BitmapDataUsed = new bool[81];
        public static string[] globals_PairCache_Data = new string[20480];
        public static int globals_PairCache_Count = 0;
        public static bool[] globals_BitmapPushLastUsed = new bool[41];
        public static bool[] globals_BitmapDataLastUsed = new bool[41];
        public static string[] globals_ChunkCache_Name = new string[20480];
        public static string[] globals_ChunkCache_Data = new string[20480];
        public static string[] globals_ChunkCache_DE = new string[20480];
        public static int[] globals_ChunkCache_Reused = new int[20480];
        public static int globals_ChunkCache = 0;
        public static string globals_ChunkDeBak = "";
        public int[,] globals_PixelMap = new int[340, 256];
        public static System.Text.StringBuilder globals_imagedata = new System.Text.StringBuilder();
        public static System.Text.StringBuilder globaldata = new System.Text.StringBuilder();
        public static string globals_RegBC = "";
        public static string globals_RegDE = "";
        public static string globals_RegHL = "";
        public static string globals_LastDE = "";
        public static string globals_LastHL = "";
        public static string txtxpos_text = "0";
        public static string txtypos_text = "0";
        public static string txtYScale_Text="1";
        public static string txtXScale_Text = "1";
        public static string txtHeader_Text = "";
        public static string globals_BitmapData = "";
        
        public static string cboLineGroups_Text="1";
        public static string cboPreprocessor_Text = "";
        public static string cboEngine_Text = "";
        public static bool globals_SkipNextline = false;
        public static bool chkInterlaceField_Checked = false;
        int RandomReg = 0;
        string nl = VbX.Chr(13) + VbX.Chr(10);
        public static int globals_DEUsed = 0;
        public static int globals_PicNumber = 0;
        private string DoFilename(string lin)
        {
            string response = "Pic" + ss.GetItem(lin, "\\", ss.CountItems(lin, "\\")).Replace(".", "");
            response = response.Replace(" ", "");
            response = response.Replace("[", "");
            response = response.Replace("]", "");
            response = response.Replace("-", "");
            response = response.Replace("'", "");
            response = response.Replace("(", "");
            response = response.Replace(")", "");
            response = response.Replace("!", "");
            return response;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            addheader();
            globals_PicNumber += 3;
            // globals_BitmapData = "";
            //; globals_ChunkCache = 0;

            StringBuilder Chunk = new StringBuilder();

            // pictureBox1_Image = lnx.LoadImg(txtFilename_Text);
            pictureBox1_Image = (System.Drawing.Bitmap)System.Windows.Forms.Clipboard.GetImage();

            //if (exists(txtFilename.Text)) return;

            string Filename = DoFilename(txtFilename_Text);// "Pic" + ss.GetItem(txtFilename.Text, "\\", ss.CountItems(txtFilename.Text, "\\")).Replace(".", "");

            string DrawOrder = "";
            string Bitblock = "";
            string BitblockLinear = "";


            int CodeBytes = 0;

            
             StringBuilder st = new StringBuilder();
            System.Drawing.Bitmap b = (System.Drawing.Bitmap)pictureBox1_Image;
       
            System.Drawing.Bitmap b2 = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (globals_LastFrame == null)
            {
                globals_LastFrame = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
             //ConvertImage(b, globals_PixelMap);

            

            if (txtFilenameOld_Text.Length > 0)
            {
                System.Drawing.Bitmap bold = (System.Drawing.Bitmap)lnx.LoadImg(txtFilenameOld_Text);
                globals_LastFrame = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                ConvertImage(bold, globals_LastPixelMap);

            }
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x += 8)
                {
                    int pixelcount = 0;
                    for (int p = 0; p < 8; p++)
                    {

                        if (globals_PixelMap[x + p, y] != globals_LastPixelMap[x + p, y])
                        {
                            pixelcount++;
                        }

                    }
                    if (pixelcount < VbX.CInt(txtFrameDiff_Text))
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            globals_PixelMap[x + p, y] = 4;
                        }
                    }

                }
            }
            if (chkInterlace_Checked)
            {
                int ifield = 0;
                if (chkInterlaceField_Checked) ifield = 1;
                for (int y = 0; y < b.Height; y++)
                {
                    if (y % 2 == ifield)
                    {
                        for (int x = 0; x < b.Width; x += 1)
                        {

                            globals_PixelMap[x, y] = 4;

                        }
                    }
                }
                chkInterlaceField_Checked = !chkInterlaceField_Checked;
            }


            if (cboPreprocessor_Text == "PixelPairHalveX")
            {
                for (int y = 0; y < b.Height; y += 1)
                {
                    for (int x = 0; x < b.Width; x += 4)
                    {
                        int c1 = globals_PixelMap[x + 1, y];
                        int c2 = globals_PixelMap[x + 2, y];
                        globals_PixelMap[x + 0, y] = c1;
                        globals_PixelMap[x + 1, y] = c2;
                        globals_PixelMap[x + 2, y] = c1;
                        globals_PixelMap[x + 3, y] = c2;
                    }
                }
            }
            if (cboPreprocessor_Text == "PixelPairQuarterX")
            {
                for (int y = 0; y < b.Height; y += 1)
                {
                    for (int x = 0; x < b.Width; x += 8)
                    {
                        int c1 = globals_PixelMap[x + 3, y];
                        int c2 = globals_PixelMap[x + 4, y];
                        globals_PixelMap[x + 0, y] = c1;
                        globals_PixelMap[x + 1, y] = c2;
                        globals_PixelMap[x + 2, y] = c1;
                        globals_PixelMap[x + 3, y] = c2;
                        globals_PixelMap[x + 4, y] = c1;
                        globals_PixelMap[x + 5, y] = c2;
                        globals_PixelMap[x + 6, y] = c1;
                        globals_PixelMap[x + 7, y] = c2;
                    }
                }
            }
            if (cboPreprocessor_Text == "InterlaceX2")
            {
                for (int y = 0; y < b.Height; y += 2)
                {
                    for (int x = 0; x < b.Width; x += 1)
                    {
                        globals_PixelMap[x, y] = 0;
                    }
                }
            }

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    b2.SetPixel(x, y, getcolor(globals_PixelMap[x, y]));
                    if (globals_PixelMap[x, y] < 4)
                        globals_LastPixelMap[x, y] = globals_PixelMap[x, y];
                }
            }

            pictureBox1_Image = b2;
            pictureBox1_Image.Save(txtFilename_Text + "_Processed.png");

            // Application.DoEvents();
            int validwidth = b.Width / 8;
            validwidth = validwidth * 8;
            globals_initdata += "jp " + Filename + nl;


            globals_imagedata.Append(Filename + ":" + nl);



            if (cboEngine_Text.ToLower() != "akuyou")
            {
                string myvar = "sp";
                if (VbX.CInt(txtxpos_text) > 0)
                {
                    myvar = "hl";
                }
                // int xpos = ((80 - (b2.Width / 4)) / 2);
                //int xpos = (79 - VbX.CInt(txtxpos_text)) - (b2.Width/4);
                // int xpos = VbX.CInt(txtxpos_text);
                int xpos = (80 - (VbX.CInt(txtxpos_text) - b2.Width) / 4);
                globals_imagedata.Append("ld (StackRestore_Plus2-2),sp" + nl + "di" + nl + "ld " + myvar + ",&C000+" + VbX.CStr((VbX.CInt(txtxpos_text) / 1)) + "+" + (b2.Width / 4).ToString() + nl + nl);

                if (VbX.CInt(txtxpos_text) > 0)
                {
                    globals_imagedata.Append("xor a" + nl);
                    globals_imagedata.Append("ld (ImageWidthD_Plus2-2),a" + nl);
                    globals_imagedata.Append("ld a," + txtypos_text + nl);
                    globals_imagedata.Append("or a" + nl);
                    globals_imagedata.Append(Filename + "_DrawGetNextLine:" + nl);
                    globals_imagedata.Append("jr z," + Filename + "_DrawGotLine" + nl);
                    globals_imagedata.Append("call RLE_NextScreenLineHL" + nl);
                    //globals_imagedata.Append("add hl,de"+ nl);
                    globals_imagedata.Append("dec a" + nl);
                    globals_imagedata.Append("		jr " + Filename + "_DrawGetNextLine" + nl);
                    globals_imagedata.Append(Filename + "_DrawGotLine:" + nl);
                    globals_imagedata.Append("ld sp,hl" + nl);
                }

            }
            else
            {
                globals_imagedata.Append(globals_AkuyouNextFile);

            }
            globals_imagedata.Append("LD IX," + Filename + "_DrawOrder" + nl);
            globals_imagedata.Append("JP JumpToNextLine" + nl);
            globals_imagedata.Append(nl + nl);

            for (int y = 0; y < b.Height; y++)
            {
                string ChunkName = Filename + "_Line_" + y.ToString();
                globals_ChunkDeBak = globals_RegDE;
                globals_RegBC = "";
                // globals_RegDE = "";
                globals_RegHL = "";


                int DePushes = 0;
                RandomReg = 0;
                int HlPushes = 0;
                globals_DEUsed = 0;
                RandomReg = 0;
                //Chunk.Append(ChunkName + ":" + VbX.Chr(13) + VbX.Chr(10));
                for (int x = (validwidth) - 8; x >= 0; x -= 8)
                {
                    string thispair = GetPair(y, x);
                    string nextpair = GetPair(y, x - 8);
                    string thiscommand = "";
                    if (globals_RegDE == thispair || globals_RegHL == thispair)
                    {
                        // bitblocks will nuke DE
                        AddBitBlock(Bitblock, BitblockLinear, Chunk, x); Bitblock = ""; BitblockLinear = "";
                    }
                    if (globals_RegDE == thispair)
                    {
                        // AddPushes("HL", Chunk, HlPushes, globals_LastHL); HlPushes = 0;
                    }
                    if (globals_RegDE == thispair)
                    {

                        CodeBytes++; DePushes++;
                    }
                    //else if (globals_RegHL== thispair)
                    //                    {
                    //AddPushes("DE", Chunk, DePushes,globals_LastDE); DePushes = 0;
                    //CodeBytes++; HlPushes++;
                    //                    }
                    else if (nextpair != thispair)
                    {
                        AddPushes("DE", Chunk, DePushes, globals_LastDE, x); DePushes = 0;
                        // AddPushes("HL", Chunk, HlPushes, globals_LastHL); HlPushes = 0;


                        if (thispair == "ZZZZ")
                        {
                            AddBitBlock(Bitblock, BitblockLinear, Chunk, x); Bitblock = ""; BitblockLinear = "";
                            Chunk.Append("dec sp" + nl);
                            Chunk.Append("dec sp" + nl);
                        }
                        else
                        {
                            if (Bitblock.Length >= VbX.CInt(txtBitBlockLength_Text) * 3)
                            {
                                AddBitBlock(Bitblock, BitblockLinear, Chunk, x); Bitblock = ""; BitblockLinear = "";
                            }


                            Bitblock = thispair.Substring(2, 2) + "," + thispair.Substring(0, 2) + "," + Bitblock;
                            BitblockLinear = BitblockLinear + thispair.Substring(0, 2) + "," + thispair.Substring(2, 2) + ",";
                        }
                        /*
                        CodeBytes += 4;
                        AddPushes("DE", Chunk, DePushes);
                        DePushes = 0;

                        
                         if (RegBC == thispair)
                        {
                            CodeBytes += 1;
                            thiscommand = "  Push BC" + nl;
                        } if (RegHL == thispair)
                        {
                            CodeBytes += 1;
                            thiscommand = "  Push HL" + nl;
                        }
                        else
                        {
                            if (RandomReg == 2) RandomReg = 0;
                            
                            switch (RandomReg){
                                case 0:
                                    thiscommand = " LD BC,&" + thispair + nl + "  Push BC" + nl;
                                    RegBC = thispair;
                                    break;
                                case 1:
                                    thiscommand = " LD HL,&" + thispair + nl + "  Push HL" + nl;
                                    RegHL = thispair;
                                    break;

                            }
                        RandomReg++;
                        }
                        */
                    }

                    else if (globals_RegDE != thispair)
                    {

                        if (globals_DEUsed == 0)
                        {
                            globals_ChunkDeBak = "";
                        }
                        AddBitBlock(Bitblock, BitblockLinear, Chunk, x); Bitblock = ""; BitblockLinear = "";
                        AddPushes("DE", Chunk, DePushes, globals_LastDE, x); DePushes = 0;
                        // AddPushes("HL", Chunk, HlPushes,globals_LastHL); HlPushes = 0;

                        //if (RandomReg == 1) RandomReg = 0;

                        //switch (RandomReg)
                        //{
                        //  case 0:
                        globals_LastDE = globals_RegDE;
                        //thiscommand = MakeConverter("DE", globals_RegDE, thispair) + nl;//thiscommand = " LD DE,&" + thispair + nl;
                        globals_RegDE = thispair;
                        CodeBytes += 3; DePushes++;
                        //    break;
                        //case 1:
                        //    globals_LastHL = globals_RegHL;
                        //thiscommand = MakeConverter("HL", globals_RegHL, thispair) + nl;//thiscommand = " LD DE,&" + thispair + nl;
                        //      globals_RegHL = thispair;
                        //CodeBytes += 3; HlPushes++;
                        //break;

                        //}
                        //RandomReg++;

                        //  thiscommand = MakeConverter("DE", globals_RegDE, thispair) + nl;//thiscommand = " LD DE,&" + thispair + nl;
                        // globals_RegDE = thispair;
                        // CodeBytes += 3; DePushes++;
                    }
                    // thiscommand += "    PUSH DE" + nl;



                    Chunk.Append(thiscommand);
                }
                AddBitBlock(Bitblock, BitblockLinear, Chunk, 319); Bitblock = ""; BitblockLinear = "";
                AddPushes("DE", Chunk, DePushes, globals_LastDE, 319); DePushes = 0;
                // AddPushes("HL", Chunk, HlPushes, globals_LastHL); HlPushes = 0;
                // if (DrawOrder.Length > 0) DrawOrder += ",";

                CodeBytes += 2;


                String Nextline = "";
                // Nextline = nl + ";NewLine" + nl + "ld hl,&0850" + nl + "add hl,sp" + nl + "ld sp,hl" + nl + nl;
                //  if (y%8==7) Nextline = nl + ";NewLine" + nl + "ld hl,&C8A0" + nl + "add hl,sp" + nl + "ld sp,hl" + nl + nl;

                if (y % VbX.CInt(cboLineGroups_Text) != VbX.CInt(cboLineGroups_Text) - 1 && VbX.CInt(cboLineGroups_Text) > 1)
                {
                    string mylabel = "Label" + VbX.CStr(VbX.CInt(VbX.Rnd() * 32768000));
                    Nextline = "ld bc," + mylabel + nl + "jp NextLineBC" + nl + mylabel + ":" + nl;
                    globals_RegBC = "";
                }
                else
                {
                    if (cboNextLine_Text.ToLower() == "fast")
                    {
                        Nextline = "jp NextLineFirst" + nl;
                        if (y % 8 == 7) Nextline = "jp NextLineSecond" + nl;
                    }
                    else
                    {
                        if (globals_SkipNextline)
                        {
                            globals_SkipNextline = false;
                        }
                        else
                        {
                            Nextline = "jp NextLine" + nl;

                            /*
                             if (globals_localnextlinenum == 0)
                            {

                                Nextline = "LocalNextLine" + globals_localnextline.ToString() + ":jp NextLine" + nl;
                            }
                            else
                            {
                                Nextline = "jr LocalNextLine" + globals_localnextline.ToString() + nl;



                            }
                            globals_localnextlinenum++;

                            if (globals_localnextlinenum >= 2)
                            {
                                globals_localnextlinenum = -1;
                                globals_localnextline++;
                            }
                             * 
                             */
                        }
                    }
                }
                Chunk.Append(Nextline + nl + nl);

                globals_RegHL = "";



                if (!(y % VbX.CInt(cboLineGroups_Text) != VbX.CInt(cboLineGroups_Text) - 1) || VbX.CInt(cboLineGroups_Text) == 1 || y == b.Height - 1)
                {
                    string Founchunk = "";
                    int FounchunkI = 0;
                    for (int i = 0; i < globals_ChunkCache; i++)
                    {
                        if (globals_ChunkCache_Data[i] == Chunk.ToString() && (globals_ChunkCache_DE[i] == globals_ChunkDeBak || globals_ChunkDeBak == "ZZZZ"))
                        {
                            Founchunk = globals_ChunkCache_Name[i];
                            FounchunkI = i;
                        }
                    }
                    if (Founchunk == "")
                    {
                        globals_imagedata.Append(ChunkName + ":" + nl);
                        globals_imagedata.Append(Chunk);
                        DrawOrder += "  DEFW " + ChunkName + VbX.Chr(13);
                        globals_ChunkCache_Name[globals_ChunkCache] = ChunkName;
                        if (globals_ChunkDeBak == "ZZZZ") globals_ChunkDeBak = "";
                        globals_ChunkCache_DE[globals_ChunkCache] = globals_ChunkDeBak;
                        globals_ChunkCache_Data[globals_ChunkCache] = Chunk.ToString();
                        globals_ChunkCache++;




                    }
                    else
                    {
                        if (globals_ChunkCache_DE[FounchunkI].Length > 0)
                        {
                            if (globals_ChunkCache_Reused[FounchunkI] != 1)
                            {
                                globals_ChunkCache_Reused[FounchunkI] = 1;
                                globals_imagedata.Append(Founchunk + "_Reuse:" + nl);
                                globals_imagedata.Append("LD DE,&" + globals_ChunkCache_DE[FounchunkI] + nl);
                                globals_imagedata.Append("JP " + Founchunk + nl);

                            }
                            globals_RegDE = globals_ChunkCache_DE[FounchunkI];
                            DrawOrder += "  DEFW " + Founchunk + "_Reuse" + VbX.Chr(13);
                        }
                        else
                        {
                            DrawOrder += "  DEFW " + Founchunk + VbX.Chr(13);
                        }


                    }

                    Chunk = new StringBuilder();
                }
                else
                {


                }

            }


            DrawOrder += "  DEFW EndCode" + VbX.Chr(13);

            globals_imagedata.Append(nl + Filename + "_DrawOrder: " + nl);
            string Last1 = "";
            string Last2 = "";
            int repeat1 = 1;
            for (int i = 0; i <= ss.CountItems(DrawOrder, VbX.Chr(13)); i++)
            {
                string this1 = ss.GetItem(DrawOrder, VbX.Chr(13), i).Replace(VbX.Chr(10), "").Replace(VbX.Chr(13), "");
                if (this1 == Last1)
                {
                    repeat1++;
                }
                else
                {
                    if ((repeat1 >= 1 && repeat1 <= 6) || !chkLooper_Checked)
                    {
                        for (int a = 1; a <= repeat1; a++)
                        {
                            globals_imagedata.Append(Last1 + nl);
                        }
                    }
                    else if (repeat1 > 6)
                    {
                        globals_imagedata.Append("defw looper" + nl);
                        globals_imagedata.Append("  DEFB 1," + repeat1 + nl);
                        globals_imagedata.Append(Last1 + nl);
                        globals_UseLooper = true;
                    }
                    repeat1 = 1;
                    Last1 = this1;
                    // globals_imagedata.Append(this1 + nl);

                }


            }

            DoGlobalData(b2);
            // this.Text = "Total Code:" + textBox1.Text.ToString().Length;
            //int value = Convert.ToInt32("1101", 2)
            // string binary = Convert.ToString(value, 2);
        }
        private void addheader()
        {
            string Filename = DoFilename(txtFilename_Text);//"Pic" + ss.GetItem(txtFilename.Text, "\\", ss.CountItems(txtFilename.Text, "\\")).Replace(".", "");
            txtHeader_Text += Filename + "_Bank equ " + txtBank_Text + VbX.Chr(13) + VbX.Chr(10);
            txtHeader_Text += Filename + "_Ref equ " + globals_PicNumber.ToString() + VbX.Chr(13) + VbX.Chr(10);
            if (txtFilenameOld_Text.Length > 0)
            {
                txtHeader_Text += Filename + "_ParentRef equ " + DoFilename(txtFilenameOld_Text) + "_Ref " + VbX.Chr(13) + VbX.Chr(10);
            }
            else
            {
                txtHeader_Text += Filename + "_ParentRef equ 255" + VbX.Chr(13) + VbX.Chr(10);
            }
            txtHeader_Text += VbX.Chr(13) + VbX.Chr(10);
        }
       


           private string GetPair(int y, int x)
           {
               int transpcount = 0;
               if (x < 0) return "Bad!";
               string thispair = "";
               for (int pair = 0; pair < 2; pair++)
               {
                   int thisbyte = 0;
                   for (int bit = 0; bit < 4; bit++)
                   {

                       int tx = x + (3 - bit) + (pair * 4);

                       int dot = globals_PixelMap[tx, y];
                       if (dot >= 4)
                       {
                           transpcount++;
                           dot = 0;
                       }
                       string binary = VbX.Right("00" + Convert.ToString(dot, 2), 2);
                       string Binary2 = binary.Substring(1, 1) + "000" + binary.Substring(0, 1);

                       thisbyte = thisbyte + (Convert.ToInt32(Binary2, 2) << bit);
                       // if (dot == 3) VbX.MsgBox(Binary2 + "   " + bit.ToString() + "  " + thisbyte.ToString());
                   }
                   thispair = VbX.Right("00" + thisbyte.ToString("X"), 2) + thispair;
               }
               if (transpcount == 8) { return "ZZZZ"; }
               return thispair;

           }

           private void AddBitBlock(String BitBlock, String BitBlockLinear, StringBuilder st, int xpos)
           {



               if (BitBlock.Length <= (4 * 3))
               {

                   for (int i = 1; i <= VbX.Len(BitBlockLinear); i += 6)
                   {
                       bool last = false;
                       if (i + 6 > VbX.Len(BitBlockLinear)) last = true;

                       string thispair = VbX.Mid(BitBlockLinear, i, 6).Replace(",", "");

                       if (globals_RegBC == thispair)
                       {
                           if (xpos == 319 && last)
                           {
                               globals_SkipNextline = true;
                               st.Append(" jp NextLinePushBC " + nl);
                           }
                           else
                           {
                               st.Append("  Push BC" + nl);
                           }
                       }
                       else if (globals_RegDE == thispair)
                       {
                           globals_DEUsed = 1;
                           if (xpos == 319 && last)
                           {
                               globals_SkipNextline = true;
                               st.Append(" jp NextLinePushDe1");
                           }
                           else
                           {
                               st.Append("  Push DE" + nl);
                           }
                       }
                       else if (globals_RegHL == thispair)
                       {
                           if (xpos == 319 && last)
                           {
                               globals_SkipNextline = true;
                               st.Append(" jp NextLinePushHl " + nl);
                           }
                           else
                           {
                               st.Append("  Push HL " + nl);
                           }
                       }
                       else
                       {

                           RandomReg++;

                           // RandomReg = 0;
                           //if (uniuquechars(thispair) >= 3)
                           // {
                           //    RandomReg = 1;
                           // }
                           if (RandomReg == 2) RandomReg = 0;


                           if (RandomReg == 0)
                           {
                               string thiscommand2 = MakeConverter("BC", globals_RegBC, thispair) + nl;// " LD BC,&" + thispair + nl;



                               globals_RegBC = thispair;
                               if (xpos == 319 && last)
                               {
                                   globals_SkipNextline = true;
                                   thiscommand2 += " jp NextLinePushBC " + nl;
                               }
                               else
                               {

                                   if (thiscommand2.Contains("LD BC,") && chkcomressDEs_Checked)
                                   {
                                       bool found = false;

                                       thiscommand2 = "PairCache" + thispair + ":pop hl" + nl + "ld bc,&" + thispair + nl + "push bc" + nl + "jp (hl)" + nl;

                                       for (int iis = 0; iis < globals_PairCache_Count; iis++)
                                       {
                                           if (globals_PairCache_Data[iis] == thiscommand2)
                                           {
                                               found = true;
                                           }
                                       }
                                       if (!found)
                                       {
                                           globals_PairCache_Data[globals_PairCache_Count] = thiscommand2;
                                           globals_PairCache_Count++;
                                       }
                                       thiscommand2 = "call PairCache" + thispair + nl;
                                       globals_RegHL = "";
                                   }
                                   else
                                   {

                                       thiscommand2 += "  Push BC" + nl;

                                   }
                               }
                               st.Append(thiscommand2);
                           }
                           if (RandomReg == 1)
                           {
                               string thiscommand2 = MakeConverter("HL", globals_RegHL, thispair) + nl;// " LD BC,&" + thispair + nl;
                               globals_RegHL = thispair;
                               if (xpos == 319 && last)
                               {
                                   globals_SkipNextline = true;
                                   thiscommand2 += "  jp NextLinePushHl " + nl;
                               }
                               else
                               {

                                   thiscommand2 += "  Push HL" + nl;

                               }
                               st.Append(thiscommand2);
                           }
                       }
                   }
                   BitBlock = "";
                   BitBlockLinear = "";
                   return;
               }

               if (BitBlock == "") return;
               int bytecount = BitBlock.Length / 3;
               int alreadyexists = VbX.InStr(globals_BitmapData, BitBlock);
               // if (globals_BitmapData.Length < bytecount) alreadyexists = -1;
               string thiscommand = "";
               string mylabel = "      Label" + VbX.CStr(VbX.CInt(VbX.Rnd() * 32768000));
               if (alreadyexists > 0)
               {
                   alreadyexists = (alreadyexists - 1) / 3;
                   // BitmapPushReturn_Plus2
                   // thiscommand = "ld hl,&FFFF" + nl + "add hl,sp" + nl + "ex de,hl" + nl + "ld hl,BitmapData+" + VbX.CStr(alreadyexists + bytecount - 1) + "" + nl + "ld bc,&" + VbX.Right("0000" + (bytecount).ToString("X"), 4) + nl;
                   //thiscommand += "lddr" + nl + "ex de,hl" + nl + "ld sp,hl" + nl + "inc sp" + nl;

                   //thiscommand += "ld hl," + mylabel + nl + "jp BitmapPush"+bytecount.ToString()+  nl;
                   // if (xpos == 319)
                   //{
                   //   globals_BitmapPushLastUsed[bytecount] = true;
                   //  globals_SkipNextline = true;
                   //    thiscommand += "jp BitmapPushLast" + bytecount.ToString() + nl;
                   // }
                   // else
                   //{
                   if (xpos == 319)
                   {
                       globals_BitmapDataLastUsed[bytecount] = true;
                       thiscommand += "call FinalBitmapPush" + bytecount.ToString() + nl;
                       globals_SkipNextline = true;
                   }
                   else
                   {
                       thiscommand += "call BitmapPush" + bytecount.ToString() + nl;
                       globals_BitmapDataUsed[bytecount] = true;
                   }
                   //}
                   thiscommand += "defw BitmapData+" + VbX.CStr(alreadyexists + bytecount - 1) + "" + nl; //+ "ld c,&" + VbX.Right("00" + (bytecount).ToString("X"), 2) + nl;


                   // thiscommand += mylabel + ":" + nl;
                   BitBlock = "";
                   st.Append(thiscommand);
                   globals_RegBC = "";
                   // globals_RegDE = "";
                   globals_RegHL = "";

                   return;
               }



               /*
      
               }
                */

               //thiscommand = "ld hl,&FFFF" + nl + "add hl,sp" + nl + "ex de,hl" + nl + "ld hl,BitmapData+" + VbX.CStr((BitmapData.Length / 2)+bytecount-1) + "" + nl + "ld bc,&" + VbX.Right("0000" + (bytecount).ToString("X"), 4) + nl;
               //thiscommand += "lddr" + nl + "ex de,hl" + nl + "ld sp,hl" + nl + "inc sp" + nl;

               //thiscommand += "ld hl," + mylabel + nl + "jp BitmapPush" +bytecount.ToString()+ nl;
               if (xpos == 319)
               {
                   globals_BitmapDataLastUsed[bytecount] = true;
                   thiscommand += "call FinalBitmapPush" + bytecount.ToString() + nl;
                   globals_SkipNextline = true;
               }
               else
               {
                   thiscommand += "call BitmapPush" + bytecount.ToString() + nl;
                   globals_BitmapDataUsed[bytecount] = true;
               }
               thiscommand += "defw BitmapData+" + VbX.CStr((globals_BitmapData.Length / 3) + bytecount - 1) + "" + nl;//+ "ld c,&" + VbX.Right("00" + (bytecount).ToString("X"), 2) + nl;
               // thiscommand += mylabel + ":" + nl;
               globals_BitmapData = globals_BitmapData + BitBlock;

               BitBlock = "";
               st.Append(thiscommand);
               globals_RegBC = "";
               // globals_RegDE = "";
               globals_RegHL = "";

           }
           private void AddPushes(string REG, StringBuilder st, int ct, string regorig, int xpos)
           {
               int decompression = VbX.CInt(txtDeCompression_Text);
               int swapped = 0;
               if (ct == 0) return;

               if (globals_RegDE == "ZZZZ")
               {
                   if (ct == 2)
                   {
                       if (xpos == 319)
                       {
                           st.Append("jp NextLineDecSP4" + nl);
                           globals_SkipNextline = true;
                       }
                       else
                       {
                           st.Append("DEC SP" + nl + "DEC SP" + nl + "DEC SP" + nl + "DEC SP" + nl);
                       }
                       return;

                   }
                   if (ct == 4 && xpos == 319)
                   {
                       st.Append("jp NextLineDecSP8" + nl);
                       globals_SkipNextline = true;
                       return;
                   }

                   st.Append("ld hl,&FF" + VbX.Right("FF" + ((255 - (ct * 2)) + 1).ToString("X"), 2) + nl);
                   if (xpos == 319)
                   {
                       st.Append("jp NextLineSPshift" + nl);
                       globals_SkipNextline = true;
                   }
                   else
                   {
                       st.Append("add hl,sp" + nl + "ld sp,hl" + nl);
                   }
                   //globals_RegDE=topush;
                   globals_RegHL = "";
                   globals_LastHL = "";
                   return;

               }

               if (REG == "HL" && regorig != globals_RegHL)
               {
                   if (ct == decompression && (globals_RegHL == "F0F0" || globals_RegHL == "0F0F" || globals_RegHL == "FFFF" || globals_RegHL == "0000"))
                   {
                       st.Append("EX DE,HL" + nl);
                       st.Append("Call PushDE_" + globals_RegHL + "x" + nl);
                       swapped = 1;
                       globals_RegHL = "";
                       ct = ct - decompression;

                   }
                   else
                   {
                       st.Append(MakeConverter("HL", regorig, globals_RegHL) + nl);//thiscommand = " LD DE,&" + thispair + nl;

                   }
               }
               if (REG == "DE" && regorig != globals_RegDE)
               {


                   if (ct == decompression && (globals_RegDE == "F0F0" || globals_RegDE == "0F0F" || globals_RegDE == "FFFF" || globals_RegDE == "0000"))
                   {
                       if (globals_DEUsed == 0)
                       {
                           globals_ChunkDeBak = "";
                       }
                       globals_DEUsed = 1;
                       st.Append("Call PushDE_" + globals_RegDE + "x" + nl);
                       ct = ct - decompression;
                       globals_LastDE = globals_RegDE;
                       globals_RegHL = "";


                   }
                   else if (chkRst0_Checked && globals_RegDE.Substring(0, 2) == globals_RegDE.Substring(2, 2) && ct > 1)
                   {
                       st.Append("RST 0" + nl);
                       st.Append("Defb &" + globals_RegDE.Substring(0, 2) + nl);
                       ct -= 2;
                       globals_LastDE = globals_RegDE;
                   }
                   else
                   {
                       if (regorig != globals_RegDE)
                       {
                           if (globals_DEUsed == 0)
                           {
                               globals_ChunkDeBak = "";
                           }
                           globals_DEUsed = 1;
                           st.Append(MakeConverter("DE", regorig, globals_RegDE) + nl);//thiscommand = " LD DE,&" + thispair + nl;
                       }
                       globals_LastDE = globals_RegDE;
                   }
               }

               globals_DEUsed = 1;
               if (ct == 0)
               {
                   if (swapped == 1) st.Append("EX DE,HL" + nl);
                   return;
               }
               if (ct <= 4 && xpos == 319)
               {
                   globals_SkipNextline = true;
                   st.Append(" jp NextLinePushDe" + ct.ToString() + nl); return;
               }
               if (ct == 1)
               {
                   if (swapped == 1) st.Append("EX DE,HL" + nl);
                   st.Append("  PUSH " + REG + nl); return;
               }
               string part = "";

               if (ct >= 3 && ct <= 4 && chkRst6_Checked == true)
               {
                   st.Append("  RST 6 " + nl);
                   globals_RegHL = "";
                   ct -= 3;
                   if (ct == 0) return;
               }
               if (ct <= 4)
               {
                   if (swapped == 1) st.Append("EX DE,HL" + nl);
                   for (int i = 0; i < ct; i++)
                   {
                       st.Append("  PUSH " + REG + nl);

                   }
                   return;
               }
               // part += "       LD B," + VbX.CStr(ct) + nl;
               string mylabel = "      Label" + VbX.CStr(VbX.CInt(VbX.Rnd() * 32768000));
               if (REG == "HL")
               {
                   string tmp = globals_RegDE;
                   globals_RegDE = globals_RegHL;
                   globals_RegHL = tmp;
                   if (swapped == 0) part += "EX DE,HL" + nl;

               }

               // part += "ld hl," + mylabel + nl;

               //part += "jp MultiPushDe" + VbX.CStr(ct) + nl;
               globals_RegHL = "";
               globals_LastHL = "";

               if (xpos == 319)
               {
                   globals_MultiPushDeLast[ct] = true;
                   part += "jp MultiPushDeLast" + VbX.CStr(ct) + nl;
                   globals_SkipNextline = true;

               }
               else
               {

                   part += "call MultiPushDe" + VbX.CStr(ct) + nl;
               }
               if (ct > globals_MaxDePush) globals_MaxDePush = ct;
               globals_DePushUsed[ct] = true;
               //part += mylabel+":"+nl;
               //part += "       PUSH " + REG+nl;
               //part += "       djnz " + mylabel + nl;
               st.Append(part);
               // RegBC = "";

           }
           private string MakeConverter(string RegKey, string RegSrc, string RegDest)
           {
               if (RegSrc == RegDest) return "";

               switch (RegKey)
               {
                   case "DE":
                       globals_RegDE = RegSrc; break;

                   case "BC":
                       globals_RegBC = RegSrc; break;

                   case "HL":
                       globals_RegHL = RegSrc; break;
               }

               string response = "";
               string part1 = "";
               string part2 = "";

               if (RegSrc == "0000" && RegDest == "FFFF")
               {
                   response = "DEC " + RegKey + nl;
               }

               if (RegSrc == "FFFF" && RegDest == "0000")
               {
                   response = "INC " + RegKey + nl;

               }

               if (response == "")
               {


                   if (RegKey != "BC")
                   {
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegBC, 1, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",B";
                       }
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegBC, 3, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",C";
                       }
                   }

                   if (RegKey != "HL")
                   {
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegHL, 1, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",H";
                       }
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegHL, 3, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",L";
                       }

                   }
                   if (RegKey != "DE")
                   {
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegDE, 1, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",D";
                           globals_DEUsed = 1;
                       }
                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(globals_RegDE, 3, 2))
                       {
                           part2 = "Ld " + VbX.Mid(RegKey, 2, 1) + ",E";
                           globals_DEUsed = 1;
                       }
                   }
                   if (RegKey != "BC")
                   {
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegBC, 1, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",B";
                       }
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegBC, 3, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",C";
                       }
                   }
                   if (RegKey != "HL")
                   {
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegHL, 1, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",H";
                       }
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegHL, 3, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",L";
                       }
                   }
                   if (RegKey != "DE")
                   {
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegDE, 1, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",D";
                           globals_DEUsed = 1;
                       }
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(globals_RegDE, 3, 2))
                       {
                           part1 = "Ld " + VbX.Mid(RegKey, 1, 1) + ",E";
                           globals_DEUsed = 1;
                       }
                   }
                   if (part1 != "" && part2 != "")
                   {

                       if (VbX.Mid(RegDest, 3, 2) == VbX.Mid(RegSrc, 3, 2))
                       {
                           part2 = "";
                       }
                       if (VbX.Mid(RegDest, 1, 2) == VbX.Mid(RegSrc, 1, 2))
                       {
                           part1 = "";
                       }
                       response = part1 + nl + part2 + nl;
                   }
               }
               if (response == "")
               {
                   if (VbX.Mid(RegSrc, 1, 2) == VbX.Mid(RegDest, 1, 2))
                   {
                       //first half matches
                       if (VbX.Mid(RegSrc, 1, 2) == VbX.Mid(RegDest, 3, 2))
                       {
                           response = "Ld " + VbX.Mid(RegKey, 2, 1) + "," + VbX.Mid(RegKey, 1, 1);
                       }
                       if (VbX.Mid(RegSrc, 3, 2) == VbX.Mid(RegDest, 3, 2))
                       {
                           response = "Ld " + VbX.Mid(RegKey, 2, 1) + "," + VbX.Mid(RegKey, 2, 1);
                       }
                       response = "Ld " + VbX.Mid(RegKey, 2, 1) + ",&" + VbX.Mid(RegDest, 3, 2);
                   }
                   else if (VbX.Mid(RegSrc, 3, 2) == VbX.Mid(RegDest, 3, 2))
                   {
                       //second half matches
                       if (VbX.Mid(RegSrc, 1, 2) == VbX.Mid(RegDest, 1, 2))
                       {
                           response = "Ld " + VbX.Mid(RegKey, 1, 1) + "," + VbX.Mid(RegKey, 1, 1);
                       }
                       else if (VbX.Mid(RegSrc, 3, 2) == VbX.Mid(RegDest, 1, 2))
                       {
                           response = "Ld " + VbX.Mid(RegKey, 1, 1) + "," + VbX.Mid(RegKey, 2, 1);
                       }
                       else response = "Ld " + VbX.Mid(RegKey, 1, 1) + ",&" + VbX.Mid(RegDest, 1, 2);
                   }



                   else response = "LD " + RegKey + ",&" + RegDest;
               }

               switch (RegKey)
               {
                   case "DE":
                       globals_RegDE = RegDest; break;

                   case "BC":
                       globals_RegBC = RegDest; break;

                   case "HL":
                       globals_RegHL = RegDest; break;
               }



               return response;
           }

           private void ConvertImage(Bitmap b, int[,] pxl)
           {

               for (int y = 0; y < b.Height; y++)
               {
                   for (int x = 0; x < b.Width; x++)
                   {
                       int xx = x / VbX.CInt(txtXScale_Text);
                       xx = xx * VbX.CInt(txtXScale_Text) + VbX.CInt(VbX.CInt(txtXScale_Text) / 2);
                       int yy = y / VbX.CInt(txtYScale_Text);
                       yy = yy * VbX.CInt(txtYScale_Text);
                       yy = yy + VbX.CInt(VbX.CInt(txtYScale_Text) / 2);
                       if (chkScaledownDither_Checked)
                       {
                           int halfscale = VbX.CInt(txtYScale_Text) / 4;
                           int linenum = y % 2;
                           if (linenum == 1) yy = yy + halfscale;
                           if (yy >= b.Height) yy = b.Height - 1;
                       }
                       else
                       {

                       }
                       Color c = b.GetPixel(xx, yy);

                       int bestcolor = 0;
                       int bestcolormatch = 255 * 3;
                       for (int i = 0; i <= 4; i++)
                       {
                           int thismatch = Math.Abs(c.R - getcolor(i).R) + Math.Abs(c.G - getcolor(i).G) + Math.Abs(c.B - getcolor(i).B);
                           if (Math.Abs(thismatch) < bestcolormatch) { bestcolor = i; bestcolormatch = Math.Abs(thismatch); }
                       }

                       for (int i = 0; i <= ss.CountItems(txtColorConv_Text, VbX.Chr(13)); i++)
                       {
                           string subpart = ss.GetItem(txtColorConv_Text, VbX.Chr(13), i);
                           int newcol = VbX.CInt(ss.GetItem(subpart, ",", 0));
                           int Tolerance = VbX.CInt(ss.GetItem(subpart, ",", 1));
                           int R = VbX.CInt(ss.GetItem(subpart, ",", 2));
                           int G = VbX.CInt(ss.GetItem(subpart, ",", 3));
                           int B = VbX.CInt(ss.GetItem(subpart, ",", 4));


                           int thismatch = Math.Abs(c.R - R) + Math.Abs(c.G - G) + Math.Abs(c.B - B);
                           if (Tolerance > 0)
                           {
                               if (Math.Abs(thismatch) < Tolerance) { bestcolor = newcol; bestcolormatch = Math.Abs(thismatch); }
                           }
                       }

                       // int thismatch = Math.Abs(c.R - getcolor(i).R) + Math.Abs(c.G - getcolor(i).G) + Math.Abs(c.B - getcolor(i).B);
                       //if (Math.Abs(thismatch) < bestcolormatch) { bestcolor = i; bestcolormatch = Math.Abs(thismatch); }

                       pxl[x, y] = bestcolor;


                   }
               }



           }
           public static string globals_AkuyouNextFile =
                       "ld (Background_CompiledSprite_Minus1+1),de" + VbX.Chr(13) + VbX.Chr(10) +
                       "call Akuyou_ScreenBuffer_GetActiveScreen" + VbX.Chr(13) + VbX.Chr(10) +
                       "ld h,a" + VbX.Chr(13) + VbX.Chr(10) +
                       "ld l,&50" + VbX.Chr(13) + VbX.Chr(10) +
                       "ld (StackRestore_Plus2-2),sp" + VbX.Chr(13) + VbX.Chr(10) +
                       "di" + VbX.Chr(13) + VbX.Chr(10) +
                       "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10);





           public static string globals_AkuyouNextLine =

              "NextLine: " + VbX.Chr(13) + VbX.Chr(10) +

       "ld hl,&0850" + VbX.Chr(13) + VbX.Chr(10) +
       "add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +

       "ei" + VbX.Chr(13) + VbX.Chr(10) +
       "ld sp,&0000:StackRestore_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
       "di" + VbX.Chr(13) + VbX.Chr(10) +

       "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
               //"jp CompiledSprite_GetNxtLin :CompiledSprite_NextLineJump_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
               //"CompiledSprite_GetNxtLin:" + VbX.Chr(13) + VbX.Chr(10) +
               //"jp nc,JumpToNextLine" + VbX.Chr(13) + VbX.Chr(10) +

       //"ld hl,&c050" + VbX.Chr(13) + VbX.Chr(10) +
               //"add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +
               //"ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
               //"jp JumpToNextLine" + VbX.Chr(13) + VbX.Chr(10) +
               //"CompiledSprite_GetNxtLinAlt:" + VbX.Chr(13) + VbX.Chr(10) +
       "Background_CompiledSprite_Minus1:" + VbX.Chr(13) + VbX.Chr(10) +
       "bit 7,h" + VbX.Chr(13) + VbX.Chr(10) +
       "jp z,JumpToNextLine" + VbX.Chr(13) + VbX.Chr(10) +
       "ld hl,&c050" + VbX.Chr(13) + VbX.Chr(10) +
       "add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +
       "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
       ";push hl" + VbX.Chr(13) + VbX.Chr(10) +
       "jp JumpToNextLine" + VbX.Chr(13) + VbX.Chr(10) +

       "JumpToNextLine: " + VbX.Chr(13) + VbX.Chr(10) +
       "LD L,(IX)" + VbX.Chr(13) + VbX.Chr(10) +
       "INC IX" + VbX.Chr(13) + VbX.Chr(10) +
       "LD H,(IX)" + VbX.Chr(13) + VbX.Chr(10) +
       "INC IX" + VbX.Chr(13) + VbX.Chr(10) +
       "JP (HL)" + VbX.Chr(13) + VbX.Chr(10)
   ;

           public static string globals_AkuyouNextLineBCdisable = "CompiledSprite_GetNxtLinbc: defw &0000 :CompiledSprite_NextLineJumpBC_Plus2" + VbX.Chr(13) + VbX.Chr(10);
           public static string globals_AkuyouNextLineBC =

          "NextLineBC: " + VbX.Chr(13) + VbX.Chr(10) +

   "ld hl,&0850" + VbX.Chr(13) + VbX.Chr(10) +
   "add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +

   "ld sp,(StackRestore_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
   "ei" + VbX.Chr(13) + VbX.Chr(10) +
   "di" + VbX.Chr(13) + VbX.Chr(10) +

   "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
   "jp CompiledSprite_GetNxtLinBC :CompiledSprite_NextLineJumpBC_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
   "CompiledSprite_GetNxtLinBC:" + VbX.Chr(13) + VbX.Chr(10) +
   "jp nc,JumpToNextLineBC" + VbX.Chr(13) + VbX.Chr(10) +

   "ld hl,&c050" + VbX.Chr(13) + VbX.Chr(10) +
   "add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +
   "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
   "jp JumpToNextLineBC" + VbX.Chr(13) + VbX.Chr(10) +
   "CompiledSprite_GetNxtLinAltBC:" + VbX.Chr(13) + VbX.Chr(10) +
   "bit 7,h" + VbX.Chr(13) + VbX.Chr(10) +
   "jp z,JumpToNextLineBC" + VbX.Chr(13) + VbX.Chr(10) +
   "ld hl,&c050" + VbX.Chr(13) + VbX.Chr(10) +
   "add hl,sp" + VbX.Chr(13) + VbX.Chr(10) +
   "ld sp,hl" + VbX.Chr(13) + VbX.Chr(10) +
   ";push hl" + VbX.Chr(13) + VbX.Chr(10) +
   "jp JumpToNextLineBC" + VbX.Chr(13) + VbX.Chr(10) +

   "JumpToNextLineBC: " + VbX.Chr(13) + VbX.Chr(10) +
   "LD L,C" + VbX.Chr(13) + VbX.Chr(10) +
   "LD H,B" + VbX.Chr(13) + VbX.Chr(10) +
   "JP (HL)" + VbX.Chr(13) + VbX.Chr(10)
   ;

           public static bool globals_UseLooper = false;
           public static string globals_LooperDef =
                   "LooperContinueAddress:defw LooperContinue" + VbX.Chr(13) + VbX.Chr(10) +
           "Looper:" + VbX.Chr(13) + VbX.Chr(10) +

           "ld b,ixh" + VbX.Chr(13) + VbX.Chr(10) +
           "ld c,ixl" + VbX.Chr(13) + VbX.Chr(10) +

           "LD a,(bc)" + VbX.Chr(13) + VbX.Chr(10) +
           "INC bc" + VbX.Chr(13) + VbX.Chr(10) +
           "ld (Looper_CountB_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "LD a,(bc)" + VbX.Chr(13) + VbX.Chr(10) +
           "INC bc" + VbX.Chr(13) + VbX.Chr(10) +
           "ld (Looper_CountSize_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "ld (RestoreLooperAddress_Plus2-2),bc" + VbX.Chr(13) + VbX.Chr(10) +

           "LooperNextStage:" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld hl,&0000 :RestoreLooperAddress_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld (Looper_Address_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +

           "	ld a,0:Looper_CountB_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld (Looper_Count_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +


           "	LooperRepeat:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld hl,&0000 :Looper_Address_Plus2" + VbX.Chr(13) + VbX.Chr(10) +

           "		LD c,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		INC hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		LD b,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		INC hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (Looper_Address_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld h,b" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld l,c" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld ix,LooperContinueAddress" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp (hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "   LooperContinue:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,0:Looper_Count_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (Looper_Count_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp nz,LooperRepeat" + VbX.Chr(13) + VbX.Chr(10) +


           "	ld a,0:Looper_CountSize_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "	dec a" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld (Looper_CountSize_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "jp nz,LooperNextStage" + VbX.Chr(13) + VbX.Chr(10) +

           "ld ix,(Looper_Address_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
           "LD L,(IX)" + VbX.Chr(13) + VbX.Chr(10) +
           "INC IX" + VbX.Chr(13) + VbX.Chr(10) +
           "LD H,(IX)" + VbX.Chr(13) + VbX.Chr(10) +
           "INC IX" + VbX.Chr(13) + VbX.Chr(10) +
           "JP (HL)" + VbX.Chr(13) + VbX.Chr(10);

           public static Boolean useRLE = false;
           public static string globals_RleDecoder =
                 "RLE_ImageWidth equ 38" + VbX.Chr(13) + VbX.Chr(10) +

               "RLE_Draw:" + VbX.Chr(13) + VbX.Chr(10) +
           "  		ld a,ixh" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (ImageWidthA_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (ImageWidthB_Plus2-2),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (ImageWidthC_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (ImageWidthD_Plus2-2),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (ImageWidthE_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		cpl" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (NegativeImageWidth_Plus2-2),a" + VbX.Chr(13) + VbX.Chr(10) +



           "		ld a,d" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_LastByteH_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,e" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_LastByteL_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +



           "	push hl" + VbX.Chr(13) + VbX.Chr(10) +

           //"		ld hl,&C000-1+20+RLE_ImageWidth" + VbX.Chr(13) + VbX.Chr(10) +
               //"		ld (RLE_ScrPos_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +

           "		ld a,IXL" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld h,&C0" + VbX.Chr(13) + VbX.Chr(10) +
           "		LD L,a" + VbX.Chr(13) + VbX.Chr(10) +

           "		ld a,b" + VbX.Chr(13) + VbX.Chr(10) +
               //"		ld hl,&C000-1+20+RLE_ImageWidth" + VbX.Chr(13) + VbX.Chr(10) +
           "				ld de,&FFFF :NegativeImageWidth_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "		or a" + VbX.Chr(13) + VbX.Chr(10) +

           "RLE_DrawGetNextLine:" + VbX.Chr(13) + VbX.Chr(10) +
           "		jr z,RLE_DrawGotLine" + VbX.Chr(13) + VbX.Chr(10) +
           "		call RLE_NextScreenLineHL" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec a" + VbX.Chr(13) + VbX.Chr(10) +
           "		jr RLE_DrawGetNextLine" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_DrawGotLine:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_ScrPos_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +





           "	;	xor a" + VbX.Chr(13) + VbX.Chr(10) +
           "				ld iyl,RLE_ImageWidth :ImageWidthA_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,255" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld e,a" + VbX.Chr(13) + VbX.Chr(10) +
           "		;ld (Nibble_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_MoreBytesLoop:" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld b,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	or a" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp z,RLE_OneByteData" + VbX.Chr(13) + VbX.Chr(10) +
           "	and %00001111" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp z,RLE_PlainBitmapData" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld ixh,0" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld ixl,a" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	;we're doing Nibble data, Expand the data into two pixels of Mode 1 and duplicate" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,b" + VbX.Chr(13) + VbX.Chr(10) +
           "	and %00110000" + VbX.Chr(13) + VbX.Chr(10) +
           "	rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "	rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,b" + VbX.Chr(13) + VbX.Chr(10) +
           "	and %11000000" + VbX.Chr(13) + VbX.Chr(10) +
           "	or c" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	rrca	;Remove these for Left->right" + VbX.Chr(13) + VbX.Chr(10) +
           "	rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "	or c" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,ixl" + VbX.Chr(13) + VbX.Chr(10) +
           "	cp 15" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp nz,RLE_NoMoreNibbleBytes" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_MoreNibbleBytes:" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld d,0" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld e,a" + VbX.Chr(13) + VbX.Chr(10) +
           "		add ix,de" + VbX.Chr(13) + VbX.Chr(10) +
           "		cp 255" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp z,RLE_MoreNibbleBytes" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_NoMoreNibbleBytes:" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,e" + VbX.Chr(13) + VbX.Chr(10) +
           "	or a" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp z,RLE_MoreBytesPart2Flip" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,ixl" + VbX.Chr(13) + VbX.Chr(10) +
           "	cp 4" + VbX.Chr(13) + VbX.Chr(10) +
           "	call nc,RLE_ByteNibbles" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	xor a" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld d,a ;byte for screen" + VbX.Chr(13) + VbX.Chr(10) +
           "	push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld hl,&C050 :RLE_ScrPos_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld b,iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_MoreBytes:" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,c" + VbX.Chr(13) + VbX.Chr(10) +
           "	and %00110011" + VbX.Chr(13) + VbX.Chr(10) +
           "	or d" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld d,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	dec ix" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,ixl" + VbX.Chr(13) + VbX.Chr(10) +
           "	or ixh" + VbX.Chr(13) + VbX.Chr(10) +
           "	jr z,RLE_LastByteFlip" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_MoreBytesPart2:" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,c" + VbX.Chr(13) + VbX.Chr(10) +
           "	and %11001100" + VbX.Chr(13) + VbX.Chr(10) +
           "	or d" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld d,a" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	dec ix" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (hl),d" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec b" + VbX.Chr(13) + VbX.Chr(10) +
           "		call z,RLE_NextScreenLineHL" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	xor a" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld d,a ;byte for screen" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,ixl" + VbX.Chr(13) + VbX.Chr(10) +
           "	or ixh" + VbX.Chr(13) + VbX.Chr(10) +
           "	jr nz,RLE_MoreBytes" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_LastByte:" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld iyl,b" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld (RLE_ScrPos_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           ";	ld iyl,b" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,&00:RLE_LastByteH_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "	cp h" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp nz,RLE_MoreBytesLoop" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,&00:RLE_LastByteL_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "	cp l" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp nz,RLE_MoreBytesLoop" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10);


           public static string globals_RLE_NextScreenLineHL =
                   "RLE_NextScreenLineHL:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "				ld b,RLE_ImageWidth :ImageWidthE_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,&800+RLE_ImageWidth :ImageWidthD_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret nc" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,&c050" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10);


           public static string globals_RleDecoder2 =
           "	exx 			;keep the firmware working!" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop bc" + VbX.Chr(13) + VbX.Chr(10) +
           "	exx" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_LastByteFlip:" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,e" + VbX.Chr(13) + VbX.Chr(10) +
           "	cpl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld e,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp RLE_LastByte" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_MoreBytesPart2Flip:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld b,iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld hl,(RLE_ScrPos_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,e" + VbX.Chr(13) + VbX.Chr(10) +
           "	cpl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld e,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp RLE_MoreBytesPart2" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_NextScreenLineHL:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "				ld b,RLE_ImageWidth :ImageWidthE_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,&800+RLE_ImageWidth :ImageWidthD_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret nc" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,&c050" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_NextScreenLine:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld iyl,RLE_ImageWidth :ImageWidthC_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld hl,&800+RLE_ImageWidth :ImageWidthB_Plus2" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "		ex hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret nc" + VbX.Chr(13) + VbX.Chr(10) +
           "	push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld hl,&c050" + VbX.Chr(13) + VbX.Chr(10) +
           "		add hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "		ex hl,de" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ret" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_PlainBitmapData:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "		rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "		rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "		rrca" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld b,0" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		cp 15" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp nz,RLE_PlainBitmapDataNoExtras" + VbX.Chr(13) + VbX.Chr(10) +
           "	;More than 14 bytes, load an extra byte into the count" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_PlainBitmapDataHasExtras:" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		or a" + VbX.Chr(13) + VbX.Chr(10) +
           "		jr z,RLE_PlainBitmapDataNoExtras	; no more bytes" + VbX.Chr(13) + VbX.Chr(10) +
           "		push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld h,0" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld l,a" + VbX.Chr(13) + VbX.Chr(10) +
           "			add hl,bc" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld b,h" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld c,l" + VbX.Chr(13) + VbX.Chr(10) +
           "		pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		cp 255" + VbX.Chr(13) + VbX.Chr(10) +
           "		jr z,RLE_PlainBitmapDataHasExtras" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_PlainBitmapDataNoExtras:" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,(RLE_ScrPos_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
           "		RLE_PlainBitmapData_More:" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (de),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec de" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "		call z,RLE_NextScreenLine" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec bc" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,b" + VbX.Chr(13) + VbX.Chr(10) +
           "		or c" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp nz,RLE_PlainBitmapData_More" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_ScrPos_Plus2-2),de" + VbX.Chr(13) + VbX.Chr(10) +
           ";ret" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp RLE_MoreBytesLoop" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_OneByteData:" + VbX.Chr(13) + VbX.Chr(10) +
           "	push de" + VbX.Chr(13) + VbX.Chr(10) +
           "		xor a " + VbX.Chr(13) + VbX.Chr(10) +
           "		ld b,a" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_OneByteDataExtras:" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		push hl" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld h,0" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld l,a" + VbX.Chr(13) + VbX.Chr(10) +
           "			add hl,bc" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld b,h" + VbX.Chr(13) + VbX.Chr(10) +
           "			ld c,l" + VbX.Chr(13) + VbX.Chr(10) +
           "		pop hl" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		cp 255" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp z,RLE_OneByteDataExtras" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		inc hl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,(hl)" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_ThisOneByte_Plus1-1),a" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld de,(RLE_ScrPos_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_OneByteData_More:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,00:RLE_ThisOneByte_Plus1" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (de),a" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec de" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "		call z,RLE_NextScreenLine" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec bc" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,b" + VbX.Chr(13) + VbX.Chr(10) +
           "		or c" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp nz,RLE_OneByteData_More" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (RLE_ScrPos_Plus2-2),de" + VbX.Chr(13) + VbX.Chr(10) +
           "		;ret" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	pop de" + VbX.Chr(13) + VbX.Chr(10) +
           "	jp RLE_MoreBytesLoop" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_ByteNibbles:" + VbX.Chr(13) + VbX.Chr(10) +
           "	di" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld a,c" + VbX.Chr(13) + VbX.Chr(10) +
           "	exx" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld b,iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld c,a" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld d,ixh" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld e,ixl" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld hl,(RLE_ScrPos_Plus2-2)" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_ByteNibblesMore3:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,3" + VbX.Chr(13) + VbX.Chr(10) +
           "RLE_ByteNibblesMore:" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld (hl),c" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec hl " + VbX.Chr(13) + VbX.Chr(10) +
           "		dec b;iyl" + VbX.Chr(13) + VbX.Chr(10) +
           "		call z,RLE_NextScreenLineHL" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec de" + VbX.Chr(13) + VbX.Chr(10) +
           "		dec de" + VbX.Chr(13) + VbX.Chr(10) +
           "		cp e" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp c,RLE_ByteNibblesMore" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "		ld a,d" + VbX.Chr(13) + VbX.Chr(10) +
           "		or a" + VbX.Chr(13) + VbX.Chr(10) +
           "		jp nz,RLE_ByteNibblesMore3" + VbX.Chr(13) + VbX.Chr(10) +
           "" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld (RLE_ScrPos_Plus2-2),hl" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld iyl,b" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld ixh,d" + VbX.Chr(13) + VbX.Chr(10) +
           "	ld ixl,e" + VbX.Chr(13) + VbX.Chr(10) +
           "	exx" + VbX.Chr(13) + VbX.Chr(10) +
           "";



           private void DoGlobalData(System.Drawing.Bitmap b2)
           {
               globals_globaldata = new StringBuilder();


               globals_globaldata.Append(nl + nl + nl + nl + nl + nl + ";Global Code");

               if (globals_useRLE == true) addrledecoder();
               else
               {
                   globals_globaldata.Append(nl + "RLE_ImageWidth equ 0" + nl);
                   globals_globaldata.Append(globals_RLE_NextScreenLineHL);
               }

               string EndCode = nl + "EndCode:" + nl;

               //EndCode += "LD BC,&7F00 ;Gate array port" + nl;
               //EndCode+="ld a,%10000001 ;Switch to ram config A (A < 7!)" + nl ;
               //EndCode+="OUT (C),A ;Send it" + nl ;
               //EndCode+="ld      hl,&0040" + nl ;
               //EndCode+="JumpFix:" + nl ;
               //EndCode+="dec     l" + nl ;
               //EndCode+="ld      a,(hl)			; get byte from rom" + nl ;
               //EndCode+="ld      (hl),a			; write byte to ram" + nl ;
               //EndCode+="jr      nz,JumpFix" + nl ;
               //EndCode+="ld a,%10001101 ;Switch to ram config A (A < 7!)" + nl ;
               //EndCode += "OUT (C),A ;Send it" + nl;
               if (cboEngine_Text.ToLower() == "akuyou")
               {
                   EndCode += "ld sp,(StackRestore_Plus2-2)";
               }
               else
               {
                   EndCode += "ld sp,&0000:StackRestore_Plus2";
               }
               EndCode += nl + "ei" + nl + "ret" + nl;

               globals_globaldata.Append(EndCode);

               for (int i = 40; i > 0; i--)
               {
                   if (globals_DePushUsed[i])
                   {
                       if (globals_MultiPushDeLast[i])
                       {
                           globals_globaldata.Append(nl + "MultiPushDeLast" + VbX.CStr(i) + ": ld HL,NextLine");
                           if (i >= 30)
                           {
                               globals_globaldata.Append(nl + "jp MultiPushDe" + VbX.CStr(i) + "B ");
                           }
                           else
                           {
                               globals_globaldata.Append(nl + "jr MultiPushDe" + VbX.CStr(i) + "B ");
                           }
                       }

                       globals_globaldata.Append(nl + "MultiPushDe" + VbX.CStr(i) + ": pop HL");
                       if (i >= 30)
                       {
                           globals_globaldata.Append(nl + "jp MultiPushDe" + VbX.CStr(i) + "B ");
                       }
                       else
                       {
                           globals_globaldata.Append(nl + "jr MultiPushDe" + VbX.CStr(i) + "B ");
                       }



                   }
               }
               for (int i = 40; i > 0; i--)
               {
                   if (i <= globals_MaxDePush)
                   {
                       globals_globaldata.Append(nl + "MultiPushDe" + VbX.CStr(i) + "B: Push DE");
                   }
               }
               globals_globaldata.Append(nl + "jp (hl)" + nl);
               for (int i = 40; i > 20; i--)
               {
                   if (globals_BitmapDataUsed[i * 2])
                   {
                       globals_globaldata.Append(nl + "BitmapPush" + VbX.CStr(i * 2) + ": " + "ld b,&" + VbX.Right("00" + (i * 2).ToString("X"), 2));
                       globals_globaldata.Append(nl + "jr BitmapPush" + nl);
                   }
               }
               globals_globaldata.Append(nl + "BitmapPush:" + nl);
               globals_globaldata.Append("ld (BitmapPushDeRestore_Plus2-2),de" + nl);
               globals_globaldata.Append("pop iy" + nl);
               globals_globaldata.Append("ld l,(iy)" + nl);
               globals_globaldata.Append("inc iy" + nl);
               globals_globaldata.Append("ld h,(iy)" + nl);
               globals_globaldata.Append("inc iy" + nl);


               globals_globaldata.Append("BitmapPushRepeat:" + nl);
               globals_globaldata.Append("ld d,(hl)" + nl);
               globals_globaldata.Append("dec hl" + nl);
               globals_globaldata.Append("ld e,(hl)" + nl);
               globals_globaldata.Append("dec hl" + nl);
               globals_globaldata.Append("push de" + nl);
               globals_globaldata.Append("djnz BitmapPushRepeat" + nl);
               globals_globaldata.Append(nl + "ld de,&0000 :BitmapPushDeRestore_Plus2" + nl);
               globals_globaldata.Append(nl + "jp (iy)" + nl);


               for (int i = 20; i > 0; i--)
               {
                   if (globals_BitmapDataUsed[i * 2])
                   {
                       globals_globaldata.Append(nl + "BitmapPush" + VbX.CStr(i * 2) + ": " + "ld b,&" + VbX.Right("00" + (i).ToString("X"), 2));
                       globals_globaldata.Append(nl + "jr BitmapPush");
                   }
               }
               globals_globaldata.Append(nl);


               for (int i = 40; i > 0; i--)
               {
                   if (globals_BitmapDataLastUsed[i])
                   {
                       globals_globaldata.Append(nl + "finalBitmapPush" + VbX.CStr(i) + ": " + "ld b,&" + VbX.Right("00" + (i / 2).ToString("X"), 2));
                       globals_globaldata.Append(nl + "jr finalBitmapPush" + nl);
                   }
               }


               globals_globaldata.Append("finalBitmapPush:" + nl);
               globals_globaldata.Append("ld (BitmapPushDeRestore_Plus2-2),de" + nl);
               globals_globaldata.Append("pop iy" + nl);
               globals_globaldata.Append("ld l,(iy)" + nl);
               globals_globaldata.Append("inc iy" + nl);
               globals_globaldata.Append("ld h,(iy)" + nl);
               globals_globaldata.Append("inc iy" + nl);

               globals_globaldata.Append("ld iy,nextline" + nl);
               globals_globaldata.Append("jp BitmapPushRepeat" + nl);




               for (int i = 4; i >= 1; i--)
               {
                   globals_globaldata.Append("NextLinePushDe" + VbX.CStr(i) + ": push de" + nl);
               }

               if (cboEngine_Text.ToLower() == "akuyou")
               {
                   globals_globaldata.Append(nl);
                   if (VbX.CInt(cboLineGroups_Text) > 1)
                   {

                       globals_globaldata.Append(globals_AkuyouNextLineBC + nl);
                   }
                   else
                   {


                   }
                   globals_globaldata.Append(globals_AkuyouNextLine + nl);
               }
               else
               {

                   if (VbX.CInt(cboLineGroups_Text) > 1)
                   {

                       globals_globaldata.Append(nl + "NextLineBC: " + nl);
                       globals_globaldata.Append("ld hl,&0850" + nl + "add hl,sp" + nl + "ld sp,hl" + nl);
                       globals_globaldata.Append("jp nc,JumpToNextLineBC" + nl);
                       globals_globaldata.Append("ld hl,&c050" + nl + "add hl,sp" + nl + "ld sp,hl" + nl);
                       globals_globaldata.Append("JumpToNextLineBC:ld h,b" + nl + "ld l,c" + nl + "jp (hl)" + nl);
                   }

                   if (cboNextLine_Text.ToLower() == "fast")
                   {
                       globals_globaldata.Append(nl + "NextLineFirst: " + nl);
                       globals_globaldata.Append("ld hl,&0850" + nl + "add hl,sp" + nl + "ld sp,hl" + nl);

                       globals_globaldata.Append("JP JumpToNextLine" + nl);

                       globals_globaldata.Append(nl + "NextLineSecond: " + nl);
                       globals_globaldata.Append("ld hl,&C8A0" + nl + "add hl,sp" + nl + "ld sp,hl" + nl);
                   }
                   else
                   {
                       globals_globaldata.Append(nl + "NextLine: " + nl);
                       globals_globaldata.Append("ld hl,&0800+" + VbX.CStr(b2.Width / 4) + nl + "add hl,sp" + nl + "ld sp,hl" + nl);
                       globals_globaldata.Append("jp nc,JumpToNextLine" + nl);
                       globals_globaldata.Append("ld hl,&c050" + nl + "add hl,sp" + nl + "ld sp,hl" + nl);

                   }
                   globals_globaldata.Append(nl + "JumpToNextLine: " + nl);
                   globals_globaldata.Append("LD L,(IX)" + nl);
                   globals_globaldata.Append("INC IX" + nl);
                   globals_globaldata.Append("LD H,(IX)" + nl);
                   globals_globaldata.Append("INC IX" + nl);
                   globals_globaldata.Append("JP (HL)" + nl);

               }

               globals_globaldata.Append("NextLinePushHl: Push HL" + nl);
               globals_globaldata.Append("jr NextLine" + nl);
               globals_globaldata.Append("NextLinePushBC: Push BC" + nl);
               globals_globaldata.Append("jr NextLine" + nl);

               globals_globaldata.Append("NextLineSPshift:add hl,sp" + nl);
               globals_globaldata.Append("ld sp,hl" + nl);
               globals_globaldata.Append("jr NextLine" + nl);
               globals_globaldata.Append("NextLineDecSP8:dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("NextLineDecSP4:dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("dec sp" + nl);
               globals_globaldata.Append("jr NextLine" + nl);

               if (VbX.CInt(cboLineGroups_Text) > 1)
               {


               }
               else
               {
                   globals_globaldata.Append(globals_AkuyouNextLineBCdisable + nl);

               }

               if (globals_UseLooper)
               {
                   globals_globaldata.Append(globals_LooperDef + nl);
               }


               globals_globaldata.Append(nl + "BitmapData: " + nl);

               for (int i = 0; i <= globals_BitmapData.Length / 30; i++)
               {

                   for (int a = 0; a < 10; a++)
                   {
                       if ((i * 30 + a * 3) < globals_BitmapData.Length)
                       {
                           if (a > 0) globals_globaldata.Append(","); else globals_globaldata.Append(nl + "defb "); ;
                           globals_globaldata.Append("&" + globals_BitmapData.Substring(i * 30 + a * 3, 3).Replace(",", ""));
                       }
                   }
               }

               globals_globaldata.Append("" + nl);
               globals_globaldata.Append("DoubleByteDE:" + nl);

               globals_globaldata.Append("pop iy" + nl);
               globals_globaldata.Append("ld a,(iy)" + nl);
               globals_globaldata.Append("inc iy" + nl);
               globals_globaldata.Append("ld d,a" + nl);
               globals_globaldata.Append("ld e,a" + nl);
               globals_globaldata.Append("push de" + nl);
               globals_globaldata.Append("push de" + nl);
               globals_globaldata.Append("jp(iy)" + nl);
               globals_globaldata.Append("" + nl);
               globals_globaldata.Append("PushDE_0000x:" + nl);
               globals_globaldata.Append("Ld DE,&0000" + nl);
               globals_globaldata.Append("jr PushDE_Multi" + nl);

               globals_globaldata.Append("PushDE_F0F0x:" + nl);
               globals_globaldata.Append("Ld DE,&F0F0" + nl);
               globals_globaldata.Append("jr PushDE_Multi" + nl);

               globals_globaldata.Append("PushDE_0F0Fx:" + nl);
               globals_globaldata.Append("Ld DE,&0F0F" + nl);
               globals_globaldata.Append("jr PushDE_Multi" + nl);


               globals_globaldata.Append("PushDE_FFFFx:" + nl);
               globals_globaldata.Append("Ld DE,&FFFF" + nl);
               globals_globaldata.Append("PushDE_Multi" + nl);
               globals_globaldata.Append("pop hl" + nl);
               for (int i = 1; i <= VbX.CInt(txtDeCompression_Text); i++)
               {
                   globals_globaldata.Append("push DE" + nl);
               }
               //st.Append("push DE" + nl);
               globals_globaldata.Append("jp (hl)" + nl);

               globals_globaldata.Append(nl);
               for (int i = 0; i < globals_PairCache_Count; i++)
               {

                   globals_globaldata.Append(globals_PairCache_Data[i]);
               }


               if (globals_DoRawBmp)
               {
                   globals_globaldata.Append("DrawRawBmp:" + nl);
                   globals_globaldata.Append("RawBmpRepeatNextLine:" + nl);
                   globals_globaldata.Append("ld c,b" + nl);
                   globals_globaldata.Append("ld b,IXL" + nl);
                   globals_globaldata.Append("RawBmpRepeat:" + nl);
                   globals_globaldata.Append("pop de" + nl);
                   globals_globaldata.Append("ld (hl),d" + nl);
                   globals_globaldata.Append("dec hl" + nl);
                   globals_globaldata.Append("ld (hl),e" + nl);
                   globals_globaldata.Append("dec hl" + nl);

                   globals_globaldata.Append("djnz RawBmpRepeat" + nl);

                   globals_globaldata.Append("ld de,&0800+" + VbX.CStr(b2.Width / 4) + nl);
                   globals_globaldata.Append("add hl,de" + nl);
                   globals_globaldata.Append("jp nc,JumpToNextLineRawBmp" + nl);
                   globals_globaldata.Append("ld de,&c050" + nl);
                   globals_globaldata.Append("add hl,de" + nl);
                   globals_globaldata.Append("JumpToNextLineRawBmp:" + nl);
                   globals_globaldata.Append("ld b,c" + nl);

                   globals_globaldata.Append("djnz RawBmpRepeatNextLine" + nl);

                   globals_globaldata.Append("ld sp,&0000:StackRestore_PlusRawBmp2" + nl);
                   globals_globaldata.Append("ei" + nl);
                   globals_globaldata.Append("ret" + nl);

               }



               textBox1_Text = globals_initdata + nl + globals_imagedata.ToString() + nl + globals_globaldata.ToString();


           }

           Color getcolor(int i)
           {
               switch (i)
               {
                   case 0:
                       return Color0_BackColor;

                   case 1:
                       return Color1_BackColor;
                   case 2:
                       return Color2_BackColor;
                   case 3:
                       return Color3_BackColor;
               }
               return ColorA_BackColor;


           }


           private void addrledecoder()
           {
               globals_globaldata.Append(nl + globals_RleDecoder + nl);

               if (cboEngine_Text.ToLower() == "akuyou" || cboEngine_Text.ToLower() == "akuyouc000")
               {
                   globals_globaldata.Append("ei" + VbX.Chr(13) + VbX.Chr(10));
               }
               globals_globaldata.Append(nl + globals_RleDecoder2 + nl);

               if (cboEngine_Text.ToLower() == "akuyou" || cboEngine_Text.ToLower() == "akuyouc000")
               {
                   globals_globaldata.Append("ei" + VbX.Chr(13) + VbX.Chr(10));
               }
               globals_globaldata.Append("ret" + VbX.Chr(13) + VbX.Chr(10));

           }

           public void Doreset()
           {

               globals_PicNumber = 0;
               txtColorConv_Text = "";
               txtypos_text = "0";
               txtxpos_text = "0";
               txtBank_Text = "0";
               globals_useRLE = false;
               globals_DoRawBmp = false;
               globals_RegBC = "";
               globals_RegDE = "";
               globals_RegHL = "";
               globals_DEUsed = 0;
               globals_LastDE = "";
               globals_LastHL = "";
               globals_ChunkDeBak = "";
               globals_BitmapData = "";
               for (int i = 0; i < globals_ChunkCache; i++)
               {
                   globals_ChunkCache_Name[i] = "";
                   globals_ChunkCache_Data[i] = "";
                   globals_ChunkCache_DE[i] = "";
                   globals_ChunkCache_Reused[i] = 0;
               }
               globals_ChunkCache = 0;
               globals_GlobalsDone = 0;
               if (cboEngine_Text.ToLower() == "akuyou")
               {
                   globals_initdata = globals_AkuyouInit + "org " + txtOrg_Text + VbX.Chr(13) + VbX.Chr(10);

               }
               else
               {
                   globals_initdata = "org " + txtOrg_Text + VbX.Chr(13) + VbX.Chr(10) + VbX.Chr(13) + VbX.Chr(10) + "nolist" + VbX.Chr(13) + VbX.Chr(10);
               }
               globals_initdata += "FirstByte:" + nl;

               if (chkRst6_Checked)
               {
                   globals_initdata += "LD hl,&D5E1" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0030),hl" + VbX.Chr(13) + VbX.Chr(10) + "LD hl,&D5D5" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0032),hl" + VbX.Chr(13) + VbX.Chr(10) + "LD hl,&D5E9" + VbX.Chr(13) + VbX.Chr(10) + "ld (&0034),hl" + VbX.Chr(13) + VbX.Chr(10);
               }

               if (chkRst0_Checked)
               {
                   globals_initdata += "ld hl,&0000" + nl + "ld (hl),&C3" + nl + "inc hl" + nl + "ld (hl),DoubleByteDE" + nl;
               }



               globals_imagedata = new System.Text.StringBuilder();
               globals_globaldata = new System.Text.StringBuilder();
               globals_PairCache_Count = 0;
               globals_MaxDePush = 5;
               for (int i = 0; i <= 40; i++)
               {
                   globals_BitmapPushLastUsed[i] = false;
                   globals_DePushUsed[i] = false;
                   globals_MultiPushDeLast[i] = false;

               }
               for (int i = 0; i <= 80; i++)
               {
                   globals_BitmapDataUsed[i] = false;
               }
               clearPrevioushistory();
               /*
               for (int x = 0; x < 320; x++)
               {
                   for (int y = 0; y < 200; y++)
                   {
                       globals_LastPixelMap[x, y] = 99;
                       globals_PixelMap[x, y] = 4;
                   }
               }
                */

           }
           public static string globals_AkuyouInit =
               "read \"..\\CoreDefs.asm\" ;read \"BootStrap.asm\"" + VbX.Chr(13) + VbX.Chr(10);
           public  void clearPrevioushistory()
           {

               for (int x = 0; x < 320; x++)
               {
                   for (int y = 0; y < 200; y++)
                   {
                       globals_LastPixelMap[x, y] = 99;
                       globals_PixelMap[x, y] = 4;
                   }
               }
           }
    }
 
}
