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

        /**
     * Конструктор класса Controller
     * @param SIZE - значение размера карты
     */
        public MapController(int sizeY, int sizeX)
        {
            map = new Map(sizeY, sizeX);
        }


        /**
         * void MoveDown() - смещение фигуры вниз на одну позицию
         * Функция либо двигает фигуру, либо если нет возможности двигать её, создаёт новую
         */
        public void MoveDown()
        {
            if (map.CanDownThisFigure(map.figure))
            {
                map.DownFigure();
            }
            else
            {
                map.CheckPoints();
                map.AddFigure();
            }
        }

        /**
         * void MoveLeft() - смещение фигуры влево на одну позицию
         */
        public void MoveLeft()
        {
            if (map.CanDownThisFigure(map.figure))
            {
                map.LeftFigure();
            }
        }

        /**
         * void MoveRight() - смещение фигуры вправо на одну позицию
         */
        public void MoveRight()
        {
            if (map.CanDownThisFigure(map.figure))
            {
                map.RightFigure();
            }
        }

        /**
         * void MoveRotate() - поворот фигуры
         */
        public void MoveRotate()
        {
            if (map.CanDownThisFigure(map.figure))
            {
                map.RotateFigure();
            }
        }

        /**
         * bool CheckMap() - функция проверки поля
         * Если игрок не проиграл, тогда функция проверяет поле
         * на наличие заполненных строк и рисует карту
         * с кол-вом очков на текущий момент
         * @return false - если игрок проиграл, true - если ещё нет
         */
        public bool CheckMap()
        {
            return !map.Defeat();

        }

        /**
         * void GameCycle - функция игрового цикла, запускает игру :)
         * @param beginGameCycle  - передаём состояние игры
         * если true - играем, если false - игра окончена
         */

    };
}