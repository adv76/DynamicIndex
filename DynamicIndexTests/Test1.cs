using DynamicIndex;
using DynamicIndexTests.Models;

namespace DynamicIndexTests
{
    [TestClass]
    public sealed class Test1
    {
        private readonly TopLevelObject _object = new TopLevelObject()
        {
            Property1 = 34,
            Property2 = "Hello",
            Array1 = [1, 2, 3],
            Array2 = [
                new BottomObject()
                {
                    Property1 = 564,
                    Property2 = "Dotnet",
                },
                new BottomObject()
                {
                    Property1 = -4,
                    Property2 = "Alphabet"
                }
            ],
            Object1 = new MiddleObject()
            {
                Property1 = -780,
                Property2 = "Nesting",
                Object1 = new BottomObject()
                {
                    Property1 = 1,
                    Property2 = "Visual"
                }
            }
        };

        [TestMethod]
        public void TestMethod1()
        {
            var success = _object.Index()["Property1"].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, 34);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var success = _object.Index()["Property2"].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, "Hello");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var success = _object.Index()["Array1"][0].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var success = _object.Index()["Array2"][1]["Property1"].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, -4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var success = _object.Index()["Object1"]["Property1"].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, -780);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var success = _object.Index()["Object1"]["Object1"]["Property2"].Get(out var val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, "Visual");
        }

        [TestMethod]
        public void TestMethod7()
        {
            var success = _object.Index()["Object1"]["Object1"]["Property762"].Get(out var val);

            Assert.IsFalse(success);
        }
    }
}
