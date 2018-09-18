namespace toy_robot
{
    public interface IRobot
    {
        void Place(Table table, ushort px, ushort py, string direction);
        void Move();
        void Left();
        void Right();
        void Report();
    }
}