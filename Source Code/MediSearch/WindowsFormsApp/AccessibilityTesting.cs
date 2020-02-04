using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;


namespace WindowsFormsApp
{
    public class AccessibilityTesting
    {
        public static IEnumerable<object[]> GetFontSizes(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { 18 },
                new object[] { "jeff" },
                new object[] { "32.5" },
                new object[] {"18" },
            };

            return allData.Take(numTests);
        }

        public bool containsnumbers(string fontsize)

        {

            char[] fontsizearr = fontsize.ToCharArray();
            char[] nums = new char[] { '.','1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < fontsizearr.Length; i++)
            {
                if (!(nums.Contains(fontsizearr[i])))
                    return false;

            }

            return true;

        }

        public bool nospecialcharacters(string fontsize)
        {
            char[] fontsizearr = fontsize.ToCharArray();
            char[] speiChars = new char[] { '!', ',',  '?', '#', '£', '$', '^', '&', '*', '(', ')' };
            foreach (var t in fontsize)
                if ((speiChars.Contains(t)))
                    return false;

            return true;

        }




        [Fact]
        public void Test_getfontsize()
        {
            bool r;
            Form f;
            f = new map();
            if ((map.DefaultFont) != null)
                r = true;
            else
            {
                r = false;
            }
            
            Assert.True(r,$"Font was retrieved {map.DefaultFont}");
        }

        [Theory]
        [InlineData("36")]
        public void Test_changefontsize(string s)
        {
            bool r;
            float size;
            size = Convert.ToSingle(s, new CultureInfo("en-gb"));
            Form f;
            f = new map {Font = new Font(Control.DefaultFont.FontFamily.ToString(), size)};
            if ((f.Font.Size) == size)
                r = true;
            else
                r = false;
            Assert.True(r, $"Font size was not changed {map.DefaultFont.Size}");
        }

        [Theory]
        [InlineData("Red")]
        public void Test_fontcolour(string col)
        {
            bool r;
            Form f;
            f = new map();
            Color colour = f.ForeColor;
            if (col == "Red") colour = Color.Red;

            f.ForeColor = colour;

            if (f.ForeColor == Color.Red)
                r = true;
            else
                r = false;

            Assert.True(r,"font colour not changed");
        }

        [Theory]
        [MemberData(nameof(GetFontSizes), parameters: 3)]
        public void validateSizeinput(string size)
        {
            bool r;
            if (containsnumbers(size) && (nospecialcharacters(size)))
                r = true;
            else
                r = false;

            Assert.True(r,"font size entered not valid");


        }


    }
}
