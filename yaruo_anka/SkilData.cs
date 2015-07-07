using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaruo_anka
{
    class SkilData
    {
        ParamData param;
        static int data;
        //ID
        int _ID;
        //Skil名
        string _Name;
        //スキルによる変化値
        int _Num;
        //変化ステータス名
        string _dataName;
        //処理＋とかーとか
        enum Prosess { Add, Sub, Multi, Divi, }
        Prosess _Poro;
        public SkilData(string name,int henka,string dataName,Prosess data) {
            _Name = name;
            _Num = henka;
            _dataName = dataName;
            _Poro = data;
        }
        public string[] GetStringListData()
        {
            string [] data=new string[5];
            data[0] = _ID.ToString();
            data[1] = _Name;
            data[2] = _Num.ToString();
            data[3] = _dataName;
            data[4] = _Poro.ToString();
            return data;
        }
    }
}
