using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Lab5.TouringTrip Test = new Lab5.TouringTrip();
            List<Lab5.TouringTrip> list = new List<Lab5.TouringTrip>();
            for(int i = 0;i < 10; i++)
            {
                Lab5.TouringTrip nw = new Lab5.TouringTrip
                {
                    City = "City" + i,
                    Count = i,
                    Date = "02.10",
                    Name = "ss",
                    HeadName = "Poor"
                };
                list.Add(nw);
            }
            int res = Test.MaxCount(list);
            Assert.AreEqual(res, 9);
        }
    }
}
