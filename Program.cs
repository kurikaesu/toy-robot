using System;

namespace toy_robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Table();
            var r = new Robot();
            r.Place(t, 1, 1);
            r.Move(t);
            r.Report();
        }
    }
}
