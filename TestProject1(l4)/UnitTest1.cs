using System.Runtime.InteropServices;

namespace TestProject1;

    [TestFixture]
    public class UnitTest1
    {
       [Test]
        public void TestInput()
        {
            int[][] array = new int[2][];
            My2DArray.InputRows(ref array, new string[] { "4 9 3 10", "+ 10 = , 4" });
            int[][] result = new int[][] { new int[]{4, 9, 3, 10 }, new int[]{0, 10, 0, 0, 4 } };
            bool isEqual = true;
            for (int i = 0; i < array.Length; i++) {
                isEqual = array[i].SequenceEqual(result[i]);
            }
            Assert.IsTrue(isEqual);
        }

       [Test]
        public void TestFindMax()
        {
            int[][] array = new int[2][];
            My2DArray.InputRows(ref array, new string[] { "4 9 3 10", "+ 10 = , 4" });
            My2DArray.FindMax(array, out int[] maxValues);
            int[] result = new int[] { 10, 10 };
            Assert.IsTrue(maxValues.SequenceEqual(result));
        }

       [Test]
        public void TestFindMin()
        {
            int[][] array = new int[2][];
            My2DArray.InputRows(ref array, new string[] { "4 9 3 10", "+ 10 = , 4" });
            My2DArray.FindMin(array, out int[] maxValues);
            int[] result = new int[] { 3, 0 };
            Assert.IsTrue(maxValues.SequenceEqual(result));
        }

        [Test]
        public void TestSumsRows()
        {
            int[][] array = new int[2][];
            My2DArray.InputRows(ref array, new string[] { "4 9 3 10", "+ 10 = , 4" });
            My2DArray.SumsRows(array, out int[] maxValues);
            int[] result = new int[] { 26, 14 };
            Assert.IsTrue(maxValues.SequenceEqual(result));
        }
    }
