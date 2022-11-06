using NUnit.Framework;
using System.Linq;

namespace Assessment.Sorter.Test
{
    public class SorterTest
    {
        [TestCase("Erna Dorey Battelle", 3, "Battelle")]
        [TestCase("Selle Bellison", 2, "Bellison")]
        [TestCase("Madel Bordie Mapplebeck", 3, "Mapplebeck")]
        [TestCase("Leonerd Adda Mitchell Monaghan", 4, "Monaghan")]
        public void TestConstructStructureParts(string fullname, int partCount, string lastname)
        {
            var personName = new PersonName(fullname);

            Assert.AreEqual(fullname, personName.Fullname);
            Assert.AreEqual(partCount, personName.StructureParts.Count());
            Assert.AreEqual(lastname, personName.StructureParts.ElementAt(0));
        }

        [TestCase("Erna Dorey Battelle", "Selle Bellison", -1)]
        [TestCase("Flori Chaunce Franzel", "Odetta Sue Kaspar", -1)]
        [TestCase("Madel Bordie Mapplebeck", "Leonerd Adda Mitchell Monaghan", -1)]
        [TestCase("Debra Micheli", "Hailey Avie Annakin", 1)]
        [TestCase("Steve Vai", "Joe Satriani", 1)]
        [TestCase("Yngwie Malmsteen", "Nuno Bettencourt", 1)]
        [TestCase("Richie Kotzen", "Richie Kotzen", 0)]
        [TestCase("Guthrie Govan", "Guthrie Govan", 0)]
        [TestCase("Adam Smith", "Alena Smith", -1)]
        [TestCase("Michelle Wilhelm Ashmore", "Michael Wilhelm Ashmore", 1)]
        [TestCase("Michelle Maria Magdalena Ashmore", "Michelle Maria Magda Ashmore", 1)]
        public void TestCompareName(string nameOne, string nameTwo, int expectedResult)
        {
            var personNameOne = new PersonName(nameOne);
            var personNameTwo = new PersonName(nameTwo);

            var result = personNameOne.CompareTo(personNameTwo);

            Assert.AreEqual(result, expectedResult);
        }
    }
}