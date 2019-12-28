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
        double temp;
        double strenth;
        double swift;
        double bright;
        double stamina;
        double health;
        double determination;
        double intelligence;
        double weight;
        int weapon_skill_lv_atk;
        int dodge_skill_lv_atk;
        double damageMin, damageMax;
        double effectAttr;
        double pierceAttr;
        double breakAttr;
        double body_armor;
        double body_armor_type;
        double head_armor;
        double head_armor_type;
        double accuracy;
        double dodge;
        double maxstanima;
        double tire;
        double staminaRe;
        double remainSta;

        int round;

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
            tblist.Add(weaponSkillLvTB_atk);
            tblist.Add(dodgeSkillLvTB_atk);
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
                
                // data input section
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
                weight = ul.ACTAttrCal(weightTB, weightAddTB);
                weightAct.Content = weight;
                weapon_skill_lv_atk = ul.GetIntInTB(weaponSkillLvTB_atk);
                weaponSkillLvAct_atk.Content = weapon_skill_lv_atk;
                dodge_skill_lv_atk = ul.GetIntInTB(dodgeSkillLvTB_atk);
                dodgeSkillLvAct_atk.Content = dodge_skill_lv_atk;
                damageMin = ul.GetDoubleInTB(damageMinTB);
                damageMax = ul.GetDoubleInTB(damageMaxTB);
                rangeAct.Content = "" + damageMin + " - " + damageMax;
                effectAttr = ul.ACTAttrCal(effectiveTB, effectiveAddTB);
                effectAct.Content = effectAttr;
                pierceAttr = ul.ACTAttrCal(pierceTB, pierceAddTB);
                pierceAct.Content = pierceAttr;
                breakAttr = ul.ACTAttrCal(breakTB, breakAddTB);
                breakAct.Content = breakAttr;
                body_armor = ul.ACTAttrCal(bodyArmorTB, bodyArmorAddTB);
                bodyArmorAct.Content = body_armor;
                body_armor_type = headArmorTypeCB.SelectedIndex;
                head_armor = ul.ACTAttrCal(headArmorTB, headArmorAddTB);
                headArmorAct.Content = head_armor;
                head_armor_type = headArmorTypeCB.SelectedIndex;

                // battle calculated section
                round = ul.GetIntInTB(roundTB);
                accuracy = 20 * weapon_skill_lv_atk;
                if (accuracy > swift * 2)
                {
                    accuracy = swift * 2;
                }
                accuracyTxt.Content = accuracy;

                dodge = 20 * dodge_skill_lv_atk;
                if (dodge > bright * 2)
                {
                    dodge = bright * 2;
                }
                dodgeTxt.Content = dodge;

                maxstanima = stamina * 3 - weight;
                maxStaTxt.Content = maxstanima;

                tire = round + weight/2;
                tireTxt.Content = tire;

                staminaRe = 15 - tire;
                recoverStaTxt.Content = staminaRe;

                remainSta = ul.GetDoubleInTB(remainStaTB);
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
