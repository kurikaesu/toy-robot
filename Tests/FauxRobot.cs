using toy_robot;

namespace Tests
{
    public sealed class FauxRobot : IRobot
    {
        private string lastCommand = "";

        public void Place(Table table, ushort px, ushort py, string direction)
        {
            lastCommand = string.Format("PLACE {0},{1},{2}", px, py, direction);
        }

        public void Move()
        {
            lastCommand = "MOVE";
        }

        public void Left()
        {
            lastCommand = "LEFT";
        }

        public void Right()
        {
            lastCommand = "RIGHT";
        }

        public void Report()
        {
            lastCommand = "REPORT";
        }

        public string LastCommand()
        {
            return lastCommand;
        }
    }
}