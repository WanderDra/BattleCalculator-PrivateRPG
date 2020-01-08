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
        CalFunctions fun;
        Random dice;
        double temp;
        int player_lv;                      //玩家等级                *
        double strenth;                     //力量                    *
        double damage_mult;                 //力量伤害系数
        double max_carry_weight_atk;        //攻击方最大负重
        double swift;                       //敏捷                    *
        double max_accuracy;                //命中值上限
        double bright;                      //才智                    *
        double max_dodge;                   //最大回避值
        double max_guard;                   //最大格挡值
        double stamina;                     //体能                    *
        double max_stamina;                 //体力上限
        double health;                      //健康                    *
        double max_hp;                      //血量上限
        double determination;               //决心                    *
        double intelligence;                //智力                    *
        int skill_point;                    //技能点
        double weight;                      //负重                    *
        int weapon_skill_lv_atk;            //武器技能等级            *
        int dodge_skill_lv_atk;             //回避技能等级            *
        int guard_skill_lv_atk;             //格挡技能等级            *
        double damageMin, damageMax;        //伤害范围                *
        double effect_attr_atk;             //有效系数                *
        double pierce_attr_atk;             //穿甲系数                *
        double break_attr_atk;              //破甲系数                *
        double body_armor;                  //身体护甲值              *
        double body_armor_type;             //身体护甲类型            *
        double head_armor;                  //头部护甲值              *
        double head_armor_type;             //头部护甲类型            *
        double accuracy;                    //命中
        double dodge;                       //回避
        double guard_atk;                   //格挡
        double maxstanima;                  //耐力上限
        double tire;                        //疲劳
        double stamina_regen;                   //耐力回复
        double remain_stamina;                   //剩余耐力                *
        double initiative;                  //主动性
        double str_adj;                     //力量补正
        double hp = 0;                          //HP
        double height_adj;                  //高度差补正              *
        double angle_adj;                   //角度补正                *
        double combo_adj;                   //连击补正                *
        double con_dodge_adj;               //连续回避补正            *
        double pinch_adj;                   //夹击惩罚                *
        double headshot_adj;                //爆头率                  *
        double hitrate_final;               //命中率
        int enter_round_atk;                //进攻方加入的回合        *
        double armor_def_atk;               //攻击方护甲阻挡值        *         --

        double swift_tgt;                   //目标敏捷                *
        double tire_tgt;                    //目标疲劳          
        double determination_tgt;           //目标决心                *
        double remainSta_tgt;               //目标剩余耐力            *
        double weight_tgt;                  //目标负重                *
        int weapon_skill_lv_tgt;            //目标武器技能等级        *
        int dodge_skill_lv_tgt;             //目标回避技能等级        *
        int guard_skill_lv_tgt;             //目标格挡技能等级        *
        double accuracy_tgt;                //目标命中  
        double initiative_tgt;              //目标主动性
        int enter_round_tgt;                //目标加入的回合          *
        double dodge_tgt;                   //目标回避
        double guard_tgt;                   //目标格挡
        double bright_tgt;                  //目标才智                *
        double armor_def_tgt;               //目标护甲阻挡值                    --
        double max_accuracy_tgt;            //目标最大命中值
        double max_dodge_tgt;               //目标最大回避值
        double max_guard_tgt;               //目标最大格挡值



        double weapon_attack_atk;           //攻击方武器伤害
        double damage_atk;                  //攻击方伤害输出
        double armor_damage_atk;            //攻击方对护甲耐久损伤
        double body_damage_atk;             //攻击方对肉体损伤
        double ap_damage_atk;               //攻击方穿甲伤害
        double overflow_damage_atk;         //攻击方溢出伤害                    --
        

        int round;

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void Init(object sender, EventArgs e)
        {
            fun = new CalFunctions();
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
                //力量：提供伤害系数和负重上限，1%每点，1.5倍负重
                strenth = ul.ACTAttrCal(strengthTB, strengthAddTB);
                strengthAct.Content = strenth;
                damage_mult = fun.GetDamageMultipier(strenth);
                //敏捷：提供命中值上限，为2倍敏捷
                swift = ul.ACTAttrCal(swiftTB, swiftAddTB);
                swiftAct.Content = swift;
                max_accuracy = fun.GetMaxAccuracy(swift);
                //才智：提供回避值上限，为2倍才智
                bright = ul.ACTAttrCal(brightTB, brightAddTB);
                brightAct.Content = bright;
                max_dodge = fun.GetMaxDodge(bright);
                max_guard = fun.GetMaxGuard(bright);
                //体能：提供体力上限，5倍体能为体力上限
                stamina = ul.ACTAttrCal(staminaTB, staminaAddTB);
                staminaAct.Content = stamina;
                max_stamina = fun.GetMaxStamina(stamina, weight);
                //健康：提供生命上限，3倍健康为血量
                health = ul.ACTAttrCal(healthTB, healthAddTB);
                healthAct.Content = health;
                max_hp = fun.GetMaxHP(health);
                //决心：主动性和豁免
                determination = ul.ACTAttrCal(determinationTB, determinationAddTB);
                determinationAct.Content = determination;
                //智力：提供技能点，每点智力提供1技能点
                intelligence = ul.ACTAttrCal(intelligenceTB, intelligenceAddTB);
                intelligenceAct.Content = intelligence;
//                skill_point = (int)intelligence * 1 + 5 + ul.Accumulate(player_lv);
                weight = ul.ACTAttrCal(weightTB, weightAddTB);
                max_carry_weight_atk = fun.GetMaxCarryWeight(strenth);
                weightAct.Content = weight + "/" + max_carry_weight_atk;
                weapon_skill_lv_atk = ul.GetIntInTB(weaponSkillLvTB_atk);
                weaponSkillLvAct_atk.Content = weapon_skill_lv_atk;
                dodge_skill_lv_atk = ul.GetIntInTB(dodgeSkillLvTB_atk);
                dodgeSkillLvAct_atk.Content = dodge_skill_lv_atk;
                guard_skill_lv_atk = ul.GetIntInTB(guardSkillLvTB_atk);
                guardSkillLvAct_atk.Content = guard_skill_lv_atk;
                damageMin = ul.GetDoubleInTB(damageMinTB);
                damageMax = ul.GetDoubleInTB(damageMaxTB);
                rangeAct.Content = "" + damageMin + " - " + damageMax;
                effect_attr_atk = ul.ACTAttrCal(effectiveTB, effectiveAddTB);
                effectAct.Content = effect_attr_atk;
                pierce_attr_atk = ul.ACTAttrCal(pierceTB, pierceAddTB);
                pierceAct.Content = pierce_attr_atk;
                break_attr_atk = ul.ACTAttrCal(breakTB, breakAddTB);
                breakAct.Content = break_attr_atk;
                body_armor = ul.ACTAttrCal(bodyArmorTB, bodyArmorAddTB);
                bodyArmorAct.Content = body_armor;
                body_armor_type = headArmorTypeCB.SelectedIndex;
                head_armor = ul.ACTAttrCal(headArmorTB, headArmorAddTB);
                headArmorAct.Content = head_armor;
                head_armor_type = headArmorTypeCB.SelectedIndex;
                enter_round_atk = fun.GetACTRound(enterRoundTB_atk, roundTB);
                enterRoundACT_atk.Content = enter_round_atk;
                

                    //target
                swift_tgt = ul.ACTAttrCal(swiftTB_tgt, swiftAddTB_tgt);
                swiftAct_tgt.Content = swift_tgt;
                max_accuracy_tgt = fun.GetMaxAccuracy(swift_tgt);
                bright_tgt = ul.ACTAttrCal(brightTB_tgt, brightAddTB_tgt);
                brightAct_tgt.Content = bright_tgt;
                max_dodge_tgt = fun.GetMaxDodge(bright_tgt);
                max_guard_tgt = fun.GetMaxGuard(bright_tgt);
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
                enter_round_tgt = fun.GetACTRound(enterRoundTB_tgt, roundTB);
                enterRoundACT_tgt.Content = enter_round_tgt;

                // battle calculated section
                round = ul.GetIntInTB(roundTB);
                accuracy = fun.GetAccuracy(weapon_skill_lv_atk, max_accuracy);
                accuracyTxt.Content = accuracy;

                dodge = fun.GetDodge(dodge_skill_lv_atk, max_dodge);
                dodgeTxt.Content = dodge;

                guard_atk = fun.GetGuard(guard_skill_lv_atk, max_guard);
                guardTxt.Content = guard_atk;

                maxStaTxt.Content = max_stamina;

                tire = fun.GetCurrentTire(enter_round_atk, weight);
                tireTxt.Content = tire;

                stamina_regen = fun.GetCurrentStaminaRegeneration(tire);
                recoverStaTxt.Content = stamina_regen;

                remain_stamina = ul.GetDoubleInTB(remainStaTB);

                initiative = fun.GetInitiative(determination, remain_stamina, tire);
                initTxt.Content = initiative;

                hpTxt.Content = hp + "/" + max_hp;

                height_adj = ul.GetDoubleInTB(heightAdjTB) / 100.0;
                angle_adj = ul.GetDoubleInTB(angleAdjTB) / 100.0;
                combo_adj = ul.GetDoubleInTB(comboAdjTB) / 100.0;
                con_dodge_adj = ul.GetDoubleInTB(conDodgeAdjTB) / 100.0;
                pinch_adj = ul.GetDoubleInTB(pinchAdjTB) / 100.0;
                headshot_adj = ul.GetDoubleInTB(headshotAdjTB) / 100.0;

                // hitrate cal
                accuracy_tgt = fun.GetAccuracy(weapon_skill_lv_tgt, max_accuracy_tgt);

                ////////////////////////////////////////////////////////////////
                dodge_tgt = fun.GetDodge(dodge_skill_lv_tgt, max_dodge_tgt);

                guard_tgt = fun.GetGuard(guard_skill_lv_tgt, max_guard_tgt);

                tire_tgt = fun.GetCurrentTire(enter_round_tgt, weight_tgt);
                tireTxt_tgt.Content = tire_tgt;

                initiative_tgt = fun.GetInitiative(determination_tgt, remainSta_tgt, tire_tgt);

                hitrate_final = fun.GetHitRate(accuracy, accuracy_tgt, initiative_tgt, height_adj, angle_adj, combo_adj, con_dodge_adj, pinch_adj);
                hitRateTxt.Content = hitrate_final;

                //伤害输出=武器攻击力*力量补正系数 *武器对目标类型有效系数
                damage_atk = weapon_attack_atk * damage_mult * effect_attr_atk;
                //护甲耐久损伤 = 伤害输出 * 破甲系数
                armor_damage_atk = damage_atk * break_attr_atk;
                //穿甲伤害=伤害输出*穿甲系数–护甲阻挡值   *护甲阻挡值是剩余护甲值的1/10
                ap_damage_atk = damage_atk * pierce_attr_atk - armor_def_tgt;
                //肉体损伤 = 穿甲伤害＋溢出伤害      *溢出伤害=(总伤害-护甲阻挡伤害)*无甲完整伤害
                body_damage_atk = ap_damage_atk + overflow_damage_atk;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveBtn_Atk_Click(object sender, RoutedEventArgs e)
        {
            ul.AddAttrToSaveList("test", 300);
            ul.AddAttrToSaveList("test2", "123");
            ul.AddAttrToSaveList("test3", 12.6);
            ul.SaveCharacter("test");
        }

        private void LoadBtn_Atk_Click(object sender, RoutedEventArgs e)
        {
            ul.ReadCharacter("test");
            MessageBox.Show((string)ul.GetAttrInSaveList("test") + (string)ul.GetAttrInSaveList("test2") + (string)ul.GetAttrInSaveList("test3"));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
