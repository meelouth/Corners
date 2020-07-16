using System.Collections.Generic;
using Core.Movement.Animation;
using Map;
using UnityEngine;

namespace Core.Movement
{
    public interface IMovement
    {
        void Move(Vector2Int newPosition);
        IEnumerable<Cell> GetPossibleCellsToMove(Board board);
        bool IsMovePossible(Board board, Cell newPosition);
        Vector2Int Position { get; set; }
        IMovementAnimation MovementAnimation { get; set; }
    }
}