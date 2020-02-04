using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class AccessibilityMethods

    {

        public bool nospecialcharacters(string fontsize)
        {
            char[] fontsizearr = fontsize.ToCharArray();
            char[] speiChars = new char[] { '!', ',', '?', '#', '£', '$', '^', '&', '*', '(', ')' };
            foreach (var t in fontsize)
                if ((speiChars.Contains(t)))
                    return false;

            return true;

        }

        public bool containsnumbers(string fontsize)

        { 
            char[] fontsizearr = fontsize.ToCharArray();
            char[] nums = new char[] { '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < fontsizearr.Length; i++)
            {
                if (!(nums.Contains(fontsizearr[i])))
                    return false;

            }
            return true;
        }


        public void changeFontSize(string s)
        {
            if (!(containsnumbers(s) || !(nospecialcharacters(s))))
               throw new SystemException("Invalid font size");

            float size;
            size = Convert.ToSingle(s, new CultureInfo("en-gb"));
            Form f;
            f = new map { Font = new Font(Control.DefaultFont.FontFamily.ToString(), size) };

        }

        public void changeFontColour(string col)
        {
            Form f;
            f = new map();
            Color colour = f.ForeColor;
            switch (col)
            {
                case "Red":
                    colour = Color.Red;
                    break;
                case "Blue":
                    colour = Color.Blue;
                    break;
                case "Orange":
                    colour = Color.Orange;
                    break;
            }

            f.ForeColor = colour;

        }


    }
}
