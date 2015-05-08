using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yaruo_anka
{
    public partial class Form2 : Form
    {

        string[] paramBackUp;
        int paramuNum;
        
        Form1 form1_;
        Data data_;
       

        void setLabelAndTextBox(int state_num,int num) {
            Label label = new Label();
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(90, 20 + 30 * num);
            textBox.Name = "textBox" + num;
            textBox.Size = new System.Drawing.Size(100, 19);
            textBox.TabIndex = num + 1;
            textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 20 + 30 * num);
            label.Name = "label" + num;
            label.Size = new System.Drawing.Size(58, 12);
            label.TabIndex = state_num + num + 1;
            label.Text = "ステータス" + (num + 1);

            this.Controls.Add(label);
            this.Controls.Add(textBox);
        }
        void formInit(int state_num) {
            int ichi = 20, sa = 30;
            for (int i = 2; i < state_num; i++)
            {

                setLabelAndTextBox(state_num,i);
                //Label label = new Label();
                //TextBox textBox = new TextBox();
                //textBox.Location = new System.Drawing.Point(90, 20+30*i);
                //textBox.Name = "textBox"+i;
                //textBox.Size = new System.Drawing.Size(100, 19);
                //textBox.TabIndex = i+1;
                //textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

                //label.AutoSize = true;
                //label.Location = new System.Drawing.Point(10, 20 + 30 * i);
                //label.Name = "label"+i;
                //label.Size = new System.Drawing.Size(58, 12);
                //label.TabIndex = state_num + i+1;
                //label.Text = "ステータスi+1";
    
                //this.Controls.Add(label);
                //this.Controls.Add(textBox);
            }

            Point pt = button1.Location;
            pt.Y = 20 + 30 * state_num;
            button1.Location = pt;      
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }
        
       
        
        

        public Form2(Form1 form1)
        {
            InitializeComponent();
            form1_ = form1;
            setLabel(form1_.getState());
        }
        void setLabel(string[] s)
        {
            formInit(s.Length);
            paramuNum = s.Length;
            setControls("label", s);
            
        }
        Control getContlol(string contolol_name) {
            return this.Controls.Find(contolol_name, false)[0];
        }
        Control[] getControls(string control_class) {
            List<Control> controls = new List<Control>();
            for (int i = 0; i < paramuNum; i++)
            {

                controls.Add(getContlol(control_class + i));
            }
            return controls.ToArray();
        }
        void setControls(string control_class,string[] set_str)
        {
            for (int i = 0; i < paramuNum; i++)
            {

                this.Controls.Find(control_class + i, false)[0].Text = set_str[i];
            }


        }
        public void createCharactorMode(Data data) 
        {
            data_ = data;
        }
        public void setMode(string s) {
            button1.Text = s;
        }
        public void setListViewItem(string[] s)
        {
            paramBackUp = s;
           setControls("textBox",s);

        }

       
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text.ToString().Equals("作成")) return;
            TextBox tc = (TextBox)sender;
            int number = (tc.TabIndex) - 1;
            if (!tc.Text.Equals(paramBackUp[number]) || !isParamBackUp())
            {
                button1.Text = "変更";
            }
        }

        bool isToData(string control_class)
        {


            int count = 0;
            for (int i = 1; i < paramuNum; i++)
            {
                Control con = this.getContlol(control_class + i);
                if (!int.TryParse(con.Text, out count)) return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("作成")) {
                if (textBox0.Text.ToString().Equals("") || !isToData("textBox")) return;
                //if(!isToData("textBox"))return;
                Control[] cons= getControls("textBox");
                string s = FormTool.changeCSVstringsTostring(cons);
                //string s="";
                //int count=0;
                //foreach(Control con in cons){
                //    s+=con.Text ;
                //    if(count!=cons.Length-1){
                //        s += ",";
                //    }
                //}
                //s = s.Substring(0, s.Length - 1);
                
                form1_.setCharactorData(s);
            }
            //if (button1.Text.ToString().Equals("変更"))
            //{
            //    int i;
            //    if (textBox0.Text.ToString().Equals("") || !isToData("textBox")) return;
            //     string s = FormTool.changeCSVstringsTostring(cons);
            //    data_.change(s);
            //    form1_.setCharactorData(s);
            //}
            this.Close();
        }
        bool isParamBackUp() {
            for (int i = 1; i < paramuNum; i++)
            {
                Control con = getContlol("textBox" + i);
                string s=con.Text;
                if (s.Equals(paramBackUp[i])) return false;
            }
            return true;
        }
        
    }
}
