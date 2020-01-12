using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;

namespace BattleCalculator.Properties
{
    class CalFunctions
    {
        Hashtable con_dodge_list;
        Hashtable atk_tgt_list;
        Hashtable con_atk_list;
        Random dice;
        int cal_round;
        public CalFunctions()
        {
            con_dodge_list = new Hashtable();
            atk_tgt_list = new Hashtable();
            con_atk_list = new Hashtable();
            dice = new Random();
            cal_round = -1;
        }
        ~CalFunctions()
        {
            con_dodge_list.Clear();
            atk_tgt_list.Clear();
            con_atk_list.Clear();
        }

        //获取力量伤害系数
        public double GetDamageMultipier(double strenth)
        {
            double damage_mult = 0.01 * strenth + 1;
            return damage_mult;
        }

        //获取最大命中值
        public double GetMaxAccuracy(double swift)
        {
            double max_accuracy = swift * 2.0;
            return max_accuracy;
        }

        //获取最大回避值
        public double GetMaxDodge(double bright)
        {
            double max_dodge = bright * 2.0;
            return max_dodge;
        }


        //获取最大格挡值
        public double GetMaxGuard(double bright)
        {
            double max_guard = bright * 2.0;
            return max_guard;
        }

        //获取最大耐力
        public double GetMaxStamina(double stamina, double weight)
        {
            double max_stanima = stamina * 5.0 - weight;
            return max_stanima;
        }

        //获取最大HP
        public double GetMaxHP(double health)
        {
            double max_hp = health * 3.0;
            return max_hp;
        }

        //获取最大负重
        public double GetMaxCarryWeight(double strenth)
        {
            double max_carry_weight = strenth * 1.5;
            return max_carry_weight;
        }

        //获取命中值
        public double GetAccuracy(double weapon_skill_lv, double max_accuracy)
        {
            double accuracy;
            accuracy = 20 * weapon_skill_lv;
            if (accuracy > max_accuracy)
            {
                accuracy = max_accuracy;
            }
            return accuracy;
        }

        //获取回避值(闪避)
        public double GetDodge_Dodge(double dodge_skill_lv, double max_dodge)
        {
            double dodge;
            dodge = 20 * dodge_skill_lv;
            if (dodge > max_dodge)
            {
                dodge = max_dodge;
            }
            return dodge;
        }

        //获取回避值(盾牌)
        public double GetDodge_Shield(double shield_skill_lv, double swift)
        {
            double dodge;
            dodge = 20 * shield_skill_lv;
            if(dodge > swift * 2.0)
            {
                dodge = swift * 2.0;
            }
            return dodge;
        }

        //获取格挡值
        public double GetGuard(double guard_skill_lv, double max_guard)
        {
            double guard;
            guard = 20 * guard_skill_lv;
            if (guard > max_guard)
            {
                guard = max_guard;
            }
            return guard;
        }

