using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace yaruo_anka
{
    class controller
    {
        ParamData _Params;
        PlayerData _Players;
        DataList _PlayerList;
        SkilData _Skils;

        public controller()
        {
            _Params = ParamData.Create();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResultUpdate(RichTextBox resultView)
        {

        }

        /// <summary>
        /// パラメータ名のセット
        /// パラメータはキャラクターの耐や魔などのステータス名のこと
        /// </summary>
        /// <param name="data"></param>
        public void SetParam(string[] data)
        {
            ParamData.SetParam(data.ToList());
        }
        /// <summary>
        /// partyListに表示するパラメータをセット
        /// </summary>
        /// <param name="partyList"></param>
        public void SetListViewItemParamSetting(ListView partyList)
        {
        }
        /// <summary>
        /// パラメータ選択するボタン(ラジオボタン)を設定
        /// </summary>
        /// <param name="paramSelectBox"></param>
        public void SetParamSelectCheckList(GroupBox paramSelectBox)
        {

        }
        /// <summary>
        /// 新しいキャラクターを作ってcharactorListに追加
        /// </summary>
        /// <param name="charactorList"></param>
        public void AddNewCharactor(ListView charactorList)
        {

        }
        /// <summary>
        /// charactorListから選択したキャラクターを削除
        /// </summary>
        /// <param name="charactorList"></param>
        public void DeleteCharactor(ListView charactorList)
        {

        }
        /// <summary>
        /// charactorListから選択したキャラクターを編集
        /// </summary>
        /// <param name="charactorList"></param>
        public void CangeCharactor(ListView charactorList)
        {

        }
        /// <summary>
        /// charactorListから選択したキャラクターをpartyListに追加
        /// </summary>
        /// <param name="charactorList"></param>
        /// <param name="partyList"></param>
        public void AddCharactorToParty(ListView charactorList, ListView partyList)
        {

        }
        //DeleteCharactorと動きは同じだろう
        //public void DeletePartyCharactor(ListView partyList)
        //{

        //}

        /// <summary>
        /// GroupBox内のラジオボタンを使用しているのでそこの名前使えば何番目のステータスが変わったかわかる
        /// </summary>
        /// <param name="battleParamBox"></param>
        public void SetBattleParam(GroupBox battleParamBox)
        {

        }
        /// <summary>
        /// number番目のparamに変更する
        /// numberの指定やparamの指定が煩雑?
        /// </summary>
        /// <param name="number"></param>
        /// <param name="param"></param>
        public void SetBattleParam(int number,int param)
        {

        }
        /// <summary>
        /// 結果のpartyListの名前を変える
        /// </summary>
        /// <param name="partyList"></param>
        /// <param name="partyName"></param>
        public void SetPartyName(ListView partyList, string partyName)
        {

        }
        /// <summary>
        /// パーティーのリーダー以外のキャラのステータス補正率を変える
        /// </summary>
        /// <param name="mult"></param>
        public void ChangeSubCharctorStetasMult(TextBox mult)
        {

        }
        /// <summary>
        /// 結果をセットする
        /// </summary>
        /// <param name="resultView"></param>
        public void Result(RichTextBox resultView)
        {

        }
    }
}
