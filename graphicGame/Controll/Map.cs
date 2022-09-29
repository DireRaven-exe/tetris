using System.Drawing;

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

            OtherFigures = new Figure(6, 0);
            currentFigure = new Figure(widthMap / 2, 0);
            nextFigure = new Figure(0, 0);
            nextFigure.ChoiceOfFigure(0, 0);

            for (int i = 0; i < heightMap; i++)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    arrayCell[i, j] = new Cell(j, i, null);
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
            currentFigure.CopyFigure(nextFigure);
            currentFigure.SetCoordinates((widthMap / 2) - 1, 0);
            nextFigure.ChoiceOfFigure(0, 0);

            currentFigure.ChangeCoordinate();
            
            
            
            for (int i = 0; i < currentFigure.ArrayCell.Count; i++)
            {
                Cell v = currentFigure.ArrayCell[i];
                arrayCell[v.CoordinateY, v.CoordinateX].Figure = currentFigure;
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
