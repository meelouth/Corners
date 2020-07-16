using System.Collections.Generic;
using UnityEngine;

namespace Core.Movement
{
    public class HorizontalVerticalOverMovement : JumpOverMovement
    {
        protected override IEnumerable<Vector2Int> MovePattern { get; } = new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };
    }
}
