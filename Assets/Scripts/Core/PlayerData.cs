using Helpers;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public struct PlayerData
    {
        [SerializeField] private string name;
        [SerializeField] private Color32 color;
        private PlayerController _playerController;
        [SerializeField] private FiguresGrid[] figuresPlacement;

        public string Name => name;
        public Color32 Color => color;
        public PlayerController PlayerController
        {
            get  => _playerController;
            set => _playerController = value;
        }

        public int[,] FiguresPlacement
        {
            get
            {
                var figuresGrid = new int[figuresPlacement.Length,figuresPlacement[0].column.Length]; // TODO refactor
                
                for (var i = 0; i < figuresPlacement.Length; i++)
                {
                    for (var j = 0; j < figuresPlacement[i].column.Length; j++)
                    {
                        figuresGrid[i, j] = figuresPlacement[i].column[j];
                    }
                }
                return figuresGrid;
            }

            private set
            {
                for (var i = 0; i < value.GetUpperBound(0); i++)
                {
                    for (var j = 0; j < value.GetUpperBound(1); j++)
                    {
                        figuresPlacement[i].column[j] = value[i, j];
                    }
                }
            }
        }

        public PlayerData(string name, Color color, int[,] figuresPlacement, PlayerController playerController) : this()
        {
            this.name = name;
            this.color = color;
            _playerController = playerController;
            FiguresPlacement = figuresPlacement;
        }
    }
}
