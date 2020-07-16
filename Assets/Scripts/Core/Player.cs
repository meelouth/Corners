using System;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData data;
        
        public Action onStartMove;
        public Action onMove;
        
        public int MoveNumber { get; private set; }
        public PlayerData Data => data;

        public void Initialize(PlayerData playerData)
        {
            data = playerData;
        }

        public bool Active
        {
            set => data.PlayerController.enabled = value;
        }

        public void StartTurn()
        {
            Active = true;
            MoveNumber++;
            
            onStartMove?.Invoke();
        }

        public void EndTurn()
        {
            Active = false;
        }
    }
}
