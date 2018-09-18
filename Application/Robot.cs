using System;
using System.Collections.Generic;

namespace toy_robot
{
    public sealed class Robot
    {
        private static readonly List<string> availableDirections = new List<string> {
            "north",
            "east",
            "south",
            "west"
        };

        private static readonly Dictionary<string, string> reverseDirLookup = new Dictionary<string, string> {
            {"01", "north"},
            {"10", "east"},
            {"0-1", "south"},
            {"-10", "west"}
        };
        // Initialise position as null to ensure we have
        // an indicator for when the robot hasn't been placed
        private ushort? x = null;
        private ushort? y = null;

        private string currentDirection;
        private short vx = 0;
        private short vy = 0;

        // The table itself
        private Table _table;

        // Places this robot on the provided table on the specified location and facing direction
        public void Place(Table table, ushort px, ushort py, string direction)
        {
            if (table == null)
                return;

            _table = table;

            var loweredDirection = direction.Trim().ToLower();

            // We're using unsigned values so we only have to check two sides
            if (px < table.width &&
                py < table.height &&
                availableDirections.Contains(loweredDirection)) {
                    x = px;
                    y = py;
                    currentDirection = direction;

                    // Reset velocity
                    vx = vy = 0;

                    switch (loweredDirection) {
                        case "north":
                            vy = 1;
                            break;
                        case "east":
                            vx = 1;
                            break;
                        case "south":
                            vy = -1;
                            break;
                        case "west":
                            vx = -1;
                            break;
                        default:
                            break;
                    }
                }
        }

        public void Move()
        {
            if (_table != null && x != null && y != null) {
                // We take advantage of unsigned characteristics
                var dx = (ushort)(x + vx);
                var dy = (ushort)(y + vy);
                if (dx < _table.width &&
                    dy < _table.height) {
                    x = dx;
                    y = dy;
                }
            }
        }

        private void UpdateDirection()
        {
            var key = string.Format("{0}{1}", vx, vy);
            currentDirection = reverseDirLookup[key];
        }

        public void Left()
        {
            if (x != null && y != null) {
                // Rotate x, y 90 degrees left is simply -y, x
                var tx = vx;
                vx = (short)-vy;
                vy = tx;

                UpdateDirection();
            }
        }

        public void Right()
        {
            if (x != null && y != null) {
                // Rotate x, y 90 degrees right is simply y, -x
                var tx = vx;
                vx = vy;
                vy = (short)-tx;

                UpdateDirection();
            }
        }

        public void Report()
        {
            if (x != null && y != null) {
                Console.WriteLine(
                    string.Format("{0},{1},{2}", x, y, currentDirection.ToUpper())
                );
            }
        }

        public Tuple<ushort?, ushort?> Position()
        {
            return new Tuple<ushort?, ushort?>(x, y);
        }

        public string Direction()
        {
            return currentDirection?.ToUpper();
        }
    }
}