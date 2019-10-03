using System;
using _04_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Test
{
    [TestClass]
    public class OutingRepositoryTests
    {
        [TestMethod]
        public void ObjectTests()
        {
            OutingRepository _outingList = new OutingRepository();
            _outingList.SeedList();

            Assert.AreEqual(2, _outingList.GetOutingList().Count);
        }
    }
}