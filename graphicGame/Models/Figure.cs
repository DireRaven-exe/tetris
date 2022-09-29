using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace graphicGame
{
    /**
     * Перечисление типов фигур
     */
    enum TypeFigures { O, T, I, L, J, Z, S};

    /**
     * class Figure - класс отвечающий за объект фигура
     * @param coordinateX - координата фигуры по X
     * @param coordinateY - координата фигуры по Y
     * @param arrayCell - массив клеток, принадлежащих фигуре
     * @param currentRotate - значение текущего поворота фигуры
     * @param typeFigure - тип фигуры
     */
    class Figure
    {
        private int coordinateX;
        private int coordinateY; // координаты относительно игрового поля
        private List<Cell> arrayCell;
        private int currentRotate;
        private TypeFigures typeFigure;

        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }
        internal List<Cell> ArrayCell { get => arrayCell; set => arrayCell = value; }
        public int CurrentRotate { get => currentRotate; set => currentRotate = value; }
        internal TypeFigures TypeFigure { get => typeFigure; set => typeFigure = value; }



        /**
         * Figure(Figure *valueFigure) - конструктор класса Figure
         * Создаёт фигуру, копируя значения заданной
         * @param valueFigure - заданная фигура
         */
        public Figure(Figure valueFigure)
        {
            CoordinateX = valueFigure.CoordinateX;
            CoordinateY = valueFigure.CoordinateY;
            ArrayCell = valueFigure.arrayCell;
            CurrentRotate = valueFigure.currentRotate;
            TypeFigure = valueFigure.TypeFigure;
            foreach (Cell i in arrayCell)
            {
                i.Figure = this;
            }
        }

        /**
         * Figure(int x, int y) - конструктор класса Figure
         * Создаёт фигуру с заданными координатами
         * @param x - координата фигуры по X
         * @param y - координата фигуры по Y
         */
        public Figure(int x, int y)
        {
            ArrayCell = new List<Cell>();
            foreach (Cell i in arrayCell)
            {
                i.Figure = null;
            }
            ChoiceOfFigure(x, y);
        }



        /**
         * void SetValueFigure(Figure *valueFigure) - функция, которая позволяет
         * копировать значения одной фигуры в другую
         * @param valueFigure - заданная фигура
         */
        public void SetValueFigure(Figure valueFigure)
        {
            arrayCell = valueFigure.arrayCell;
            CoordinateX = valueFigure.CoordinateX;
            CoordinateY = valueFigure.CoordinateY;
            TypeFigure = valueFigure.TypeFigure;
            CurrentRotate = valueFigure.CurrentRotate;
        }

        /**
         * void CopyFigure(Figure *valueFigure) - функция, которая позволяет
         * копировать значения одной фигуры в другую
         * @param valueFigure - заданная фигура
         */
        public void CopyFigure(Figure valueFigure)
        {
            arrayCell = valueFigure.arrayCell;
            TypeFigure = valueFigure.TypeFigure;
            CurrentRotate = valueFigure.CurrentRotate;
        }

        /**
         * void SetCoordinates(int x, int y) - функция для установки определённых координат
         * @param valueFigure - заданная фигура
         */
        public void SetCoordinates(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
        /**
         * int Height() - функция вычисляющая высоту фигуры
         * @return значение высоты фигуры
         */
        public int Height()
        {
            int maxY = 0;
            foreach (Cell frame in arrayCell)
            {
                if (frame.CoordinateY >= maxY)
                {
                    maxY = frame.CoordinateY;
                }
            }
            return maxY - CoordinateY;
        }

        /**
         * int Height() - функция вычисляющая ширину фигуры
         * @return значение ширины фигуры
         */
        public int Width()
        {
            int maxX = 0;
            foreach (Cell frame in arrayCell)
            {
                if (frame.CoordinateX >= maxX)
                {
                    maxX = frame.CoordinateX;
                }
            }
            return maxX + 1 - CoordinateX;
        }

        /**
         * void ChoiceOfFigure(int x, int y) - функция, которая задаёт
         * поворот и тип новой фигуре
         * По заданным координатам
         * @param x - координата фигуры по X
         * @param y - координата фигуры по Y
         */
        public void ChoiceOfFigure(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
            Random rand = new Random();
            TypeFigure = RandomEnumValue<TypeFigures>();
            BeginRotate(1 + rand.Next(4));
        }

        /**
         * static T RandomEnumValue<T>()
         * Возвращает рандомное значение из перечисления T
         */
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }

        /** void BeginRotate(int rotate)
         * функция, которая начинает поворот фигуры по заданному повороту
         * @param rotate - заданный поворот
         */
        public void BeginRotate(int rotate)
        {
            if (rotate > 4)
            {
                rotate = 1;
            }
            else if (TypeFigure == TypeFigures.Z && rotate > 2)
            {
                rotate = 1;
            }
            else if (TypeFigure == TypeFigures.S && rotate > 2)
            {
                rotate = 1;
            }
            else if (TypeFigure == TypeFigures.I && rotate > 2) 
            { 
                rotate = 1;
            }
            CurrentRotate = rotate;
            ChangeCoordinate();
        }

        /** void getFrameT(int rotate)
         * функция, которая получает текущие координаты клеток фигуры Т по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameT()
        {
            if (currentRotate == 1)
            {
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
            }
            else if (currentRotate == 2)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
            }
            else if (currentRotate == 3)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
            }
        }
        /** void getFrameO()
         * функция, которая получает текущие координаты клеток фигуры О
         */
        public void getFrameO()
        {
            arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
            arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
            arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
            arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));

        }

        /** void getFrameI(int rotate)
         * функция, которая получает текущие координаты клеток фигуры I по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameI()
        {
            if (currentRotate == 1)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 3, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 3, CoordinateY + 0, this));
            }
        }

        /** void getFrameL(int rotate)
         * функция, которая получает текущие координаты клеток фигуры L по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameL()
        {
            if (currentRotate == 1)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
            }
            else if (currentRotate == 2)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 0, this));
            }
            else if (currentRotate == 3)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 0, this));
            }
        }

        /** void getFrameJ(int rotate)
         * функция, которая получает текущие координаты клеток фигуры J по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameJ()
        {
            if (currentRotate == 1)
            {

                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
            }
            else if (currentRotate == 2)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
            }
            else if (currentRotate == 3)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
            }
        }

        /** void getFrameZ(int rotate)
         * функция, которая получает текущие координаты клеток фигуры Z по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameZ()
        {
            if (currentRotate == 1)
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 1, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 2, this));
            }
        }

        /** void getFrameS(int rotate)
         * функция, которая получает текущие координаты клеток фигуры S по заданному повороту
         * @param rotate - заданный поворот
         */
        public void getFrameS()
        {
            if (currentRotate == 1)
            {
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 2, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
            }
            else
            {
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 0, this));
                arrayCell.Add(new Cell(CoordinateX + 0, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 1, this));
                arrayCell.Add(new Cell(CoordinateX + 1, CoordinateY + 2, this));
            }
        }
     

        /** void ChangeCoordinate()
         * функция, которая назначает координаты клеток фигуры по типу фигуры
         */
        public void ChangeCoordinate()
        {
            arrayCell.Clear();
            if (TypeFigure == TypeFigures.T) getFrameT();
            else if (TypeFigure == TypeFigures.O) getFrameO();
            else if (TypeFigure == TypeFigures.I) getFrameI();
            else if (TypeFigure == TypeFigures.L) getFrameL();
            else if (TypeFigure == TypeFigures.J) getFrameJ();
            else if (TypeFigure == TypeFigures.Z) getFrameZ();
            else if (TypeFigure == TypeFigures.S) getFrameS();
        }

    }
}