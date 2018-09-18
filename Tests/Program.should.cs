using toy_robot;
using Xunit;

namespace Tests
{
    public class ProgramShould
    {
        [Fact]
        public void ProgramShould_HandleAMoveCommand()
        {
            var t = new Table();
            var r = new FauxRobot();
            Program.HandleCommand(t, r, "MOVE");

            Assert.Equal("MOVE", r.LastCommand());
        }

        [Fact]
        public void ProgramShould_HandleALeftCommand()
        {
            var t = new Table();
            var r = new FauxRobot();
            Program.HandleCommand(t, r, "LEFT");

            Assert.Equal("LEFT", r.LastCommand());
        }

        [Fact]
        public void ProgramShould_HandleARightCommand()
        {
            var t = new Table();
            var r = new FauxRobot();
            Program.HandleCommand(t, r, "RIGHT");

            Assert.Equal("RIGHT", r.LastCommand());
        }

        [Fact]
        public void ProgramShould_HandleAReportCommand()
        {
            var t = new Table();
            var r = new FauxRobot();
            Program.HandleCommand(t, r, "REPORT");

            Assert.Equal("REPORT", r.LastCommand());
        }

        [Fact]
        public void ProgramShould_HandleAPlaceCommand()
        {
            var t = new Table();
            var r = new FauxRobot();
            Program.HandleCommand(t, r, "PLACE 1,3,NORTH");

            Assert.Equal("PLACE 1,3,NORTH", r.LastCommand());
        }
    }
}