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
    public partial class Form1 : Form
    {
        private Data data_=new Data();
        Form2 form2;//= new Form2();
        string[] charactorStete_;
        readonly int charactorStateMax ;
        const int selectParamStart = 2;
        struct Battle {
           public  List<int> list1,list2;
           public int[] select, sub, win_n_lose;
            
            public Battle(int capas) {
                list1 = Enumerable.Repeat<int>(0, capas).ToList();
                list2 = Enumerable.Repeat<int>(0, capas).ToList();
                select = new int[3];
                sub = new int[select.Length];
                win_n_lose = Enumerable.Repeat<int>(0, 3).ToArray();
            }
            public void compute()
            {
                for (int i = 0; i < select.Length; i++)
                {
                    int state1 = list1[select[i]], state2 = list2[select[i]];
                    sub[i] = state1 - state2;
                    if (sub[i] > 0)
                    {
                        win_n_lose[0]++;
                    }
                    else if (sub[i] == 0)
                    {
                        win_n_lose[1]++;
                    }
                    else
                    {
                        win_n_lose[2]++;
                    }
                }
            }

        }
        void initListColumHeader(ListView list) {
            for (int i = selectParamStart; i < charactorStete_.Length; i++)
            {
                ColumnHeader c = new ColumnHeader();
                c.Text = charactorStete_[i];
                c.Width = -2;
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                list.Columns.Add(c);
            }
        }
        void initGrupInRadioButton(GroupBox gb) {
            Point prevpoint=new Point(6,15);
            for (int i = selectParamStart; i < charactorStete_.Length; i++)
            {
                RadioButton rb = new RadioButton();
                
                rb.Text = charactorStete_[i];
                //rb.Size = new Size(40,20);
                rb.AutoSize = true;
                rb.Location = prevpoint;
                
                rb.UseVisualStyleBackColor = true;
                if (gb.Text.Equals("1st")) {
                    rb.CheckedChanged += new EventHandler(this.group1RadioButtonCheckedChanged);
                }
                else if (gb.Text.Equals("2nd")) {
                    rb.CheckedChanged += new EventHandler(this.group2RadioButtonCheckedChanged);
                }
                gb.Controls.Add(rb);
                prevpoint.X = rb.Right;

            }
            gb.Size = new Size(prevpoint.X , 40);
            if (gb.Right > richTextBox1.Left)
            {
                richTextBox1.Location = new Point(gb.Right+5, richTextBox1.Location.Y);
                this.Size = new Size(richTextBox1.Right + 10, this.Size.Height);
            }
        }
        void initcombobox(ComboBox cb)
        {
            cb.Items.AddRange(new object[]{charactorStete_});
            
        }
        public Form1()
        {
            CSV dat = new CSV("dat");
            CSV csv = new CSV("status.txt");
            string[][] str=csv.read();
            string[] status;
            
            try
            {
                
                string[] hoge=new string[2+str[0].Length];
                try
                {
                    string[][] s = dat.read();
                    hoge[0] = s[0][0];
                    hoge[1] = s[0][1];
                }
                catch (Exception e)
                {
                    hoge[0] = "名前";
                    hoge[1] = "レベル";
                }
                
                for (int i = 2; i < 2 + str[0].Length; i++) { 
                    hoge[i]=str[0][i-2];
                }

                    status = hoge;
                //form2 = new Form2(this);
            }
            catch(Exception e){  
            
                //charactorStete_ = new string[] { "名前", "レベル", "筋", "耐", "敏", "魔","運", "宝" };
                status=new string[] { "名前", "レベル", "筋", "耐", "敏", "魔", "運", "宝"};
            
            }
            this.charactorStete_ = status;
            this.charactorStateMax = this.charactorStete_.Length;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            initListColumHeader(this.listView);
            initListColumHeader(this.listView1);
            initListColumHeader(this.listView2);

            initGrupInRadioButton(this.groupBox1);
            initGrupInRadioButton(this.groupBox2);
            initGrupInRadioButton(this.groupBox3);
            //groupBoxTextInit(groupBox111);
            //groupBoxTextInit(groupBox2222);
            //groupBoxTextInit(groupBox3333);


           // listAdd(this.listView, (new string[] { "テストやる夫", "4545", "168", "58", "19", "401", "8" }));
            for (int i = 0; i < data_.getMaxCharactorNum(); i++)
            {
                listAdd(this.listView, (data_.getData(i)));
               
            }
            RadioButton r= (RadioButton)(this.groupBox1.Controls[0]) ;
            r.Checked = true;
        }
        public string[] getState()
        {
            return charactorStete_;
        }
        private void listAdd(ListView list, ListViewItem item)
        {


            listAdd(list,listchange(item));

        }
        private void listAdd(ListView list, string[] s)
        {
            string[] str = new string[this.charactorStateMax < s.Length ? s.Length : this.charactorStateMax];
            if (s.Length != charactorStateMax)
            {

                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = "0";
                }
                Array.Copy(s, str, s.Length);

            }
            else {
                str=s;
            }
            list.Items.Add(new ListViewItem(str, this.charactorStateMax - 1));

        }
        void deleteListSelectedItems(ListView list)
        {
            foreach (ListViewItem item in list.SelectedItems)
            {
                list.Items.Remove(item);
            }
            
        }
        string[] listchange(ListViewItem item)
        {
            string s = "";
            foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
            {
                if (!sub.Text.Equals(""))
                s += sub.Text + ",";
            }
            s =s.Substring(0, s.Length - 1);
            return s.Split(',');
        }
        //上のlistView1に追加
        private void button2_Click(object sender, EventArgs e)
        {
            

            if (0 == listView.SelectedItems.Count)
            {
                return;
            }
            foreach (ListViewItem item in this.listView.SelectedItems)
            {
                string s=item.SubItems[0].Text.ToString();
                //ListViewItem hoge= listView1.FindItemWithText(s,false,0);
                if (checkDouble(this.listView1, s, 0))
                {
                    
                    continue;
                }
                listAdd(this.listView1, item);
                setListViewGroup(this.listView1);
            }
            
        }

        bool checkDouble(ListView listView, string keyWord, int index)
        {
            List<ListViewItem> hitItemList = new List<ListViewItem>();
            foreach (ListViewItem item in listView.Items)
                if (item.SubItems[index].Text.Contains(keyWord))
                    return true; ;
            return false;
        }
       
        
        //下のlistView2に追加
        private void button5_Click(object sender, EventArgs e)
        {

            if (0 == this.listView.SelectedItems.Count)
            {
                return;
            }
            foreach (ListViewItem item in this.listView.SelectedItems)
            {
                string s = item.SubItems[0].Text.ToString();
               // ListViewItem hoge = listView1.FindItemWithText(s);
                if (checkDouble(this.listView2, s, 0))
                {

                    continue;
                }
                listAdd(this.listView2, item);
                setListViewGroup(this.listView2);
            }
        }
        void setListViewGroup(ListView list)
        {
            if(0==list.Items.Count)return;
            int group_num = 0;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (null == list.Items[i].Group)
                    list.Items[i].Group = list.Groups[group_num];
                if (0 == group_num) { group_num = 1; }
            }
            if (list.Items[0].Group != list.Groups[0]) {
                list.Items[0].Group = list.Groups[0];
            }

        }
        //上のlistView1に削除
        private void button3_Click(object sender, EventArgs e)
        {
            deleteListSelectedItems(this.listView1);
            setListViewGroup(this.listView1);

        }
        //下のlistView2に削除
        private void button4_Click(object sender, EventArgs e)
        {
            deleteListSelectedItems(this.listView2);
            setListViewGroup(this.listView2);
        }
        //保存
        public void setCharactorData(string data)
        {
            string[] split_data = data.Split(',');
            this.listView.Items.Add(new ListViewItem(split_data));
            this.data_.setNewCharactor(split_data);

        }
        //勝負！
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (0 == this.listView1.Items.Count || 0 == this.listView2.Items.Count)
                {
                    //richTextBox1.Text = "";
                    this.richTextBox1.Text = "キャラクターが選択されていません\n" + this.richTextBox1.Text;
                    return;
                }
                this.richTextBox1.Text = "";
                int cap = this.charactorStete_.Length - selectParamStart;
                Battle battle = new Battle(cap);

                //computeListParam(listView1,battle.list1);
                //computeListParam(listView2, battle.list2);
                battle.list1 = computeListParam(this.listView1);
                battle.list2 = computeListParam(this.listView2);



                battle.select[0] = getGroupChecked(this.groupBox1);
                battle.select[1] = getGroupChecked(this.groupBox2);
                battle.select[2] = getGroupChecked(this.groupBox3);

                //for (int i = 0; i < battle.select.Length; i++)
                //{
                //    int state1 = battle.list1[battle.select[i]], state2 = battle.list2[battle.select[i]];
                //    battle.sub[i] = state1 - state2;
                //    if (battle.sub[i] > 0)
                //    {
                //        battle.win_n_lose[0]++;
                //    }
                //    else if (battle.sub[i] == 0)
                //    {
                //        battle.win_n_lose[1]++;
                //    }
                //    else {
                //        battle.win_n_lose[2]++;
                //    }
                //}
                battle.compute();
                drawRichText(battle);
            }catch(Exception exep){
                richTextBox1.Text = "";
                this.richTextBox1.Text = "キャラクターが選択されていません\n" + this.richTextBox1.Text;

            }

        }
        void drawRichText(Battle bt)
        {
            int level1 =0,level2 = 0;
            if (!int.TryParse(this.listView1.Items[0].SubItems[1].Text, out level1))
            {
                level1 = 0;
            }
            if (!int.TryParse(this.listView2.Items[0].SubItems[1].Text, out level2))
            {
                level2 = 0;
            }
            //richTextBox1.Text += "プレイヤーレベル：" + level1 + "\nエネミーレベル：" + level2 + "\nレベル差：" + (level1 - level2);
            this.richTextBox1.Text += "レベル：" + level1 + "   VS   " + level2 + "\nレベル差：" + (level1 - level2);

            this.richTextBox1.Text += "\n戦力値差：" + bt.sub.Sum() + "\n基礎勝率" + winpars(bt.win_n_lose) + "\n";

            for (int i = 0; i < bt.select.Length; i++)
            {
                int state1 = bt.list1[bt.select[i]], state2 = bt.list2[bt.select[i]];
                int param = bt.select[i] + selectParamStart;
               
                //richTextBox1.Text += "選択ステータス【" + charactorStete_[param] +"】\n"+ "・プレイヤー:" + state1 + "\n・エネミー：" + state2 + "\n・戦力差" + storong[i] + "・" + comp(state1, state2) + "\n";
                this.richTextBox1.Text += "選択ステータス:【" + this.charactorStete_[param] + "】" + state1 + "   VS   " + state2 + "　　　・" + comp(state1, state2) + "\n";
            }
        }
        int winpars(int[] i) {
            int pars = 0;
            if (3 == i[0]) {
                pars = 100;
            }
            if (2 == i[0]) {
                if (1 == i[1])
                {
                    pars = 80;
                }
                if (0 == i[1])
                {
                    pars = 70;
                }
            }
            if (1 == i[0])
            {
                if (2 == i[1])
                {
                    pars = 50;
                }
                if (1 == i[1])
                {
                    pars = 50;
                }
                if (0 == i[1])
                {
                    pars = 30;
                }
            }
            if (0 == i[0])
            {
                if (3 == i[1])
                {
                    pars = 50;
                }
                if (2 == i[1])
                {
                    pars = 40;
                }
                if (1 == i[1])
                {
                    pars = 20;
                }
                if (0 == i[1]) 
                {
                    pars = 0;
                }
            }
            return pars;
        }
        string getStates(int state1,int state2) {
            return "";
        }
        string comp(int i1, int i2) {
            string s;
            if (i1 > i2)
            {
                s = "優勢";
            }
            else if (i1 < i2)
            {
                s = "劣勢";
            }
            else 
            {
                s = "引き分け";
            }
            return s;
        }
        int getGroupChecked(GroupBox g) {
            int cap = this.charactorStete_.Length - selectParamStart;
            for (int i = 0; i < cap; i++)
            {
                if (((RadioButton)g.Controls[i]).Checked)
                {
                    return i;
                }
            }
            return this.charactorStete_.Length - selectParamStart;
        }
        void computeListParam(ListView list, List<int> comp) {
            int hoge = 0;
            int cap = this.charactorStete_.Length;
            
            foreach (ListViewItem item in list.Items)
            {
                
                    for (int i = 0; i < cap - selectParamStart; i++)
                    {
                        if (item.Group == list.Groups[0])
                            if (!int.TryParse(item.SubItems[i + selectParamStart].Text, out hoge))
                            {
                                comp[i] = 0;
                                //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                            }
                            else {
                                comp[i]=hoge;

                            }
                        else
                        {
                            if (!int.TryParse(item.SubItems[i + selectParamStart].Text, out hoge))
                            {
                                comp[i] = 0;
                                //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                            }
                            else
                            {
                                int hage = 0;
                                comp[i] = hoge;
                                if (!int.TryParse(textBox1.Text, out hage))
                                {
                                    comp[i] += hoge/2;
                                    //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                                }
                                else
                                {
                                    
                                    comp[i] += hoge/hage;

                                }
                               

                            }
                            //comp[i] += int.Parse(item.SubItems[i + selectParamStart].Text) / int.Parse(textBox1.Text);
                        }
                    }
                
                    
                
            }
        }
        List<int> computeListParam(ListView list)
        {
            List<int> comp = Enumerable.Repeat(0, this.charactorStete_.Length - selectParamStart).ToList();//new List<int>(charactorStete_.Length);
            int hoge = 0;
            int cap = this.charactorStete_.Length;

            foreach (ListViewItem item in list.Items)
            {

                for (int i = 0; i < cap - selectParamStart; i++)
                {
                    if (item.Group == list.Groups[0])
                        if (!int.TryParse(item.SubItems[i + selectParamStart].Text, out hoge))
                        {
                            comp[i] = 0;
                            //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                        }
                        else
                        {
                            comp[i] = hoge;

                        }
                    else
                    {
                        if (!int.TryParse(item.SubItems[i + selectParamStart].Text, out hoge))
                        {
                            comp[i] += 0;
                            //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                        }
                        else
                        {
                            int hage = 0;
                            //comp[i] = hoge;
                            if (!int.TryParse(textBox1.Text, out hage))
                            {
                                comp[i] += hoge / 2;
                                //comp[i] = int.Parse(item.SubItems[i + selectParamStart].Text);
                            }
                            else
                            {

                                comp[i] += hoge / hage;

                            }


                        }
                        //comp[i] += int.Parse(item.SubItems[i + selectParamStart].Text) / int.Parse(textBox1.Text);
                    }
                }



            }
            return comp;
        }
        private void groupBoxTextInit(GroupBox group) {
            int count = selectParamStart;
            foreach (RadioButton rb in group.Controls)
            {
                rb.Text = this.charactorStete_[count];
                count++;
                if (charactorStateMax==count)
                {
                    break;
                }
            }
        }

        private void checkButtonsEnable(GroupBox group,String text) {
            
            foreach (RadioButton rb in group.Controls)
            {
                if (rb.Text.Equals(text))
                {
                    rb.Enabled = false; ;
                    rb.Checked = false;
                }
            }
            checkButtonsChecked(group);
        }
        private void checkButtonsEnable(GroupBox group, String text,Boolean flag)
        {

            foreach (RadioButton rb in group.Controls)
            {
                if (rb.Text.Equals(text))
                {
                    rb.Enabled = flag;
                    if (!flag)
                    {
                        rb.Checked = flag;
                    }
                }
            }
            checkButtonsChecked(group);
        }

        private void checkButtonsChecked(GroupBox group)
        {
            Boolean check = false;
            foreach (RadioButton rb in group.Controls)
            {
                if (rb.Checked)
                {
                    check = true;
                }
            }
            if (!check) 
            {
                foreach (RadioButton rb in group.Controls) {
                    if (rb.Enabled) {
                        rb.Checked = true;
                        break;
                    }
                }
            }
        }


        private void group1RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked)
            {
                checkButtonsEnable(this.groupBox2, rb.Text, true);
                checkButtonsEnable(this.groupBox3, rb.Text, true);
            }
            else
            {
                checkButtonsEnable(this.groupBox2, rb.Text, false);
                checkButtonsEnable(this.groupBox3, rb.Text, false);
            }
        }
        private void group2RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked)
            {

                checkButtonsEnable(this.groupBox3, rb.Text, true);
            }
            else
            {

                checkButtonsEnable(this.groupBox3, rb.Text, false);
            }
        }



        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (0 == listView.SelectedItems.Count) return;
            if ((this.form2 == null) || this.form2.IsDisposed)
            {

                this.form2 = new Form2(this);

                

            }
            this.form2.Show();
            this.form2.setMode("閉じる");
            //form2.setListViewItem(listchange(listView.SelectedItems[0]));
            this.form2.setListViewItem(listchange(listView.SelectedItems[0]));
            
        }

        
        //プレイヤー作成
        private void button6_Click(object sender, EventArgs e)
        {
            if ((this.form2 == null) || this.form2.IsDisposed)
            {

                this.form2 = new Form2(this);

                

            }
            this.form2.Show();
            this.form2.setMode("作成");
            this.form2.createCharactorMode(data_);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (0 == this.listView.SelectedItems.Count) return;
            this.data_.delete(listchange(this.listView.SelectedItems[0]));
            deleteListSelectedItems(this.listView);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (0 == this.listView.SelectedItems.Count) return;
            if ((this.form2 == null) || this.form2.IsDisposed)
            {

                this.form2 = new Form2(this);



            }
            this.form2.Show();
            this.form2.setMode("閉じる");
            //form2.setListViewItem(listchange(listView.SelectedItems[0]));
            this.form2.setListViewItem(listchange(listView.SelectedItems[0]));
        }

        private void listView_MouseDoubleClick(object sender, EventArgs e)
        {
            if (0 == this.listView.SelectedItems.Count) return;
            if ((this.form2 == null) || this.form2.IsDisposed)
            {

                this.form2 = new Form2(this);



            }
            this.form2.Show();
            this.form2.setMode("閉じる");
            this.form2.setListViewItem(listchange(listView.SelectedItems[0]));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
       
    }
}
