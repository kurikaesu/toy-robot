using System;

namespace toy_robot
{
    public sealed class Robot
    {
        // Initialise position as null to ensure we have
        // an indicator for when the robot hasn't been placed
        private Nullable<ushort> x = null;
        private Nullable<ushort> y = null;

        private short vx = 0;
        private short vy = 1;

        public void Place(Table table, ushort px, ushort py)
        {
            if (px < table.width &&
                py < table.height) {
                    x = px;
                    y = py;
                }
        }

        public void Move(Table table)
        {
            if (x != null && y != null) {
                if (x + vx < table.width &&
                    y + vy < table.height) {
                    x += (ushort)vx;
                    y += (ushort)vy;
                }
            }
        }

        public void Report()
        {
            if (x != null && y != null) {
                Console.WriteLine(string.Format("{0},{1}", x, y));
            }
        }
    }
}