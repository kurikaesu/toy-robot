using System;
using toy_robot;

namespace toy_robot
{
    public class Program
    {
        public static void HandleCommand(Table t, IRobot r, string line)
        {
            // Check to see if we have a PLACE or other command
            var parts = line.Split(" ");
            if (parts.Length == 1) {
                switch (parts[0].ToLower()) {
                    case "move":
                        r.Move();
                        break;
                    case "left":
                        r.Left();
                        break;
                    case "right":
                        r.Right();
                        break;
                    case "report":
                        r.Report();
                        break;
                    default:
                        // Don't know this command, just ignore it
                        break;
                }
            } else if (parts.Length == 2 && parts[0].ToLower() == "place") {
                var pArgs = parts[1].Split(",");
                try {
                    var x = Convert.ToUInt16(pArgs[0]);
                    var y = Convert.ToUInt16(pArgs[1]);
                    var direction = pArgs[2];
                    r.Place(t, x, y, direction);
                } catch (Exception) {
                    // We silently fail here which feels bad
                }
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Please specify an instruction file");
                return;
            }

            var filename = args[0];

            var t = new Table();
            var r = new Robot();

            // Read the supplied file and parse it line by line
            using (var file = new System.IO.StreamReader(filename)) {
                string line = null;
                while ((line = file.ReadLine()) != null) {
                    HandleCommand(t, r, line);
                }
            }
        }
    }
}
