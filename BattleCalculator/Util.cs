using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;

namespace BattleCalculator.Properties
{
    class Util
    {
        private Hashtable attr_list { get; }        //存档参数表
        private string chara_path;
        public Util()
        {
            attr_list = new Hashtable();
            chara_path = Directory.GetCurrentDirectory() + "\\Characters\\";
        }

        //获取实际属性
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

        //获取文本框内浮点数
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

        //获取文本框内整数
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

        //累加
        public int Accumulate(int x)
        {
            int sum = 0;
            for (int i = 1; i <= x; i++)
            {
                sum += i;
            }
            return sum;
        }

        //添加参数至参数表
        public void AddAttrToSaveList(string attr_name, object value)
        {
            attr_list.Add(attr_name, value);
        }

        //移除参数表内参数
        public void RemoveAttrInSaveList(string attr_name)
        {
            attr_list.Remove(attr_name);
        }

        //获取参数表内参数
        public object GetAttrInSaveList(string attr_name)
        {
            object attr;
            if (attr_list.ContainsKey(attr_name))
            {
                attr = attr_list[attr_name];
            }
            else
            {
                attr = "";
            }
            return attr;
        }

        //清空参数表
        public void ClearSaveList()
        {
            attr_list.Clear();
        }

        public void SaveCharacter(string character_name)
        {
            FileStream fs;
            try
            {
                if (Directory.Exists(chara_path) == false)
                {
                    Directory.CreateDirectory(chara_path);
                }
                if (File.Exists(chara_path + character_name + ".cha") == false)
                {
                    fs = new FileStream(chara_path + character_name + ".cha", FileMode.CreateNew);
                }
                else
                {
                    fs = new FileStream(chara_path + character_name + ".cha", FileMode.Open);
                }
                StreamWriter sw = new StreamWriter(fs);
                foreach(DictionaryEntry attr in attr_list)
                {
                    sw.WriteLine(attr.Key + ":" + attr.Value);
                }
                sw.Flush();
                sw.Close();
                attr_list.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public Hashtable ReadCharacter(string character_name)
        {
            try
            {
                StreamReader sr = new StreamReader(chara_path + character_name + ".cha");
                string attr;
                string[] attr_value;
                ClearSaveList();
                while ((attr = sr.ReadLine())!= null)
                {
                    attr_value = attr.Split(':');
                    AddAttrToSaveList(attr_value[0], attr_value[1]);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return attr_list;
        }

    }
}
