
namespace BoardF
{
    //На каждую координату добавляется get и set
    //Проверяет чтобы не было переполнения
    struct Map
    {
        int size;
        int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public void Set(Coord xy, int value)
        {
            if (xy.OnBoard(size))
                map[xy.x, xy.y] = value;
        }

        public int Get (Coord xy)
        {
            if (xy.OnBoard(size))
                return map[xy.x, xy.y];
            return 0;
        }

        //Копирование откуда и куда
        public void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}
