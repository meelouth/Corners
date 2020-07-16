using System.Collections.Generic;
using Core;
using UI.Views;
using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private PlayerMoveNumbersTabView playerMoveNumbersTabView;
        [SerializeField] private WinPageView winPageView;

        public WinPageView WinPageView => winPageView;

        public void CreateUI(IEnumerable<Player> players)
        {
            playerMoveNumbersTabView.SpawnPlayerMoveNumberViews(players);
        }
    }
}
