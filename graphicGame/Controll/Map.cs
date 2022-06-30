using System;

namespace graphicGame
{
    /**
 * class Map - класс игрового поля
 * @param heightMap - высота поля
 * @param widthMap - ширина поля
 * @param points - текущее значение очков игрока
 * @param figure - текущая фигура
 * @param nextFigure - следующая фигура
 * @param OtherFigures - осталльные фигуры поля
 * @param arrayCell - вектор игрового поля
 */
    internal class Map
    {
        public int points;
        public int heightMap;
        public int widthMap;
        public Figure figure;
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
            points = 0;
            heightMap = height;
            widthMap = width;

            arrayCell = new Cell[heightMap, widthMap]; 

            OtherFigures = new Figure(6, 0);
            figure = new Figure(widthMap / 2, 0);
            nextFigure = new Figure(widthMap / 2, 0);
            
            for (int i = 0; i < heightMap; i++)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    arrayCell[i, j] = new Cell(j, i, null);
                }
            }
        }

        /**
         * bool Defeat() - функция проверки проигрыша
         * @return  true - если игрок проиграл и false если ещё нет
         */
        public bool Defeat()
        {
            if (figure.CoordinateY == 0 && !DownFigure())
            {
                Console.Write("YOU LOSE...");
                return true;
            }
            else return false;
        }

        /**
         * void ClearString() - функция, удаляющая заполненную строку
         * @param valueString - номер строки, которая является заполненной
         */
        public void ClearString(int valueString)
        {
            for (int j = 0; j < widthMap; j++)
            {
                arrayCell[valueString, j].Figure = null;
            }
        }

        /**
         * void ChangeMap() - функция, которая сдвигает все клетки карты вниз
         */
        public void ChangeMap(int valueString)
        {
            for (int i = valueString; i > 0; i--)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    arrayCell[i, j].Figure = arrayCell[i - 1, j].Figure;
                    arrayCell[i - 1, j].Figure = null;
                }
            }
        }

        /**
         * void CheckPoints() - проверка на заполненность одной из строк поля и получение очков
         */
        public void CheckPoints()
        {
            int checkString = 0; // счётчик для проверки строки на принадлежность каждой клетки к какой либо фигуре
            for (int i = 0; i < heightMap; i++)
            {
                for (int j = 0; j < widthMap; j++)
                {
                    if (arrayCell[i, j].Figure != null)
                    {
                        checkString++;
                    }
                    if (checkString == widthMap)
                    {
                        ClearString(i);
                        ChangeMap(i);
                        points += 5;
                        checkString = 0;
                    }
                }
                checkString = 0;
            }
        }

        /**
         * void UpdateFigures() - обновление фигур
         */
        public void UpdateFigures()
        {
            foreach (Cell Cell in figure.ArrayCell)
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
                    if (arrayCell[i, j].Figure == figure)
                    {
                        arrayCell[i, j].Figure = null;
                    }
                }
            }
        }

        /**
         * bool DownFigure() - функция, отвчающая за движение текущей фигуры вниз
         * @return true - если получилось переместить, false - если нет
         */
        public bool DownFigure()
        {
            if (CanDownThisFigure(figure))
            {
                ResetFigures();
                figure.CoordinateY += 1;
                figure.ChangeCoordinate();
                UpdateFigures();
                return true;
            }
            else
                return false;
        }

        /**
         * bool LeftFigure() - функция, отвчающая за движение текущей фигуры влево
         * @return true - если получилось переместить, false - если нет
         */
        public bool LeftFigure()
        {
            if (CanLeftThisFigure(figure))
            {
                ResetFigures();;
                figure.CoordinateX -= 1;
                figure.ChangeCoordinate();
                UpdateFigures();
                return true;
            }
            else return false;
        }

        /**
         * bool RightFigure() - функция, отвчающая за движение текущей фигуры вправо
         * @return true - если получилось переместить, false - если нет
         */
        public bool RightFigure()
        {
            if (CanRightThisFigure(figure))
            {
                ResetFigures();
                figure.CoordinateX += 1;
                figure.ChangeCoordinate();
                UpdateFigures();
                return true;
            }
            else return false;
        }

        /**
         * bool RotateFigure() - функция, отвечающая за поворот фигуры
         * @return true - если получилось переместить, false - если нет
         */
        public bool RotateFigure()
        {
            if (CanRightThisFigure(figure))
            {
                figure.BeginRotate(figure.CurrentRotate + 1);
                if (CanLeftThisFigure(figure) && CanRightThisFigure(figure) && CanDownThisFigure(figure))
                {
                    ResetFigures();
                    UpdateFigures();
                    return true;
                }
                else
                {
                    figure.BeginRotate(figure.CurrentRotate);
                    return false;
                }
            }
            else return false;
        }




        /**
         * bool CanDownThisFigure() - проверяет, может ли текущаяя фигура двигаться вниз
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanDownThisFigure(Figure checkFigure)
        {
            if (checkFigure.CoordinateY + checkFigure.Height() + 1 <= heightMap - 1)
            {
                
                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (arrayCell[Cell.CoordinateY + 1, Cell.CoordinateX].Figure == OtherFigures)
                    {
                        return false;
                    }
                    else continue;
                }
                return true;
            }
            else return false;
        }

        /**
         * bool CanRightThisFigure() - проверяет, может ли текущаяя фигура двигаться вправо
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanRightThisFigure(Figure checkFigure)
        {
            if (checkFigure.CoordinateX + checkFigure.Width() + 1 <= widthMap)
            {
                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (arrayCell[Cell.CoordinateY, Cell.CoordinateX + 1].Figure == OtherFigures)
                    {
                        return false;
                    }
                    else continue;
                }
                return true;
            }
            return false;
        }

        /**
         * bool CanLeftThisFigure() - проверяет, может ли текущаяя фигура двигаться влево
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanLeftThisFigure(Figure checkFigure)
        {
            if (checkFigure.CoordinateX - 1 > -1)
            {
                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (arrayCell[Cell.CoordinateY, Cell.CoordinateX - 1].Figure == OtherFigures)
                    {
                        return false;
                    }
                    else continue;
                }
                return true;
            }
            return false;
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
                    if (arrayCell[i, j].Figure != null)
                    {
                        arrayCell[i, j].Figure = OtherFigures;
                    }
                    else if (arrayCell[i, j].Figure == figure)
                    {
                        arrayCell[i, j].Figure = OtherFigures;
                    }
                }
            }
            nextFigure.ChoiceOfFigure((widthMap / 2) - 1, 0);
            figure.SetValueFigure(nextFigure);
            figure.ChangeCoordinate();
            
            
            
            for (int i = 0; i < figure.ArrayCell.Count; i++)
            {
                Cell v = figure.ArrayCell[i];
                arrayCell[v.CoordinateY, v.CoordinateX].Figure = figure;
            }
        }
    };
}
