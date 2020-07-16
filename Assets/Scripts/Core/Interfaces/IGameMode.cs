using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IGameMode
    {
        IEnumerable<PlayerData> GetPlayersData();
    }
}