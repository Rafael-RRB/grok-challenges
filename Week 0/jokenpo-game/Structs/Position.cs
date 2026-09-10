namespace JokenpoTerminal.Structs
{
    public struct Position
    {
        private int _x = 0;
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        private int _y = 0;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public static Position Zero => new Position(0, 0);

        public Position(int setX, int setY)
        {
            X = setX;
            Y = setY;
        }
    }
}