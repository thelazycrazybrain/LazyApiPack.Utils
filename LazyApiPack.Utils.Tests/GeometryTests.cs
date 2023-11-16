using LazyApiPack.Utils.Math;

namespace LazyApiPack.Utils.Tests
{
    public class GeometryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReplaceIfNaNTest()
        {
            var x = double.NaN;
            var t = GeometryMath.ReplaceIfNaN(x, 10);
            Assert.IsTrue(t == 10);

            x = 5;
            t = GeometryMath.ReplaceIfNaN(x, 10);
            Assert.IsTrue(t == 5);
            Assert.Pass();
        }

        [Test]
        public void GetNormalizedRectTest()
        {
            var x = 10;
            var y = 10;
            var width = -10;
            var height = 10;
            var result = GeometryMath.GetNormalizedRect(x, y, width, height);
            Assert.IsTrue(
                result.X == 0 &&
                result.Y == 10 &&
                result.Width == 10 &&
                result.Height == 10);


            width = 10;
            result = GeometryMath.GetNormalizedRect(x, y, width, height);

            Assert.IsTrue(
                result.X == 10 &&
                result.Y == 10 &&
                result.Width == 10 &&
                result.Height == 10);
            Assert.Pass();

        }


        [Test]
        public void IsPointInRectangleTest()
        {
            var p = new Point(10, 10);
            var r = new Rect(10, 10, 50, 50);
            var t = GeometryMath.IsPointInRectangle(p, r);
            Assert.True(t);

            p = new Point(60, 60);
            t = GeometryMath.IsPointInRectangle(p, r);
            Assert.True(t);

            p = new Point(5, 10);
            t = GeometryMath.IsPointInRectangle(p, r);
            Assert.False(t);
            Assert.Pass();
        }

        [Test]
        public void IsRectInRectTest()
        {
            var r1 = new Rect(10, 10, 50, 50);
            var r2 = new Rect(15, 15, 40, 40);
            var t = GeometryMath.IsRectInRect(r1, r2);

            Assert.True(t);
            r2 = new Rect(5, 5, 45, 45);
            t = GeometryMath.IsRectInRect(r1, r2);

            Assert.False(t);
            Assert.Pass();
        }

        [Test]
        public void RectsOverlapTest()
        {
            var r1 = new Rect(10,10,30,30);
            var r2 = new Rect(0, 0, 20, 20);
            var t = GeometryMath.RectsOverlap(r1, r2);

            Assert.True(t);
            r2 = new Rect(41, 0, 20, 20);
            t = GeometryMath.RectsOverlap(r1, r2);
            Assert.False(t);
        }
    }
}