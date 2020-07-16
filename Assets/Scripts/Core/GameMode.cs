using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Map;
using UI;
using UnityEngine;

namespace Core
{
    public abstract class GameMode : MonoBehaviour, IGameMode
    {
        [SerializeField] private Board board;
        [SerializeField] private HUD hud;

        public void StartGameMode()
        {
            var players = SpawnPlayers(GetPlayersData());
            var match = new Match(board, hud);
            match.ConnectPlayers(players);
            match.StartMatch();

            board.SpawnFigures(players);
        }
        
        public abstract IEnumerable<PlayerData> GetPlayersData();
        
        private List<Player> SpawnPlayers(IEnumerable<PlayerData> playersData)
        {
            return playersData.Select(SpawnPlayer).ToList();
        }

        private Player SpawnPlayer(PlayerData playerData)
        {
            var go = new GameObject(playerData.Name);
            var spawnedPlayer = go.AddComponent<Player>();
            
            var playerController = go.AddComponent<PlayerController>();
            playerController.Initialize(board,spawnedPlayer);
            playerData.PlayerController = playerController;
            
            spawnedPlayer.Initialize(playerData);

            return spawnedPlayer;
        }
    }
}