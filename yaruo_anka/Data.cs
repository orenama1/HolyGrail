using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace yaruo_anka
{
    
    public class Data
    {
        CSV csvData_=new CSV("data.dat");
        int dataFileNum_ = 0;//ファイル数
        int dataCharactorNum_ = 0;//キャラクターの数
        const int dataLineNum_=6;//キャラのステータスの数//魔とかその辺
        List<string[]> data_=new List<string[]>();//読み込んだデータ
        readonly string applicationPath;
        public Data()
        {
            //dataLineNum_ = 6;//ひとまず6つ
           applicationPath = Application.ExecutablePath;
            string[][] s=csvData_.read();
            foreach(string[] data in s){
                data_.Add(data);
            }
           
           dataCharactorNum_=data_.Count;
        }
        public void saveCSV() { 

        }
        public void change(string[] s) {
            csvData_.change(s); 
        }
        public void delete(string[] s)
        {
            csvData_.delete(s);
        }
        Data(String path) {
            applicationPath = path;
        }
        //キャラのステータスの取り出し
        public string[] getData(int data_num)
        {
            //           string[] files = System.IO.Directory.GetFiles(
            //   applicationPath, "*.csv", System.IO.SearchOption.TopDirectoryOnly);
            //string[] charactor_data = new string[dataLineNum_];
            //            string[] charactor_data = data_[data_num];
            if (data_num > dataCharactorNum_) 
            {
                data_num = dataCharactorNum_;
            }
            return data_[data_num];
        }
        //ファイル数を取り出す
        public int getMaxFileNum()
        {
            return dataFileNum_;
        }
        //キャラクターの数
        public int getMaxCharactorNum()  
        {
            return dataCharactorNum_;
        }
        public void setNewCharactor(string [] s) {
            data_.Add( s);
            dataCharactorNum_++; 
            csvData_.write(s);
            
        }
        /*
        //ファイル
        public void setCVSFile()
        {
            clearAllData();
            string[] cvs_file_list = getCSVDirectory();
            dataFileNum_ = cvs_file_list.Length;
            for (int i = 0; i < dataFileNum_; i++)
            {
                setCVSData(cvs_file_list[i], i);
            }
        }
        string[] getCSVDirectory()
        {
            string[] directryames = System.IO.Directory.GetFiles(
    applicationPath, "*.csv", System.IO.SearchOption.TopDirectoryOnly);
            return directryames;
        }
        void clearAllData()
        {
            data_.Initialize();
        }
        //csvファイルの数値をひとつづつ取り出す
        void addData(string data, int datanum)
        {
            data_[datanum] = data.Split(',');
        }
        //指定のファイルの中身を取り出す
        string getFileString(string filename)
        {
            StreamReader sr = new StreamReader(
       filename, Encoding.GetEncoding("Shift_JIS"));

            string text = sr.ReadToEnd();

            sr.Close();
            return text;
        }
        //csvデータを取込む
        void setCVSData(string filename, int datanum)
        {
            string s = getFileString(filename);
            if (null == s) return;
            addData(s, datanum);
        }
        //*/


    }
}
