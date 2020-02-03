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
        [Fact]
        public void Test_getfontsize()
        {
            bool r;
            Form f = new map();
            if ((map.DefaultFont) != null)
            {

                r = true;
            }
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
            float size = Convert.ToSingle(s, new CultureInfo("en-gb"));
            Form f = new map();
            f.Font = new Font(familyName: map.DefaultFont.FontFamily.ToString(), size);
            if ((f.Font.Size) == size)
            {

                r = true;
            }
            else
            {
                r = false;
            }
            Assert.True(r, $"Font size was not changed {map.DefaultFont.Size}");
        }

        
    }
}
