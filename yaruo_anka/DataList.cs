using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaruo_anka
{
    class DataList
    {
        Dictionary<int, PlayerData> _PlayerData;
        public DataList()
        {
            List<PlayerData> data = new List<PlayerData>();
            _PlayerData = data.ToDictionary(x => x.GetID());
            
        }
        public PlayerData  GetPlayerData(int id) {
            return _PlayerData[id] ;
        }
        public void Add(string[] data)
        {
            var states = data.Skip(2).ToList();
            var player = new PlayerData(data[0], data[1], states);
            _PlayerData.Add(player.GetID(),player);
        }
    }
}
