using NUnit.Framework;
using System.IO;

namespace Assessment.Sorter.Test
{
    public class ListTest
    {
        [Test]
        public void TestLoadFile()
        {
            var unsortedPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "unsorted-name-list.txt");

            var list = PersonNameList.LoadFromFile(unsortedPath);

            Assert.AreEqual(10, list.Count);
            Assert.AreEqual("Orson Milka Iddins", list[0].Fullname);
            Assert.AreEqual("Erna Dorey Battelle", list[1].Fullname);
            Assert.AreEqual("Flori Chaunce Franzel", list[2].Fullname);
            Assert.AreEqual("Odetta Sue Kaspar", list[3].Fullname);
            Assert.AreEqual("Roy Ketti Kopfen", list[4].Fullname);
            Assert.AreEqual("Madel Bordie Mapplebeck", list[5].Fullname);
            Assert.AreEqual("Selle Bellison", list[6].Fullname);
            Assert.AreEqual("Leonerd Adda Mitchell Monaghan", list[7].Fullname);
            Assert.AreEqual("Debra Micheli", list[8].Fullname);
            Assert.AreEqual("Hailey Avie Annakin", list[9].Fullname);
        }

        [Test]
        public void TestSortNameOnFile()
        {
            var unsortedPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "unsorted-name-list.txt");

            var list = PersonNameList.LoadFromFile(unsortedPath);
            list.Sort();

            Assert.AreEqual(10, list.Count);

            Assert.AreEqual("Hailey Avie Annakin", list[0].Fullname);
            Assert.AreEqual("Erna Dorey Battelle", list[1].Fullname);
            Assert.AreEqual("Selle Bellison", list[2].Fullname);
            Assert.AreEqual("Flori Chaunce Franzel", list[3].Fullname);
            Assert.AreEqual("Orson Milka Iddins", list[4].Fullname);
            Assert.AreEqual("Odetta Sue Kaspar", list[5].Fullname);
            Assert.AreEqual("Roy Ketti Kopfen", list[6].Fullname);
            Assert.AreEqual("Madel Bordie Mapplebeck", list[7].Fullname);
            Assert.AreEqual("Debra Micheli", list[8].Fullname);
            Assert.AreEqual("Leonerd Adda Mitchell Monaghan", list[9].Fullname);
        }

        [Test]
        public void TestSortNameOnFileAndSaveToFile()
        {
            var unsortedPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "unsorted-name-list.txt");

            // Load File to person name list
            var list = PersonNameList.LoadFromFile(unsortedPath);
            list.Sort();

            var sortedPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "sorted-name-list.txt");

            // Save the sorted list 
            list.SaveToFile(sortedPath);

            // load sorted list again from the stored file
            var sortedList = PersonNameList.LoadFromFile(sortedPath);

            var isExisted = File.Exists(sortedPath);

            Assert.AreEqual(true, isExisted);

            Assert.AreEqual(10, sortedList.Count);

            Assert.AreEqual("Hailey Avie Annakin", sortedList[0].Fullname);
            Assert.AreEqual("Erna Dorey Battelle", sortedList[1].Fullname);
            Assert.AreEqual("Selle Bellison", sortedList[2].Fullname);
            Assert.AreEqual("Flori Chaunce Franzel", sortedList[3].Fullname);
            Assert.AreEqual("Orson Milka Iddins", sortedList[4].Fullname);
            Assert.AreEqual("Odetta Sue Kaspar", sortedList[5].Fullname);
            Assert.AreEqual("Roy Ketti Kopfen", sortedList[6].Fullname);
            Assert.AreEqual("Madel Bordie Mapplebeck", sortedList[7].Fullname);
            Assert.AreEqual("Debra Micheli", sortedList[8].Fullname);
            Assert.AreEqual("Leonerd Adda Mitchell Monaghan", sortedList[9].Fullname);
        }

        [TearDown]
        protected void TearDown()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "sorted-name-list.txt");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
