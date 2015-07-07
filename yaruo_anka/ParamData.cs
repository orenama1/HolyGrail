using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaruo_anka
{
    class ParamData
    {
        static ParamData _intern=new ParamData();
        //耐とかのパラメータ名
        static List<string> _ParamList;
        static int _PalamLength;
        public static void SetParam(List<string> data)
        {
            _ParamList = data;
            _PalamLength = data.Count;
        }
        public int Length { get { return _PalamLength; } }
         public string GetParamName(int i)
         {
             if (i > _PalamLength) return null;
             return _ParamList.ElementAt(i);
         }
        public static ParamData Create() {
            if (_intern == null) _intern = new ParamData();
            return _intern;

        }
         ParamData()
        {
            
        }
    }
}
