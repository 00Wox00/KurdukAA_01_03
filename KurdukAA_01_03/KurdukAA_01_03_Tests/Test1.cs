using KurdukAA_01_03;

namespace KurdukAA_01_03_Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        // Проверка Q базового класса: 100 * 100 / 2 = 5000
        public void TestMethod1()
        {
            MobileOperator op = new MobileOperator("MTS", 2, 100);
            Assert.AreEqual(5000.00, op.CalculateQuality(), 0.01);
        }

        [TestMethod]
        // Проверка Q с дробными числами: 100 * 33,3 / 1,5 = 2220
        public void TestMethod2()
        {
            MobileOperator op = new MobileOperator("Beeline", 1.5, 33.3);
            Assert.AreEqual(2220.00, op.CalculateQuality(), 0.01);
        }

        // Проверка Qp, когда плата за соединение есть: 0,5 * 5000 = 2500
        [TestMethod]
        public void TestMethod3()
        {
            MobileOperatorWithFee op = new MobileOperatorWithFee("MTS", 2, 100, true);
            Assert.AreEqual(2500.00, op.CalculateQuality(), 0.01);
        }
        // Проверка Qp, когда платы нет: 2,5 * 5000 = 12500
        [TestMethod]
        public void TestMethod4()
        {
            MobileOperatorWithFee op = new MobileOperatorWithFee("MTS", 2, 100, false);

            Assert.AreEqual(12500.00, op.CalculateQuality(), 0.01);
        }
    }
}
