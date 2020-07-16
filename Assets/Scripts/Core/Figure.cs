using System;
using Core.Movement;
using Core.Movement.Animation;
using Map;
using UnityEngine;

namespace Core
{
    public class Figure : MonoBehaviour
    {
        public IMovement movement;
        public Player controllingPlayer;
        public Cell Cell { get; set; }

        [SerializeField] private CellHighlightsPalette cellHighlightsPalette;

        private void Awake()
        {
            movement = GetComponent<IMovement>();
        }

        public Color32 Color
        {
            set => GetComponent<MeshRenderer>().material.color = value;
        }

        public void Move(Cell cell)
        {
            Cell.figure = null;
            movement.Position = cell.Position;
            cell.figure = this;
            Cell = cell;
            movement.Move(cell.Position);
            
            controllingPlayer.onMove?.Invoke();

        }

        public void OnClicked(Board board)
        {
            Cell.Highlight(cellHighlightsPalette.selectedColor);
            HighlightPossibleMovement(board);
        }

        public void HighlightPossibleMovement(Board board)
        {
            foreach (var cell in movement.GetPossibleCellsToMove(board))
            {
                cell.Highlight(cellHighlightsPalette.possibleCellToMoveColor);
            }
        }
        
        public void UnhighlightPossibleMovement(Board board)
        {
            foreach (var cell in movement.GetPossibleCellsToMove(board))
            {
                cell.Unhighlight();
            }
        }

        public void SetMovement(IMovement newMovement, IMovementAnimation movementAnimation)
        {
            newMovement.Position = movement.Position;
            movement = newMovement;
            movement.MovementAnimation = movementAnimation;
        }
    }
}
