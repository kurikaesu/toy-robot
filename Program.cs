using System;

namespace toy_robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Table();
            var r = new Robot();
            r.Place(t, 1, 0, "north");
            r.Move(t);
            r.Left();
            r.Left();
            r.Move(t);
            r.Report();
            r.Right();
            r.Move(t);
            r.Report();
        }
    }
}
