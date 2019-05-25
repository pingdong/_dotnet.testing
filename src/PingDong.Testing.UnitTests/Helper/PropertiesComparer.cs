using System.Collections.Generic;
using Xunit;

namespace PingDong.Testing
{
    public class PropertiesComparerTests
    {
        #region Sample Objct

        private class TestTarget
        {
            public string S { get; set; }
            public int I { get; set; }
        }

        private class TestTargetWrap
        {
            public TestTarget Target { get; set; }
            
            public string S { get; set; }
        }

        #endregion
        
        [Fact]
        public void Null_ShouldReturn_True()
        {
            string s1 = null;
            string s2 = null;
            Assert.Equal(s1, s2, new PropertiesComparer<string>());
        }

        [Fact]
        public void Empty_ShouldReturn_True()
        {
            var s1 = new string[] { };
            var s2 = new string[] { };
            Assert.Equal(s1, s2, new PropertiesComparer<string[]>());
        }

        [Fact]
        public void NewObject_ShouldReturn_True()
        {
            var t1 = new TestTarget();
            var t2 = new TestTarget();
            Assert.Equal(t1, t2, new PropertiesComparer<TestTarget>());

            var w1 = new TestTargetWrap();
            var w2 = new TestTargetWrap();
            Assert.Equal(w1, w2, new PropertiesComparer<TestTargetWrap>());
        }

        [Fact]
        public void TwoListsWithSamePropertiesInstance_ShouldReturn_True()
        {
            var list1 = new List<TestTarget> { new TestTarget { S = "1", I = 1} };
            var list2 = new List<TestTarget> { new TestTarget { S = "1", I = 1} };
            Assert.Equal(list1, list2, new PropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoListsWithDifferentPropertiesInstance_ShouldReturn_False()
        {
            var list1 = new List<TestTarget> { new TestTarget { S = "1", I = 1} };
            var list2 = new List<TestTarget> { new TestTarget { S = "1A", I = 1} };
            Assert.NotEqual(list1, list2, new PropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoInstanceWithSameProperties_ShouldReturn_True()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = new TestTarget { S = "1", I = 1};

            Assert.NotEqual(t1, t2);
            Assert.Equal(t1, t2, new PropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoInstanceWithDifferentProperties_ShouldReturn_False()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = new TestTarget { S = "1A", I = 1};
            Assert.NotEqual(t1, t2, new PropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoInstanceOfTheSameObject_ShouldReturn_True()
        {
            var t1 = new TestTarget { S = "1", I = 1};
            var t2 = t1;

            Assert.Equal(t1, t2);
            Assert.Equal(t1, t2, new PropertiesComparer<TestTarget>());
        }

        [Fact]
        public void TwoNestedInstanceWithSameProperties_ShouldReturn_True()
        {
            var t1 = new TestTargetWrap {Target = new TestTarget {S = "1", I = 1}, S = "S"};
            var t2 = new TestTargetWrap {Target = new TestTarget {S = "1", I = 1}, S = "S"};

            Assert.Equal(t1, t2, new PropertiesComparer<TestTargetWrap>());
        }

        [Fact]
        public void TwoNestedInstanceWithDifferentProperties_ShouldReturn_False()
        {
            var t1 = new TestTargetWrap {Target = new TestTarget {S = "1", I = 1}, S = "S"};
            var t2 = new TestTargetWrap {Target = new TestTarget {S = "1A", I = 1}, S = "S"};
            Assert.NotEqual(t1, t2, new PropertiesComparer<TestTargetWrap>());
        }

        [Fact]
        public void TwoNestedInstanceOfTheSameObject_ShouldReturn_True()
        {
            var t1 = new TestTargetWrap {Target = new TestTarget {S = "1", I = 1}, S = "S"};
            var t2 = t1;
            Assert.Equal(t1, t2, new PropertiesComparer<TestTargetWrap>());
        }
    }
}