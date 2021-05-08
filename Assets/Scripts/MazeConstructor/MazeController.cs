using UnityEngine;
using System.Collections.Generic;
using Interface;


namespace MazeConstructor
{
    public class MazeController : IStartExecute
    {
        #region Fields

        private readonly CellView _cell;
        private readonly int _width;
        private readonly int _height;
        private readonly Transform _placeForLevel;

        #endregion


        #region Methods

        public MazeController(CellView cell, int width, int height, Transform placeForLevel)
        {
            _cell = cell;
            _width = width;
            _height = height;
            _placeForLevel = placeForLevel;
        }

        private void SpawnMaze(CellView cell, int width, int height)
        {
            CellModel[,] maze = GenerateMaze(width, height);

            for(int x = 0; x < width; x++)
            {
                for(int z = 0; z < height; z++)
                {
                    CellView _cell = Object.Instantiate(cell, new Vector3(x, 0, z), Quaternion.identity, _placeForLevel);

                    _cell.wallLeft.SetActive(maze[x, z]._wallLeft);
                    _cell.wallBottom.SetActive(maze[x, z]._wallBottom);
                    _cell.floor.SetActive(maze[x, z]._floor);
                }
            }
        }

        private static CellModel[,] GenerateMaze(int width, int height)
        {
            var maze = new CellModel[width, height];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int z = 0; z < maze.GetLength(1); z++)
                {
                    maze[x, z] = new CellModel { X = x, Z = z };
                }
            }

            EulerCreateMaze(maze, width, height);
            
            CutEdges(maze, width, height);

            return maze;
        }

        private static void CutEdges(CellModel[,] maze, int width, int height)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                maze[x, height - 1]._wallLeft = false;
                maze[x, height - 1]._floor = false;
            }

            for (int z = 0; z < maze.GetLength(1); z++)
            {
                maze[width - 1, z]._wallBottom = false;
                maze[width - 1, z]._floor = false;
            }
        }
        
        private static void DeleteWalls(CellModel current, CellModel chosenOne)
        {
            if (current.X == chosenOne.X)
            {
                if (current.Z > chosenOne.Z)
                {
                    current._wallBottom = false;
                }
                else
                {
                    chosenOne._wallBottom = false;
                }
            }
            else
            {
                if (current.X > chosenOne.X)
                {
                    current._wallLeft = false;
                }
                else
                {
                    chosenOne._wallLeft = false;
                }
            }
        }
        
        private static void EulerCreateMaze(CellModel[,] maze, int _width, int _height)
        {
            CellModel currentCell = maze[0, 0];
            currentCell._visited = true;

            var stack = new Stack<CellModel>();

            do
            {
                var unvisited = new List<CellModel>();

                var x = currentCell.X;
                var z = currentCell.Z;

                if (x > 0 && !maze[x - 1, z]._visited) unvisited.Add(maze[x - 1, z]);
                if (z > 0 && !maze[x, z - 1]._visited) unvisited.Add(maze[x, z - 1]);

                if (x < _width - 2 && !maze[x + 1, z]._visited) unvisited.Add(maze[x + 1, z]);
                if (z < _height - 2 && !maze[x, z + 1]._visited) unvisited.Add(maze[x, z + 1]);


                if (unvisited.Count > 0)
                {
                    CellModel chosenCell = unvisited[Random.Range(0, unvisited.Count)];
                    DeleteWalls(currentCell, chosenCell);
                    chosenCell._visited = true;
                    stack.Push(chosenCell);
                    currentCell = chosenCell;
                }
                else
                {
                    currentCell = stack.Pop();
                }
            } while (stack.Count > 0);
        }
        
        public void StartExecute()
        {
            SpawnMaze(_cell, _width,_height);
        }

        #endregion
    }
}
