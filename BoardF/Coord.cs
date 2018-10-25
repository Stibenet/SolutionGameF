using System.Collections.Generic;

namespace BoardF
{
    //Используется везде где надо вызвать координаты
    struct Coord
    {
        public int x;
        public int y;

        public Coord (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Создание последней клетки доски
        public Coord(int size)
        {
            x = size - 1;
            y = size - 1;
        }

        //Проверка координаты в пределах доски
        public bool OnBoard (int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        public IEnumerable<Coord> YieldCoord (int size)
        {
            for (y = 0; y < size; y++)
                for (x = 0; x < size; x++)
                    yield return this;
        }

        //Осуществление увеличение координат для сдвига чисел на доске
        public Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }
    }
}
