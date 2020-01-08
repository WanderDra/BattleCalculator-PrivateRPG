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

        //获取回避值
        public double GetDodge(double dodge_skill_lv, double max_dodge)
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
        public double GetHitRate(double accuracy_atk, double accuracy_tgt, double initiative_tgt, double height_adj, double angle_adj, double combo_adj, double con_dodge_adj, double pinch_adj)
        {
            double hitrate;
            hitrate = (accuracy_atk * 2.0 / (accuracy_atk * 2.0 + accuracy_tgt + initiative_tgt / 4.0)) + height_adj + angle_adj + combo_adj + con_dodge_adj + pinch_adj;
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
                if (d3 <= (guard_tgt / (guard_tgt + dodge_tgt)) * 100)
                {
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


        public double GetArmorReducedDmg()
        {
            return 0;
        }
    }
}
