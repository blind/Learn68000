

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

// DotNet-Core V1.1
// 
// Name:             GetItem
// Last Update:      17/10/2008
//
// GetItem is a splitter for strings, such as CSV lines etc.
//
// Provides:
// GetItem(String, Character, Position)     Gets item POSITION from STRING splitting on CHARACTER
// GetItemPos(line, findme, character) Finds the position of FINDME in LINE split by CHARACTER
// CountItems(ByVal lin As String, ByVal ch As String)
//
// note first position is 0
//
// Requires: NCoreLogFile
//
//EG:
//   A$=GetItem("Hello World"," ",1) = "World"
// 
//   a=CountItems(Hello World"," ") = 1

static class ss
{
    public static string GetItem(string lin,  int pos) {
        // a version of getitem which automatically uses splitter
        if (lin.Length == 0) return "";
        string ch = ",";
        return GetItem(lin, ch, pos);
    }
	public static string GetItem(string lin, string ch, int pos)
	{
		if (lin == null){return "";}
        if (lin.Length == 0 || ch.Length == 0) return "";
		// check the string isn't null (could cause a crash)
		if (lin.Length > 0) {
			try {
				string[] stringarray = lin.Split(ch.ToCharArray());
                if (pos > stringarray.GetUpperBound(0))
                {
                    return "";
                }
				return stringarray[pos];
				
			} catch (Exception ex) {
                System.Console.WriteLine("Error " + ex.ToString());        
			}
		}
		return "";
	}
    
	public static string GetItem(string lin, string ch, int pos, string brackets)
    
	{
        if (lin.Length == 0 || ch.Length == 0) return "";
		string bracketarray = "";
		string part = "";
		int foundnum = 0;

		for (int i = 1; i <= lin.Length ; i++) {
			string c = VbX.Mid(lin, i, 1);
			if (c == ch & string.IsNullOrEmpty(bracketarray)) {
				if (foundnum == pos)
					return part;
				else{part = "";foundnum = foundnum + 1;}
			} else {
				part = part + c;
			}

			//    MsgBox(c)
			if (c == VbX.Chr(34) & VbX.InStr(brackets, VbX.Chr(34)) > 0) {
				if (VbX.Right(bracketarray, 1) == VbX.Chr(34) & !string.IsNullOrEmpty(bracketarray)) {
					bracketarray = VbX.Left(bracketarray, VbX.Len(bracketarray) - 1);
				} else {
					bracketarray = bracketarray + VbX.Chr(34);
				}
				//part = part + c
			} else if ((c == "(" | c == ")") & VbX.InStr(brackets, "(") > 0) {
				if (VbX.Right(bracketarray, 1) == "(" & c == ")" & !string.IsNullOrEmpty(bracketarray)) {
					bracketarray = VbX.Left(bracketarray, VbX.Len(bracketarray) - 1);
				} else {
					bracketarray = bracketarray + "(";
				}
				//part = part + c
			} else if ((c == "{" | c == "}") & VbX.InStr(brackets, "{") > 0) {
				if (VbX.Right(bracketarray, 1) == "{" & c == "}" & !string.IsNullOrEmpty(bracketarray)) {
                    bracketarray = VbX.Left(bracketarray, VbX.Len(bracketarray) - 1);
				} else {
					bracketarray = bracketarray + "{";
				}
				//part = part + c
			}

		}
		if (foundnum == pos)
			return part;
		if (pos == -1)
			return foundnum.ToString();
		return "";
	}
    /*
	public static int GetItemPos(string lin, string findme, string ch)
	{
		int functionReturnValue = 0;
		if (lin == null)
			return functionReturnValue;
		if (lin.Length > 0) {
            
			int ps = VbX.InStr(ch + lin + ch, ch + findme + ch);
            functionReturnValue = CountItems(VbX.Left(ch + lin + ch, ps), ch) - 1;
		} else {
			functionReturnValue = -1;
		}
		return functionReturnValue;
	}*/

    public static int CountItems(string lin){
        if (lin.Length == 0) return 0;
        string ch = ",";
        return CountItems(lin, ch);
    }

	public static int CountItems(string lin, string ch, string brackets)
	{
        if (lin.Length == 0 || ch.Length == 0) return 0;
		return int.Parse(GetItem(lin, ch, -1, brackets)) + 1;
	}
	public static int CountItems(string lin, string ch)
	{
        if (ch == null) return 0;
        string[] stringarray = lin.Split(ch.ToCharArray());
        return stringarray.GetUpperBound(0);
        /*

		int functionReturnValue = 0;
		if (lin == null)
			return functionReturnValue;
		if (lin.Length == 0)
			return functionReturnValue;
		try {
			int i = 0;
			int count = 0;
			// Look through the string counting all occurances of 'ch'
			for (i = 0; i <= lin.Length - 1; i++) {
				try {
					if (lin.Substring(i,1) == ch)
						count = count + 1;
				} catch (Exception ex) {

               //     MessageBox.Show(this,ex.ToString,"");
				}

			}
			return count;
		} catch (Exception ex) {
		//	Logfile.NCoreLogfileMessage("CountItems Panic," + ex.Message, 9);
		}
		return functionReturnValue;
        */
	}
    /*
	public static string replaceone(string ln, string A, string b)
	{
		int la = 0;
		int inpos = 0;
		string c = null;
		string d = null;
		c = ln;
		la = VbX.Len(A);
		if (VbX.InStr(c, A) > 0) {
			inpos = VbX.InStr(c, A);
            d = VbX.Left(c, inpos - 1);
			d = d + b;
			d = d + VbX.Right(c, VbX.Len(c) - (inpos + (VbX.Len(A) - 1)));
			c = d;
		}
		return c;
	}*/
    /*
	public static string ncoregetbetween(string lin, string lf, string rt)
	{
		string functionReturnValue = null;
		int aa = 0;
		int bb = 0;

		aa = VbX.InStr(lin, lf) + VbX.Len(lf);
		bb = VbX.InStr(lin, rt);

		if (aa == 0 | bb == 0) {
			functionReturnValue = "";
		} else {
			functionReturnValue = VbX.Mid(lin, aa, bb - aa);
		}
		return functionReturnValue;

	}*/
}
