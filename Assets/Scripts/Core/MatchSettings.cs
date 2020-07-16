using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Match Settings")]
    public class MatchSettings : ScriptableObject
    {
        [SerializeField] private List<PlayerData> playersData;

        public IEnumerable<PlayerData> PlayersData => playersData;
    }
}
