using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<TextBox> tblist = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
            tblist.Add(strengthTB);
            tblist.Add(strengthAddTB);
            tblist.Add(swiftTB);
            tblist.Add(swiftAddTB);
            tblist.Add(brightTB);
            tblist.Add(brightAddTB);
            tblist.Add(staminaTB);
            tblist.Add(staminaAddTB);
            tblist.Add(healthTB);
            tblist.Add(healthAddTB);
            tblist.Add(determinationTB);
            tblist.Add(determinationAddTB);
            tblist.Add(intelligenceTB);
            tblist.Add(weightTB);
            tblist.Add(weightAddTB);
            tblist.Add(damageMinTB);
            tblist.Add(damageMaxTB);
            tblist.Add(effectiveTB);
            tblist.Add(effectiveAddTB);
            tblist.Add(pierceTB);
            tblist.Add(pierceAddTB);
            tblist.Add(breakTB);
            tblist.Add(breakAddTB);
            tblist.Add(bodyArmorTB);
            tblist.Add(bodyArmorAddTB);
            tblist.Add(headArmorTB);
            tblist.Add(headArmorAddTB);

            tblist.Add(roundTB);
            tblist.Add(remainStaTB);
            tblist.Add(heightAdjTB);
            tblist.Add(angleAdjTB);
            tblist.Add(comboAdjTB);
            tblist.Add(conDodgeAdjTB);
            tblist.Add(pinchAdjTB);
            tblist.Add(headshotAdjTB);
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calculation(object sender, TextChangedEventArgs e)
        {
            double temp;
            double strenth;
            double swift;
            foreach (TextBox tb in tblist)
            {
                if (tb.Text != "" && double.TryParse(tb.Text, out temp) == false)
                {
                    tb.Text = "非法数值";
                    break;
                }
            }

            if (strengthTB.Text != "")
            {
                strenth = double.Parse(strengthTB.Text);
                if (strengthAddTB.Text != "") {
                    strenth = double.Parse(strengthTB.Text) + double.Parse(strengthAddTB.Text);
                }
                strengthAct.Content = strenth;
            }

            if (swiftTB.Text != "")
            {
                swift = double.Parse(swiftTB.Text);
                if (swiftAddTB.Text != "")
                {
                    swift = double.Parse(swiftTB.Text) + double.Parse(swiftAddTB.Text);
                }
                swiftAct.Content = swift;
            }

            


        }


    }
}
