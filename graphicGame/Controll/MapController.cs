using graphicGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphicGame
{
    internal class MapController
    {
        public Map map;
        public MapLogic mapLogic;


     /**
     * Конструктор класса Controller
     * @param SIZE - значение размера карты (15x10) как пример
     */
        public MapController(int sizeY, int sizeX)
        {
            map = new Map(sizeY, sizeX);
            mapLogic = new MapLogic(map);
        }

        /**
         * void MoveDown() - смещение фигуры вниз на одну позицию
         * Функция либо двигает фигуру, либо если нет возможности двигать её, создаёт новую
         */
        public bool MoveDown()
        {
            if (CanDown(map.currentFigure))
            {
                map.ResetFigures();
                map.currentFigure.CoordinateY += 1;
                map.currentFigure.ChangeCoordinate();
                map.UpdateFigures();
                return true;
            }
            else
            {
                mapLogic.CheckLines();
                map.AddFigure();
                return false;
            }
        }

        /**
         * bool MoveLeft() - смещение фигуры влево на одну позицию
         */
        public bool MoveLeft()
        {
            if (CanDown(map.currentFigure))
            {
                if (CanLeft(map.currentFigure))
                {
                    map.ResetFigures();
                    map.currentFigure.CoordinateX -= 1;
                    map.currentFigure.ChangeCoordinate();
                    map.UpdateFigures();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /**
         * void MoveRight() - смещение фигуры вправо на одну позицию
         */
        public bool MoveRight()
        {
            if (CanDown(map.currentFigure))
            {
                if (CanRight(map.currentFigure))
                {
                    map.ResetFigures();
                    map.currentFigure.CoordinateX += 1;
                    map.currentFigure.ChangeCoordinate();
                    map.UpdateFigures();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /**
         * void MoveRotate() - поворот фигуры
         */
        public bool MoveRotate()
        {
            if (CanDown(map.currentFigure))
            {
                if (CanRight(map.currentFigure))
                {
                    map.currentFigure.BeginRotate(map.currentFigure.CurrentRotate + 1);
                    if (CanLeft(map.currentFigure) &&
                        CanRight(map.currentFigure) &&
                        CanDown(map.currentFigure))
                    {
                        map.ResetFigures();
                        map.UpdateFigures();
                        return true;
                    }
                    else
                    {
                        map.currentFigure.BeginRotate(map.currentFigure.CurrentRotate);
                        return false;
                    }
                }
                else return false;
            }
            else return false;
        }

        /**
         * bool IsDefeat() - функция для проверки на проигрыш
         * @return false - если игрок проиграл, true - если ещё нет
         */
        public bool IsDefeat()
        {
            if (map.currentFigure.CoordinateY == 0 &&
                !CanDown(map.currentFigure))
            {
                return true;
            }
            else return false;

        }

        /**
         * bool CanDown(Figure checkFigure) - проверяет, может ли текущаяя фигура двигаться вниз
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanDown(Figure checkFigure)
        {
            if (checkFigure.CoordinateY + checkFigure.Height() + 1 <= map.heightMap - 1)
            {

                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (map.arrayCell[Cell.CoordinateY + 1, Cell.CoordinateX].Figure == map.OtherFigures)
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
         * bool CanRight(Figure checkFigure) - проверяет, может ли текущаяя фигура двигаться вправо
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanRight(Figure checkFigure)
        {
            if (checkFigure.CoordinateX + checkFigure.Width() + 1 <= map.widthMap)
            {
                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (map.arrayCell[Cell.CoordinateY, Cell.CoordinateX + 1].Figure == map.OtherFigures)
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
         * bool CanLeft(Figure checkFigure) - проверяет, может ли текущаяя фигура двигаться влево
         * @param checkFigure - фигура, для которой мы проверяем возможность перемещения
         * @return true - если можно переместить, false - если нельзя
         */
        public bool CanLeft(Figure checkFigure)
        {
            if (checkFigure.CoordinateX - 1 > -1)
            {
                foreach (Cell Cell in checkFigure.ArrayCell)
                {
                    if (map.arrayCell[Cell.CoordinateY, Cell.CoordinateX - 1].Figure == map.OtherFigures)
                    {
                        return false;
                    }
                    else continue;
                }
                return true;
            }
            return false;
        }
    };
}