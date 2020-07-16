using System.Collections.Generic;
using Map;
using UnityEngine;

namespace Core.Movement
{
    public class StepMovement : BaseMovement
    {
        protected override IEnumerable<Vector2Int> MovePattern { get; } = new List<Vector2Int>
        {
            new Vector2Int(1, 1),
            new Vector2Int(-1, -1),
            new Vector2Int(-1, 1),
            new Vector2Int(1, -1),
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };
        protected override bool CheckPath(Board board, Vector2Int direction, out Cell cell)
        {
            var newPosition = Position + direction;

            cell = null;
            
            if (!board.IsCellExistAtPosition(newPosition))
            {
                return false;
            }
            
            cell = board.Cells[newPosition.x, newPosition.y];

            
            return !cell.IsBusy;
        }
    }
}
