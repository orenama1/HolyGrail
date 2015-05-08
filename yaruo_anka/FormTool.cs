using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace yaruo_anka
{
    public class FormTool
    {
        public static Size getAddSize(Size form_size, Size change)
        {
            return form_size+change;
        }
        public static string changeCSVstringsTostring(Control [] cons) {
            string s = "";
            int count = 0;
            foreach (Control con in cons)
            {
                s += con.Text;
                if (count != cons.Length - 1)
                {
                    s += ",";
                }
            }
            s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}
