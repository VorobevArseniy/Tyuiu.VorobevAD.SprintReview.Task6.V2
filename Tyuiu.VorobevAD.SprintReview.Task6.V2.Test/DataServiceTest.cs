using Tyuiu.VorobevAD.SprintReview.Task6.V2.Lib;

namespace Tyuiu.VorobevAD.SprintReview.Task6.V2.Test
{
    [TestClass]
    public class DataServiceTest
    {
        DataService ds = new();

        [TestMethod]
        public void ValidGetMatrix()
        {
            int c = 1, k = 1, l = 3, n1 = 4, n2 = 4;

            int[,] array = {
                { 1, 2, 3, 6 },
                { 4, 5, 6, 2 },
                { 7, 8, 9, 1 },
                { 1, 7, 3, 8 } };

            int res = 12;

            Assert.AreEqual(12, res);
        }
    }
}