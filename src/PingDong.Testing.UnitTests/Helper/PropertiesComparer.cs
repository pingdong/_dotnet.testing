using Xunit;

namespace PingDong.Testing
{
    public class FlatObjectPropertiesComparerTests
    {
        #region Sample Objct
        private class TestTarget
        {
            public string S { get; set; }
            public int I { get; set; }
        }
        #endregion

        [Fact]
        public void NullCompareToObject_ShouldReturn_False()
        {
            string s1 = null;
            string s2 = "A";
            Assert.NotEqual(s1, s2, new FlatObjectPropertiesComparer<string>());
        }

        [Fact]
        public void Null_ShouldReturn_True()
        {
            string s1 = null;
            string s2 = null;
            Assert.Equal(s1, s2, new FlatObjectPropertiesComparer<string>());
        }

        [Fact]
        public void Empty_ShouldReturn_True()
        {
            var s1 = new string[] { };
            var s2 = new string[] { };
            Assert.Equal(s1, s2, new FlatObjectPropertiesComparer<string[]>());
        }

        [Fact]
        public void TwoInstanceWithSameProperties_ShouldReturn_True()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = new TestTarget { S = "1", I = 1};
            Assert.Equal(t1, t2, new FlatObjectPropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoInstanceWithDifferentProperties_ShouldReturn_False()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = new TestTarget { S = "1A", I = 1};
            Assert.NotEqual(t1, t2, new FlatObjectPropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoInstanceOfTheSameObject_ShouldReturn_True()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = t1;
            Assert.Equal(t1, t2, new FlatObjectPropertiesComparer<TestTarget>());
        }
    }
}