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
        Random dice;
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
        int guard_skill_lv_atk;
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
        double guard_atk;
        double maxstanima;
        double tire;
        double staminaRe;
        double remainSta;
        double initiative;
        double str_adj;
        double hp;
        double height_adj;
        double angle_adj;
        double combo_adj;
        double con_dodge_adj;
        double pinch_adj;
        double headshot_adj;
        double hitrate_final;
        int enter_round_atk;

        double swift_tgt;
        double tire_tgt;
        double determination_tgt;
        double remainSta_tgt;
        double weight_tgt;
        int weapon_skill_lv_tgt;
        int dodge_skill_lv_tgt;
        int guard_skill_lv_tgt;
        double accuracy_tgt;
        double initiative_tgt;
        int enter_round_tgt;
        double dodge_tgt;
        double guard_tgt;
        double bright_tgt;
        

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
            tblist.Add(guardSkillLvTB_atk);
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
            tblist.Add(enterRoundTB_atk);

            tblist.Add(roundTB);
            tblist.Add(remainStaTB);
            tblist.Add(heightAdjTB);
            tblist.Add(angleAdjTB);
            tblist.Add(comboAdjTB);
            tblist.Add(conDodgeAdjTB);
            tblist.Add(pinchAdjTB);
            tblist.Add(headshotAdjTB);

            tblist.Add(swiftTB_tgt);
            tblist.Add(swiftAddTB_tgt);
            tblist.Add(brightTB_tgt);
            tblist.Add(brightAddTB_tgt);
            tblist.Add(determinationTB_tgt);
            tblist.Add(determinationAddTB_tgt);
            tblist.Add(remainStaTB_tgt);
            tblist.Add(weightTB_tgt);
            tblist.Add(weightAddTB_tgt);
            tblist.Add(weaponSkillLvTB_tgt);
            tblist.Add(dodgeSkillLvTB_tgt);
            tblist.Add(guardSkillLvTB_tgt);
            tblist.Add(enterRoundTB_tgt);


            

            ul = new Util();
            dice = new Random();
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
                    //attacker
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
                guard_skill_lv_atk = ul.GetIntInTB(guardSkillLvTB_atk);
                guardSkillLvAct_atk.Content = guard_skill_lv_atk;
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
                enter_round_atk = ul.GetACTRound(enterRoundTB_atk, roundTB);
                enterRoundACT_atk.Content = enter_round_atk;
                

                    //target
                swift_tgt = ul.ACTAttrCal(swiftTB_tgt, swiftAddTB_tgt);
                swiftAct_tgt.Content = swift_tgt;
                bright_tgt = ul.ACTAttrCal(brightTB_tgt, brightAddTB_tgt);
                brightAct_tgt.Content = bright_tgt;
                determination_tgt = ul.ACTAttrCal(determinationTB_tgt, determinationAddTB_tgt);
                determinationAct_tgt.Content = determination_tgt;
                remainSta_tgt = ul.GetDoubleInTB(remainStaTB_tgt);
                weight_tgt = ul.ACTAttrCal(weightTB_tgt, weightAddTB_tgt);
                weightAct_tgt.Content = weight_tgt;
                weapon_skill_lv_tgt = ul.GetIntInTB(weaponSkillLvTB_tgt);
                weaponSkillLv_tgt.Content = weapon_skill_lv_tgt;
                dodge_skill_lv_tgt = ul.GetIntInTB(dodgeSkillLvTB_tgt);
                dodgeSkillLvAct_tgt.Content = dodge_skill_lv_tgt;
                guard_skill_lv_tgt = ul.GetIntInTB(guardSkillLvTB_tgt);
                guardSkillLvAct_tgt.Content = guard_skill_lv_tgt;
                enter_round_tgt = ul.GetACTRound(enterRoundTB_tgt, roundTB);
                enterRoundACT_tgt.Content = enter_round_tgt;

                // battle calculated section
                round = ul.GetIntInTB(roundTB);
                accuracy = 20 * weapon_skill_lv_atk;
                if (accuracy > swift * 2.0)
                {
                    accuracy = swift * 2.0;
                }
                accuracyTxt.Content = accuracy;

                dodge = 20 * dodge_skill_lv_atk;
                if (dodge > bright * 2.0)
                {
                    dodge = bright * 2.0;
                }
                dodgeTxt.Content = dodge;

                guard_atk = 20 * guard_skill_lv_atk;
                if (guard_atk > bright * 2.0)
                {
                    guard_atk = bright * 2.0;
                }
                guardTxt.Content = guard_atk;

                maxstanima = stamina * 3.0 - weight;
                maxStaTxt.Content = maxstanima;

                tire = enter_round_atk + weight/2.0;
                tireTxt.Content = tire;

                staminaRe = 15 - tire;
                recoverStaTxt.Content = staminaRe;

                remainSta = ul.GetDoubleInTB(remainStaTB);

                initiative = (determination + remainSta) / 2.0 - tire;
                initTxt.Content = initiative;

                str_adj = strenth + 100;
                addStrTxt.Content = str_adj;

                hp = health * 2.0;
                hpTxt.Content = hp;

                height_adj = ul.GetDoubleInTB(heightAdjTB) / 100.0;
                angle_adj = ul.GetDoubleInTB(angleAdjTB) / 100.0;
                combo_adj = ul.GetDoubleInTB(comboAdjTB) / 100.0;
                con_dodge_adj = ul.GetDoubleInTB(conDodgeAdjTB) / 100.0;
                pinch_adj = ul.GetDoubleInTB(pinchAdjTB) / 100.0;
                headshot_adj = ul.GetDoubleInTB(headshotAdjTB) / 100.0;

                // hitrate cal
                accuracy_tgt = 20 * weapon_skill_lv_tgt;
                if(accuracy_tgt > swift_tgt * 2.0)
                {
                    accuracy_tgt = swift_tgt * 2.0;
                }

                dodge_tgt = 20 * dodge_skill_lv_tgt;
                if (dodge_tgt > bright_tgt * 2.0)
                {
                    dodge_tgt = bright_tgt * 2.0;
                }

                guard_tgt = 20 * guard_skill_lv_tgt;
                if (guard_tgt > bright_tgt * 2.0)
                {
                    guard_tgt = bright_tgt * 2.0;
                }

                tire_tgt = enter_round_tgt + weight_tgt / 2.0;
                tireTxt_tgt.Content = tire_tgt;

                initiative_tgt = (determination_tgt + remainSta_tgt) / 2.0 - tire_tgt;



                hitrate_final = (accuracy * 2.0 / (accuracy * 2.0 + accuracy_tgt + initiative_tgt / 4.0)) + height_adj + angle_adj + combo_adj + con_dodge_adj + pinch_adj;
                hitrate_final = ul.GetHitRate(hitrate_final);
                hitRateTxt.Content = hitrate_final;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CalBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
