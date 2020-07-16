using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class TurnBase: IDisposable
    {
        private List<Player> _players = new List<Player>();
        private int _makingAMovePlayerIndex;

        public Action<Player> OnEndTurn;

        public Player MakingAMovePlayer => _players[_makingAMovePlayerIndex];
        
        public void RegisterPlayers(List<Player> players)
        {
            _players = players;

            foreach (var player in _players)
            {
                player.onMove += OnMove;
            }
        }

        public void StartLoop()
        {
            DisableAllPlayers();
            
            _players.First().StartTurn();
            _makingAMovePlayerIndex = 0;
        }

        private void NextTurn()
        {
            MakingAMovePlayer.EndTurn();
            OnEndTurn?.Invoke(MakingAMovePlayer);
            GetPlayerMakingTheNextMove().StartTurn();
        }
        
        public void Dispose()
        {
            foreach (var player in _players)
            {
                player.onMove -= OnMove;
            }
        }

        private void DisableAllPlayers()
        {
            foreach (var player in _players)
            {
                player.Active = false;
            }
        }
        
        private void OnMove()
        {
            NextTurn();
        }

        private Player GetPlayerMakingTheNextMove()
        {
            if (++_makingAMovePlayerIndex >= _players.Count)
            {
                _makingAMovePlayerIndex = 0;
            }

            return MakingAMovePlayer;
        }
    }
}
