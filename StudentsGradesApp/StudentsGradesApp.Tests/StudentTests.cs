using NUnit.Framework;
using System.Globalization;

namespace StudentsGradesApp.Tests
{
    public class StudentTests
    {

        [Test]
        public void GetStatisticsMaxValueTest()

        {
            var student = new StudentInMemory("Jan", "Kowalski");
            student.AddGrade(3);
            student.AddGrade(5);

            var statistics = student.GetStatistics();
            Assert.AreEqual(5, statistics.Max);
        }

        [Test]
        public void GetStatisticsMinValueTest()

        {
            var student = new StudentInMemory("Jan", "Kowalski");
            student.AddGrade(3);
            student.AddGrade(5);

            var statistics = student.GetStatistics();
            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void GetStatisticsAverageValueTest()

        {
            var student = new StudentInMemory("Jan", "Kowalski");
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            var statistics = student.GetStatistics();
            Assert.AreEqual(4, statistics.Average);
        }

        [Test]
        public void GetStatisticsAwardLetterValueTest()

        {
            var student = new StudentInMemory("Jan", "Kowalski");
            student.AddGrade(5);
            student.AddGrade(5);
            student.AddGrade(5);

            var statistics = student.GetStatistics();
            Assert.That(statistics.AwardLetter, Is.EqualTo('T'));
        }
    }
}