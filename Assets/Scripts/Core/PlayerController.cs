using Map;
using UnityEngine;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Board board;

        private Camera _mainCamera;
        private Player _player;
        private Figure _selectedFigure;
        
        private const int MouseButton = 0;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            ThrowRaycast();
        }

        public void Initialize(Board board, Player player)
        {
            this.board = board;
            _player = player;
        }

        private void ThrowRaycast()
        {
            if (!Input.GetMouseButtonDown(MouseButton)) 
                return;
            
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit)) 
                return;
            
            if (hit.collider.TryGetComponent<Figure>(out var figure))
            {
                OnClick(figure);
                return;
            }

            if (hit.collider.TryGetComponent<Cell>(out var cell))
            {
                OnClick(cell);
            }
        }

        private void OnClick(Cell cell)
        {
            if (_selectedFigure == null)
            {
                return;
            }

            if (cell.IsBusy)
            {
                _selectedFigure = cell.figure;
                return;
            }

            if (!_selectedFigure.movement.IsMovePossible(board, cell)) 
                return;
            
            _selectedFigure.Cell.Unhighlight();
            _selectedFigure.UnhighlightPossibleMovement(board);
            _selectedFigure.Move(cell);
            _selectedFigure = null;
        }

        private void OnClick(Figure figure)
        {
            _selectedFigure?.UnhighlightPossibleMovement(board);
            _selectedFigure?.Cell.Unhighlight();

            
            if (figure.controllingPlayer != _player)
            {
                return;
            }
            
            figure.OnClicked(board);
            _selectedFigure = figure;
        }
    }
}
