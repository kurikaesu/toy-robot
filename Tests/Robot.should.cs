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

            r.Move();

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

        [Fact]
        public void RobotShould_IgnoreEmptyTable()
        {
            var r = new Robot();

            r.Place(null, 1, 1, "NORTH");
            var pos = r.Position();
            Assert.Null(pos.Item1);
            Assert.Null(pos.Item2);
            Assert.Null(r.Direction());
        }

        [Fact]
        public void RobotShould_BeHappilyPlacedOnTable()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 1, 2, "NORTH");
            var pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(2 == pos.Item2);
            Assert.Equal("NORTH", r.Direction());
        }

        [Fact]
        public void RobotShould_MoveForwardToValidPosition()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 1, 2, "NORTH");
            r.Move();
            var pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(3 == pos.Item2);
            Assert.Equal("NORTH", r.Direction());
        }

        [Fact]
        public void RobotShould_NotMoveIntoInvalidPositions()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 1, 4, "NORTH");
            r.Move();
            var pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(4 == pos.Item2);
            Assert.Equal("NORTH", r.Direction());

            r.Place(t, 1, 0, "SOUTH");
            r.Move();
            pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(0 == pos.Item2);
            Assert.Equal("SOUTH", r.Direction());

            r.Place(t, 4, 1, "EAST");
            r.Move();
            pos = r.Position();
            Assert.True(4 == pos.Item1);
            Assert.True(1 == pos.Item2);
            Assert.Equal("EAST", r.Direction());

            r.Place(t, 0, 1, "WEST");
            r.Move();
            pos = r.Position();
            Assert.True(0 == pos.Item1);
            Assert.True(1 == pos.Item2);
            Assert.Equal("WEST", r.Direction());
        }

        [Fact]
        public void RobotShould_MakeAValidRightTurn()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 2, 2, "NORTH");
            r.Move();
            r.Right();
            r.Move();
            var pos = r.Position();
            Assert.True(3 == pos.Item1);
            Assert.True(3 == pos.Item2);
            Assert.Equal("EAST", r.Direction());
        }

        [Fact]
        public void RobotShould_MakeAValidLeftTurn()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 2, 2, "NORTH");
            r.Move();
            r.Left();
            r.Move();
            var pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(3 == pos.Item2);
            Assert.Equal("WEST", r.Direction());
        }

        [Fact]
        public void RobotShould_BeHappyToBePlacedAgain()
        {
            var t = new Table();
            var r = new Robot();

            r.Place(t, 2, 2, "NORTH");
            r.Place(t, 1, 3, "WEST");
            var pos = r.Position();
            Assert.True(1 == pos.Item1);
            Assert.True(3 == pos.Item2);
            Assert.Equal("WEST", r.Direction());
        }
    }
}