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
using BattleCalculator.Properties;

namespace BattleCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<TextBox> tblist;
        Util ul;

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void Init(object sender, EventArgs e)
        {
            tblist = new List<TextBox>();
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
            tblist.Add(intelligenceAddTB);
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

            ul = new Util();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calculation(object sender, TextChangedEventArgs e)
        {
            double temp;
            double strenth;
            double swift;
            double bright;
            double stamina;
            double health;
            double determination;
            double intelligence;
            try
            {
                foreach (TextBox tb in tblist)
                {
                    if (tb.Text != "-")
                        if (tb.Text != "" && double.TryParse(tb.Text, out temp) == false)
                        {
                            tb.Text = "";
                            break;
                        }
                }
                
                strenth = ul.ACTAttrCal(strengthTB, strengthAddTB);
                strengthAct.Content = strenth;
                swift = ul.ACTAttrCal(swiftTB, swiftAddTB);
                swiftAct.Content = swift;
                bright = ul.ACTAttrCal(brightTB, brightAddTB);
                brightAct.Content = bright;
                stamina = ul.ACTAttrCal(staminaTB, staminaAddTB);
                staminaAct.Content = stamina;
                health = ul.ACTAttrCal(healthTB, healthAddTB);
                healthAct.Content = health;
                determination = ul.ACTAttrCal(determinationTB, determinationAddTB);
                determinationAct.Content = determination;
                intelligence = ul.ACTAttrCal(intelligenceTB, intelligenceAddTB);
                intelligenceAct.Content = intelligence;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
