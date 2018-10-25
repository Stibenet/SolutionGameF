using System;

namespace BoardF
{
    public class Game
    {
        int size;
        Map map; //карта
        Coord space; //координаты пустого места

        //Счетчик ходов
        public int moves { get; private set; }

        public Game (int size)
        {
            this.size = size;
            map = new Map(size);
        }

        public void Start(int seed = 0)
        {
            int digit = 0;
            //??? минута 53:10 TODO
            foreach (Coord xy in new Coord().YieldCoord(size))
                map.Set(xy, ++digit);
            // Инициализация пустого места на карте (смотреть конструктор в Coord.cs)
            space = new Coord(size);
            if (seed > 0)
                Shuffle(seed);

            moves = 0; 
        }

        //Перемешивание чисел на доске
        /*Чем меньше seed тем проще игра и меньше ходов*/
        void Shuffle (int seed)
        {
            //Seed передается сразу для того, чтобы перемешивалось всегда в одну позицию
            Random random = new Random(seed);
            for (int j = 0; j < seed; j++)
                PressAt(random.Next(size), random.Next(size));
        }

        //Нажать на плашку
        public int PressAt(int x, int y)
        {
            /*PressAt - это фасад, который получает структуру Coord */
            return PressAt(new Coord(x,y));
        }

        //Создание координаты
        int PressAt(Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            if (xy.x != space.x && //Нажатие по диагонали
                xy.y != space.y) //Нажатие по вертикали
                return 0;

            //Учет шагов, с помощью модуля суммы разниц по координатам x и y
            int steps = Math.Abs(xy.x - space.x) +
                        Math.Abs(xy.y - space.y);

            /*Чтобы была возможность сдвигать влево/вправо или вверх/вниз мы переставляем местами 
             * пустое место и число с помощью знаков операций + и - (производится сдвиг) */
            while (xy.x != space.x)
                Shift(Math.Sign(xy.x - space.x), 0); //влево/вправо
            while (xy.y != space.y)
                Shift(0, Math.Sign(xy.y - space.y)); //вверх/вниз

            moves += steps; 
            return steps;
        }

        //Сдвиг чисел (плашек)
        void Shift (int sx, int sy)
        {
            //Сохранили координаты куда сдвинуть
            Coord next = space.Add(sx, sy);
            //Произведение сдвига
            map.Copy(next, space); // map[space] := map[next]
            space = next;
        }

        //Получить число на
        public int GetDigitAt(int x, int y)
        {
            return GetDigitAt (new Coord(x,y));
        }

        int GetDigitAt (Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }

        //Проверка окончания игры (все ли собрано)
        public bool Solved()
        {
            if (!space.Equals(new Coord(size)))
                return false;
            int digit = 0;
            foreach (Coord xy in new Coord().YieldCoord(size))
                if (map.Get(xy) != ++digit)
                    return space.Equals(xy);
            return true;
        }
    }
}
