using System.Collections.Generic;
using Map;
using UnityEngine;

namespace Core.Movement
{
    public abstract class JumpOverMovement : BaseMovement
    {
        protected override bool CheckPath(Board board,Vector2Int direction, out Cell cell)
        {
            var nextCellPosition = Position + (direction * 2);

            cell = null;

            if (!board.IsCellExistAtPosition(nextCellPosition))
            {
                return false;
            }

            if (board.Cells[nextCellPosition.x, nextCellPosition.y] == null) 
                return false;

            if (!board.Cells[Position.x + direction.x, Position.y + direction.y].IsBusy) 
                return false;

            if (board.Cells[nextCellPosition.x, nextCellPosition.y].IsBusy) 
                return false;
            
            cell = board.Cells[nextCellPosition.x, nextCellPosition.y];
            return true;

        }
    }
}
