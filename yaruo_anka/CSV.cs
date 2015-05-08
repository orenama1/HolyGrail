using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaruo_anka
{
    public partial class CSV
    {
        struct csvData
        {
            string[] data_;
            public csvData(string[] s)
            {
                List<String> list = new List<String>(s); // 新インスタンスを生成
                list.Remove("");
                string[] temp = list.ToArray();
                data_ = temp;
            }
            public string[] read()
            {
                return data_;
            }
            public int length()
            {
                return data_.Length;
            }
        };
        readonly string filePath_;
        public CSV(string file_name)
        {

            // 相対パスから絶対パスを取得する
            filePath_ = System.IO.Path.GetFullPath(file_name);
            if (System.IO.File.Exists(filePath_))
            {
            }
            else
            {
                // hStream が破棄されることを保証するために using を使用する
                // 指定したパスのファイルを作成する
                using (System.IO.FileStream hStream = System.IO.File.Create(filePath_))
                {
                    // 作成時に返される FileStream を利用して閉じる
                    if (hStream != null)
                    {
                        hStream.Close();
                    }
                }
            }

        }

        public void clear() {
            //書き込むファイルが既に存在している場合は、ファイルの末尾に追加する
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
               filePath_,
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));

            sw.Write("");
            //閉じる
            sw.Close();
        }
        public string[][] read()
        {

            List<csvData> csv_list = new List<csvData>();
            System.IO.StreamReader cReader = (
           new System.IO.StreamReader(filePath_, System.Text.Encoding.GetEncoding("shift_jis")));


            while (cReader.Peek() >= 0)
            {

                // ファイルを 1 行ずつ読み込む
                string stBuffer = cReader.ReadLine();
                stBuffer.Trim();
                if (null == stBuffer||stBuffer.Equals("")) continue;
                if (stBuffer[0].Equals("#") || stBuffer[0].Equals("＃")) continue;
                // 読み込んだものを追加で格納する
                csv_list.Add(new csvData(stBuffer.Split(',')));

            }
            //string[][] csv_data = new string[csv_list.Count][];
            List<string[]> csv_data=new List<string[]>();
            
            foreach (var s in csv_list)
            {
                csv_data.Add(s.read());
                
            }

            cReader.Close();
            return csv_data.ToArray() ;

        }
        public void write(string [] csv_string) {
            //Shift JISで書き込む
            //書き込むファイルが既に存在している場合は、ファイルの末尾に追加する
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
               filePath_,
                true,
                System.Text.Encoding.GetEncoding("shift_jis"));

            string s = "";
            if (0 != csv_string.Length)
            {
                foreach (string str in csv_string)
                {
                    //TextBox1.Textの内容を書き込む
                    s += str + ",";

                }
                s = s.Substring(0, s.Length - 1);
            }
            s += "\n";
            sw.Write(s);
            //閉じる
            sw.Close();
        }
        public void delete(string[] csv_string)
        {
            string[][] s = read();
            
            List<string[]> list = new List<string[]>(s);

            foreach (string[] str in list.ToArray())
            {
                if (str.Length == 0)
                {
                    list.Remove(str); continue;
                }
                if (str[0].Equals(csv_string[0]))
                { list.Remove(str); }
            } 
            s = list.ToArray();
           
            writeAll(s);
        }
        public void writeAll(string[][] csv_string)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
               filePath_,
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            foreach(string[] strarry in csv_string){
                foreach (string s in strarry)
                {
                    //TextBox1.Textの内容を書き込む
                    sw.Write(s + ",");
                }
                sw.Write("\n");
            }
            
            sw.Close();
        }

        public void change(string[] csv_string)
        {
            delete(csv_string);
            write(csv_string);
        }
    }
}
