namespace graphicGame.Logic
{
    internal class MapLogic
    {
        public Map map;
        public int points;

        public MapLogic(Map map)
        {
            this.map = map;
        }

        /**
         * void ClearLine(int valueLine) - функция, удаляющая заполненную строку
         * @param valueString - номер строки, которая является заполненной
         */
        public void ClearLine(int valueLine)
        {
            for (int j = 0; j < map.widthMap; j++)
            {
                map.arrayCell[valueLine, j].Figure = null;
            }
        }

        /**
         * void DownCells(int valueString) - функция, которая сдвигает все клетки карты вниз
         */
        public void DownCells(int valueLine)
        {
            for (int i = valueLine; i > 0; i--)
            {
                for (int j = 0; j < map.widthMap; j++)
                {
                    map.arrayCell[i, j].Figure = map.arrayCell[i - 1, j].Figure;
                    map.arrayCell[i - 1, j].Figure = null;
                }
            }
        }

        /**
         * void CheckLines() - проверка на заполненность одной из строк поля и получение очков
         */
        public void CheckLines()
        {
            int countCells = 0; // счётчик для проверки каждой клетки строки
            for (int i = 0; i < map.heightMap; i++)
            {
                for (int j = 0; j < map.widthMap; j++)
                {
                    if (map.arrayCell[i, j].Figure != null)
                    {
                        countCells++;
                    }
                    if (countCells == map.widthMap)
                    {
                        ClearLine(i);
                        DownCells(i);
                        points += 10;
                        countCells = 0;
                    }
                }
                countCells = 0;
            }
        }
    }
}
