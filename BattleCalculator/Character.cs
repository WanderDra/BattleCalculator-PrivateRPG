using BattleCalculator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCalculator
{
    class Character
    {
        private string name;                        //角色名称
        private string player_lv;                      //等级                    *
        private string strenth;                     //力量                    *
        private string swift;                       //敏捷                    *
        private string bright;                      //才智                    *
        private string stamina;                     //体能                    *
        private string health;                      //健康                    *
        private string determination;               //决心                    *
        private string intelligence;                //智力                    *
        private string skill_point;                    //技能点
        private string weight;                      //负重                    *
        private string weapon_skill_lv;            //武器技能等级            *
        private string dodge_skill_lv;             //回避技能等级            *
        private string guard_skill_lv;             //格挡技能等级            *
        private string damageMin, damageMax;        //伤害范围                *
        private string effect_attr;             //有效系数                *
        private string pierce_attr;             //穿甲系数                *
        private string break_attr;              //破甲系数                *
        private string body_armor;                  //身体护甲值              *
        private string body_armor_type;             //身体护甲类型            *
        private string head_armor;                  //头部护甲值              *
        private string head_armor_type;             //头部护甲类型            *
        private string remain_stamina;              //剩余耐力                *
        private string hp;                          //HP
        private string enter_round;

        Util ul;

        public Character()
        {
            name = "";
            player_lv = "";
            strenth = "";
            swift = "";
            bright = "";
            stamina = "";
            health = "";
            determination = "";
            intelligence = "";
            skill_point = "";
            weight = "";
            weapon_skill_lv = "";
            dodge_skill_lv = "";
            guard_skill_lv = "";
            damageMax = "";
            damageMin = "";
            effect_attr = "";
            pierce_attr = "";
            break_attr = "";
            body_armor = "";
            body_armor_type = "";
            head_armor = "";
            head_armor_type = "";
            remain_stamina = "";
            hp = "";
            enter_round = "";


            ul = new Util();
        }

        public string Name { get => name; set => name = value; }
        public string Player_lv { get => player_lv; set => player_lv = value; }
        public string Strenth { get => strenth; set => strenth = value; }
        public string Swift { get => swift; set => swift = value; }
        public string Bright { get => bright; set => bright = value; }
        public string Stamina { get => stamina; set => stamina = value; }
        public string Health { get => health; set => health = value; }
        public string Determination { get => determination; set => determination = value; }
        public string Intelligence { get => intelligence; set => intelligence = value; }
        public string Skill_point { get => skill_point; set => skill_point = value; }
        public string Weight { get => weight; set => weight = value; }
        public string Weapon_skill_lv { get => weapon_skill_lv; set => weapon_skill_lv = value; }
        public string Dodge_skill_lv { get => dodge_skill_lv; set => dodge_skill_lv = value; }
        public string Guard_skill_lv { get => guard_skill_lv; set => guard_skill_lv = value; }
        public string DamageMin { get => damageMin; set => damageMin = value; }
        public string DamageMax { get => damageMax; set => damageMax = value; }
        public string Effect_attr { get => effect_attr; set => effect_attr = value; }
        public string Pierce_attr { get => pierce_attr; set => pierce_attr = value; }
        public string Break_attr { get => break_attr; set => break_attr = value; }
        public string Body_armor { get => body_armor; set => body_armor = value; }
        public string Body_armor_type { get => body_armor_type; set => body_armor_type = value; }
        public string Head_armor { get => head_armor; set => head_armor = value; }
        public string Head_armor_type { get => head_armor_type; set => head_armor_type = value; }
        public string Remain_stamina { get => remain_stamina; set => remain_stamina = value; }
        public string Hp { get => hp; set => hp = value; }
        public string Enter_round { get => enter_round; set => enter_round = value; }

        public void Save()
        {
            ul.AddAttrToSaveList("Name", name);
            ul.AddAttrToSaveList("Player_lv", player_lv);
            ul.AddAttrToSaveList("Strenth", strenth);
            ul.AddAttrToSaveList("Swift", swift);
            ul.AddAttrToSaveList("Bright", bright);
            ul.AddAttrToSaveList("Stamina", stamina);
            ul.AddAttrToSaveList("Health", health);
            ul.AddAttrToSaveList("Determination", determination);
            ul.AddAttrToSaveList("Intelligence", intelligence);
            ul.AddAttrToSaveList("Skill_point", skill_point);
            ul.AddAttrToSaveList("Weight", weight);
            ul.AddAttrToSaveList("Weapon_skill_lv", weapon_skill_lv);
            ul.AddAttrToSaveList("Dodge_skill_lv", dodge_skill_lv);
            ul.AddAttrToSaveList("Guard_skill_lv", guard_skill_lv);
            ul.AddAttrToSaveList("DamageMin", damageMin);
            ul.AddAttrToSaveList("DamageMax", damageMax);
            ul.AddAttrToSaveList("Effect_attr", effect_attr);
            ul.AddAttrToSaveList("Pierce_attr", pierce_attr);
            ul.AddAttrToSaveList("Break_attr", break_attr);
            ul.AddAttrToSaveList("Body_armor", body_armor);
            ul.AddAttrToSaveList("Body_armor_type", body_armor_type);
            ul.AddAttrToSaveList("Head_armor", head_armor);
            ul.AddAttrToSaveList("Head_armor_type", head_armor_type);
            ul.AddAttrToSaveList("Remain_stamina", remain_stamina);
            ul.AddAttrToSaveList("Hp", hp);
            ul.AddAttrToSaveList("Enter_round", enter_round);
            ul.SaveCharacter(name);
            ul.ClearSaveList();
        }

        public void Read(string name)
        {
            ul.ClearSaveList();
            ul.ReadCharacter(name);
            this.name = ul.GetAttrInSaveList("Name").ToString();
            player_lv = ul.GetAttrInSaveList("Player_lv").ToString();
            strenth = ul.GetAttrInSaveList("Strenth").ToString();
            swift = ul.GetAttrInSaveList("Swift").ToString();
            bright = ul.GetAttrInSaveList("Bright").ToString();
            stamina = ul.GetAttrInSaveList("Stamina").ToString();
            health = ul.GetAttrInSaveList("Health").ToString();
            determination = ul.GetAttrInSaveList("Determination").ToString();
            intelligence = ul.GetAttrInSaveList("Intelligence").ToString();
            skill_point = ul.GetAttrInSaveList("Skill_point").ToString();
            weight = ul.GetAttrInSaveList("Weight").ToString();
            weapon_skill_lv = ul.GetAttrInSaveList("Weapon_skill_lv").ToString();
            dodge_skill_lv = ul.GetAttrInSaveList("Dodge_skill_lv").ToString();
            guard_skill_lv = ul.GetAttrInSaveList("Guard_skill_lv").ToString();
            damageMin = ul.GetAttrInSaveList("DamageMin").ToString();
            damageMax = ul.GetAttrInSaveList("DamageMax").ToString();
            effect_attr = ul.GetAttrInSaveList("Effect_attr").ToString();
            pierce_attr = ul.GetAttrInSaveList("Pierce_attr").ToString();
            break_attr = ul.GetAttrInSaveList("Break_attr").ToString();
            body_armor = ul.GetAttrInSaveList("Body_armor").ToString();
            body_armor_type = ul.GetAttrInSaveList("Body_armor_type").ToString();
            head_armor = ul.GetAttrInSaveList("Head_armor").ToString();
            head_armor_type = ul.GetAttrInSaveList("Head_armor_type").ToString();
            remain_stamina = ul.GetAttrInSaveList("Remain_stamina").ToString();
            hp = ul.GetAttrInSaveList("Hp").ToString();
            enter_round = ul.GetAttrInSaveList("Enter_round").ToString();
        }
    }
}