        //计算命中率
        public double GetHitRate(double accuracy_atk, double accuracy_adj_atk, double dodge_tgt, double dodge_adj_tgt, double initiative_tgt, double height_adj, double angle_adj, double combo_adj, double con_dodge_adj, double pinch_adj)
        {
            double hitrate;
            hitrate = ((accuracy_atk * 2.0 + accuracy_adj_atk)/ ((accuracy_atk * 2.0 + accuracy_adj_atk) + (dodge_tgt + initiative_tgt / 3.0 + dodge_adj_tgt))) + height_adj + angle_adj + combo_adj + con_dodge_adj + pinch_adj;
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

        //获取当前疲劳
        public double GetCurrentTire(double entered_round, double weight)
        {
            double tire;
            tire = entered_round + weight / 4.0;
            return tire;
        }

        //获取耐力回复量
        public double GetCurrentStaminaRegeneration(double tire)
        {
            double stamina_regen;
            stamina_regen = 20 - tire;
            if (stamina_regen < 5)
            {
                stamina_regen = 5;
            }
            return stamina_regen;
        }

        //获取主动性
        public double GetInitiative(double determination, double remain_stamina, double tire)
        {
            double initiative;
            initiative = (determination + remain_stamina / 2.0) / 2.0 - tire;
            return initiative;
        }

        //获取回避值
        public double GetDodge(int dodge_skill_lv, double max_dodge)
        {
            double dodge;
            dodge = 20 * dodge_skill_lv;
            if (dodge > max_dodge)
            {
                dodge = max_dodge;
            }
            return dodge;
        }

        //获取格挡值
        public double GetGuard(int guard_skill_lv, double max_guard)
        {
            double guard;
            guard = 20 * guard_skill_lv;
            if (guard > max_guard)
            {
                guard = max_guard;
            }
            return guard;
        }




        //获取攻击结果
        //result-
        //status: head/body/guard/dodge 命中情况
        //damage: 身体伤害
        //stanima: 剩余耐力
        //effect_damage: 武器有效伤害
        //armor_damage: 护甲伤害
        //ap_damage: 穿甲伤害
        //overflow_damage: 溢出伤害
        public Hashtable GetAttackResult(string name_atk, string name_tgt, int round, double hitrate_final,
                                         double headshot_adj, double dodge_tgt, double guard_tgt, double stanima,
                                         double weapon_attack_atk, double damage_mult, double effect_attr_atk,
                                         double break_attr_atk, double pierce_attr_atk, double armor_def_tgt_head,
                                         double armor_def_tgt_body, out double combo_adj, out double con_dodge_adj)
        {
            Hashtable result = new Hashtable();
            double damage_atk;
            double armor_damage_atk;
            double ap_damage_atk;
            double overflow_damage_atk;
            double body_damage_atk;
            double ap_requrie_atk;
            double remain_armor_tgt;
            double armor_reduce;
            double ap_effect_damage_atk;
            if (cal_round != round)
            {
                con_dodge_list.Clear();
                cal_round = round;
            }
            // 连续回避惩罚判定
            int dodge_times;
            if (!con_dodge_list.ContainsKey(name_tgt))
            {
                con_dodge_list.Add(name_tgt, 0);
                dodge_times = 0;
            }
            else
            {
                dodge_times = (int)con_dodge_list[name_tgt];
            }
            //连击补正判定
            int combo;
            if (!atk_tgt_list.ContainsKey(name_atk))
            {
                atk_tgt_list.Add(name_atk, name_tgt);
            }
            if (!con_atk_list.ContainsKey(name_atk))
            {
                con_atk_list.Add(name_atk, 0);
            }
            if (!atk_tgt_list[name_atk].ToString().Equals(name_tgt))
            {
                con_atk_list[name_atk] = 0;
                atk_tgt_list[name_atk] = name_tgt;
            }
            combo = (int)con_atk_list[name_atk];

            int d1 = dice.Next(1, 100);
            if (d1 <= hitrate_final)
            {
                int d2 = dice.Next(1, 100);
                result.Add("hit", true);
                //伤害输出=武器攻击力*力量补正系数 *武器对目标类型有效系数
                damage_atk = GetEffectDamage(weapon_attack_atk, effect_attr_atk, damage_mult);
                //护甲耐久损伤 = 伤害输出 * 破甲系数
                armor_damage_atk = GetArmorDamage(damage_atk, break_attr_atk);
                result.Add("effect_damage", damage_atk);
                result.Add("armor_damage", armor_damage_atk);
                if (d2 <= headshot_adj * 100)
                {
                    //headshot
                    result.Add("status", "head");
                    //破甲需求伤害
                    ap_requrie_atk = GetAPRequiredDamage(armor_damage_atk, armor_def_tgt_head, break_attr_atk);
                    //溢出伤害
                    overflow_damage_atk = GetOverflowDamage(ap_requrie_atk, damage_atk);
                    //剩余护甲值
                    remain_armor_tgt = GetRemainArmor(armor_def_tgt_head, armor_damage_atk);
                    //穿甲伤害
                    ap_damage_atk = GetAPDamage(damage_atk, pierce_attr_atk);
                    //护甲阻挡值
                    armor_reduce = GetArmorReducedDmg(remain_armor_tgt);
                    //有效穿甲伤害
                    ap_effect_damage_atk = GetEffectAPDamage(ap_damage_atk, armor_reduce);
                    //肉体伤害
                    body_damage_atk = GetBodyDamage(ap_effect_damage_atk, overflow_damage_atk);
                    result.Add("damage", body_damage_atk * 1.5);
                }
                else
                {
                    //bodyshot
                    result.Add("status", "body");
                    //破甲需求伤害
                    ap_requrie_atk = GetAPRequiredDamage(armor_damage_atk, armor_def_tgt_body, break_attr_atk);
                    //溢出伤害
                    overflow_damage_atk = GetOverflowDamage(ap_requrie_atk, damage_atk);
                    //剩余护甲值
                    remain_armor_tgt = GetRemainArmor(armor_def_tgt_body, armor_damage_atk);
                    //穿甲伤害
                    ap_damage_atk = GetAPDamage(damage_atk, pierce_attr_atk);
                    //护甲阻挡值
                    armor_reduce = GetArmorReducedDmg(remain_armor_tgt);
                    //有效穿甲伤害
                    ap_effect_damage_atk = GetEffectAPDamage(ap_damage_atk, armor_reduce);
                    //肉体伤害
                    body_damage_atk = GetBodyDamage(ap_effect_damage_atk, overflow_damage_atk);
                    result.Add("damage", body_damage_atk);
                }
                result.Add("ap_damage", ap_effect_damage_atk);
                result.Add("overflow_damage", overflow_damage_atk);

                stanima -= 5;
            }
            else
            {
                //not hit - dodge
                int d3 = dice.Next(1, 100);
                result.Add("hit", false);
                if (d3 <= (guard_tgt / (guard_tgt + dodge_tgt)) * 100)
                {
                    //guard();
                    result.Add("status", "gurad");
                }
                else
                {
                    //dodge();
                    result.Add("status", "dodge");
                }
                
                result.Add("damage", 0);
                stanima -= 2;
            }
            result.Add("stanima", stanima);
            dodge_times++;
            con_dodge_list[name_tgt] = dodge_times;
            con_dodge_adj = dodge_times * 5;
            combo++;
            con_atk_list[name_atk] = combo;
            combo_adj = combo * 5;
            return result;  //"部位,伤害,剩余耐力"
        }

        //获取实际在场回合数
        public int GetACTRound(TextBox enter_round, TextBox round)
        {
            int result;
            if (enter_round.Text != "")
            {
                if (round.Text != "")
                {
                    result = int.Parse(round.Text) - int.Parse(enter_round.Text);
                    return result;
                }
            }
            return 0;
        }

        //获取武器攻击
        public double GetWeaponAttack(double min_dmg, double max_dmg)
        {
            double damage;
            damage = dice.Next((int)min_dmg, (int)max_dmg);
            return damage;
        }

        //获取武器有效伤害
        public double GetEffectDamage(double weapon_damage, double effect_attr, double strenth_adj)
        {
            double effect_damage;
            effect_damage = weapon_damage * effect_attr * strenth_adj;
            return effect_damage;
        }

        //获取护甲损伤
        public double GetArmorDamage(double effect_damage, double break_armor_attr)
        {
            double armor_damage;
            armor_damage = effect_damage * break_armor_attr;
            return armor_damage;
        }

        //获取穿甲需求伤害
        public double GetAPRequiredDamage(double armor_damage, double armor, double break_armor_attr)
        {
            double ap_required_damage;
            if(armor_damage > armor)
            {
                ap_required_damage = armor / break_armor_attr;
            }
            else
            {
                ap_required_damage = -1;
            }
            return ap_required_damage;
        }

        //获取溢出伤害
        public double GetOverflowDamage(double ap_required_damage, double effect_damage)
        {
            double overflow_damage;
            overflow_damage = effect_damage - ap_required_damage;
            if(ap_required_damage == -1)
            {
                overflow_damage = 0;
            }
            if (overflow_damage < 0)
            {
                overflow_damage = 0;
            }
            return overflow_damage;
        }

        //获取剩余护甲
        public double GetRemainArmor(double armor, double armor_damage)
        {
            double remain_armor;
            remain_armor = armor - armor_damage;
            if (remain_armor < 0)
            {
                remain_armor = 0;
            }
            return remain_armor;
        }

        //获取穿甲伤害
        public double GetAPDamage(double effect_daamge, double ap_attr)
        {
            double ap_damage;
            ap_damage = effect_daamge * ap_attr;
            return ap_damage;
        }

        //获取护甲阻挡值
        public double GetArmorReducedDmg(double remain_armor)
        {
            double armor_reduce;
            armor_reduce = remain_armor * 0.1;
            return armor_reduce;
        }

        //获取有效穿甲伤害
        public double GetEffectAPDamage(double ap_damage, double armor_reduce)
        {
            double effect_ap_damage;
            effect_ap_damage = ap_damage - armor_reduce;
            if (effect_ap_damage < 0)
            {
                effect_ap_damage = 0;
            }
            return effect_ap_damage;
        }

        //获取肉体损伤
        public double GetBodyDamage(double effect_ap_damage, double overflow_damage)
        {
            double body_damage;
            body_damage = effect_ap_damage + overflow_damage;
            return body_damage;
        }
    }
}
