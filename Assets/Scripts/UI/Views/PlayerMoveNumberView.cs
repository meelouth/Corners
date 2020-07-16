using Core;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class PlayerMoveNumberView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nickname;
        [SerializeField] private TMP_Text moveNumberText;

        private Player _player;

        private void OnDisable()
        {
            _player = null;
        }
        
        public void BindPlayer(Player player)
        {
            _player = player;
            player.onStartMove += OnStartMove;

            nickname.text = player.Data.Name;
        }

        private void OnStartMove()
        {
            moveNumberText.text = _player.MoveNumber.ToString();
        }
    }
}
