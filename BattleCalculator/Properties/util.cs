using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleCalculator.Properties
{
    class Util
    {
        public Util()
        {

        }
        public double ACTAttrCal(TextBox basic, TextBox add)
        {
            double result;
            if (basic.Text != "" && basic.Text != "-")
            {
                result = double.Parse(basic.Text);
                if (add.Text != "" && add.Text != "-")
                {
                    result = double.Parse(basic.Text) + double.Parse(add.Text);
                }
                return result;
            }
            return 0;
        }

        public double GetDoubleInTB(TextBox tb)
        {
            double result;
            if(tb.Text != "" && tb.Text != "-")
            {
                result = double.Parse(tb.Text);
                return result;
            }
            return 0;
        }

        public int GetIntInTB(TextBox tb)
        {
            int result;
            if(tb.Text != "" && tb.Text != "-")
            {
                result = int.Parse(tb.Text);
                return result;
            }
            return 0;
        }
    }
}
