using System;

namespace toy_robot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Please specify an instruction file");
                return;
            }

            var filename = args[0];

            var t = new Table();
            var r = new Robot();

            using (var file = new System.IO.StreamReader(filename)) {
                string line = null;
                while ((line = file.ReadLine()) != null) {
                    var parts = line.Split(" ");
                    if (parts.Length == 1) {
                        switch (parts[0].ToLower()) {
                            case "move":
                                r.Move(t);
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
                                // Don't know this command
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
            }
        }
    }
}
