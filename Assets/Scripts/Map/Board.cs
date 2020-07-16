using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Map
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private int height = 8;
        [SerializeField] private int width = 8;

        [SerializeField] private float cellSize = 100f;

        [SerializeField] private Color32 darkCellColor = Color.black;
        [SerializeField] private Color32 lightCellColor = Color.white;

        private static Cell CellPrefab => Resources.Load<Cell>("Prefabs/Map/Cell");
        private static Figure FigurePrefab => Resources.Load<Figure>("Prefabs/Figure");

        private void Awake()
        {
            Setup();
        }

        public void Setup()
        {
            Setup(height,width);
        }

        public void Setup(int height, int width)
        {
            Cells = new Cell[height, width];

            var cellPrefab = CellPrefab;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    Cells[x, y] = SpawnCell(cellPrefab, x, y);
                }
            }
        }

        public void SpawnFigures(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                SpawnFigures(player);
            }
        }

        public bool IsCellExistAtPosition(Vector2Int position)
        {
            return position.x >= 0 && position.y >= 0 && position.x < width && position.y < height;
        }

        public int[,] GetPlayerFigurePlacements(Player player)
        {
            var figurePlacements = new int[width,height];

            for (var index0 = 0; index0 < Cells.GetLength(0); index0++)
            {
                for (var index1 = 0; index1 < Cells.GetLength(1); index1++)
                {
                    var cell = Cells[index0, index1];
                    if (cell.figure == null)
                    {
                        figurePlacements[index0, index1] = 0;
                    }
                    else
                    {
                        if (cell.figure.controllingPlayer == player)
                            figurePlacements[index0, index1] = 1;
                    }
                }
            }

            return figurePlacements;
        }

        public Cell[,] Cells { get; private set; }

        private Figure SpawnFigure(Figure figurePrefab, int x, int y)
        {
            var cell = Cells[x, y];
            var figure = Instantiate(figurePrefab, new Vector3(cell.Position.x, 0 ,cell.Position.y), Quaternion.identity);
            figure.movement.Position = cell.Position;
            cell.figure = figure;
            figure.Cell = cell;

            return figure;
        }
        
        
        private void SpawnFigures(Player player)
        {
            var bound0 = player.Data.FiguresPlacement.GetUpperBound(0);
            var bound1 = player.Data.FiguresPlacement.GetUpperBound(1);

            var figurePrefab = FigurePrefab;
            
            for (var y = 0; y <= bound0; y++)
            {
                for (var x = 0; x <= bound1; x++)
                {
                    if (player.Data.FiguresPlacement[x, y] != 1) 
                        continue;
                    
                    var figure = SpawnFigure(figurePrefab, x, y);
                    figure.Color = player.Data.Color;
                    figure.controllingPlayer = player;
                }
            }
        }

        private Cell SpawnCell(Cell cellPrefab, int x, int y)
        {
            var createdCell = Instantiate(cellPrefab, transform);
            createdCell.SetPosition(new Vector3((x * cellSize), 0,(y * cellSize)));

            if (IsCellDark(x,y))
            {
                createdCell.Color = darkCellColor;
                return createdCell;
            }

            createdCell.Color = lightCellColor;

            return createdCell;
        }

        private static bool IsCellDark(int x, int y)
        {
            return x % 2 == y % 2;
        }
    }
}
