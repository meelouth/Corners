using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class HotSeat : GameMode
    {
        [SerializeField] private MatchSettings matchSettings;

        public override IEnumerable<PlayerData> GetPlayersData()
        {
            return matchSettings.PlayersData;
        }
    }
}
