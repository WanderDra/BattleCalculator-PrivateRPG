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

        public int GetACTRound(TextBox enter_round, TextBox round)
        {
            int result;
            if(enter_round.Text != "")
            {
                if (round.Text != "")
                {
                    result = int.Parse(round.Text) - int.Parse(enter_round.Text);
                    return result;
                }
            }
            return 0;
        }

        public double GetHitRate(double hitrate)
        {
            if (hitrate < 0.05)
            {
                hitrate = 0.05;
            }
            else if (hitrate >= 0.95)
            {
                hitrate = 0.95;
            }
            return hitrate * 100;
        }

        public double GetAttackResult(Random dice, double hitrate_final, double headshot_adj, double dodge_tgt, double guard_tgt)
        {
            int d1 = dice.Next(1, 100);
            if (d1 <= hitrate_final)
            {
                int d2 = dice.Next(1, 100);
                if (d2 <= headshot_adj * 100)
                {
                    //headshot
                }
                else
                {
                    //bodyshot
                }
            }
            else
            {
                //not hit - dodge
                int d3 = dice.Next(1, 100);
                if (d3 <= (guard_tgt / (guard_tgt + dodge_tgt)) * 100){
                    //working...
                    //guard();
                }
                else
                {
                    //dodge();
                }
                
            }
            return 0;
        }
    }
}
