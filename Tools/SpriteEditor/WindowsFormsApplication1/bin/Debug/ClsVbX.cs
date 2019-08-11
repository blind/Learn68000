using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

    //Fake Visual Basic eXtensions
   public static class VbX
    {
       // objects we need to do the work
       private static Random VbXrnd= new Random();
       public static string nz(string nz) { if (nz == null) return ""; return nz; }
       public static void PopFormTime(String title, String promptText,int timer) {

           TextBox t = null;
           Form form = PopForm(title, promptText, "nobuttons",ref t);
           double op = form.Opacity;
           form.Opacity = 0;
           form.Show();
           //Application.DoEvents();
           
           System.Threading.Thread.Sleep(timer-400);
           
           form.Close();

       }
       public static bool exists(string lin)
       {

           return System.IO.File.Exists(lin);
       }
       public static string NoCaseReplace(string haystack,string needle1,string needle2) { 
           // case insensitive replace - result is same case as before, but needle1 matches anything
           haystack=haystack.Replace(needle1, needle2); // try a basic replace first
           int pos=0;
           do
           {
               pos = InStr(haystack.ToLower(), needle1.ToLower());
               if (pos>0) haystack = Left(haystack, pos - 1) + needle2 + Mid(haystack,pos + needle1.Length, haystack.Length - (pos + needle1.Length-1));
               
           } while (pos > 0);
           return haystack;
       }

       public static Form PopForm(String title, String promptText, String value,ref TextBox t) {
           Form form = new Form();
           Label label = new Label();

           if (t == null) t = new TextBox();
           TextBox textBox = t;

           Button buttonOk = new Button();
           Button buttonCancel = new Button();

           form.Text = title;
           label.Text = promptText;
           textBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           label.Font = textBox.Font;
           textBox.Text = value;

           if ((textBox.Text.ToLower()) == "null" || textBox.Text.ToLower() == "okonly" || (textBox.Text.ToLower()) == "nobuttons") textBox.Visible = false;

           buttonOk.Font = textBox.Font;
           buttonCancel.Font = textBox.Font;
           buttonOk.Text = "OK";
           buttonCancel.Text = "Cancel";

           if ((textBox.Text.ToLower()) == "yes/no")
           {
               textBox.Visible = false; buttonOk.Text = "Yes";
               buttonCancel.Text = "No";
           }

           buttonOk.DialogResult = DialogResult.OK;
           buttonCancel.DialogResult = DialogResult.Cancel;

           label.SetBounds(9, 15, 372, 13);
           textBox.SetBounds(12, 40, 372, 20);
           buttonOk.SetBounds(55, 60, 150, 60);
           buttonCancel.SetBounds(400 - (150 + 55), 60, 150, 60);

           label.AutoSize = true;
           textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
           if (value == "okonly")
           {
               buttonOk.SetBounds(115, 60, 150, 60);
               buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
           }
           else
           {
               buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
           }
           buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

           form.ClientSize = new System.Drawing.Size(400, 130);
           form.Controls.AddRange(new Control[] { label, textBox });

           if (value == "okonly")
           {
               form.Controls.AddRange(new Control[] { buttonOk });
           }  else if (value != "nobuttons")
           {
               form.Controls.AddRange(new Control[] { buttonOk, buttonCancel });
           }

           
           form.ClientSize = new System.Drawing.Size(Math.Max(450, label.Right + 10), label.Height + 130);
           form.FormBorderStyle = FormBorderStyle.FixedDialog;
           form.StartPosition = FormStartPosition.CenterScreen;
           form.MinimizeBox = false;
           form.MaximizeBox = false;
           form.AcceptButton = buttonOk;
           form.CancelButton = buttonCancel;
           
           return form;
       }
       public static int Bin2Dec(string bin) {
           return Convert.ToInt32(bin, 2);
       }
       public static String Dec2Bin8Bit(int dec) {
           return Right("00000000"+Convert.ToString(dec, 2),8);
       }
       public static String Hex(int dec)
       {
           return dec.ToString("X"); 
       }
       public static String InputBox(String title,String promptText, String value) {

           TextBox textBox = new TextBox();
           Form form = PopForm(title, promptText, value,ref textBox);
           DialogResult dialogResult = form.ShowDialog();
           if ((textBox.Text.ToLower()) == "yes/no") {
               
               if (dialogResult == DialogResult.OK) return "*yes*";
               return "*no*";
           }
           
           return textBox.Text;
       }

       // Functions and subs which fake VB.Net functionality
       public static String ChrW(int lin) { 
           if (lin<=0) return "";
           
           return Char.ConvertFromUtf32(lin); }
       //public static void Beep() { Console.Beep(); }
       public static int AscW(String lin) {
          // try
          // {
           if (lin.Length==0) return 0;
           Char[] ss           = lin.Substring(0, 1).ToCharArray();

               return ((int)ss[0]);
           //}
          // catch (Exception ex) { }
           //return 0;
       }
       public static void Randomize() { VbXrnd = new Random(); }
        public static string Chr(int num) { char ch = (char)(num); return ch.ToString(); }
        public static int Len(String Lin) { return Lin.Length; }
        public static string Mid(String Lin, int Start, int len) { 
            if (Lin=="") return "";
            if (len < 1) return ""; else return Lin.Substring(Start - 1, len); }
        public static string Right(String Lin, int len) {
            if (len <= 0) return "";
            if (string.IsNullOrEmpty(Lin)) return "";
            if (Lin.Length <= len) return Lin; else return Lin.Substring(Lin.Length - len); 
        }
        public static int InStr(String Lin, String Lin2) { return Lin.IndexOf(Lin2)+1; }
        public static string Replace(String lin, String Lin2, String Lin3) {
            if (string.IsNullOrEmpty(lin)) return "";
            if (lin.Length > 0 && Lin2.Length>0) return lin.Replace(Lin2, Lin3); else return ""; }
        public static bool StringGT(String lin1, String lin2) {
            // is string1 > String2 ?
            int minlen = lin1.Length;
            if (lin2.Length < minlen) minlen = lin2.Length;

            for (int i=0;i<minlen;i++){
                if (AscW(lin1.Substring(i, 1)) > AscW(lin2.Substring(i, 1))) return true;
                if (AscW(lin1.Substring(i, 1)) < AscW(lin2.Substring(i, 1))) return false;
            }
            if (lin1.Length<lin2.Length) return true;
            return false;
        }
        public static string SafeSub(string lin, int from, int len) {
            if (len<=0) return "";      // no length
            if (lin.Length==0) return ""; // no source string
            if (from>=lin.Length) return ""; // startpoint after end of string 
            if (from <0) return ""; // before end of string 
            if (from + len > lin.Length) len = lin.Length - from;
            return lin.Substring(from, len);
        }
        public static string Left(this string value, int maxLength)
        {
            if (maxLength <= 0) return "";
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }
        //public static String Environ(String lin) { return System.Environment.GetEnvironmentVariable(lin); }
        public static String CurDir() {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        public static char[] CChar(string lin) { return lin.ToCharArray(); }
        public static string LCase(string lin) { return lin.ToLower(); }
        public static string Trim(string lin) { return lin.Trim(); }

       // this is an incomplete version - Dir should allow a folder to be listed item by item, but this does not.
        public static String Dir(string lin) {

            String file = System.IO.Path.GetFileName(lin);
            String path = System.IO.Path.GetDirectoryName(lin);
            string[] files = System.IO.Directory.GetFiles(path, file, System.IO.SearchOption.TopDirectoryOnly);
            if (files.Length > 0)
            {
                return lin;
            } else {
                return "";
            }


            //if (lnx.exists(lin)) return lin; else return ""; 
        }

       
        public static void Kill(String lin) { System.IO.File.Delete(lin); }
        public static void Rename(String File1,String File2) { System.IO.File.Move(File1,File2); }
        public static void doMessageBox(String lin) { System.Diagnostics.Debug.Write(lin); }
        public static void MsgBox(String lin) {

            InputBox("?", lin, "okonly");

            // System.Diagnostics.Debug.Write(lin);
        
        }
        //public static String Format(object obj, String lin) {return String.Format(lin, obj); }
        public static bool CBool(string lin) { if (lin.Trim() == "1" || lin.Trim().ToLower() == "true") return true; else return false; }
        public static int CInt(string lin) {

            if (lin.Length== 0) return 0;
            int a=0;
            if (Int32.TryParse(lin,out a))  return int.Parse(lin);  else return 0; }
        public static int CInt(double lin) { return (int)(lin); }
        public static string CStr(double lin) { return (lin.ToString()); }
        public static int Val(string Lin) {
            if (nz(Lin) == "") return 0;
            Lin = Lin.Trim();
            if (Lin.Substring(0, 1) == "&") { 
                return Convert.ToInt32( Lin.Substring(1,Lin.Length-1) , 16);
            }
            return int.Parse(Lin); } 
        public static double CDbl(string Lin) {
            double a;
            if (Double.TryParse(Lin,out a)) return double.Parse(Lin); else return 0;
        }
        public static string LTrim(string lin) { return lin.TrimStart(); }
        public static string RTrim(string lin) { return lin.TrimEnd(); }
        //public static void NCoreLogfileMessage(String lin, int num) {if (num>5){System.Diagnostics.Debug.Write(lin);} }
        public static double Rnd() {  return VbXrnd.NextDouble();
        }





        public static string IntToBin(int i)
        {
            return VbX.Right("00000000" + Convert.ToString(i, 2), 8);
        }
        public static int HexToInt(string i) {
            return Convert.ToInt32(i, 16);
        
        }

        public static String nl(){
            return Chr(13) + Chr(10) ;
        }
        public static string HexToBin(string i)
        {
            try
            {
                int hint = Convert.ToInt32(i, 16);
                return IntToBin(hint);
            }
            catch (Exception e)
            {
                return "00000000";
            }

            //.ToString("X");
        }
        public static string BinToHex(string i)
        {
            int hint = Convert.ToInt32(i, 2);
            return hint.ToString("X");
            //.ToString("X");
        }
        public static int BinToInt(string B)
        {
            return Convert.ToInt32(B, 2);
        }

        public static string BinOr(string B1, string B2)
        {
            string NewBin = "";
            for (int i = 0; i < 8; i++)
            {
                if (B2.Substring(i, 1) == "1" || B1.Substring(i, 1) == "1")
                {
                    NewBin += "1";
                }
                else
                {
                    NewBin += "0";
                }
            }
            return NewBin;
        }
        public static string BinAnd(string B1, string B2)
        {
            string NewBin = "";
            for (int i = 0; i < 8; i++)
            {
                if (B2.Substring(i, 1) == "1" && B1.Substring(i, 1) == "1")
                {
                    NewBin += "1";
                }
                else
                {
                    NewBin += "0";
                }
            }
            return NewBin;
        }
    }

