using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace yaruo_anka
{
    
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        controller _Contlooler;
        public UserControl1()
        {
            InitializeComponent();
            _Contlooler = new controller();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GetPlayer(object sender, RoutedEventArgs e)
        {
            _Contlooler.AddCharactorToParty(CharactorList, PartyList1);
            _Contlooler.ResultUpdate(ResultText);
        }

        private void Cansel(object sender, RoutedEventArgs e)
        {
            _Contlooler.DeleteCharactor(PartyList1);
            _Contlooler.ResultUpdate(ResultText);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _Contlooler.AddCharactorToParty(CharactorList, PartyList2);
            _Contlooler.ResultUpdate(ResultText);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _Contlooler.DeleteCharactor(PartyList2);
            _Contlooler.ResultUpdate(ResultText);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Contlooler.ChangeSubCharctorStetasMult(SubPatryState);
            _Contlooler.ResultUpdate(ResultText);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            _Contlooler.AddNewCharactor(CharactorList);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _Contlooler.DeleteCharactor(CharactorList);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            _Contlooler.CangeCharactor(CharactorList);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _Contlooler.SetParamSelectCheckList(SelectParam1);
            _Contlooler.ResultUpdate(ResultText);

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            _Contlooler.SetParamSelectCheckList(SelectParam2);
            _Contlooler.ResultUpdate(ResultText);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            _Contlooler.SetParamSelectCheckList(SelectParam3);
            _Contlooler.ResultUpdate(ResultText);
        }
    }
}
