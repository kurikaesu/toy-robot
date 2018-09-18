using Xunit;

namespace toy_robot
{
    public class RobotShould
    {
        [Fact]
        public void RobotShould_NotMoveIfNotPlaced()
        {
            var t = new Table();
            var r = new Robot();
            r.Move(t);

            var pos = r.Position();
            Assert.Null(pos.Item1);
            Assert.Null(pos.Item2);
            Assert.Null(r.Direction());
        }

        [Fact]
        public void RobotShould_NotTurnIfNotPlaced()
        {
            var t = new Table();
            var r = new Robot();

            r.Left();

            Assert.Null(r.Direction());

            r.Right();
            Assert.Null(r.Direction());
        }

        [Fact]
        public void RobotShould_IgnorePlacementOffTable()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 10, 4, "NORTH");
            var pos = r.Position();
            Assert.Null(pos.Item1);
            Assert.Null(pos.Item2);
            Assert.Null(r.Direction());
        }
    }
}