using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkuSpriteEditor
{
    class RLEBinaryZX
    {
        public Int16[,] spritepixel;
        public int height;
        public int width;

        public byte[] RleData = new byte[65536];
        public int RleDataPos = 0;

        public void NewRLE()
        {
            
            //string Filename = DoFilename(txtFilename.Text);//"Pic" + ss.GetItem(txtFilename.Text, "\\", ss.CountItems(txtFilename.Text, "\\")).Replace(".", "");

            //            addheader();

            //          globals.PicNumber += 3 ;


            string lastnibble = "";
            string Randombytes = "";
            int nibblecount = 1;


            int FirstY =height; // intentionally backwards!
            int LastY = 0;
           
                LastY = height; // intentionally backwards!
                FirstY = 0;
            //}




            int CurrentMode = 0; //1=nibble . 2=byte 3=repeatingbytes
            int lineitem = 0;
            String RepeatingBytes = "";

            for (int y = FirstY; y < LastY; y++)
            {


                for (int x = width - 16; x >= 0; x -= 16)
                {
                    string thispair = GetPair(y, x);

                    for (int by = 0; by < 2; by++)
                    {
                        string ThisByte = "";
                        switch (by)
                        {
                            case 0:
                                ThisByte = thispair.Substring(0, 2);
                                break;
                            case 1:
                                ThisByte = thispair.Substring(2, 2);
                                break;
                        }


                        string nibble = "";
                        for (int n = 0; n < 2; n++)
                        {
                            switch (n)
                            {
                                case 1:
                                     //nibble = VbX.BinAnd(VbX.HexToBin(ThisByte), "11001100");
                                     //nibble = nibble.Substring(0, 2) + nibble.Substring(4, 2);

                                    nibble = VbX.BinAnd(VbX.HexToBin(ThisByte), "11110000");
                                    nibble = nibble.Substring(0, 4);

                                    break;
                                case 0:
                                    //nibble = VbX.BinAnd(VbX.HexToBin(ThisByte), "00110011");
                                    //nibble = nibble.Substring(2 + 0, 2) + nibble.Substring(2 + 4, 2);

                                    nibble = VbX.BinAnd(VbX.HexToBin(ThisByte), "00001111");
                                    nibble = nibble.Substring(4, 4);

                                    break;
                            }

                            if (nibble == lastnibble)
                            {
                                nibblecount++;
                                CurrentMode = 1;
                            }
                            else if (lastnibble == "")
                            {
                                lastnibble = nibble;
                                nibblecount = 1;
                            }
                            else
                            {
                                if (nibblecount > 1)
                                {
                                    if (Randombytes.Length > 1)
                                    {
                                        if (Randombytes.Length == 4)
                                        {
                                            donibblebatch(Randombytes, 1);
                                            donibblebatch(lastnibble, nibblecount);
                                            lastnibble = "";
                                        }
                                        else
                                        {
                                            dobytebatchWithRepeater(Randombytes);
                                            donibblebatch(lastnibble, nibblecount);
                                        }
                                        Randombytes = "";
                                    }
                                    else
                                    {
                                        {
                                            donibblebatch(lastnibble, nibblecount);
                                        }
                                    }
                                }
                                else
                                {
                                    if (VbX.Len(Randombytes) == 4 && n == 1)  //
                                    {
                                        //finish the last byte
                                        donibblebatch(Randombytes, nibblecount);
                                        nibblecount = 0;
                                        Randombytes = lastnibble;
                                        CurrentMode = 2;
                                    }
                                    else
                                    {
                                        Randombytes = Randombytes + lastnibble;
                                        CurrentMode = 2;
                                        nibblecount = 0;
                                    }
                                }
                                nibblecount = 1;
                                lastnibble = nibble;
                            }
                        }
                    }
                }

            }
            dobytebatchWithRepeater(Randombytes);
            donibblebatch(lastnibble, nibblecount);






            /*
            FirstY = FirstY + VbX.CInt(txtYpos.Text);

            globals.imagedata.Append(Filename + ":" + nl);
            globals.imagedata.Append("ld hl," + Filename + "_rledata-1" + nl);
            globals.imagedata.Append("ld de," + Filename + "_rledataEnd-1" + nl);
            globals.imagedata.Append("ld b," + FirstY.ToString() + nl);
            int thiswidth = b.Width / 4;
            globals.imagedata.Append("ld ixh," + thiswidth.ToString() + nl);


            thiswidth = VbX.CInt(txtXpos.Text) + thiswidth - 1;
            
            globals.imagedata.Append("ld IXL," + thiswidth.ToString() + nl);

            globals.imagedata.Append("di" + nl);
            globals.imagedata.Append("exx " + nl);
            globals.imagedata.Append("push bc" + nl);
            globals.imagedata.Append("exx" + nl);
            globals.imagedata.Append("jp RLE_Draw" + nl);
            globals.imagedata.Append(Filename + "_rledata:" + nl);
            globals.imagedata.Append(Chunk.ToString() + nl);
            globals.imagedata.Append(Filename + "_rledataEnd: defb 0" + nl);
            textBox1.Text = globals.initdata + nl + globals.imagedata.ToString() + nl + globals.globaldata.ToString();
             */
        }



        /*
         
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
                    int dot = spritepixel[tx, y];
                    if (dot > 15)
                    {
                        transpcount++;
                        dot = 0;
                    }
                    else if (dot > 3) {
                        dot = 3;
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
         */

        private string GetPair(int y, int x)
        {
            int transpcount = 0;
            if (x < 0) return "Bad!";
            string thispair = "";
            for (int pair = 0; pair < 2; pair++)
            {
                int thisbyte = 0;
                for (int bit = 0; bit < 8; bit++)
                {

                    int tx = x + (7 - bit) + (pair * 8);

                    int dot = spritepixel[tx, y];
                    
                    if (dot > 15)
                    {
                        transpcount++;
                        dot = 0;
                    }
                    else if (dot > 1) {
                        dot = 1;
                    }
                    string binary = VbX.Right("00" + Convert.ToString(dot, 2), 1);
                    string Binary2 = binary;//binary.Substring(1, 1) + "000" + binary.Substring(0, 1);

                    thisbyte = thisbyte + (Convert.ToInt32(Binary2, 2) << bit);
                    // if (dot == 3) VbX.MsgBox(Binary2 + "   " + bit.ToString() + "  " + thisbyte.ToString());
                }
                thispair = VbX.Right("00" + thisbyte.ToString("X"), 2) + thispair;
            }
            if (transpcount == 16) { return "ZZZZ"; }

            return thispair;

        }
        void dobytebatchWithRepeater(string bitdata)//, StringBuilder Chunk)
        {

            string LastByte = "";
            string ThisChunk = "";
            int ThisChunkCount = 0;
            int mode = 0; //1=different 2=same
            for (int i = 0; i < bitdata.Length; i += 8)
            {
                string thisbyte = (bitdata + "    ").Substring(i, 8);
                if (LastByte == thisbyte)
                {
                    if (mode == 1)
                    {
                        // current bytes are not matching
                        dobytebatch(ThisChunk.Substring(0, ThisChunk.Length - 8));
                        ThisChunk = ThisChunk.Substring(ThisChunk.Length - 8, 8);
                    }
                    mode = 2;
                }
                if (LastByte != thisbyte && LastByte != "")
                {
                    if (mode == 2)
                    {
                        // Matching bytes
                        doOnebytebatch(ThisChunk);
                        ThisChunk = "";
                    }
                    mode = 1;
                }
                LastByte = thisbyte;
                ThisChunk += thisbyte;
                ThisChunkCount++;
            }
            if (mode == 1)
            {
                dobytebatch(ThisChunk);
            }
            else
            {
                doOnebytebatch(ThisChunk);
            }
        }

        void doOnebytebatch(string bitdata)//, StringBuilder Chunk)
        {
            bitdata = bitdata.Trim();
            if (bitdata.Length == 0) return;
            int lng = bitdata.Length / 8;
            if (lng < 3)
            {
                // this code needs at least 3 bytes!
                dobytebatch(bitdata);
                return;
            }
            // Chunk.Append(nl + "defb &00,");          //Double Zero nibble is the marker for a repating byte batch
            addbytetodata(0);
            while (lng >= 0)
            {

                int pp2 = lng;
                if (pp2 > 255) pp2 = 255;
                // Chunk.Append((pp2).ToString("x"));
                addbytetodata(pp2);
                lng -= 255;
            }
            addbytetodata(VbX.BinToHex(unnibble(bitdata.Substring(0, 8))));

        }
        void addbytetodata(byte b) {
            RleData[RleDataPos] = b;
            RleDataPos++;
        }
        void addbytetodata(int b)
        {
            if (b > 255)
            {
                VbX.MsgBox("Int too high!" + b);
            }
            RleData[RleDataPos] = (byte)b;
            RleDataPos++;
        }
        void addbytetodata(string b)
        {
            if (b.Length > 2) {
                VbX.MsgBox("Chunk too long!" + b);
            }
            RleData[RleDataPos] = (byte)VbX.HexToInt(b);
            RleDataPos++;
        }

        void donibblebatch(string nibblename, int nibblecount)//, StringBuilder Chunk)
        {

            int lineitem = 0;
            //while (nibblecount > 0)
            // {
            //if (lineitem > 0)
            //{ Chunk.Append(","); }
            //else
            //{ Chunk.Append(nl + "defb "); }

            int nc = nibblecount;
            if (nibblecount > 15) nc = 15;
            //nibblecount -= nc;
            string ct = VbX.IntToBin(nc).Substring(4, 4);
            addbytetodata(VbX.BinToHex(nibblename + ct));
            nibblecount -= 15;
            while (nibblecount >= 0)
            {

                int pp2 = nibblecount;
                if (pp2 > 255) pp2 = 255;
                //Chunk.Append(",&" + (pp2).ToString("x"));
                addbytetodata(pp2);
                nibblecount -= 255;
            }

            lineitem++;
            //    }

        }

        string unnibble(string nibbled)
        {
            return nibbled.Substring(4, 4) + nibbled.Substring(0, 4);
            //VbX.MsgBox(nibbled);
            //return nibbled.Substring(0 + 4, 2) + nibbled.Substring(4 - 4, 2) + nibbled.Substring(2 + 4, 2) + nibbled.Substring(6 - 4, 2);
            //return nibbled.Substring(0, 2) + nibbled.Substring(4, 2) + nibbled.Substring(2, 2) + nibbled.Substring(6, 2);
            // nibble=globals.BinAnd(globals.HexToBin(ThisByte),"11001100");
            // nibble = nibble.Substring(0, 2) + nibble.Substring(4, 2);
            // nibble = globals.BinAnd(globals.HexToBin(ThisByte), "00110011");
            // nibble = nibble.Substring(2 + 0, 2) + nibble.Substring(2 + 4, 2);


        }

        void dobytebatch(string bitdata)//, StringBuilder Chunk)
        {
            bitdata = bitdata.Trim();
            if (bitdata.Length == 0) return;
            int lng = bitdata.Length / 8;
            int partnum = 0;
            for (int i = 0; i < bitdata.Length; i += 8)
            {
                //;
                string part = VbX.Mid(bitdata + "    ", i + 1, 8).Trim();

                if (part.Length == 8)
                {
                    //if (i > 0)
                    //{
                        //Chunk.Append(",");

                    //}
                    //else
                    //{
                        //Chunk.Append(nl + "defb ");

                    //}
                    // if (partnum == 14) partnum = 0;
                    if (partnum == 0)
                    {
                        int pp = (lng - (i / 8));
                        if (pp > 15) pp = 15;
                        //Chunk.Append("&" + (16 * pp).ToString("x") + ",");
                        addbytetodata((16 * pp));
                        if (pp == 15)
                        {
                            pp = (lng - (i / 8));
                            pp -= 15;
                            while (pp >= 0)
                            {

                                int pp2 = pp;
                                if (pp2 > 255) pp2 = 255;
                                //Chunk.Append("&" + (pp2).ToString("x") + ",");
                                addbytetodata(pp2);
                                pp -= 255;
                            }
                        }

                    }
                    partnum = partnum + 1;

                    addbytetodata(VbX.BinToHex(unnibble(part)));
                    // VbX.MsgBox("&" + globals.BinToHex(part));
                    // donibblebatch(part, 1, Chunk);
                }
                else
                {
                    //Chunk.Append(nl);
                    donibblebatch(part, 1);
                }
            }


        }
    }
}
