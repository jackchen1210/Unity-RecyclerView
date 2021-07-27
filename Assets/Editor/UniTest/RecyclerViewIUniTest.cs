using NUnit.Framework;
using RecyclerView;

namespace Tests
{
    public class RecyclerViewUniTest
    {
        [TestCase(1000,100,20,10)]
        [TestCase(1000,100,5,5)]
        [TestCase(1000,100,10,10)]
        [TestCase(1000,100,0,0)]
        [TestCase(100, 50,3, 2)]
        [TestCase(100, 50,1, 1)]
        [TestCase(100, 50,2, 2)]
        [TestCase(100, 50,0, 0)]
        [TestCase(100, 80,3, 2)]
        [TestCase(100, 80,1, 1)]
        [TestCase(100, 80,2, 2)]
        [TestCase(100, 80,0, 0)]
        [TestCase(100, 100,3, 1)]
        [TestCase(100, 100,1, 1)]
        [TestCase(100, 100,0, 0)]
        [TestCase(100, 0,10, 0)]
        [TestCase(100, 0,2, 0)]
        [TestCase(100, 0,0, 0)]
        [TestCase(0, 0,0, 0)]
        [TestCase(0, 10,0, 0)]
        [TestCase(0, 10,10, 0)]
        public void ViewCalculator_Calculate_Grid_Needed_By_ScrollRect_Size_In_Verticle_Mode(int scrollRectHeight,int gridViewHeight,
           int totalItemAmount,int expectGridAmount)
        {
            var viewCalculator = new ViewCalculator();
            viewCalculator.ScrollRectHeight = scrollRectHeight;
            viewCalculator.GridViewHeight = gridViewHeight;
            viewCalculator.TotalItemAmount = totalItemAmount;
            viewCalculator.Calculate();
            Assert.AreEqual(expectGridAmount,viewCalculator.GridsSpawnAmount);
        }
    }
}
