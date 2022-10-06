using System.Drawing;
using System.Collections.Generic;

namespace graphicGame
{
    /**
 * class Map - класс игрового поля
 * @param heightMap - высота поля
 * @param widthMap - ширина поля
 * @param figure - текущая фигура
 * @param nextFigure - следующая фигура
 * @param OtherFigures - осталльные фигуры поля
 * @param arrayCell - вектор игрового поля
 */
    internal class Map
    {
        public int heightMap;
        public int widthMap;
        public Figure currentFigure;
        public Figure nextFigure;
        public Figure OtherFigures;
        public Cell[,] arrayCell;
        public Cell[,] nextCells;

        /**
         * Map(int height, int width) - Конструктор класса поле
         * @param height - задаём длину
         * @param width  - задаём ширину
         * создаёт поле по заданным размерам
         */
        public Map(int height, int width)
        {
            heightMap = height;
            widthMap = width;

            arrayCell = new Cell[heightMap, widthMap]; 
            nextCells = new Cell[4, 4];

            OtherFigures = new Figure();
            currentFigure = new Figure();
            nextFigure = new Figure(x: 0, y: 0);

            for (int i = 0; i < heightMap; i++)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    arrayCell[i, j] = new Cell(j, i, null);
                }
            }

            for (int i = 0; i < nextCells.GetLength(0); i++)
            {
                for (int j = 0; j < nextCells.GetLength(1); j++)
                {
                    nextCells[i, j] = new Cell(j, i, null);
                }
            }
        }

        /**
         * void UpdateFigures() - обновление фигур
         */
        public void UpdateFigures()
        {
            foreach (Cell Cell in currentFigure.ArrayCell)
            {
                arrayCell[Cell.CoordinateY, Cell.CoordinateX].Figure = Cell.Figure;
            }
        }

        /**
         * void ResetFigures() - сброс фигур
         */
        public void ResetFigures()
        {
            for (int i = 0; i <= heightMap - 1; i++)
            {
                for (int j = 0; j <= widthMap - 1; j++)
                {
                    if (arrayCell[i, j].Figure == currentFigure)
                    {
                        arrayCell[i, j].Figure = null;
                    }
                }
            }
        }

        /**
         * void AddFigure() - функция, которая добавляет на игровое поле новую фигуру
         */
        public void AddFigure()
        {
            for (int i = 0; i < heightMap; i++)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    if (arrayCell[i, j].Figure == currentFigure)
                    {
                        arrayCell[i, j].Figure = OtherFigures;
                    }
                }
            }
            currentFigure = nextFigure;
            currentFigure.SetCoordinates(x: (widthMap / 2) - 1, y: 0);
            currentFigure.ChangeCoordinate();

            nextFigure = new Figure(0, 0);
            SetCells(nextFigure);
            
            for (int i = 0; i < currentFigure.ArrayCell.Count; i++)
            {
                Cell v = currentFigure.ArrayCell[i];
                arrayCell[v.CoordinateY, v.CoordinateX].Figure = currentFigure;
            }
        }

        /*
         * Метод, который присваивает значения клеткам мини-поля координаты следующей фигуры
         */
        private void SetCells(Figure value)
        {
            

            for (int i = 0; i < nextCells.GetLength(0); i++)
            {
                for (int j = 0; j < nextCells.GetLength(1); j++)
                {
                    nextCells[i, j].Figure = null;
                }
            }


            for (int k = 0; k < value.ArrayCell.Count; k++)
            {
                for (int i = 0; i < nextCells.GetLength(0); i++)
                {
                    for (int j = 0; j < nextCells.GetLength(1); j++)
                    {
                        int figureCellX = value.ArrayCell[k].CoordinateX;
                        int figureCellY = value.ArrayCell[k].CoordinateY;

                        if (figureCellX == nextCells[i, j].CoordinateX && figureCellY == nextCells[i, j].CoordinateY)
                        {
                            nextCells[i, j].Figure = value;
                        }
                    }
                }
            }
        }


        public Brush GetColor(Figure checkFigure)
        {
            switch (checkFigure.TypeFigure)
            {
                case TypeFigures.O:
                    return Brushes.Green;
                case TypeFigures.T:
                    return Brushes.Red;
                case TypeFigures.I:
                    return Brushes.Blue;
                case TypeFigures.L:
                case TypeFigures.J:
                    return Brushes.Olive;
                default:
                    return Brushes.Yellow;
            }
        }
    };
}
