using System;
using System.Collections.Generic;

namespace toy_robot
{
    public sealed class Robot
    {
        private static List<string> availableDirections = new List<string> {
            "north",
            "east",
            "south",
            "west"
        };
        // Initialise position as null to ensure we have
        // an indicator for when the robot hasn't been placed
        private Nullable<ushort> x = null;
        private Nullable<ushort> y = null;

        private string currentDirection;
        private short vx = 0;
        private short vy = 0;

        // Places this robot on the provided table on the specified location and facing direction
        public void Place(Table table, ushort px, ushort py, string direction)
        {
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

        public void Move(Table table)
        {
            if (x != null && y != null) {
                // We take advantage of unsigned characteristics
                var dx = (ushort)(x + vx);
                var dy = (ushort)(y + vy);
                if (dx < table.width &&
                    dy < table.height) {
                    x = dx;
                    y = dy;
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