using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace UI.Views
{
    public class PlayerMoveNumbersTabView : MonoBehaviour
    {
        private readonly List<PlayerMoveNumberView> _playerMoveNumberViews = new List<PlayerMoveNumberView>();
        private static PlayerMoveNumberView Prefab => Resources.Load<PlayerMoveNumberView>("Prefabs/UI/PlayerMoveNumberView");

        public PlayerMoveNumberView SpawnPlayerMoveNumberView(Player player)
        {
            var view = Instantiate(Prefab, transform);
            view.BindPlayer(player);
            _playerMoveNumberViews.Add(view);

            return view;
        }

        public List<PlayerMoveNumberView> SpawnPlayerMoveNumberViews(IEnumerable<Player> players)
        {
            return players.Select(SpawnPlayerMoveNumberView).ToList();
        }
    }
}
