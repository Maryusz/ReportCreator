using System;
using Xunit;
using Report_Creator.Logic;

namespace ReportCreatorTests
{
    public class PracticeCreatorTests
    {
        [Fact]
        public void TestInitialization()
        {
            var practiceCreator = new PracticeCreator(@"C:\Users\Maryusz\Downloads\file_2020.csv", new string[] { ";" });
            var items = practiceCreator.Items();
        }

        [Fact]
        public void TestGetPractice()
        {
            var practiceCreator = new PracticeCreator(@"C:\Users\Maryusz\Downloads\file_2020.csv", new string[] { ";" });
            var items = practiceCreator.Items();


            var practice = practiceCreator.GetPractice(64906);
            Assert.True(practice.Client == "Siemens IT");
            Assert.True(practice.DDTID == 64906);
            Assert.False(practice.ItemCount() == 1);
        }
    }
}
