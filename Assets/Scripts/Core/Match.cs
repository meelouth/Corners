using System;
using System.Collections.Generic;
using System.Linq;
using Map;
using UI;

namespace Core
{
    public class Match : IDisposable
    {
        private Action<Player> _onWin;
        
        private readonly TurnBase _turnBase = new TurnBase();
        
        private readonly Dictionary<Player, int[,]> _playersFigurePlacement = new Dictionary<Player, int[,]>();

        private readonly Board _board;
        private readonly HUD _hud;

        public Match(Board board, HUD hud)
        {
            _board = board;
            _turnBase.OnEndTurn += OnEndTurn;

            _hud = hud;
        }

        public void ConnectPlayers(List<Player> players)
        {
            _turnBase.RegisterPlayers(players);

            foreach (var player in players)
            {
                _playersFigurePlacement.Add(player, player.Data.FiguresPlacement);
            }
            
            _hud.CreateUI(players);
            
            _onWin += player => _hud.WinPageView.Show(player.Data.Name);
        }

        public void StartMatch()
        {
            _turnBase.StartLoop();
        }

        public void Dispose()
        {
            _turnBase.OnEndTurn -= OnEndTurn;
            _onWin -= player => _hud.WinPageView.Show(player.Data.Name);
        }
        
        private bool IsPlayerWIn(Player player)
        {
            var enemiesFiguresPlacement = GetEnemiesFiguresPlacement(player);

            return enemiesFiguresPlacement.Any(enemiesPlacement => _board.GetPlayerFigurePlacements(player).Cast<int>().SequenceEqual(enemiesPlacement.Value.Cast<int>()));
        }
        
        private void OnEndTurn(Player player)
        {
            if (IsPlayerWIn(_turnBase.MakingAMovePlayer))
            {
                _onWin?.Invoke(player);
            }
        }

        private Dictionary<Player, int[,]> GetEnemiesFiguresPlacement(Player player)
        {
            var enemiesFiguresPlacement = _playersFigurePlacement.ToDictionary(entry => entry.Key,
                entry => entry.Value);
            enemiesFiguresPlacement.Remove(player);

            return enemiesFiguresPlacement;
        }
        
    }
}
