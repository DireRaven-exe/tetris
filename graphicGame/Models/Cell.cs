using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphicGame
{
    internal class Cell
    {
        /**
 * class Cell - класс, отвечающий за клетку поля/фигуры
 * @param coordinateX - координата клетки по X
 * @param coordinateY - координата клетки по Y
 * @param figure - фигура, которой принадлежит клетка
 */

            private int coordinateX;
            private int coordinateY;
            private Figure figure;

        /**
         * Cell(Cell *pFigure) - конструктор, копирующий значения одной клетки в другую
         * @param valueX - значение координаты Х
         * @param valueY - значение координаты Y
         * @param valueFigure - значение фигуры, к которой клетка будет относиться
         */
        public Cell(Cell pFigure)
            {
                CoordinateX = pFigure.CoordinateX;
                CoordinateY = pFigure.CoordinateY;
                Figure = pFigure.Figure;
            }

            /**
             * Cell() - конструктор пустой клетки
             */
            public Cell()
            {
                CoordinateX = 0;
                CoordinateY = 0;
                Figure = null;
            }

        /**
             * Cell() - конструктор клетки пренадлежащей к фигурам
             */
        public Cell(Figure valueFigure)
        {
            CoordinateX = 0;
            CoordinateY = 0;
            Figure = valueFigure;
        }

        /**
         * 
         * Cell(int valueX, int valueY, Figure *valueFigure) - конструктор класса Клетка
         * @param valueX - координата клетки по X
         * @param valueY - координата клетки по Y
         * @param valueFigure - фигура, к которой принадлежит клетка
         */
        public Cell(int valueX, int valueY, Figure valueFigure)
            {
                CoordinateY = valueY;
                CoordinateX = valueX;
                Figure = valueFigure;
            }
        /**
         * Cell(int valueX, int valueY) - конструктор класса Клетка

         */
        public Cell(int valueX, int valueY)
        {
                CoordinateY = valueY;
                CoordinateX = valueX;
                Figure = new Figure(figure);
        }

        public void SetCell(int valueX, int valueY, Figure valueFigure)
        {
            CoordinateY = valueY;
            CoordinateX = valueX;
            Figure = valueFigure;
        }


        public Figure Figure { get => figure; set => figure = value; }
            public int CoordinateY { get => coordinateY; set => coordinateY = value; }
            public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        }
}
