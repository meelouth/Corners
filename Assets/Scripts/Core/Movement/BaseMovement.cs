using System.Collections.Generic;
using System.Linq;
using Core.Movement.Animation;
using Map;
using UnityEngine;

namespace Core.Movement
{
    public abstract class BaseMovement : MonoBehaviour, IMovement
    {
        protected abstract IEnumerable<Vector2Int> MovePattern { get; }
        
        private Vector2Int _position;
        private IMovementAnimation _movementAnimation;
        
        public void Move(Vector2Int newPosition)
        {
            _position = newPosition;
            _movementAnimation.Move(transform, new Vector3(newPosition.x,0 ,newPosition.y));
        }
        
        public IEnumerable<Cell> GetPossibleCellsToMove(Board board)
        {
            var possibleCells = new List<Cell>();

            foreach (var movePattern in MovePattern)
            {
                if (CheckPath(board, movePattern, out var cell))
                {
                    possibleCells.Add(cell);
                }   
            }
                
            return possibleCells;
        }

        public IMovementAnimation MovementAnimation
        {
            get => _movementAnimation;
            set => _movementAnimation = value;
        }

        public Vector2Int Position
        {
            get => _position;
            set => _position = value;
        }

        public bool IsMovePossible(Board board, Cell newPosition)
        {
            return GetPossibleCellsToMove(board).Contains(newPosition);
        }

        protected abstract bool CheckPath(Board board, Vector2Int direction, out Cell cell);
    }
}
