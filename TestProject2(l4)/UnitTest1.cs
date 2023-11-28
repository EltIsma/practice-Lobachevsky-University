namespace TestProject2;


    [TestFixture]
    public class UnitTest1
    {
        MyArrayInteger array = new MyArrayInteger(6);
        [Test]
        public void TestInputData()
        {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            int[] result = new int[6] { 6, 10, 2, 8, 10, 4 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], array[i]);
            }
        }

        [Test]
        public void TestFindValue() {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            array.FindValue(10, out List<int> indices);
            List<int> result = new List<int> { 1, 4 };
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], indices[i]);
            }
        }

        [Test]
        public void TestDeleteValue()
        {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            array.DeleteValue(10);
            int[] result = new int[4] { 6, 2, 8, 4 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], array[i]);
            }
            Assert.AreEqual(result.Length, array.GetLenght());
        }

        [Test]
        public void TestFindMax()
        {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            int result = 10;
            array.FindMax(out int max);
            Assert.AreEqual(result, max);
        }

        [Test]
        public void TestAdd()
        {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            MyArrayInteger secondArray = new MyArrayInteger(6);
            secondArray.InputData(new int[] {2, 2, 2, 2, 2, 2});

            int[] result = new int[6] {8, 12, 4, 10, 12, 6 };
            array.Add(secondArray);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], array[i]);
            }
        }

        [Test]
        public void TestSort()
        {
            array.InputData(new int[] { 6, 10, 2, 8, 10, 4 });
            array.Sort(0, array.GetLenght() - 1);

            int[] result = new int[6] { 2, 4, 6, 8, 10, 10 };

            for (int i = 0;i < result.Length; i++)
            {
                Assert.AreEqual(result[i], array[i]);
            }
        }
    }
