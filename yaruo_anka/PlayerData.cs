using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace yaruo_anka
{
    
using Statas = System.Collections.Generic.List<int>;
    
    class PlayerData
    {
        //PlayerのIDカウント用
        static int MaxPlayerCounter = 0;
        static void PlayerPlus() { MaxPlayerCounter++; }

        
        ParamData param;

        //PlayerのID
        int _PlimaryNumber;

        string _Name;
        int _Level;
        //パラメータの数値
        Statas _StatasList = new Statas();



        //dataをテキストから数値に変えたほうがいいか検討
        public PlayerData(string name, int level, Statas data)
        {
            _PlimaryNumber = MaxPlayerCounter;
            PlayerPlus();
            _Name = name;
            _Level = level;
            _StatasList = data;
        }
        //dataをテキストから数値に変えたほうがいいか検討
        public PlayerData(string name, string level, List<string> data)
        {
            _PlimaryNumber = MaxPlayerCounter;
            PlayerPlus();
            _Name = name;
            _Level = int.Parse(level);
            _StatasList = data.Select(x=>int.Parse(x)).ToList();
        }

        public int GetID()
        {
            return _PlimaryNumber;
        }

        //Player名取得
        public string GetName()
        {
            return this._Name;
        }
        //各パラメータ取得
        //エラーはｰ1で返す
        public int GetParam(int index)
        {
            if (index < 0) return -1;
            if (index > _StatasList.Count) return 0;
            int param=index==0?_Level:_StatasList.ElementAt(index-1);

            return param;
        }
        //パラメータ編集時に使用
        //intに変換する際をどうするか検討
        public bool SGetParam(int index,string data)
        {
            if (index < 0) return false;
               
            if (index == 0) { _Level = int.Parse(data); return true; }
            
            _StatasList.Insert(index - 1,int.Parse( data));
            _StatasList.RemoveAt(index);
                return true;
        }
        //データを文字列の配列に
        //保存やListViewに使える
        public string[] GetStringListData()
        {
            string[] data = new string[param.Length];
            for (int i = 0; i < param.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        data[i] = _Name;
                        break;
                    case 1:
                        data[i] = _Level.ToString();
                        break;
                    default:
                        data[i] = _StatasList.ElementAt(i - 2).ToString();
                        break;

                }
               
            }
            return data;
        }
    }
}
